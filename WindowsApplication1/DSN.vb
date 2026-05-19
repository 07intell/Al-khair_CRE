Imports System
Imports Microsoft.Win32

Module DSN

    Public Enum DataSourceType
        System
        User
    End Enum

    Private Sub DSN_check()
        Dim reg As Microsoft.Win32.RegistryKey = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("SOFTWARE")
    End Sub

    Public Function GetUserDataSourceNames() As System.Collections.SortedList
        Dim dsnList As New System.Collections.SortedList()
        ' get user dsn's
        Dim reg As Microsoft.Win32.RegistryKey = (Microsoft.Win32.Registry.CurrentUser).OpenSubKey("Software")
        If reg IsNot Nothing Then
            reg = reg.OpenSubKey("ODBC")
            If reg IsNot Nothing Then
                reg = reg.OpenSubKey("ODBC.INI")
                If reg IsNot Nothing Then
                    reg = reg.OpenSubKey("ODBC Data Sources")
                    If reg IsNot Nothing Then
                        ' Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                        For Each sName As String In reg.GetValueNames()
                            dsnList.Add(sName, DataSourceType.User)
                        Next
                    End If
                    Try
                        reg.Close()
                    Catch
                    End Try
                End If
            End If
        End If

        Return dsnList
    End Function

    Public Function GetAllDataSourceNames() As System.Collections.SortedList
        ' Get the list of user DSN's first.
        Dim dsnList As System.Collections.SortedList = GetUserDataSourceNames()

        ' Get list of System DSN's and add them to the first list.
        Dim systemDsnList As System.Collections.SortedList = GetSystemDataSourceNames()
        For i As Integer = 0 To systemDsnList.Count - 1
            Dim sName As String = TryCast(systemDsnList.GetKey(i), String)
            Dim type As DataSourceType = DirectCast(systemDsnList.GetByIndex(i), DataSourceType)
            Try
                ' This dsn to the master list
                dsnList.Add(sName, type)
                ' An exception can be thrown if the key being added is a duplicate so 
                ' we just catch it here and have to ignore it.
            Catch ex As Exception
                Error_handle("Getting All DNS List Error", ex)
            End Try
        Next

        Return dsnList
    End Function

    Public Function GetSystemDataSourceNames() As System.Collections.SortedList
        Dim dsnList As New System.Collections.SortedList()

        ' get system dsn's
        Dim reg As Microsoft.Win32.RegistryKey = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software")
        If reg IsNot Nothing Then
            reg = reg.OpenSubKey("ODBC")
            If reg IsNot Nothing Then
                reg = reg.OpenSubKey("ODBC.INI")
                If reg IsNot Nothing Then
                    reg = reg.OpenSubKey("ODBC Data Sources")
                    If reg IsNot Nothing Then
                        ' Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                        For Each sName As String In reg.GetValueNames()
                            dsnList.Add(sName, DataSourceType.System)
                        Next
                    End If
                    Try
                        reg.Close()
                        ' ignore this exception if we couldn't close 
                    Catch
                    End Try
                End If
            End If
        End If

        Return dsnList
    End Function


    Public Sub Dsn_create(ByVal DBname As String, _
                              ByVal DSNname As String, _
                              ByVal Description As String, _
                              ByVal Username As String, _
                              ByVal Passsword As String, _
                              ByVal Server As String, _
                              ByVal Port As String)
        Try
            Call Shell("rundll32.exe shell32.dll,Control_RunDLL ODBCCP32.cpl @2, 5")
            Dim strdriverodbc As New String(Space(255))
            'check that mysql ODBC drive is installed or not
            If checkMySQLDriver(strdriverodbc) = False Then
                MsgBox("MySQL ODBC 3.51 Driver Is Not Installed." & Environment.NewLine & "Install driver then run setup, For driver you can download and Install " & Environment.NewLine & "-------MySQL Connector ODBC 3.51-------", vbOK, "Create Mysql DSN")
                Exit Sub
            Else
                MakeMySQLDSN(DBname, DSNname, Description, strdriverodbc, Username, Passsword, Server, Port, 3, "")
                strdriverodbc = "C:\WINDOWS\System32\myodbc3.dll"
            End If
        Catch ex As Exception
            Error_handle("DNS Create Error", ex)
        End Try
    End Sub

    Private Function MakeMySQLDSN(ByVal DB_Name As String, _
                                ByVal DSN As String, _
                                ByVal Description As String, _
                                ByVal Driver_Name As String, _
                                ByVal userid As String, _
                                ByVal password As String, _
                                ByVal Server_Name As String, _
                                ByVal port As String, _
                                ByVal stroption As String, _
                                ByVal stmt As String _
                                ) As Boolean

  
        Dim regHandle As RegistryKey ' Stores the Handle to Registry in which values need to be set

        Dim reg As RegistryKey = Registry.CurrentUser
        Dim conRegKey1 As String = "SOFTWARE\ODBC\ODBC.INI\" & DSN
        Dim conRegKey2 As String = "SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources"

        Try
            regHandle = reg.CreateSubKey(conRegKey1)
            regHandle.SetValue("Database", DB_Name)
            regHandle.SetValue("Description", Description)
            regHandle.SetValue("Driver", Driver_Name)
            regHandle.SetValue("Option", stroption)
            regHandle.SetValue("Password", password)
            regHandle.SetValue("Port", port)
            regHandle.SetValue("Server", Server_Name)
            regHandle.SetValue("Stmt", stmt)
            regHandle.SetValue("User", userid)
            regHandle.Close()
            reg.Close()

            regHandle = reg.CreateSubKey(conRegKey2)
            regHandle.SetValue(DSN, "MySQL ODBC 3.51 Driver")
            regHandle.Close()
            reg.Close()
            MsgBox("Successfully created the System DSN." & vbCrLf & "You can view the created DSN by clicking on Get DSN button.", MsgBoxStyle.Information, "Create System DSN")
        Catch err As Exception
            Error_handle("DNS Create Error", err)
        End Try

        Return Nothing

    End Function

    Private Function checkMySQLDriver(ByRef DriverODBC As String) As Boolean

        Dim regHandle As RegistryKey            ' Stores the Handle to Registry in which values need to be set
        Dim reg As RegistryKey = Registry.LocalMachine
        Dim conRegKey1 As String = "SOFTWARE\ODBC\ODBCINST.INI\MySQL ODBC 3.51 Driver"
        Try
            regHandle = reg.OpenSubKey(conRegKey1)
            If regHandle.ValueCount > 0 Then
                DriverODBC = regHandle.GetValue("Driver")
                checkMySQLDriver = True
            Else
                checkMySQLDriver = False
            End If
        Catch err As Exception
            Error_handle("MySQL Driver Search Error", err)
        End Try

        Return Nothing

    End Function

    Private Function MySQLDSNWanted(ByVal strdsnName As String) As Boolean

        Dim reghandle As RegistryKey
        Dim reg As RegistryKey = Registry.LocalMachine
        Dim conRegKey1 As String = "SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources\"
        Dim tmpdsnvalue As String
        Try
            reghandle = reg.OpenSubKey(conRegKey1)
            If reghandle.ValueCount > 0 Then
                tmpdsnvalue = reghandle.GetValue(strdsnName)
                If tmpdsnvalue = "" Then
                    MySQLDSNWanted = False
                Else
                    MySQLDSNWanted = True
                End If
            Else
                MySQLDSNWanted = False
            End If
        Catch err As Exception
            Error_handle("MYSQL DNS Search Error", err)
        End Try

        Return Nothing

    End Function

End Module
