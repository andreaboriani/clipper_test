Imports ClipperLib
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class frmMain
    Dim myBitmap As Bitmap
    Dim newgraphic As Graphics
    Dim slab As New RectPoly(200, 200, New IntPoint(0, 0))
    Dim column As New RectPoly(30, 30, New IntPoint(0, 0))
    Dim zoom As Double = 1
    Dim offset As Double = 20
    Dim pathArea As Double
    Dim pathPerimeter As Double

    Private Class RectPoly
        Private _w, _h As Double
        Private _origin As IntPoint
        Private _poly As New List(Of IntPoint)
        ReadOnly Property Poly As List(Of IntPoint)
            Get
                Return _poly
            End Get
        End Property
        Property width As Double
            Get
                Return _w
            End Get
            Set(value As Double)
                _w = value
                _poly = BuildRectangularPolygon(_w, _h, _origin)
            End Set
        End Property
        Property height As Double
            Get
                Return _h
            End Get
            Set(value As Double)
                _h = value
                _poly = BuildRectangularPolygon(_w, _h, _origin)
            End Set
        End Property
        Property origin As IntPoint
            Get
                Return _origin
            End Get
            Set(value As IntPoint)
                _origin = value
                _poly = BuildRectangularPolygon(_w, _h, _origin)
            End Set
        End Property

        Public Sub New(w As Double, h As Double, origin As IntPoint)
            _w = w
            _h = h
            _origin = origin
            _poly = BuildRectangularPolygon(_w, _h, _origin)
        End Sub
        Private Function BuildRectangularPolygon(width As Double, height As Double, origin As IntPoint) As List(Of IntPoint)
            Dim rp As New List(Of IntPoint)
            Dim ox As Double = origin.X
            Dim oy As Double = origin.Y
            Dim hw As Double = width / 2
            Dim hh As Double = height / 2
            rp.Add(New IntPoint(ox - hw, oy - hh))
            rp.Add(New IntPoint(ox - hw, oy + hh))
            rp.Add(New IntPoint(ox + hw, oy + hh))
            rp.Add(New IntPoint(ox + hw, oy - hh))
            Return rp
        End Function
    End Class
    Private Function PolygonToPointFArray(pg As List(Of IntPoint)) As PointF()
        Dim result(pg.Count - 1) As PointF
        Dim pbw As Double = PictureBox1.ClientRectangle.Width / 2
        Dim pbh As Double = PictureBox1.ClientRectangle.Height / 2
        For i As Integer = 0 To pg.Count - 1
            result(i) = New PointF(pg(i).X * zoom + pbw, pg(i).Y * zoom + pbh)
        Next
        Return result
    End Function

    Private Sub Draw()
        myBitmap = New Bitmap(PictureBox1.ClientRectangle.Width, PictureBox1.ClientRectangle.Height, PixelFormat.Format32bppArgb)
        newgraphic = Graphics.FromImage(myBitmap)
        newgraphic.SmoothingMode = SmoothingMode.AntiAlias
        newgraphic.Clear(Color.White)
        Dim punchingPath As New List(Of List(Of IntPoint))
        Dim offsetPolygon As New List(Of List(Of IntPoint))
        DrawPolygon(slab.Poly, Color.Gray, Color.FromArgb(&HFF, 20, 20, 20))
        DrawPolygon(column.Poly, Color.DarkGray, Color.FromArgb(&HFF, 20, 20, 20))
        'do the offset
        Dim co As New ClipperOffset()
        co.AddPath(column.Poly, JoinType.jtRound, EndType.etClosedPolygon)
        co.Execute(offsetPolygon, offset)
        DrawPolygon(offsetPolygon, Color.FromArgb(0, 0, &HFF, 0), Color.FromArgb(&HFF, 0, 0, 0))
        Dim c As New Clipper()
        c.AddPath(slab.Poly, PolyType.ptSubject, True)
        c.AddPaths(offsetPolygon, PolyType.ptClip, True)
        c.Execute(ClipType.ctIntersection, punchingPath, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd)
        DrawPolygon(punchingPath, Color.FromArgb(&H30, 0, 0, &HFF), Color.FromArgb(&HFF, 0, &H66, 0))
        pathArea = 0
        pathPerimeter = 0
        For Each p As List(Of IntPoint) In punchingPath
            pathArea = pathArea + ClipperLib.Clipper.Area(p)
            pathPerimeter = pathPerimeter + polygonPerimeter(p)
        Next
        txtArea.Text = Format(pathArea, "0.00")
        txtPerimeter.Text = Format(pathPerimeter, "0.00")
    End Sub

    Private Function polygonPerimeter(polygon As List(Of IntPoint)) As Double
        Dim p As Double
        polygon.Add(polygon(0))
        For i As Integer = 1 To polygon.Count - 1
            p = p + Math.Sqrt((polygon(i).X - polygon(i - 1).X) ^ 2 + (polygon(i).Y - polygon(i - 1).Y) ^ 2)
        Next
        polygon.RemoveAt(polygon.Count - 1)
        Return p
    End Function
    Private Function BuildRectangularPolygon(width As Double, height As Double, origin As IntPoint) As List(Of IntPoint)
        Dim rp As New List(Of IntPoint)
        Dim ox As Double = origin.X
        Dim oy As Double = origin.Y
        Dim hw As Double = width / 2
        Dim hh As Double = height / 2
        rp.Add(New IntPoint(ox - hw, oy - hh))
        rp.Add(New IntPoint(ox - hw, oy + hh))
        rp.Add(New IntPoint(ox + hw, oy + hh))
        rp.Add(New IntPoint(ox + hw, oy - hh))
        Return rp
    End Function
    Private Sub DrawPolygon(solution As Object, brushColor As Color, penColor As Color)
        Dim path As New GraphicsPath()

        path.FillMode = FillMode.Winding
        If TypeOf solution Is List(Of List(Of IntPoint)) Then
            For Each pg As List(Of IntPoint) In DirectCast(solution, List(Of List(Of IntPoint)))
                Dim pts As PointF() = PolygonToPointFArray(pg)
                path.AddPolygon(pts)
            Next
        ElseIf TypeOf solution Is List(Of IntPoint) Then
            Dim pg As List(Of IntPoint) = DirectCast(solution, List(Of IntPoint))
            Dim pts As PointF() = PolygonToPointFArray(pg)
            path.AddPolygon(pts)
        End If
        Dim myBrush As New SolidBrush(brushColor)
        Dim myPen As New Pen(penColor)
        myPen.Width = 1.0
        newgraphic.FillPath(myBrush, path)
        newgraphic.DrawPath(myPen, path)
        PictureBox1.Image = myBitmap

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        trbX.Minimum = -txtSw.Text / 2 + column.width / 2
        trbX.Maximum = txtSw.Text / 2 - column.width / 2
        trbY.Minimum = -txtSh.Text / 2 + column.height / 2
        trbY.Maximum = txtSh.Text / 2 - column.height / 2
        column.origin = New IntPoint(trbX.Value, trbY.Value)
        Draw()
    End Sub

    Private Sub trb_ValueChanged(sender As Object, e As EventArgs) Handles trbX.ValueChanged, trbY.ValueChanged
        column.origin = New IntPoint(trbX.Value, trbY.Value)
        Draw()
    End Sub

    Private Sub txtCw_TextChanged(sender As Object, e As EventArgs) Handles txtCw.TextChanged
        On Error Resume Next
        column.width = txtCw.Text
        trbX.Minimum = -txtSw.Text / 2 + column.width / 2
        trbX.Maximum = txtSw.Text / 2 - column.width / 2
        Draw()
    End Sub
    Private Sub txtCh_TextChanged(sender As Object, e As EventArgs) Handles txtCh.TextChanged
        On Error Resume Next
        column.height = txtCh.Text
        trbY.Minimum = -txtSh.Text / 2 + column.height / 2
        trbY.Maximum = txtSh.Text / 2 - column.height / 2
        Draw()
    End Sub
    Private Sub txtSw_TextChanged(sender As Object, e As EventArgs) Handles txtSw.TextChanged
        On Error Resume Next
        slab.width = txtSw.Text
        trbX.Minimum = -txtSw.Text / 2 + column.width / 2
        trbX.Maximum = txtSw.Text / 2 - column.width / 2
        Draw()
    End Sub
    Private Sub txtSh_TextChanged(sender As Object, e As EventArgs) Handles txtSh.TextChanged
        On Error Resume Next
        slab.height = txtSh.Text
        trbY.Minimum = -txtSh.Text / 2 + column.height / 2
        trbY.Maximum = txtSh.Text / 2 - column.height / 2
        Draw()
    End Sub

    Private Sub txtCoffset_TextChanged(sender As Object, e As EventArgs) Handles txtCoffset.TextChanged
        On Error Resume Next
        offset = txtCoffset.Text
        Draw()
    End Sub
End Class
