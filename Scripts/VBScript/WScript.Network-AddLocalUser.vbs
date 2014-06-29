On Error Resume Next
Dim strComputerName
Dim strPassword
Dim strUserName
Dim checkuser
Dim WshNetwork 
Dim objComputer 
Dim colaccounts 
Dim objGroup 
Dim objUser2 

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
	' Add the user, if the user doesn't exist
	Set colaccounts = GetObject("WinNT://" & strComputerName & ",computer")
	Set objUser = colaccounts.Create("user", strUserName)
	objUser.SetPassword strPassword
	objUser.SetInfo
End If