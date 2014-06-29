Dim wshShell

set WshShell = WScript.CreateObject("WScript.Shell")
WshShell.Run "cmd /c xcopy.exe " & chr(34) & "c:\LoadResults\ResultsDataFiles\" & strDBName  & ".*" & chr(34) & " " & chr(34) & strStartFolder & chr(34) & " /y", 0, true 

