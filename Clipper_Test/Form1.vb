Imports ClipperLib
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class frmMain
    Private Function PolygonToPointFArray(pg As List(Of IntPoint), scale As Double) As PointF()

        Dim result(pg.Count - 1) As PointF
        For i As Integer = 0 To pg.Count - 1
            result(i) = New PointF(pg(i).X / scale + PictureBox1.ClientRectangle.Width / 2, pg(i).Y / scale + PictureBox1.ClientRectangle.Height / 2)
        Next
        Return result
    End Function
    Dim myBitmap As Bitmap
    Dim newgraphic As Graphics
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        myBitmap = New Bitmap(PictureBox1.ClientRectangle.Width, PictureBox1.ClientRectangle.Height, PixelFormat.Format32bppArgb)
        newgraphic = Graphics.FromImage(myBitmap)
        Dim subj As New List(Of List(Of IntPoint))
        Dim clip As New List(Of List(Of IntPoint))
        Dim solution As New List(Of List(Of IntPoint))
        Dim solution2 As New List(Of List(Of IntPoint))
        Dim b1, h1 As Double
        Dim o1 As IntPoint
        Dim b2, h2 As Double
        Dim o2 As IntPoint
        Dim offset As Double = 20
        Dim scale As Double = 1
        b1 = 30
        h1 = 30
        b2 = 100
        h2 = 100
        o1 = New IntPoint(-20, -25)
        o2 = New IntPoint(0, 0)
        Dim rect1 As New List(Of IntPoint)
        Dim rect2 As New List(Of IntPoint)
        rect1.Add(New IntPoint(o1.X - b1 / 2, o1.Y - h1 / 2))
        rect1.Add(New IntPoint(o1.X - b1 / 2, o1.Y + h1 / 2))
        rect1.Add(New IntPoint(o1.X + b1 / 2, o1.Y + h1 / 2))
        rect1.Add(New IntPoint(o1.X + b1 / 2, o1.Y - h1 / 2))
        DrawPolygon(rect1, Color.FromArgb(&HFF, 0, &HFF, 0), Color.FromArgb(&HFF, 20, 20, 20), scale)
        Dim co As New ClipperOffset()
        co.AddPath(rect1, JoinType.jtRound, EndType.etClosedPolygon)
        co.Execute(solution2, offset * scale)
        DrawPolygon(solution2, Color.FromArgb(0, 0, &HFF, 0), Color.FromArgb(&HFF, 0, 0, 0), scale)
        rect2.Add(New IntPoint(o2.X - b2 / 2, o2.Y - h2 / 2))
        rect2.Add(New IntPoint(o2.X - b2 / 2, o2.Y + h2 / 2))
        rect2.Add(New IntPoint(o2.X + b2 / 2, o2.Y + h2 / 2))
        rect2.Add(New IntPoint(o2.X + b2 / 2, o2.Y - h2 / 2))
        DrawPolygon(rect2, Color.FromArgb(0, 0, &HFF, 0), Color.FromArgb(&HFF, 20, 20, 20), scale)

        Dim c As New Clipper()
        c.AddPath(rect2, PolyType.ptSubject, True)
        c.AddPaths(solution2, PolyType.ptClip, True)
        c.Execute(ClipType.ctIntersection, solution, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd)
        DrawPolygon(solution, Color.FromArgb(&H30, 0, 0, &HFF), Color.FromArgb(&HFF, 0, &H66, 0), scale)
    End Sub
    Private Sub DrawPolygon(solution As Object, c1 As Color, c2 As Color, scale As Double)





        Dim path As New GraphicsPath()

        newgraphic.SmoothingMode = SmoothingMode.AntiAlias


        path.FillMode = FillMode.Winding
        If TypeOf solution Is List(Of List(Of IntPoint)) Then
            For Each pg As List(Of IntPoint) In DirectCast(solution, List(Of List(Of IntPoint)))
                Dim pts As PointF() = PolygonToPointFArray(pg, scale)
                path.AddPolygon(pts)
            Next

        ElseIf TypeOf solution Is List(Of IntPoint) Then
            Dim pg As List(Of IntPoint) = DirectCast(solution, List(Of IntPoint))
            Dim pts As PointF() = PolygonToPointFArray(pg, scale)
            path.AddPolygon(pts)


        End If
        Dim myBrush As New SolidBrush(c1)
        Dim myPen As New Pen(c2)
        myPen.Width = 1.0
        'If myBrush.Color.A > 0 Then
        newgraphic.FillPath(myBrush, path)
        'End If
        newgraphic.DrawPath(myPen, path)
        PictureBox1.Image = myBitmap

    End Sub
End Class
