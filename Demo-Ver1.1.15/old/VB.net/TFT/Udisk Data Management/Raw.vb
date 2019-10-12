Imports System.Runtime.InteropServices

Public Class Raw
    'Transfer other object into serialized bytes array.
    Public Shared Function RawSerialize(ByVal anything) As Byte()
        Dim rawsize As Integer = Marshal.SizeOf(anything)
        Dim buffer As IntPtr = Marshal.AllocHGlobal(rawsize)
        Marshal.StructureToPtr(anything, buffer, False)
        Dim rawdatas(rawsize) As Byte
        Marshal.Copy(buffer, rawdatas, 0, rawsize)
        Marshal.FreeHGlobal(buffer)
        Return rawdatas
    End Function
    'Transfer serialized bytes array into other object.
    Public Shared Function RawDeserialize(ByVal rawdatas() As Byte, ByVal anytype As Type) As Object
        Dim rawsize As Integer = Marshal.SizeOf(anytype)
        If rawsize > rawdatas.Length Then
            Return Nothing
        End If
        Dim buffer As IntPtr = Marshal.AllocHGlobal(rawsize)
        Marshal.Copy(rawdatas, 0, buffer, rawsize)
        Dim retobj As Object = Marshal.PtrToStructure(buffer, anytype)
        Marshal.FreeHGlobal(buffer)
        Return retobj
    End Function

End Class
