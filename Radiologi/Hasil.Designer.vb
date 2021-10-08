<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Hasil
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Hasil))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnDash = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnHasil = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHasil = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlHasil.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel1.Controls.Add(Me.pnlStats)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.btnDash)
        Me.Panel1.Controls.Add(Me.pictureBox1)
        Me.Panel1.Controls.Add(Me.btnKeluar)
        Me.Panel1.Controls.Add(Me.btnHasil)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1484, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 905)
        Me.Panel1.TabIndex = 0
        '
        'pnlStats
        '
        Me.pnlStats.BackColor = System.Drawing.Color.Orange
        Me.pnlStats.Location = New System.Drawing.Point(222, 235)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Size = New System.Drawing.Size(8, 45)
        Me.pnlStats.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(65, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "RADIOLOGI"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Orange
        Me.Panel5.Location = New System.Drawing.Point(0, 217)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(230, 5)
        Me.Panel5.TabIndex = 7
        '
        'btnDash
        '
        Me.btnDash.Enabled = False
        Me.btnDash.FlatAppearance.BorderSize = 0
        Me.btnDash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue
        Me.btnDash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.btnDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDash.ForeColor = System.Drawing.Color.White
        Me.btnDash.Location = New System.Drawing.Point(0, 235)
        Me.btnDash.Name = "btnDash"
        Me.btnDash.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnDash.Size = New System.Drawing.Size(230, 45)
        Me.btnDash.TabIndex = 9
        Me.btnDash.Text = "Antrian"
        Me.btnDash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDash.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(36, 51)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(163, 154)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 7
        Me.pictureBox1.TabStop = False
        '
        'btnKeluar
        '
        Me.btnKeluar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnKeluar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnKeluar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnKeluar.FlatAppearance.BorderSize = 2
        Me.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeluar.ForeColor = System.Drawing.Color.White
        Me.btnKeluar.Location = New System.Drawing.Point(0, 0)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(230, 45)
        Me.btnKeluar.TabIndex = 4
        Me.btnKeluar.Text = "KEMBALI"
        Me.btnKeluar.UseVisualStyleBackColor = False
        '
        'btnHasil
        '
        Me.btnHasil.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnHasil.FlatAppearance.BorderSize = 0
        Me.btnHasil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue
        Me.btnHasil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.btnHasil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHasil.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHasil.ForeColor = System.Drawing.Color.White
        Me.btnHasil.Location = New System.Drawing.Point(0, 286)
        Me.btnHasil.Name = "btnHasil"
        Me.btnHasil.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnHasil.Size = New System.Drawing.Size(230, 45)
        Me.btnHasil.TabIndex = 3
        Me.btnHasil.Text = "Hasil Pemeriksaan Radiologi"
        Me.btnHasil.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHasil.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1484, 92)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1484, 47)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "HASIL PEMERIKSAAN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1484, 45)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PELAYANAN RADIOLOGI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlHasil
        '
        Me.pnlHasil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlHasil.Controls.Add(Me.GroupBox2)
        Me.pnlHasil.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlHasil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHasil.Location = New System.Drawing.Point(0, 92)
        Me.pnlHasil.Name = "pnlHasil"
        Me.pnlHasil.Size = New System.Drawing.Size(1484, 813)
        Me.pnlHasil.TabIndex = 7
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCari)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox2.Location = New System.Drawing.Point(405, 377)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(671, 55)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter Data"
        '
        'btnCari
        '
        Me.btnCari.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCari.Image = CType(resources.GetObject("btnCari.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(625, 12)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(40, 40)
        Me.btnCari.TabIndex = 5
        Me.btnCari.UseVisualStyleBackColor = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(419, 20)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker2.TabIndex = 4
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(143, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(199, 26)
        Me.DateTimePicker1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(352, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Sampai"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(100, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Dari"
        '
        'Hasil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(1714, 905)
        Me.Controls.Add(Me.pnlHasil)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Hasil"
        Me.Text = "Hasil"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlHasil.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlStats As Panel
    Friend WithEvents btnHasil As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents Label1 As Label
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnDash As Button
    Friend WithEvents pnlHasil As Panel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnCari As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
