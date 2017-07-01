Option Strict On

Imports System.IO
Imports System.Text

Public Class FileRenamer
    Sub renamefiles(dirname As String)
        For Each f As String In Directory.GetFiles(dirname)
            Try
                auto_rename(f)
            Catch ex As Exception
            End Try
        Next
    End Sub
    Function ByteToStr(b() As Byte) As String
        Dim sb As New StringBuilder
        For i As Integer = 0 To b.Length - 1
            sb.Append(Chr(b(i)))
        Next
        Return sb.ToString
    End Function
    Public Shared Sub ChangeExt(fn As String, s As String)
        If Path.GetFileName(fn).Contains(".") Then
            Dim f As String = fn
            f = Path.GetDirectoryName(f) + "\" + Path.GetFileNameWithoutExtension(f) + "."
            File.Move(fn, f + s)
        Else
            File.Move(fn, fn + "." + s)
        End If
    End Sub
    Sub auto_rename(fn As String)
        If Not File.Exists(fn) Then Return
        Dim fs As New FileStream(fn, FileMode.Open)
        If fs.Length = 0 Then
            fs.Close()
            ChangeExt(fn, "empty")
            Return
        End If
        If fs.Length < 4 Then Return
        Dim first4(3) As Byte
        fs.Read(first4, 0, 4)
        Dim head = ByteToStr(first4)
        Dim REVntable As New List(Of String)
        Dim ntable As New List(Of String)
        Dim revhead = StrReverse(head)
        Dim Rename As String = ""
        Select Case head
            Case "BMD0"
                Rename = "nsbmd"
            Case "BCA0"
                Rename = "nsbca"
            Case "BTX0"
                Rename = "nsbtx"
            Case "BTP0"
                Rename = "nsbtp"
            Case "RTFN"
                Rename = "NFTR"
            Case "RECN"
                Rename = "NCER"
            Case "RGCN"
                Rename = "NCGR"
            Case "RLCN"
                Rename = "NCLR"
            Case "RCSN"
                Rename = "NSCR"
        End Select
        If Rename.Length <> 0 Then
            fs.Close()
            ChangeExt(fn, Rename)
            Return
        End If
        fs.Close()
    End Sub
End Class
