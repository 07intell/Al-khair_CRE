Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing.Printing

Public NotInheritable Class Shell32
    Private Sub New()
    End Sub
    Public Shared ShellFolderType As Type = GetType(IShellFolder)
    Public Shared EnumIDListType As Type = GetType(IEnumIDList)
    Public Shared IID_IShellFolder As New Guid("{000214E6-0000-0000-C000-000000000046}")

    ' Retrieves the path of a folder as an PIDL.
    ' Handle to the owner window.
    ' A CSIDL value that identifies the folder to be located.
    ' Token that can be used to represent a particular user.
    ' Reserved.
    <DllImport("shell32.dll")> _
    Public Shared Function SHGetFolderLocation(hwndOwner As IntPtr, nFolder As Int32, hToken As IntPtr, dwReserved As UInt32, ByRef ppidl As IntPtr) As Int32
    End Function
    ' Address of a pointer to an item identifier list structure
    ' specifying the folder's location relative to the root of the namespace
    ' (the desktop).
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function DestroyIcon(handle As IntPtr) As Boolean
    End Function

    ' Retrieves the IShellFolder interface for the desktop folder, which is the root of the Shell's namespace.
    <DllImport("shell32.dll")> _
    Public Shared Function SHGetDesktopFolder(ByRef ppshf As IntPtr) As Int32
    End Function
    ' Address that receives an IShellFolder interface pointer for the
    ' desktop folder.
    ' Takes a STRRET structure returned by IShellFolder::GetDisplayNameOf, converts it to a string, and
    ' places the result in a buffer.
    ' Pointer to the STRRET structure. When the function returns, this pointer will no
    ' longer be valid.
    ' Pointer to the item's ITEMIDLIST structure.
    ' Buffer to hold the display name. It will be returned as a null-terminated
    ' string. If cchBuf is too small, the name will be truncated to fit.
    <DllImport("shlwapi.dll")> _
    Public Shared Function StrRetToBuf(ByRef pstr As STRRET, pidl As IntPtr, pszBuf As StringBuilder, cchBuf As UInt32) As Int32
    End Function
    ' Size of pszBuf, in characters. If cchBuf is too small, the string will be
    ' truncated to fit.
    <DllImport("shell32.dll")> _
    Public Shared Function SHGetFileInfo(pszPath As String, dwFileAttribs As UInteger, ByRef psfi As SHFILEINFO, cbFileInfo As UInteger, uFlags As SHGFI) As IntPtr
    End Function

    <DllImport("shell32.dll")> _
    Public Shared Function SHGetFileInfo(pIDL As IntPtr, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbFileInfo As UInteger, uFlags As SHGFI) As IntPtr
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure SHFILEINFO
        Public Sub New(b As Boolean)
            hIcon = IntPtr.Zero
            iIcon = 0
            dwAttributes = 0
            szDisplayName = ""
            szTypeName = ""
        End Sub

        ''' <summary>Maximal Length of unmanaged Windows-Path-strings</summary>
        Private Const MAX_PATH As Integer = 260
        ''' <summary>Maximal Length of unmanaged Typename</summary>
        Private Const MAX_TYPE As Integer = 80

        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_TYPE)> _
        Public szTypeName As String
    End Structure

    <DllImport("shell32.dll")> _
    Public Shared Function ILCombine(pIDLParent As IntPtr, pIDLChild As IntPtr) As IntPtr
    End Function

    <DllImport("shell32.dll")> _
    Public Shared Sub ILFree(<[In]()> pidl As IntPtr)
    End Sub

    Public Shared Function GetDesktopFolder() As IShellFolder
        Dim ptrRet As IntPtr
        SHGetDesktopFolder(ptrRet)

        Dim obj As [Object] = Marshal.GetTypedObjectForIUnknown(ptrRet, ShellFolderType)
        Dim ishellFolder As IShellFolder = DirectCast(obj, IShellFolder)

        Return ishellFolder
    End Function

    ''' <summary>
    '''  managed equivalent of IShellFolder interface
    '''  Pinvoke.net / Mod by Arik Poznanski - pooya parsa
    '''  Msdn:      http://msdn.microsoft.com/en-us/library/windows/desktop/bb775075(v=vs.85).aspx
    '''  Pinvoke:   http://pinvoke.net/default.aspx/Interfaces/IShellFolder.html
    ''' </summary>
    <ComImport()> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    <Guid("000214E6-0000-0000-C000-000000000046")> _
    Public Interface IShellFolder
        ''' <summary>
        ''' Translates a file object's or folder's display name into an item identifier list.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="hwnd">Optional window handle</param>
        ''' <param name="pbc">Optional bind context that controls the parsing operation. This parameter is normally set to NULL. </param>
        ''' <param name="pszDisplayName">Null-terminated UNICODE string with the display name</param>
        ''' <param name="pchEaten">Pointer to a ULONG value that receives the number of characters of the display name that was parsed.</param>
        ''' <param name="ppidl"> Pointer to an ITEMIDLIST pointer that receives the item identifier list for the object.</param>
        ''' <param name="pdwAttributes">Optional parameter that can be used to query for file attributes.this can be values from the SFGAO enum</param>
        Sub ParseDisplayName(hwnd As IntPtr, pbc As IntPtr, pszDisplayName As [String], pchEaten As UInt32, ByRef ppidl As IntPtr, pdwAttributes As UInt32)

        ''' <summary>
        '''Allows a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
        '''Return value: error code, if any
        ''' </summary>
        ''' <param name="hwnd">If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take user input.</param>
        ''' <param name="grfFlags">Flags indicating which items to include in the  enumeration. For a list of possible values, see the SHCONTF enum. </param>
        ''' <param name="ppenumIDList">Address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. </param>
        Sub EnumObjects(hwnd As IntPtr, grfFlags As ESHCONTF, ByRef ppenumIDList As IntPtr)

        ''' <summary>
        '''Retrieves an IShellFolder object for a subfolder.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="pidl">Address of an ITEMIDLIST structure (PIDL) that identifies the subfolder.</param>
        ''' <param name="pbc">Optional address of an IBindCtx interface on a bind context object to be used during this operation.</param>
        ''' <param name="riid">Identifier of the interface to return. </param>
        ''' <param name="ppv">Address that receives the interface pointer.</param>
        Sub BindToObject(pidl As IntPtr, pbc As IntPtr, <[In]()> ByRef riid As Guid, ByRef ppv As IntPtr)

        ''' <summary>
        ''' Requests a pointer to an object's storage interface.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="pidl">Address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. </param>
        ''' <param name="pbc">Optional address of an IBindCtx interface on a bind context object to be  used during this operation.</param>
        ''' <param name="riid">Interface identifier (IID) of the requested storage interface.</param>
        ''' <param name="ppv"> Address that receives the interface pointer specified by riid.</param>
        Sub BindToStorage(pidl As IntPtr, pbc As IntPtr, <[In]()> ByRef riid As Guid, ByRef ppv As IntPtr)

        ''' <summary>
        ''' Determines the relative order of two file objects or folders, given
        ''' their item identifier lists. Return value: If this method is
        ''' successful, the CODE field of the HRESULT contains one of the
        ''' following values (the code can be retrived using the helper function
        ''' GetHResultCode): Negative A negative return value indicates that the first item should precede the second (pidl1 < pidl2).
        ''' /       
        ''' Positive A positive return value indicates that the first item should follow the second (pidl1 > pidl2).  Zero A return value of zero''indicates that the two items are the same (pidl1 = pidl2).
        ''' </summary>
        ''' <param name="lParam">Value that specifies how the comparison  should be performed. The lower Sixteen bits of lParam define the sorting  rule.
        '''  The upper sixteen bits of lParam are used for flags that modify the sorting rule. values can be from  the SHCIDS enum
        ''' </param>
        ''' <param name="pidl1">Pointer to the first item's ITEMIDLIST structure.</param>
        ''' <param name="pidl2"> Pointer to the second item's ITEMIDLIST structure.</param>
        ''' <returns></returns>
        <PreserveSig()> _
        Function CompareIDs(lParam As Int32, pidl1 As IntPtr, pidl2 As IntPtr) As Int32

        ''' <summary>
        ''' Requests an object that can be used to obtain information from or .
        ''' with a folder object.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="hwndOwner">Handle to the owner window.</param>
        ''' <param name="riid">Identifier of the requested interface.</param>
        ''' <param name="ppv">Address of a pointer to the requested interface. </param>
        Sub CreateViewObject(hwndOwner As IntPtr, <[In]()> ByRef riid As Guid, ByRef ppv As IntPtr)

        ''' <summary>
        ''' Retrieves the attributes of one or more file objects or subfolders.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="cidl">Number of file objects from which to retrieve attributes. </param>
        ''' <param name="apidl">Address of an array of pointers to ITEMIDLIST structures, each of which  uniquely identifies a file object relative to the parent folder.</param>
        ''' <param name="rgfInOut">Address of a single ULONG value that, on entry contains the attributes that the caller is
        ''' requesting. On exit, this value contains the requested attributes that are common to all of the specified objects. this value can be from the SFGAO enum
        ''' </param>
        Sub GetAttributesOf(cidl As UInt32, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> apidl As IntPtr(), ByRef rgfInOut As ESFGAO)

        ''' <summary>
        ''' Retrieves an OLE interface that can be used to carry out actions on the
        ''' specified file objects or folders. Return value: error code, if any
        ''' </summary>
        ''' <param name="hwndOwner">Handle to the owner window that the client should specify if it displays a dialog box or message box.</param>
        ''' <param name="cidl">Number of file objects or subfolders specified in the apidl parameter. </param>
        ''' <param name="apidl">Address of an array of pointers to ITEMIDLIST  structures, each of which  uniquely identifies a file object or subfolder relative to the parent folder.</param>
        ''' <param name="riid">Identifier of the COM interface object to return.</param>
        ''' <param name="rgfReserved"> Reserved. </param>
        ''' <param name="ppv">Pointer to the requested interface.</param>
        Sub GetUIObjectOf(hwndOwner As IntPtr, cidl As UInt32, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> apidl As IntPtr(), <[In]()> ByRef riid As Guid, rgfReserved As UInt32, ByRef ppv As IntPtr)

        ''' <summary>
        ''' Retrieves the display name for the specified file object or subfolder.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="pidl">Address of an ITEMIDLIST structure (PIDL)  that uniquely identifies the file  object or subfolder relative to the parent  folder. </param>
        ''' <param name="uFlags">Flags used to request the type of display name to return. For a list of possible values. </param>
        ''' <param name="pName"> Address of a STRRET structure in which to return the display name.</param>
        Sub GetDisplayNameOf(pidl As IntPtr, uFlags As ESHGDN, ByRef pName As STRRET)

        ''' <summary>
        ''' Sets the display name of a file object or subfolder, changing the item
        ''' identifier in the process.
        ''' Return value: error code, if any
        ''' </summary>
        ''' <param name="hwnd"> Handle to the owner window of any dialog or message boxes that the client displays.</param>
        ''' <param name="pidl"> Pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. </param>
        ''' <param name="pszName"> Pointer to a null-terminated string that specifies the new display name.</param>
        ''' <param name="uFlags">Flags indicating the type of name specified by  the lpszName parameter. For a list of possible values, see the description of the SHGNO enum.</param>
        ''' <param name="ppidlOut"></param>
        Sub SetNameOf(hwnd As IntPtr, pidl As IntPtr, pszName As [String], uFlags As ESHCONTF, ByRef ppidlOut As IntPtr)

    End Interface

    Public Enum ESFGAO As UInteger
        SFGAO_CANCOPY = &H1
        SFGAO_CANMOVE = &H2
        SFGAO_CANLINK = &H4
        SFGAO_LINK = &H10000
        SFGAO_SHARE = &H20000
        SFGAO_READONLY = &H40000
        SFGAO_HIDDEN = &H80000
        SFGAO_FOLDER = &H20000000
        SFGAO_FILESYSTEM = &H40000000
        SFGAO_HASSUBFOLDER = &H80000000UI
    End Enum

    Public Enum ESHCONTF
        SHCONTF_FOLDERS = &H20
        SHCONTF_NONFOLDERS = &H40
        SHCONTF_INCLUDEHIDDEN = &H80
        SHCONTF_INIT_ON_FIRST_NEXT = &H100
        SHCONTF_NETPRINTERSRCH = &H200
        SHCONTF_SHAREABLE = &H400
        SHCONTF_STORAGE = &H800
    End Enum

    Public Enum ESHGDN
        SHGDN_NORMAL = &H0
        SHGDN_INFOLDER = &H1
        SHGDN_FOREDITING = &H1000
        SHGDN_FORADDRESSBAR = &H4000
        SHGDN_FORPARSING = &H8000
    End Enum

    ' this works too...from Unions.cs
    <StructLayout(LayoutKind.Explicit, Size:=520)> _
    Public Structure STRRETinternal
        <FieldOffset(0)> _
        Public pOleStr As IntPtr

        <FieldOffset(0)> _
        Public pStr As IntPtr
        ' LPSTR pStr;   NOT USED
        <FieldOffset(0)> _
        Public uOffset As UInteger

    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure STRRET
        Public uType As UInteger
        Public data As STRRETinternal
    End Structure

    Public Enum CSIDL
        CSIDL_FLAG_CREATE = (&H8000)
        ' Version 5.0. Combine this CSIDL with any of the following
        'CSIDLs to force the creation of the associated folder.
        CSIDL_ADMINTOOLS = (&H30)
        ' Version 5.0. The file system directory that is used to store
        ' administrative tools for an individual user. The Microsoft
        ' Management Console (MMC) will save customized consoles to
        ' this directory, and it will roam with the user.
        CSIDL_ALTSTARTUP = (&H1D)
        ' The file system directory that corresponds to the user's
        ' nonlocalized Startup program group.
        CSIDL_APPDATA = (&H1A)
        ' Version 4.71. The file system directory that serves as a
        ' common repository for application-specific data. A typical
        ' path is C:\Documents and Settings\username\Application Data.
        ' This CSIDL is supported by the redistributable Shfolder.dll
        ' for systems that do not have the Microsoft® Internet
        ' Explorer 4.0 integrated Shell installed.
        CSIDL_BITBUCKET = (&HA)
        ' The virtual folder containing the objects in the user's
        ' Recycle Bin.
        CSIDL_CDBURN_AREA = (&H3B)
        ' Version 6.0. The file system directory acting as a staging
        ' area for files waiting to be written to CD. A typical path
        ' is C:\Documents and Settings\username\Local Settings\
        ' Application Data\Microsoft\CD Burning.
        CSIDL_COMMON_ADMINTOOLS = (&H2F)
        ' Version 5.0. The file system directory containing
        ' administrative tools for all users of the computer.
        CSIDL_COMMON_ALTSTARTUP = (&H1E)
        ' The file system directory that corresponds to the
        ' nonlocalized Startup program group for all users. Valid only
        ' for Microsoft Windows NT® systems.
        CSIDL_COMMON_APPDATA = (&H23)
        ' Version 5.0. The file system directory containing application
        ' data for all users. A typical path is C:\Documents and
        ' Settings\All Users\Application Data.
        CSIDL_COMMON_DESKTOPDIRECTORY = (&H19)
        ' The file system directory that contains files and folders
        ' that appear on the desktop for all users. A typical path is
        ' C:\Documents and Settings\All Users\Desktop. Valid only for
        ' Windows NT systems.
        CSIDL_COMMON_DOCUMENTS = (&H2E)
        ' The file system directory that contains documents that are
        ' common to all users. A typical paths is C:\Documents and
        ' Settings\All Users\Documents. Valid for Windows NT systems
        ' and Microsoft Windows® 95 and Windows 98 systems with
        ' Shfolder.dll installed.
        CSIDL_COMMON_FAVORITES = (&H1F)
        ' The file system directory that serves as a common repository
        ' for favorite items common to all users. Valid only for
        ' Windows NT systems.
        CSIDL_COMMON_MUSIC = (&H35)
        ' Version 6.0. The file system directory that serves as a
        ' repository for music files common to all users. A typical
        ' path is C:\Documents and Settings\All Users\Documents\
        ' My Music.
        CSIDL_COMMON_PICTURES = (&H36)
        ' Version 6.0. The file system directory that serves as a
        ' repository for image files common to all users. A typical
        ' path is C:\Documents and Settings\All Users\Documents\
        ' My Pictures.
        CSIDL_COMMON_PROGRAMS = (&H17)
        ' The file system directory that contains the directories for
        ' the common program groups that appear on the Start menu for
        ' all users. A typical path is C:\Documents and Settings\
        ' All Users\Start Menu\Programs. Valid only for Windows NT
        ' systems.
        CSIDL_COMMON_STARTMENU = (&H16)
        ' The file system directory that contains the programs and
        ' folders that appear on the Start menu for all users. A
        ' typical path is C:\Documents and Settings\All Users\
        ' Start Menu. Valid only for Windows NT systems.
        CSIDL_COMMON_STARTUP = (&H18)
        ' The file system directory that contains the programs that
        ' appear in the Startup folder for all users. A typical path
        ' is C:\Documents and Settings\All Users\Start Menu\Programs\
        ' Startup. Valid only for Windows NT systems.
        CSIDL_COMMON_TEMPLATES = (&H2D)
        ' The file system directory that contains the templates that
        ' are available to all users. A typical path is C:\Documents
        ' and Settings\All Users\Templates. Valid only for Windows
        ' NT systems.
        CSIDL_COMMON_VIDEO = (&H37)
        ' Version 6.0. The file system directory that serves as a
        ' repository for video files common to all users. A typical
        ' path is C:\Documents and Settings\All Users\Documents\
        ' My Videos.
        CSIDL_CONTROLS = (&H3)
        ' The virtual folder containing icons for the Control Panel
        ' applications.
        CSIDL_COOKIES = (&H21)
        ' The file system directory that serves as a common repository
        ' for Internet cookies. A typical path is C:\Documents and
        ' Settings\username\Cookies.
        CSIDL_DESKTOP = (&H0)
        ' The virtual folder representing the Windows desktop, the root
        ' of the namespace.
        CSIDL_DESKTOPDIRECTORY = (&H10)
        ' The file system directory used to physically store file
        ' objects on the desktop (not to be confused with the desktop
        ' folder itself). A typical path is C:\Documents and
        ' Settings\username\Desktop.
        CSIDL_DRIVES = (&H11)
        ' The virtual folder representing My Computer, containing
        ' everything on the local computer: storage devices, printers,
        ' and Control Panel. The folder may also contain mapped
        ' network drives.
        CSIDL_FAVORITES = (&H6)
        ' The file system directory that serves as a common repository
        ' for the user's favorite items. A typical path is C:\Documents
        ' and Settings\username\Favorites.
        CSIDL_FONTS = (&H14)
        ' A virtual folder containing fonts. A typical path is
        ' C:\Windows\Fonts.
        CSIDL_HISTORY = (&H22)
        ' The file system directory that serves as a common repository
        ' for Internet history items.
        CSIDL_INTERNET = (&H1)
        ' A virtual folder representing the Internet.
        CSIDL_INTERNET_CACHE = (&H20)
        ' Version 4.72. The file system directory that serves as a
        ' common repository for temporary Internet files. A typical
        ' path is C:\Documents and Settings\username\Local Settings\
        ' Temporary Internet Files.
        CSIDL_LOCAL_APPDATA = (&H1C)
        ' Version 5.0. The file system directory that serves as a data
        ' repository for local (nonroaming) applications. A typical
        ' path is C:\Documents and Settings\username\Local Settings\
        ' Application Data.
        CSIDL_MYDOCUMENTS = (&HC)
        ' Version 6.0. The virtual folder representing the My Documents
        ' desktop item. This should not be confused with
        ' CSIDL_PERSONAL, which represents the file system folder that
        ' physically stores the documents.
        CSIDL_MYMUSIC = (&HD)
        ' The file system directory that serves as a common repository
        ' for music files. A typical path is C:\Documents and Settings
        ' \User\My Documents\My Music.
        CSIDL_MYPICTURES = (&H27)
        ' Version 5.0. The file system directory that serves as a
        ' common repository for image files. A typical path is
        ' C:\Documents and Settings\username\My Documents\My Pictures.
        CSIDL_MYVIDEO = (&HE)
        ' Version 6.0. The file system directory that serves as a
        ' common repository for video files. A typical path is
        ' C:\Documents and Settings\username\My Documents\My Videos.
        CSIDL_NETHOOD = (&H13)
        ' A file system directory containing the link objects that may
        ' exist in the My Network Places virtual folder. It is not the
        ' same as CSIDL_NETWORK, which represents the network namespace
        ' root. A typical path is C:\Documents and Settings\username\
        ' NetHood.
        CSIDL_NETWORK = (&H12)
        ' A virtual folder representing Network Neighborhood, the root
        ' of the network namespace hierarchy.
        CSIDL_PERSONAL = (&H5)
        ' The file system directory used to physically store a user's
        ' common repository of documents. A typical path is
        ' C:\Documents and Settings\username\My Documents. This should
        ' be distinguished from the virtual My Documents folder in
        ' the namespace, identified by CSIDL_MYDOCUMENTS.
        CSIDL_PRINTERS = (&H4)
        ' The virtual folder containing installed printers.
        CSIDL_PRINTHOOD = (&H1B)
        ' The file system directory that contains the link objects that
        ' can exist in the Printers virtual folder. A typical path is
        ' C:\Documents and Settings\username\PrintHood.
        CSIDL_PROFILE = (&H28)
        ' Version 5.0. The user's profile folder. A typical path is
        ' C:\Documents and Settings\username. Applications should not
        ' create files or folders at this level; they should put their
        ' data under the locations referred to by CSIDL_APPDATA or
        ' CSIDL_LOCAL_APPDATA.
        CSIDL_PROFILES = (&H3E)
        ' Version 6.0. The file system directory containing user
        ' profile folders. A typical path is C:\Documents and Settings.
        CSIDL_PROGRAM_FILES = (&H26)
        ' Version 5.0. The Program Files folder. A typical path is
        ' C:\Program Files.
        CSIDL_PROGRAM_FILES_COMMON = (&H2B)
        ' Version 5.0. A folder for components that are shared across
        ' applications. A typical path is C:\Program Files\Common.
        ' Valid only for Windows NT, Windows 2000, and Windows XP
        ' systems. Not valid for Windows Millennium Edition
        ' (Windows Me).
        CSIDL_PROGRAMS = (&H2)
        ' The file system directory that contains the user's program
        ' groups (which are themselves file system directories).
        ' A typical path is C:\Documents and Settings\username\
        ' Start Menu\Programs.
        CSIDL_RECENT = (&H8)
        ' The file system directory that contains shortcuts to the
        ' user's most recently used documents. A typical path is
        ' C:\Documents and Settings\username\My Recent Documents.
        ' To create a shortcut in this folder, use SHAddToRecentDocs.
        ' In addition to creating the shortcut, this function updates
        ' the Shell's list of recent documents and adds the shortcut
        ' to the My Recent Documents submenu of the Start menu.
        CSIDL_SENDTO = (&H9)
        ' The file system directory that contains Send To menu items.
        ' A typical path is C:\Documents and Settings\username\SendTo.
        CSIDL_STARTMENU = (&HB)
        ' The file system directory containing Start menu items. A
        ' typical path is C:\Documents and Settings\username\Start Menu.
        CSIDL_STARTUP = (&H7)
        ' The file system directory that corresponds to the user's
        ' Startup program group. The system starts these programs
        ' whenever any user logs onto Windows NT or starts Windows 95.
        ' A typical path is C:\Documents and Settings\username\
        ' Start Menu\Programs\Startup.
        CSIDL_SYSTEM = (&H25)
        ' Version 5.0. The Windows System folder. A typical path is
        ' C:\Windows\System32.
        CSIDL_TEMPLATES = (&H15)
        ' The file system directory that serves as a common repository
        ' for document templates. A typical path is C:\Documents
        ' and Settings\username\Templates.
        CSIDL_WINDOWS = (&H24)
        ' Version 5.0. The Windows directory or SYSROOT. This
        ' corresponds to the %windir% or %SYSTEMROOT% environment
        ' variables. A typical path is C:\Windows.
    End Enum

    <ComImport()> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    <Guid("000214F2-0000-0000-C000-000000000046")> _
    Public Interface IEnumIDList

        ''' <summary>
        ''' Retrieves the specified number of item identifiers in the
        ''' enumeration sequence and advances the current position by
        ''' the number of items retrieved.
        ''' </summary>
        ''' <param name="celt">Number of elements in the array pointed to by the rgelt parameter.</param>
        ''' <param name="rgelt">
        ''' Address of an array of ITEMIDLIST pointers that receives the item identifiers. The implementation must allocate these item identifiers
        ''' using the Shell's allocator (retrieved by the SHGetMalloc function). The calling application is responsible for freeing the item
        ''' identifiers using the Shell's allocator.
        ''' </param>
        ''' <param name="pceltFetched">
        ''' Address of a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than the value
        ''' specified in the celt parameter. This parameter can be NULL only if celt is one.
        ''' </param>
        <PreserveSig()> _
        Function [Next](celt As UInteger, <MarshalAs(UnmanagedType.LPArray)> rgelt As IntPtr(), ByRef pceltFetched As Integer) As UInteger

        ''' <summary>
        ''' Skips over the specified number of elements in the enumeration sequence.
        ''' </summary>
        ''' <param name="celt">Number of item identifiers to skip.</param>
        <PreserveSig()> _
        Function Skip(celt As UInteger) As UInteger

        ''' <summary>
        ''' Returns to the beginning of the enumeration sequence.
        ''' </summary>
        <PreserveSig()> _
        Function Reset() As UInteger

        ''' <summary>
        ''' Creates a new item enumeration object with the same contents and state as the current one.
        ''' </summary>
        ''' <param name="ppenum">
        ''' Address of a pointer to the new enumeration object. The calling application must
        ''' eventually free the new object by calling its Release member function.
        ''' </param>
        <PreserveSig()> _
        Function Clone(ByRef ppenum As IEnumIDList) As UInteger
    End Interface

    <Flags()> _
    Public Enum SHGFI As Integer
        ''' <summary>get icon</summary>
        Icon = &H100
        ''' <summary>get display name</summary>
        DisplayName = &H200
        ''' <summary>get type name</summary>
        TypeName = &H400
        ''' <summary>get attributes</summary>
        Attributes = &H800
        ''' <summary>get icon location</summary>
        IconLocation = &H1000
        ''' <summary>return exe type</summary>
        ExeType = &H2000
        ''' <summary>get system icon index</summary>
        SysIconIndex = &H4000
        ''' <summary>put a link overlay on icon</summary>
        LinkOverlay = &H8000
        ''' <summary>show icon in selected state</summary>
        Selected = &H10000
        ''' <summary>get only specified attributes</summary>
        Attr_Specified = &H20000
        ''' <summary>get large icon</summary>
        LargeIcon = &H0
        ''' <summary>get small icon</summary>
        SmallIcon = &H1
        ''' <summary>get open icon</summary>
        OpenIcon = &H2
        ''' <summary>get shell size icon</summary>
        ShellIconSize = &H4
        ''' <summary>pszPath is a pidl</summary>
        PIDL = &H8
        ''' <summary>use passed dwFileAttribute</summary>
        UseFileAttributes = &H10
        ''' <summary>apply the appropriate overlays</summary>
        AddOverlays = &H20
        ''' <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
        OverlayIndex = &H40
    End Enum
End Class

Public NotInheritable Class PrinterIcons
    Private Sub New()

    End Sub

    Public Shared Function GetPrintersWithIcons(hwndOwner As IntPtr) As Dictionary(Of String, Icon)
        Dim result As New Dictionary(Of String, Icon)()

        Dim iDesktopFolder As Shell32.IShellFolder = Shell32.GetDesktopFolder()
        Try
            Dim pidlPrintersFolder As IntPtr
            If Shell32.SHGetFolderLocation(hwndOwner, CInt(Shell32.CSIDL.CSIDL_PRINTERS), IntPtr.Zero, 0, pidlPrintersFolder) = 0 Then
                Try
                    Dim strDisplay As New StringBuilder(260)
                    Dim guidIShellFolder As Guid = Shell32.IID_IShellFolder
                    Dim ptrPrintersShellFolder As IntPtr
                    iDesktopFolder.BindToObject(pidlPrintersFolder, IntPtr.Zero, guidIShellFolder, ptrPrintersShellFolder)
                    Dim objPrintersShellFolder As [Object] = Marshal.GetTypedObjectForIUnknown(ptrPrintersShellFolder, Shell32.ShellFolderType)
                    Try
                        Dim printersShellFolder As Shell32.IShellFolder = DirectCast(objPrintersShellFolder, Shell32.IShellFolder)

                        Dim ptrObjectsList As IntPtr

                        printersShellFolder.EnumObjects(hwndOwner, Shell32.ESHCONTF.SHCONTF_NONFOLDERS, ptrObjectsList)
                        Dim objEnumIDList As [Object] = Marshal.GetTypedObjectForIUnknown(ptrObjectsList, Shell32.EnumIDListType)
                        Try
                            Dim iEnumIDList As Shell32.IEnumIDList = DirectCast(objEnumIDList, Shell32.IEnumIDList)
                            Dim rgelt As IntPtr() = New IntPtr(0) {}
                            Dim pidlPrinter As IntPtr
                            Dim pceltFetched As Integer
                            Dim ptrString As Shell32.STRRET
                            While iEnumIDList.[Next](1, rgelt, pceltFetched) = 0 AndAlso pceltFetched = 1
                                printersShellFolder.GetDisplayNameOf(rgelt(0), Shell32.ESHGDN.SHGDN_NORMAL, ptrString)
                                If Shell32.StrRetToBuf(ptrString, rgelt(0), strDisplay, CUInt(strDisplay.Capacity)) = 0 Then
                                    pidlPrinter = Shell32.ILCombine(pidlPrintersFolder, rgelt(0))
                                    Dim printerDisplayNameInPrintersFolder As String = strDisplay.ToString()

                                    Dim shinfo As New Shell32.SHFILEINFO()
                                    Shell32.SHGetFileInfo(pidlPrinter, 0, shinfo, CUInt(Marshal.SizeOf(shinfo)), Shell32.SHGFI.PIDL Or Shell32.SHGFI.AddOverlays Or Shell32.SHGFI.Icon)
                                    Dim printerIcon As Icon = DirectCast(Icon.FromHandle(shinfo.hIcon).Clone(), Icon)
                                    Shell32.DestroyIcon(shinfo.hIcon)

                                    result.Add(printerDisplayNameInPrintersFolder, printerIcon)
                                    printersdetails.Add(printerDisplayNameInPrintersFolder, printerIcon)

                                End If
                            End While
                        Finally
                            Marshal.ReleaseComObject(objEnumIDList)
                        End Try
                    Finally
                        Marshal.ReleaseComObject(objPrintersShellFolder)
                    End Try
                Finally
                    Shell32.ILFree(pidlPrintersFolder)
                End Try
            End If
        Finally
            Marshal.ReleaseComObject(iDesktopFolder)
        End Try

        Return result
    End Function
End Class
