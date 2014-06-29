Option Explicit
Dim URL		' string
Dim xmlhttp	' http request
Dim objFileSys  ' File System Object
Dim file	' file 

URL = "http://www.google.com"
 
' Create the HTTP object
Set xmlhttp = CreateObject("Microsoft.XmlHttp")

' Open connection
xmlhttp.open "GET",  URL , false 

' Send the request synchronously
xmlhttp.send ""

' Write the response to a file
Set objFileSys = CreateObject("Scripting.FileSystemObject")
Set file= objFileSys.OpenTextFile("Google.htm", 8, True, 0)
file.Write(xmlhttp.responseText)
File.Close