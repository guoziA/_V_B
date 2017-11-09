Public Class AlarmListViewSorter
    Implements System.Collections.IComparer
    Public SortIndex As Integer
    Public Sub New(ByVal SortIndex As Integer)
        Me.SortIndex = SortIndex
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim x1, y1 As ListViewItem
        Dim intx, inty As String
        x1 = x
        y1 = y
        intx = x1.SubItems(SortIndex).ToString()
        inty = y1.SubItems(SortIndex).ToString()
        If (intx < inty) Then
            Return -1
        ElseIf (intx = inty) Then
            Return 0
        End If
        Return 1
    End Function
End Class
