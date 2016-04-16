<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoUpdater
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.LblText = New System.Windows.Forms.Label
        Me.WBData = New System.Windows.Forms.WebBrowser
        Me.GBUpdate = New System.Windows.Forms.GroupBox
        Me.GBLbl = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.GBUpdate.SuspendLayout()
        Me.GBLbl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 257)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Retry"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(471, 257)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LblText
        '
        Me.LblText.AutoSize = True
        Me.LblText.Location = New System.Drawing.Point(6, 7)
        Me.LblText.Name = "LblText"
        Me.LblText.Size = New System.Drawing.Size(39, 13)
        Me.LblText.TabIndex = 3
        Me.LblText.Text = "Label1"
        '
        'WBData
        '
        Me.WBData.Location = New System.Drawing.Point(6, 69)
        Me.WBData.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WBData.Name = "WBData"
        Me.WBData.Size = New System.Drawing.Size(522, 164)
        Me.WBData.TabIndex = 4
        '
        'GBUpdate
        '
        Me.GBUpdate.Controls.Add(Me.GBLbl)
        Me.GBUpdate.Controls.Add(Me.WBData)
        Me.GBUpdate.Location = New System.Drawing.Point(12, 12)
        Me.GBUpdate.Name = "GBUpdate"
        Me.GBUpdate.Size = New System.Drawing.Size(534, 239)
        Me.GBUpdate.TabIndex = 5
        Me.GBUpdate.TabStop = False
        Me.GBUpdate.Text = "Updater In Progress"
        '
        'GBLbl
        '
        Me.GBLbl.Controls.Add(Me.LblText)
        Me.GBLbl.Location = New System.Drawing.Point(6, 13)
        Me.GBLbl.Name = "GBLbl"
        Me.GBLbl.Size = New System.Drawing.Size(522, 50)
        Me.GBLbl.TabIndex = 5
        Me.GBLbl.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(390, 256)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Done"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'AutoUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 289)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GBUpdate)
        Me.Name = "AutoUpdater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.GBUpdate.ResumeLayout(False)
        Me.GBLbl.ResumeLayout(False)
        Me.GBLbl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LblText As System.Windows.Forms.Label
    Friend WithEvents WBData As System.Windows.Forms.WebBrowser
    Friend WithEvents GBUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GBLbl As System.Windows.Forms.GroupBox

End Class
