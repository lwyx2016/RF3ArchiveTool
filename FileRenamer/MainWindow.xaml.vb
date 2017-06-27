Imports System.Collections.ObjectModel

Class MainWindow

    Private Sub TextBlock_Drop(sender As Object, e As DragEventArgs)
        Dim f = CType(e.Data.GetData(DataFormats.FileDrop), String())
        RenameFiles(f)
    End Sub
    Private Sub RenameFiles(f As String())
        Dim ren As New FileRenamer
        System.Threading.Tasks.Parallel.ForEach(f, Sub(fn As String)
                                                       Try
                                                           ren.auto_rename(fn)
                                                       Catch ex As Exception
                                                       End Try
                                                   End Sub)
    End Sub
End Class