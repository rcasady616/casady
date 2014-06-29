Option Explicit
Dim strDrive
Dim strUNC
Dim objNetwork
Dim strProfile 
Dim strUser 
Dim strPassword 
Dim objPopUp 

Set objNetwork = CreateObject("WScript.Network") 

strDrive = "Q:"
strUNC = "\\sv-qa-01\QUE1"
strProfile = "False"   ' Mapping (not) stored in user Profile
strUser = "casady"
strPassword = "casady123"

Set objPopUp = CreateObject("WScript.Shell")

objNetwork.MapNetworkDrive strDrive, strUNC, strProfile, strUser, strPassword 

objPopUp.popup "Drive " & strDrive & " connected successfully." 

