Imports ClipperLib
Public Class frmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim subj As New List(Of List(Of IntPoint))
        Dim clip As New List(Of List(Of IntPoint))
        Dim solution As New PolyTree

        Dim c As New Clipper()
        c.AddPaths(subj, PolyType.ptSubject, True)
        c.AddPaths(clip, PolyType.ptClip, True)
        c.Execute(ClipType.ctIntersection, solution, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd)
        DrawPolygons(solution, Color.FromArgb(&H30, 0, &HFF, 0), Color.FromArgb(&HFF, 0, &H66, 0))
    End Sub
    Private Sub DrawPolygons(solution As PolyTree, c1 As Color, c2 As Color)

    End Sub
End Class
