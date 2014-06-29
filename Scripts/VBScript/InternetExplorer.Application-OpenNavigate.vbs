Dim oIE	
IeNew("www.google.com")

' Put your name into the "Search" textbox 
' Notice below that the textbox's name is "q"
oIE.document.all.q.value = "Rick Casady"

WScript.Sleep(100)

' Click the Search button
' Notice below that the button's name is "q"
oIE.document.all.btnG.click()


' Create a Internet Explorer COM object and then Navigate the Navigate sub
' Also sets the Internet explorer to be visible
Public Sub IeNew(ByVal strURL)
	Set oIE = CreateObject("InternetExplorer.Application")
	Navigate(strURL)
	oIE.Visible = True
End Sub

' Navigates to the URL provided then waits for IE to complete.
Public Sub Navigate(ByVal strURL)
	oIE.Navigate(strURL)
	Do
		WScript.Sleep(200)
	Loop Until Not oIE.Busy
End Sub