Dim objFSO
Dim objFile
Dim strFile
Dim strLine

' Get the path of the file to be used
if(WScript.Arguments.Count = 1)then
	strFile = WScript.Arguments(0)
else
	wscript.echo("Drag and Drop a text file to this script to run it.")
	WScript.quit()
end if

Set objFSO = CreateObject("Scripting.FileSystemObject")

' The 1 is used to open the file for reading
Set objFile = objFSO.OpenTextFile(strFile, 1)

Do While Not objFile.AtEndOfStream
	strLine = objFile.ReadLine
	wscript.echo(strLine)
loop