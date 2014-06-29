option explicit

Dim strComputer
Dim strUser
Dim strDomain
Dim StrPassword
 
strComputer = "mycomp" 
strDomain = "mydom.net" 
strUser = "myuser"

CreateShare "Share1", "D:\mydir", "this is mydir"

Private Sub CreateShare(strShareName, strPath, strDescription) 
	Dim objSWbemServices 	'as object  
	Dim objSWbemObject 	'as 'object     
	Dim colSWbemObject 	'as object  
       	Dim intRet 		'as integer  
        Dim blnExists 		'as boolean  
        Dim objSWbem 		' as object 
	Dim objSWbemLocator 
	Dim colSwbemObjectSet 
	Dim blnShareExists 

	strPassword = "workshare" 'objPassword.GetPassword()
 
	Set objSWbemLocator = CreateObject("WbemScripting.SWbemLocator")
	Set objSWbemServices = objSWbemLocator.ConnectServer(strComputer, "root\cimv2", _
	     strUser, strPassword, "MS_409", "ntlmdomain:" + strDomain)

	Set colSwbemObjectSet = objSWbemServices.InstancesOf("Win32_Share") 

      	For each objSWbem in colSwbemObjectSet 
		'msgbox(objswbem.name)
      		If(objSWbem.name = strShareName)Then  
    			blnShareExists = True 
    			Exit For 
    		Else            
    			blnShareExists = False 
    	    End If 
    	Next  

	'msgbox("Ready to share") 
    	If (blnShareExists = False)Then 

      		set objSWbemObject = objSWbemServices.Get("Win32_Share")  

        	intRet = objSWbemObject.Create(strPath, strShareName, 0, 10, strDescription) 
        Else 
        	'msgbox("Folder aready shared") 
        End If 
msgbox(intret)
End Sub
