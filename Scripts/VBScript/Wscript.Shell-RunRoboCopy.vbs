Dim wshShell
Dim strRoboCMD
Dim strSourceFile 
Dim strDestFile 
Dim strOptions

set WshShell = WScript.CreateObject("WScript.Shell")

strRoboCMD = "cmd /c " & chr(34) & "c:\Program Files\Windows Resource Kits\Tools\robocopy.exe" & chr(34) & " "
strSourceFile = chr(34) & "" & chr(34) & " "
strDestFile = chr(34) & "" & chr(34) & " "
strOptions = " "

WshShell.Run strRoboCMD & strSourceFile & strDestFile & strOptions, 0, true 