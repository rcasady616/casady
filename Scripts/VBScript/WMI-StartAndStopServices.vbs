Option Explicit
Dim objWMIService
Dim objItem
Dim objService
Dim colListOfServices
Dim strComputer
Dim strService
Dim intSleep 

' Use the local computer
strComputer = "."

' 5 second sleep
intSleep = 5000

'On Error Resume Next
' NB strService is case sensitive.
strService = " 'Alerter' "

Set objWMIService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")

Set colListOfServices = objWMIService.ExecQuery("Select * from Win32_Service Where Name =" & strService & " ")

For Each objService in colListOfServices
	objService.StopService()
	Wscript.Echo("Your "& strService & " service has Stopped") 
	WSCript.Sleep intSleep
	objService.StartService()
Next 

WScript.Echo("Your "& strService & " service has Started")


