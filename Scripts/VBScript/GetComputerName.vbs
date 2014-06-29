Dim wshNetwork

set wshNetwork = Wscript.createObject("Wscript.Network")
msgbox(wshNetwork.ComputerName)