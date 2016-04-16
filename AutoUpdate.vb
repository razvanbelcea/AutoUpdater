Imports System.IO
Imports System.Net
Imports System.Text

Public Class AutoUpdater

    Private XMLFunction As New XMLFunc.XmlFunctions

    Private Connection As System.Net.HttpWebRequest
    Private WithEvents Timer As Windows.Forms.Timer
    Private TimeDelay As Integer 'Timeout in seconds
    Private HttpWait As Boolean ' Wait for Http page to load
    Private Retry As Boolean ' Retry to load failed connection
    Private TimeOut As Boolean ' Wait has timed out.
    Private Canceled As Boolean ' Cancel button Clicked.
    Private Setup As Boolean 'Setup options menu.
    Private Closeme As Boolean  ' Close the form.
    Private Updated As Boolean 'Files were updated
    Private AutoUpdate As Boolean ' autoupdate

    Private Sub AutoUpdater_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Closeme Then
            e.Cancel = True
        End If
    End Sub

    Private Sub AutoUpdater_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Defaults.AppName

        StartUpdate()
        Deleteoldexe()
    End Sub

    Private Sub StartUpdate()
        Dim Updaterfile As String
        Dim Serverfile As String
        Dim TotalUpdates As Integer
        Dim LastUpdate As Integer
        Dim lastUpdatefile As String
        '        Dim CurrentUdate As Integer
        Dim FileList As List(Of XMLFunc.XmlFunctions.FileDetails)

        Button1.Enabled = False
        Button4.Enabled = False
        Me.Show()
        LblText.Text = "Connecting to Remote Server" & vbCrLf & " Please ensure that your internet connection is active"
        Me.Refresh()
        WBData.Url = New System.Uri("http://" & UpdateSite & "/Default.html")
        HttpWait = False
        TimeDelay = TimeOutlen
        Timer = New Windows.Forms.Timer
        Timer.Interval = 1000
        Timer.Enabled = True
        While Not (HttpWait Or TimeOut Or Canceled)

            System.Windows.Forms.Application.DoEvents()

            If TimeOut Then
                LblText.Text = "Connection to Remote Server Failed" & vbCrLf & "Application will continue in 10 seconds"
                Button1.Enabled = True
                TimeOut = False
                TimeDelay = 10
                Timer.Interval = 1000
                Timer.Enabled = True
                Retry = False
                TimeDelay = 30
                While Not (TimeOut Or Retry Or Canceled)
                    System.Windows.Forms.Application.DoEvents()
                End While
                If Retry Then
                    LblText.Text = "Reconnecting to Remote Server" & vbCrLf & " Please ensure that your internet connection is active"
                    Button1.Enabled = False
                    TimeOut = False
                    HttpWait = False
                    TimeDelay = TimeOutlen
                    Timer.Interval = 1000
                    Timer.Enabled = True
                Else
                    LoadApp()
                    Exit Sub
                End If
            End If
        End While
        If Not Canceled Then
            LblText.Text = "Connection to Remote Server completed" & vbCrLf & " Please wait while checking for new updates"
            GBLbl.Refresh()
            Updaterfile = AppPath & "\Resources\UpdateLog.xml"
            Serverfile = "http://" & UpdateSite & "/" & UpdateID & ".XML"
            lastUpdatefile = AppPath & "\Resources\lastupdate.txt"
            Try

                If File.Exists(lastUpdatefile) Then
                    Try
                        Using sr As New StreamReader(lastUpdatefile)
                            LastUpdate = sr.ReadToEnd()
                        End Using
                    Catch e As Exception
                        Console.WriteLine("The file could not be read:")
                        Console.WriteLine(e.Message)
                    End Try
                End If
                If File.Exists(Updaterfile) Then
                    File.Delete(Updaterfile)
                End If
                My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                XMLFunction.OpenXMLDoc(Updaterfile)
                XMLFunction.XMLSNode("/updates")
                TotalUpdates = Val(XMLFunction.GetNodeVal("total"))
                If TotalUpdates > LastUpdate Then
                    FileList = XMLFunction.GetFiles
                    For Each ThisFile As XMLFunc.XmlFunctions.FileDetails In FileList
                        If ThisFile.Update > LastUpdate Then
                            Updated = True
                            Updaterfile = AppPath & "\" & ThisFile.Local
                            Serverfile = "http://" & UpdateSite & "/" & ThisFile.Server
                            LblText.Text = "Downloading " & ThisFile.File & " from server" & vbCrLf & " Please wait for update to complete"
                            GBLbl.Refresh()
                            If File.Exists(Updaterfile) Then File.Delete(Updaterfile)
                            My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                        End If
                    Next
                End If
                If Updated Then
                    LblText.Text = "Update succesfully installed." & vbCrLf & "Application will Exit in a few seconds"

                    If Directory.Exists(AppPath & "\Resources") Then
                        If File.Exists(lastUpdatefile) Then
                            Try
                                Using sw As StreamWriter = File.CreateText(lastUpdatefile)
                                    sw.WriteLine(TotalUpdates)
                                End Using
                            Catch e As Exception
                                Console.WriteLine("The file could not be read:")
                                Console.WriteLine(e.Message)
                            End Try
                        Else
                            File.Create(lastUpdatefile)
                        End If
                    Else
                        Directory.CreateDirectory(AppPath & "\Resources")
                    End If
                Else
                    LblText.Text = "No Updates to load." & vbCrLf & "Application will Exit in a few seconds"
                End If
            Catch ex As Exception
                LblText.Text = "Error during download" & vbCrLf & "Application will Exit in a few seconds"
            End Try
            TimeOut = False
            TimeDelay = 10
            Timer.Interval = 1000
            Timer.Enabled = True
            Retry = False
            Button3.Enabled = False
            Button4.Enabled = True
            While Not (TimeOut Or Canceled)
                System.Windows.Forms.Application.DoEvents()
            End While
        End If
        LoadApp()
    End Sub

    Private Sub Deleteoldexe()
        Dim versions = {"MPOS Server Tool V2.0.0.5.exe", "MPOS Server Tool V2.0.0.4.exe", "MPOS Server Tool V2.0.0.3.exe", "MPOS Server Tool V2.0.0.2.exe", "MPOS Server Tool V2.0.0.1.exe", "MPOS Server Tool V2.0.0.0.exe"}
        For Each version As String In versions
            If File.Exists(AppPath & "\" & version) Then
                File.Delete(AppPath & "\" & version)
            End If
        Next
    End Sub


    Private Sub LoadApp()
        Shell(AppPath & "\" & AppEXE, AppWinStyle.NormalFocus)
        Closeme = True
        Me.Close()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WBData.DocumentCompleted
        HttpWait = True
        If WBData.DocumentTitle.ToUpper <> "MPOS" Then TimeOut = True
    End Sub

    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If TimeDelay = 0 Or Canceled Then
            TimeOut = True
            Timer.Enabled = False
        Else
            TimeDelay -= 1
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Canceled = True
    End Sub

    Private Sub Retry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Retry = True
    End Sub

    Private Sub Done_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TimeDelay = 0
    End Sub
End Class
