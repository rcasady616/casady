'On Error Resume Next
Dim strComputerName
Dim strPassword
Dim strUserName
Dim checkuser
Dim WshNetwork 
Dim objComputer 
Dim colaccounts 
Dim objGroup 
Dim objUser2 
Dim objstr

Set WshNetwork = CreateObject("WScript.Network")
strComputerName = WshNetwork.ComputerName 'getting the machine name

strUserName="casady"
strPassword="casady123"

checkuser = 1 
Set objComputer = GetObject("WinNT://" & strComputerName)
objComputer.Filter = Array("User")
For Each objUser In objComputer
	' See if user already exists
	If (objUser.Name = strUserName) And (checkuser = 1) Then 
		checkuser = 0
	End If
Next

If checkuser = 1 Then
	' Add the user
	Set colaccounts = GetObject("WinNT://" & strComputerName & ",computer")
	Set objUser = colaccounts.Create("user", strUserName)
	objUser.SetPassword strPassword
	objUser.SetInfo

	' Add user to the Administrators group
	objstr = "/" & strUserName & ",user"
	Set objGroup = GetObject("WinNT://" & strComputerName & "/Administrators,group")
	Set objUser2 = GetObject("WinNT://" & strComputerName & objstr)
	objGroup.Add (objUser2.ADsPath)
End If