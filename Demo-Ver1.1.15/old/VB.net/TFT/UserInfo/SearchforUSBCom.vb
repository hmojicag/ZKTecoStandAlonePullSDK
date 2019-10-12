Option Explicit On
Imports Microsoft.Win32
Public Class SearchforUSBCom
    'Search for the virtual serial port created by usbclient.
    Public Function SearchforCom(ByRef sCom As String) As Boolean
        Dim sComValue As String
        Dim sTmpara As String
        Dim myReg As RegistryKey
        myReg = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM")

        Dim sComName() As String
        sComName = myReg.GetValueNames() 'strings array composed of the key name holded by the subkey "SERIALCOMM"
        Dim i As Integer
        For i = 0 To sComName.Length - 1
            sComValue = myReg.GetValue(sComName(i)).ToString() 'obtain the key value of the corresponding key name
            If sComValue = "" Then
                Continue For
            End If

            sCom = ""
            Dim j As Integer
            If sComName(i) = "\Device\USBSER000" Then 'find the virtual serial port created by usbclient
                For j = 0 To 10
                    sTmpara = ""
                    Dim myReg2 As RegistryKey
                    myReg2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\USB\\VID_1B55&PID_B400\\" & j.ToString() & "\\Device Parameters")

                    If myReg2 IsNot Nothing Then
                        sTmpara = myReg2.GetValue("PortName").ToString()

                        If sComValue = sTmpara Then
                            sCom = sTmpara
                            Return True
                        End If
                    End If
                Next
            End If
        Next
        Return False
    End Function
End Class

