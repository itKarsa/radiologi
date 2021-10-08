<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Template
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Template))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtDateReg = New System.Windows.Forms.TextBox()
        Me.txtNoReg = New System.Windows.Forms.TextBox()
        Me.txtKetKlinis = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTglLahir = New System.Windows.Forms.TextBox()
        Me.txtNoRM = New System.Windows.Forms.TextBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDokter1 = New System.Windows.Forms.TextBox()
        Me.txtPemeriksaan = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtUsia = New System.Windows.Forms.TextBox()
        Me.txtNamaPasien = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJam = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSelesai = New System.Windows.Forms.Button()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.txtTemplate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(375, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(537, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 33)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Print"
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(456, 48)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 33)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Isi Hasil"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(131, 54)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(238, 22)
        Me.TextBox1.TabIndex = 3
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 16)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(781, 380)
        Me.WebBrowser1.TabIndex = 4
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nama File"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(462, 84)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 16)
        Me.Label22.TabIndex = 54
        Me.Label22.Text = "Jam"
        '
        'txtDateReg
        '
        Me.txtDateReg.BackColor = System.Drawing.Color.White
        Me.txtDateReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDateReg.Enabled = False
        Me.txtDateReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateReg.Location = New System.Drawing.Point(505, 49)
        Me.txtDateReg.Name = "txtDateReg"
        Me.txtDateReg.Size = New System.Drawing.Size(265, 24)
        Me.txtDateReg.TabIndex = 53
        '
        'txtNoReg
        '
        Me.txtNoReg.BackColor = System.Drawing.Color.White
        Me.txtNoReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoReg.Enabled = False
        Me.txtNoReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoReg.Location = New System.Drawing.Point(505, 19)
        Me.txtNoReg.Name = "txtNoReg"
        Me.txtNoReg.Size = New System.Drawing.Size(265, 24)
        Me.txtNoReg.TabIndex = 50
        '
        'txtKetKlinis
        '
        Me.txtKetKlinis.BackColor = System.Drawing.Color.White
        Me.txtKetKlinis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKetKlinis.Enabled = False
        Me.txtKetKlinis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKetKlinis.Location = New System.Drawing.Point(102, 139)
        Me.txtKetKlinis.Name = "txtKetKlinis"
        Me.txtKetKlinis.Size = New System.Drawing.Size(267, 24)
        Me.txtKetKlinis.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(382, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 16)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Tgl. Permintaan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Ket. Klinis"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(397, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 16)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "No. Reg. Rad"
        '
        'txtTglLahir
        '
        Me.txtTglLahir.BackColor = System.Drawing.Color.White
        Me.txtTglLahir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTglLahir.Enabled = False
        Me.txtTglLahir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTglLahir.Location = New System.Drawing.Point(102, 79)
        Me.txtTglLahir.Name = "txtTglLahir"
        Me.txtTglLahir.Size = New System.Drawing.Size(168, 24)
        Me.txtTglLahir.TabIndex = 48
        '
        'txtNoRM
        '
        Me.txtNoRM.BackColor = System.Drawing.Color.White
        Me.txtNoRM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoRM.Enabled = False
        Me.txtNoRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRM.Location = New System.Drawing.Point(102, 19)
        Me.txtNoRM.Name = "txtNoRM"
        Me.txtNoRM.Size = New System.Drawing.Size(267, 24)
        Me.txtNoRM.TabIndex = 38
        '
        'txtAlamat
        '
        Me.txtAlamat.BackColor = System.Drawing.Color.White
        Me.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(102, 109)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(267, 24)
        Me.txtAlamat.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(37, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "No. RM"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(40, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Alamat"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(400, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 16)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Pemeriksaan"
        '
        'txtDokter1
        '
        Me.txtDokter1.BackColor = System.Drawing.Color.White
        Me.txtDokter1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDokter1.Enabled = False
        Me.txtDokter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDokter1.Location = New System.Drawing.Point(505, 139)
        Me.txtDokter1.Name = "txtDokter1"
        Me.txtDokter1.Size = New System.Drawing.Size(265, 24)
        Me.txtDokter1.TabIndex = 45
        '
        'txtPemeriksaan
        '
        Me.txtPemeriksaan.BackColor = System.Drawing.Color.White
        Me.txtPemeriksaan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPemeriksaan.Enabled = False
        Me.txtPemeriksaan.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPemeriksaan.Location = New System.Drawing.Point(505, 109)
        Me.txtPemeriksaan.Name = "txtPemeriksaan"
        Me.txtPemeriksaan.Size = New System.Drawing.Size(265, 24)
        Me.txtPemeriksaan.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(380, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 16)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "Dokter Pengirim"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(47, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Nama"
        '
        'txtUsia
        '
        Me.txtUsia.BackColor = System.Drawing.Color.White
        Me.txtUsia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsia.Enabled = False
        Me.txtUsia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsia.Location = New System.Drawing.Point(322, 79)
        Me.txtUsia.Name = "txtUsia"
        Me.txtUsia.Size = New System.Drawing.Size(47, 24)
        Me.txtUsia.TabIndex = 43
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.BackColor = System.Drawing.Color.White
        Me.txtNamaPasien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNamaPasien.Enabled = False
        Me.txtNamaPasien.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaPasien.Location = New System.Drawing.Point(102, 49)
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.Size = New System.Drawing.Size(267, 24)
        Me.txtNamaPasien.TabIndex = 41
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(276, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Usia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(23, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Tgl. Lahir"
        '
        'txtJam
        '
        Me.txtJam.BackColor = System.Drawing.Color.White
        Me.txtJam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJam.Enabled = False
        Me.txtJam.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJam.Location = New System.Drawing.Point(505, 79)
        Me.txtJam.Name = "txtJam"
        Me.txtJam.Size = New System.Drawing.Size(265, 24)
        Me.txtJam.TabIndex = 56
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtJam)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNamaPasien)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtUsia)
        Me.GroupBox1.Controls.Add(Me.txtDateReg)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtNoReg)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtKetKlinis)
        Me.GroupBox1.Controls.Add(Me.txtPemeriksaan)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDokter1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTglLahir)
        Me.GroupBox1.Controls.Add(Me.txtAlamat)
        Me.GroupBox1.Controls.Add(Me.txtNoRM)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 179)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Pasien"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(776, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(177, 115)
        Me.PictureBox1.TabIndex = 59
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(959, 18)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(36, 25)
        Me.Button4.TabIndex = 58
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(776, 19)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(177, 23)
        Me.TextBox8.TabIndex = 57
        Me.TextBox8.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSelesai)
        Me.GroupBox2.Controls.Add(Me.btnCari)
        Me.GroupBox2.Controls.Add(Me.txtTemplate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(0, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(787, 95)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Template"
        '
        'btnSelesai
        '
        Me.btnSelesai.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSelesai.ForeColor = System.Drawing.Color.White
        Me.btnSelesai.Location = New System.Drawing.Point(685, 49)
        Me.btnSelesai.Name = "btnSelesai"
        Me.btnSelesai.Size = New System.Drawing.Size(85, 32)
        Me.btnSelesai.TabIndex = 17
        Me.btnSelesai.Text = "Selesai"
        Me.btnSelesai.UseVisualStyleBackColor = False
        '
        'btnCari
        '
        Me.btnCari.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCari.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnCari.FlatAppearance.BorderSize = 2
        Me.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCari.Image = CType(resources.GetObject("btnCari.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(375, 20)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(36, 25)
        Me.btnCari.TabIndex = 16
        Me.btnCari.UseVisualStyleBackColor = False
        '
        'txtTemplate
        '
        Me.txtTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemplate.Location = New System.Drawing.Point(131, 21)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(238, 22)
        Me.txtTemplate.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "File Template"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.InitialDirectory = "C:\Users\IT_SIMRS\Documents\Custom Office Templates"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.WebBrowser1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 274)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(787, 399)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'Template
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(787, 668)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Template"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Template"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label5 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtDateReg As TextBox
    Friend WithEvents txtNoReg As TextBox
    Friend WithEvents txtKetKlinis As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTglLahir As TextBox
    Friend WithEvents txtNoRM As TextBox
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDokter1 As TextBox
    Friend WithEvents txtPemeriksaan As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtUsia As TextBox
    Friend WithEvents txtNamaPasien As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtJam As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnCari As Button
    Friend WithEvents txtTemplate As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnSelesai As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents PictureBox1 As PictureBox
End Class
