Module Defaults
    'Alter the Defaults in this module to fit with each project that uses this updater.

    'Project name
    Public Const AppName As String = "MPOS tool updater"

    ' Unique Project ID --
    Public Const UpdateID As String = "Update"

    ' The Applications Root Path "C:\Dir1\Dir2" (No trailing backslash)
    Public AppPath As String = Application.StartupPath

    ' The Applications Exe "Dir3\Prog.exe" (from the root path. No leading Backslash)
    Public Const AppEXE As String = "MPOS Server tool 2.0.exe"

    ' Other startup defaults.
    Public Const LastUpdate As Integer = 0 ' Last update loaded..
    Public Const TimeOutlen As Integer = 60 ' Wait time to connect to Update Site in seconds
    Public Const UpdateSite As String = "sunt.pro/m_update" ' Default site to download updates from.
End Module
