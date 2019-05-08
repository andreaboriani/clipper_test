<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCw = New System.Windows.Forms.TextBox()
        Me.txtCh = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSh = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSw = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.trbX = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.trbY = New System.Windows.Forms.TrackBar()
        Me.txtCoffset = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPerimeter = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(193, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(639, 530)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Column width"
        '
        'txtCw
        '
        Me.txtCw.Location = New System.Drawing.Point(12, 136)
        Me.txtCw.Name = "txtCw"
        Me.txtCw.Size = New System.Drawing.Size(100, 20)
        Me.txtCw.TabIndex = 3
        Me.txtCw.Text = "30"
        '
        'txtCh
        '
        Me.txtCh.Location = New System.Drawing.Point(12, 189)
        Me.txtCh.Name = "txtCh"
        Me.txtCh.Size = New System.Drawing.Size(100, 20)
        Me.txtCh.TabIndex = 5
        Me.txtCh.Text = "30"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Column height"
        '
        'txtSh
        '
        Me.txtSh.Location = New System.Drawing.Point(12, 76)
        Me.txtSh.Name = "txtSh"
        Me.txtSh.Size = New System.Drawing.Size(100, 20)
        Me.txtSh.TabIndex = 9
        Me.txtSh.Text = "200"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Slab height"
        '
        'txtSw
        '
        Me.txtSw.Location = New System.Drawing.Point(12, 23)
        Me.txtSw.Name = "txtSw"
        Me.txtSw.Size = New System.Drawing.Size(100, 20)
        Me.txtSw.TabIndex = 7
        Me.txtSw.Text = "200"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Slab width"
        '
        'trbX
        '
        Me.trbX.Location = New System.Drawing.Point(12, 308)
        Me.trbX.Maximum = 100
        Me.trbX.Minimum = -100
        Me.trbX.Name = "trbX"
        Me.trbX.Size = New System.Drawing.Size(175, 45)
        Me.trbX.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 281)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Column x position"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 356)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Column y position"
        '
        'trbY
        '
        Me.trbY.Location = New System.Drawing.Point(12, 383)
        Me.trbY.Maximum = 100
        Me.trbY.Minimum = -100
        Me.trbY.Name = "trbY"
        Me.trbY.Size = New System.Drawing.Size(175, 45)
        Me.trbY.TabIndex = 12
        '
        'txtCoffset
        '
        Me.txtCoffset.Location = New System.Drawing.Point(15, 240)
        Me.txtCoffset.Name = "txtCoffset"
        Me.txtCoffset.Size = New System.Drawing.Size(100, 20)
        Me.txtCoffset.TabIndex = 15
        Me.txtCoffset.Text = "50"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Column offset (2x slab thickness)"
        '
        'txtArea
        '
        Me.txtArea.Location = New System.Drawing.Point(12, 447)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(160, 20)
        Me.txtArea.TabIndex = 17
        Me.txtArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 431)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Punching area"
        '
        'txtPerimeter
        '
        Me.txtPerimeter.Location = New System.Drawing.Point(12, 498)
        Me.txtPerimeter.Name = "txtPerimeter"
        Me.txtPerimeter.ReadOnly = True
        Me.txtPerimeter.Size = New System.Drawing.Size(160, 20)
        Me.txtPerimeter.TabIndex = 19
        Me.txtPerimeter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 482)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Punching perimeter"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 533)
        Me.Controls.Add(Me.txtPerimeter)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCoffset)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.trbY)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.trbX)
        Me.Controls.Add(Me.txtSh)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSw)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCw)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmMain"
        Me.Text = "Clipper Test"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCw As TextBox
    Friend WithEvents txtCh As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSh As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSw As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents trbX As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents trbY As TrackBar
    Friend WithEvents txtCoffset As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtArea As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPerimeter As TextBox
    Friend WithEvents Label9 As Label
End Class
