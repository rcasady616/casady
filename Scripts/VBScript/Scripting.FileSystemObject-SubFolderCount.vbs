Dim intget
Dim intpost
Dim objTextFilein 
Dim strFile
Dim intFolder 

Set objFSO = CreateObject("Scripting.FileSystemObject")
objStartFolder = "E:\"

Set objFolder = objFSO.GetFolder(objStartFolder)

ShowSubfolders(objFSO.GetFolder(objStartFolder))

wscript.Echo(intFolder & " Folders found")


' ##### Functions #####

Sub ShowSubFolders(Folder)
	on error resume next
	For Each Subfolder in Folder.SubFolders
		'Wscript.Echo Subfolder.Path
		intFolder = intFolder + 1
        	Set objFolder = objFSO.GetFolder(Subfolder.Path)
        	ShowSubfolders(objFSO.GetFolder(objFolder)) 
   	 Next
End Sub
