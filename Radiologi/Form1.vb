Option Explicit On
Imports System.IO
Imports System.Net.Sockets
Imports Tulpep.NotificationWindow
Imports MySql.Data.MySqlClient
Public Class Form1

    'Dim client As TcpClient
    'Dim Listener As New TcpListener(8080)

    Public Ambil_Data As String
    Public Form_Ambil_Data As String
    Public unit As String
    Public noTindakanRadiologi As String

    Dim ind As String
    Dim idDetail As String

    Dim key As String
    Dim value As String

    Sub warnaStatus()
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2.Rows(i).Cells(4).Value.ToString = "PERMINTAAN" Then
                DataGridView2.CurrentCell = Nothing
            ElseIf DataGridView2.Rows(i).Cells(4).Value.ToString = "DALAM TINDAKAN" Then
                DataGridView2.CurrentCell = Nothing
            ElseIf DataGridView2.Rows(i).Cells(4).Value.ToString = "SELESAI" Then
                DataGridView2.CurrentCell = Nothing
                'DataGridView2.Rows(i).Visible = False
            End If
        Next
    End Sub

    Function totalTarif() As String
        Dim total As Long = 0
        Dim hasil As Long = 0
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            total = total + Val(DataGridView2.Rows(i).Cells(3).Value)
        Next
        hasil = total.ToString("#,##0")
        Return hasil
    End Function

    Sub cariDataPasien()
        conn.Close()
        Dim query As String
        query = "SELECT * 
                   FROM vw_pasienradiologi
                  WHERE noRekamedis Like '%" & txtNoRM.Text & "%'"
        cmd = New MySqlCommand(query, conn)
        da = New MySqlDataAdapter(cmd)

        Dim str As New DataTable
        str.Clear()
        da.Fill(str)

        txtNoReg.Text = ""
        txtNamaPasien.Text = ""
        txtAlamat.Text = ""
        txtTglLahir.Text = ""
        txtNoPermintaan.Text = ""
        txtTglReg.Text = ""
        txtKet.Text = ""
        txtKdUnit.Text = ""
        txtUnitAsal.Text = ""
        txtKdDokter.Text = ""
        txtDokter.Text = ""
        txtDokterPemeriksa.Text = ""
        noTindakanRadiologi = ""

        If str.Rows.Count() > 0 Then
            txtNoReg.Text = str.Rows(0)(1).ToString
            txtNamaPasien.Text = str.Rows(0)(2).ToString
            txtNoPermintaan.Text = str.Rows(0)(5).ToString
            txtTglLahir.Text = str.Rows(0)(6).ToString
            txtAlamat.Text = str.Rows(0)(7).ToString
            txtTglReg.Text = str.Rows(0)(8).ToString
            txtKet.Text = str.Rows(0)(10).ToString
            txtDokter.Text = str.Rows(0)(12).ToString
            txtDokterPemeriksa.Text = str.Rows(0)(14).ToString
            noTindakanRadiologi = str.Rows(0)(15).ToString

            DataGridView1.DataSource = str

            txtKdInstalasi.Text = txtNoPermintaan.Text.Substring(0, 2)
            Select Case txtKdInstalasi.Text
                Case "RJ"
                    txtInstalasi.Text = "RAWAT JALAN"
                Case "RI"
                    txtInstalasi.Text = "RAWAT INAP"
                Case "IGD"
                    txtInstalasi.Text = "IGD"
            End Select

            Call tampilDataSudahDitindakAll()
        Else
            MessageBox.Show("Pasien Tidak Ada / Belum Terdaftar", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Timer5.Start()
        End If
        DataGridView1.ClearSelection()
        DataGridView2.ClearSelection()
        conn.Close()
    End Sub

    Sub tampilDataAll()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT * FROM vw_pasienradiologi
                                    WHERE (tglMasukRadiologiRajal BETWEEN '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' 
                                      AND '" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), "yyyy-MM-dd") & "')
                                      AND (totalTindakanRadiologiRajal IS NOT NULL AND totalTindakanRadiologiRajal != 0)
                                   ORDER BY tglMasukRadiologiRajal DESC", conn)
        'da = New MySqlDataAdapter("SELECT * FROM vw_pasienradiologi
        '                            ORDER BY tglMasukRadiologiRajal DESC", conn)
        ds = New DataSet
        da.Fill(ds, "vw_pasienradiologi")
        DataGridView1.DataSource = ds.Tables("vw_pasienradiologi")
        DataGridView1.ToString.ToUpper()

        Call aturDGV()
        Call warnaStatus()
    End Sub

    Sub tampilDataSudahDitindakAll()

        Dim query As String = ""
        Select Case txtKdInstalasi.Text
            Case "RJ"
                query = "CALL datadetailradrajal('" & noTindakanRadiologi & "')"
            Case "RI"
                query = "CALL datadetailradranap('" & noTindakanRadiologi & "')"
            Case "IGD"
                query = "CALL datadetailradrajal('" & noTindakanRadiologi & "')"
        End Select

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView2.Rows.Clear()

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    Do While dr.Read
                        DataGridView2.Rows.Add(dr.Item("kdTarif"), dr.Item("tindakan"), dr.Item("PPA"),
                                       dr.Item("tarif"), dr.Item("statusTindakan"), dr.Item("tglMulaiLayaniPasien"),
                                       dr.Item("tglSelesaiLayaniPasien"), dr.Item("idTindakanRadiologiRajal"),
                                       dr.Item("noTindakanRadiologiRajal"))
                    Loop
                Case "RI"
                    Do While dr.Read
                        DataGridView2.Rows.Add(dr.Item("kdTarif"), dr.Item("tindakan"), dr.Item("PPA"),
                                       dr.Item("tarif"), dr.Item("statusTindakan"), dr.Item("tglMulaiLayaniPasien"),
                                       dr.Item("tglSelesaiLayaniPasien"), dr.Item("idTindakanRadiologiRanap"),
                                       dr.Item("noTindakanRadiologiRanap"))
                    Loop
                Case "IGD"
                    Do While dr.Read
                        DataGridView2.Rows.Add(dr.Item("kdTarif"), dr.Item("tindakan"), dr.Item("PPA"),
                                       dr.Item("tarif"), dr.Item("statusTindakan"), dr.Item("tglMulaiLayaniPasien"),
                                       dr.Item("tglSelesaiLayaniPasien"), dr.Item("idTindakanRadiologiRajal"),
                                       dr.Item("noTindakanRadiologiRajal"))
                    Loop
            End Select

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub updateRegistrasiRadRajal()
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Call koneksiServer()
        Try
            Dim str As String
            str = "UPDATE t_registrasiradiologirajal 
                   SET tglMulaiLayaniPasien = '" & dt & "', statusRadiologi = 'DALAM TINDAKAN' 
                   WHERE noRegistrasiRadiologiRajal = '" & txtNoPermintaan.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'MessageBox.Show("Update data Registrasi Pemeriksaan Radiologi berhasil dilakukan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateRegistrasiRadRanap()
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Call koneksiServer()
        Try
            Dim str As String
            str = "UPDATE t_registrasiradiologiranap 
                   SET tglMulaiLayaniPasien = '" & dt & "', statusRadiologi = 'DALAM TINDAKAN' 
                   WHERE noRegistrasiRadiologiRanap = '" & txtNoPermintaan.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'MessageBox.Show("Update data Registrasi Pemeriksaan Radiologi berhasil dilakukan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateRegistrasiRadLuar()
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Call koneksiServer()
        Try
            Dim str As String
            str = "UPDATE t_registrasiradiologi 
                   SET tglMulaiLayaniPasien = '" & dt & "', statusRadiologi = 'DALAM TINDAKAN' 
                   WHERE noRegistrasiRadiologi = '" & txtNoPermintaan.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            MessageBox.Show("Update data Registrasi Pemeriksaan Radiologi berhasil dilakukan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateTglTindakan()
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim str As String = ""

        Select Case txtKdInstalasi.Text
            Case "RJ"
                str = "UPDATE t_tindakanradiologirajal
                   SET tglTindakanRadiologiRajal= '" & dt & "'
                   WHERE noTindakanRadiologiRajal = '" & noTindakanRadiologi & "'"
            Case "RI"
                str = "UPDATE t_tindakanradiologiranap 
                   SET tglTindakanRadiologiRanap = '" & dt & "'
                   WHERE noTindakanRadiologiRanap = '" & noTindakanRadiologi & "'"
            Case "3"
            Case "IGD"
                str = "UPDATE t_tindakanradiologirajal
                   SET tglTindakanRadiologiRajal= '" & dt & "'
                   WHERE noTindakanRadiologiRajal = '" & noTindakanRadiologi & "'"
        End Select

        Call koneksiServer()
        Try
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Tindakan Radiologi dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateStatusDetail()
        Dim str As String = ""

        Select Case txtKdInstalasi.Text
            Case "RJ"
                str = "UPDATE t_detailtindakanradiologirajal
                          SET statusTindakan = 'DALAM TINDAKAN' 
                        WHERE idTindakanRadiologiRajal = '" & idDetail & "'"
            Case "RI"
                str = "UPDATE t_detailtindakanradiologiranap
                          SET statusTindakan = 'DALAM TINDAKAN' 
                        WHERE idTindakanRadiologiRanap = '" & idDetail & "'"
            Case "3"
            Case "IGD"
                str = "UPDATE t_detailtindakanradiologirajal
                          SET statusTindakan = 'DALAM TINDAKAN' 
                        WHERE idTindakanRadiologiRajal = '" & idDetail & "'"
        End Select

        Call koneksiServer()
        Try
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Update Dokter Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateTglSelesaiTindakan()
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim str As String = ""

        Select Case txtKdInstalasi.Text
            Case "RJ"
                str = "UPDATE t_registrasiradiologirajal
                          SET tglSelesaiLayaniPasien= '" & dt & "'
                        WHERE noRegistrasiRadiologiRajal = '" & txtNoPermintaan.Text & "'"
            Case "RI"
                str = "UPDATE t_registrasiradiologiranap 
                          SET tglSelesaiLayaniPasien = '" & dt & "'
                        WHERE noRegistrasiRadiologiRanap = '" & txtNoPermintaan.Text & "'"
            Case "3"
            Case "IGD"
                str = "UPDATE t_registrasiradiologirajal
                          SET tglSelesaiLayaniPasien= '" & dt & "'
                        WHERE noRegistrasiRadiologiRajal = '" & txtNoPermintaan.Text & "'"
        End Select

        Call koneksiServer()
        Try
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Update Tanggal Tindakan Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub cekStatusSelesai()
        Dim rowCount As Integer = 0
        rowCount = DataGridView2.Rows.Count

        Dim itemCount As Integer
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2.Rows(i).Cells(4).Value.ToString = "SELESAI" Then
                itemCount = itemCount + 1
            End If
        Next

        'MsgBox("Jumlah tindakan : " & rowCount)
        'MsgBox("Jumlah tindakan yg selesai : " & itemCount)

        If itemCount = rowCount Then
            Call updateStatusRegPermintaan()
            Call tampilDataAll()
            'MsgBox("Update Status")
            'Else
            'MsgBox("Masih ada tindakan yang belum terselesaikan")
        End If
    End Sub

    Sub updateStatusRegPermintaan()
        Dim str As String = ""

        Select Case txtKdInstalasi.Text
            Case "RJ"
                str = "UPDATE t_registrasiradiologirajal
                          SET statusRadiologi = 'SELESAI'
                        WHERE noRegistrasiRadiologiRajal = '" & txtNoPermintaan.Text & "'"
            Case "RI"
                str = "UPDATE t_registrasiradiologiranap 
                          SET statusRadiologi = 'SELESAI'
                        WHERE noRegistrasiRadiologiRanap = '" & txtNoPermintaan.Text & "'"
            Case "3"
            Case "IGD"
                str = "UPDATE t_registrasiradiologirajal
                          SET statusRadiologi = 'SELESAI'
                        WHERE noRegistrasiRadiologiRajal = '" & txtNoPermintaan.Text & "'"
        End Select

        Call koneksiServer()
        Try
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Update Tanggal Tindakan Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Update 'Status Selesai' gagal dilakukan.", MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Private Sub ClickMulai()
        Select Case txtKdInstalasi.Text
            Case "RJ"
                Call updateRegistrasiRadRajal()
                Call updateTglTindakan()
                Call updateStatusDetail()
            Case "RI"
                Call updateRegistrasiRadRanap()
                Call updateTglTindakan()
                Call updateStatusDetail()
                'MsgBox("Tindakan Pemeriksaan dimulai", MsgBoxStyle.Information, "Informasi")
            Case "3"
                Call updateRegistrasiRadLuar()
                Call updateTglTindakan()
                Call updateStatusDetail()
            Case "IGD"
                Call updateRegistrasiRadRajal()
                Call updateTglTindakan()
                Call updateStatusDetail()
                'MsgBox("Tindakan Pemeriksaan dimulai", MsgBoxStyle.Information, "Informasi")
        End Select
        'Try
        '    client = New TcpClient(txtIpAddres2.Text, 8000)     'IP tujuan
        '    Dim writer As New StreamWriter(client.GetStream())
        '    writer.Write(txtIpAddress.Text)                     'IP pengirim
        '    writer.Flush()
        '    'ListBox1.Items.Add("Me:- " + TextBox1.Text)
        '    'TextBox1.Clear()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'DataGridView2.Columns.Clear()

        Call tampilDataAll()
        Call tampilDataSudahDitindakAll()
        Call warnaStatus()
    End Sub

    Private Sub ClickSelesai(id As String)
        Dim str As String = ""

        Select Case txtKdInstalasi.Text
            Case "RJ"
                str = "UPDATE t_detailtindakanradiologirajal 
                          SET statusTindakan = 'SELESAI'
                        WHERE idTindakanRadiologiRajal = '" & id & "'"
            Case "RI"
                str = "UPDATE t_detailtindakanradiologiranap 
                          SET statusTindakan = 'SELESAI'
                        WHERE idTindakanRadiologiRanap = '" & id & "'"
            Case "3"
                str = "UPDATE t_detailtindakanradiologi
                          SET statusTindakan = 'SELESAI'
                        WHERE idTindakanRadiologi = '" & id & "'"
            Case "IGD"
                str = "UPDATE t_detailtindakanradiologirajal 
                          SET statusTindakan = 'SELESAI'
                        WHERE idTindakanRadiologiRajal = '" & id & "'"
        End Select

        Call koneksiServer()
        Try
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'MsgBox("Pemeriksaan Radiologi selesai dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, "Error", MessageBoxIcon.Error)
        End Try

        Call updateTglSelesaiTindakan()

        'DataGridView2.Columns.Clear()

        Call tampilDataAll()
        Call tampilDataSudahDitindakAll()
        Call warnaStatus()

        conn.Close()

        'Hasil.Ambil_Data = True
        'Hasil.Form_Ambil_Data = "Hasil"
        'Hasil.Show()
    End Sub

    Private Sub ClickHasil()
        'Hasil.Ambil_Data = True
        'Hasil.Form_Ambil_Data = "Hasil"
        'Hasil.Show()
    End Sub

    Private Sub Populate(kode As String, tindakan As String, dokter As String, tarif As String)
        Dim row As String() = New String() {kode, tindakan, dokter, tarif}

        DataGridView2.Rows.Add(row)
    End Sub

    Sub aturDGV()
        Try
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns(3).Width = 150
            DataGridView1.Columns(4).Width = 120
            DataGridView1.Columns(5).Width = 150
            DataGridView1.Columns(6).Width = 150
            DataGridView1.Columns(7).Width = 250
            DataGridView1.Columns(8).Width = 160
            DataGridView1.Columns(9).Width = 170
            DataGridView1.Columns(10).Width = 170
            DataGridView1.Columns(11).Width = 100
            DataGridView1.Columns(12).Width = 300
            DataGridView1.Columns(13).Width = 100
            DataGridView1.Columns(14).Width = 250
            DataGridView1.Columns(15).Width = 100
            DataGridView1.Columns(16).Width = 100
            DataGridView1.Columns(17).Width = 130
            DataGridView1.Columns(18).Width = 70
            DataGridView1.Columns(0).HeaderText = "No.RM"
            DataGridView1.Columns(1).HeaderText = "No.Daftar"
            DataGridView1.Columns(2).HeaderText = "Nama Pasien"
            DataGridView1.Columns(3).HeaderText = "KD.Unit Asal"
            DataGridView1.Columns(4).HeaderText = "Asal Ruang/Poli"
            DataGridView1.Columns(5).HeaderText = "No.Permintaan"
            DataGridView1.Columns(6).HeaderText = "Tgl.Lahir"
            DataGridView1.Columns(7).HeaderText = "Alamat"
            DataGridView1.Columns(8).HeaderText = "Tgl.Permintaan"
            DataGridView1.Columns(9).HeaderText = "Status Tindakan"
            DataGridView1.Columns(10).HeaderText = "Ket.Klinis"
            DataGridView1.Columns(11).HeaderText = "KD.Dokter"
            DataGridView1.Columns(12).HeaderText = "Dokter Pengirim"
            DataGridView1.Columns(13).HeaderText = "KD.Dokter"
            DataGridView1.Columns(14).HeaderText = "Dokter Radiologi"
            DataGridView1.Columns(15).HeaderText = "No.Tindakan"
            DataGridView1.Columns(16).HeaderText = "Total Biaya"
            DataGridView1.Columns(17).HeaderText = "Pembayaran"
            DataGridView1.Columns(18).HeaderText = "Penjamin"

            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.Columns(11).Visible = False
            DataGridView1.Columns(13).Visible = False
            DataGridView1.Columns(14).Visible = False
            DataGridView1.Columns(15).Visible = False
            DataGridView1.Columns(16).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Sub dgv2()
        Try
            DataGridView2.Columns(0).Width = 150
            DataGridView2.Columns(1).Width = 250
            DataGridView2.Columns(2).Width = 250
            DataGridView2.Columns(3).Width = 200
            DataGridView2.Columns(4).Width = 200
            DataGridView2.Columns(0).HeaderText = "Kode"
            DataGridView2.Columns(1).HeaderText = "Jenis Pemeriksaan"
            DataGridView2.Columns(2).HeaderText = "Dokter Pemeriksa"
            DataGridView2.Columns(3).HeaderText = "Tarif Tindakan"
            DataGridView2.Columns(4).HeaderText = "Status"
            DataGridView2.Columns(5).HeaderText = "Waktu Mulai"
            DataGridView2.Columns(6).HeaderText = "Waktu Selesai"
            DataGridView2.Columns(7).HeaderText = "ID"

            Dim btn As New DataGridViewButtonColumn()
            DataGridView2.Columns.Add(btn)
            btn.HeaderText = "Proses"
            btn.Text = ">>>"
            btn.Name = "btn"
            btn.Width = 120
            btn.FlatStyle = FlatStyle.Flat
            btn.UseColumnTextForButtonValue = True


        Catch ex As Exception

        End Try
    End Sub

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnHasil.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Listener.Stop()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer3.Start()
        'Listener.Start()

        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.Manual
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        Dim pcname As String
        Dim ipadd As String = ""
        pcname = System.Net.Dns.GetHostName

        Dim objAddressList() As System.Net.IPAddress =
            System.Net.Dns.GetHostEntry("").AddressList
        For i = 0 To objAddressList.GetUpperBound(0)
            If objAddressList(i).AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                ipadd = objAddressList(i).ToString
                txtIpAddress.Text = objAddressList(i).ToString
                Exit For
            End If
        Next

        txtHostname.Text = "PC Name : " & pcname & " | IP Address : " & ipadd

        Call tampilDataAll()
        Call aturDGV()
        Call warnaStatus()
        'Call isiComboUnit()
        'Call tampilData()

        btnHasil.Enabled = False

        btnDash.BackColor = Color.DodgerBlue

    End Sub
    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        pnlStats.Height = btnDash.Height
        pnlStats.Top = btnDash.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnHasil_Click(sender As Object, e As EventArgs) Handles btnHasil.Click
        Dim fhasil As New Hasil

        pnlStats.Height = btnHasil.Height
        pnlStats.Top = btnHasil.Top

        'Dim btn As Button = CType(sender, Button)
        'setColor(btn)

        'Hasil.Ambil_Data = True
        'Hasil.Form_Ambil_Data = "Hasil"
        'Hasil.Show()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dim konfirmasi As MsgBoxResult

        konfirmasi = MsgBox("Apakah anda yakin ingin keluar..?", vbQuestion + vbYesNo, "EXIT")
        If konfirmasi = vbYes Then
            Me.Close()
            LoginForm.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim noRm, noReg, namaPasien, alamat, usia, notindakan, ket, dokter1, dokter2, noPermin, tglReg As String

        If e.RowIndex = -1 Then
            Return
        End If

        noRm = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        noReg = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        namaPasien = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        unit = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        noPermin = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
        usia = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
        alamat = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
        tglReg = DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
        ket = DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
        dokter1 = DataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
        dokter2 = DataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString
        noTindakanRadiologi = DataGridView1.Rows(e.RowIndex).Cells(15).Value.ToString

        txtNoRM.Text = noRm
        txtNoReg.Text = noReg
        txtNamaPasien.Text = namaPasien
        txtAlamat.Text = alamat
        txtNoPermintaan.Text = noPermin
        txtTglReg.Text = tglReg
        txtTglLahir.Text = usia
        txtKet.Text = ket
        txtDokter.Text = dokter1
        txtDokterPemeriksa.Text = dokter2
        txtNoTindakan.Text = noTindakanRadiologi

        txtKdInstalasi.Text = txtNoPermintaan.Text.Substring(0, 2)

        Select Case txtKdInstalasi.Text
            Case "RJ"
                txtInstalasi.Text = "RAWAT JALAN"
            Case "RI"
                txtInstalasi.Text = "RAWAT INAP"
            Case "IGD"
                txtInstalasi.Text = "IGD"
        End Select

        GroupBox2.Visible = True
        'DataGridView2.Columns.Clear()

        Call tampilDataSudahDitindakAll()
        Call warnaStatus()
        Call totalTarif()
        'Timer4.Start()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim noRm, noReg, namaPasien, alamat, usia, notindakan, ket, dokter1, dokter2, noPermin, tglReg As String

        If e.RowIndex = -1 Then
            Return
        End If

        noRm = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        noReg = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        namaPasien = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        unit = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        noPermin = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
        usia = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
        alamat = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
        tglReg = DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
        ket = DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
        dokter1 = DataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
        dokter2 = DataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString
        noTindakanRadiologi = DataGridView1.Rows(e.RowIndex).Cells(15).Value.ToString

        txtNoRM.Text = noRm
        txtNoReg.Text = noReg
        txtNamaPasien.Text = namaPasien
        txtAlamat.Text = alamat
        txtNoPermintaan.Text = noPermin
        txtTglReg.Text = tglReg
        txtTglLahir.Text = usia
        txtKet.Text = ket
        txtDokter.Text = dokter1
        txtDokterPemeriksa.Text = dokter2
        txtNoTindakan.Text = noTindakanRadiologi

        txtKdInstalasi.Text = txtNoPermintaan.Text.Substring(0, 2)

        Select Case txtKdInstalasi.Text
            Case "RJ"
                txtInstalasi.Text = "RAWAT JALAN"
            Case "RI"
                txtInstalasi.Text = "RAWAT INAP"
            Case "IGD"
                txtInstalasi.Text = "IGD"
        End Select

        GroupBox2.Visible = True
        'DataGridView2.Columns.Clear()

        Call tampilDataSudahDitindakAll()
        Call warnaStatus()
        Call totalTarif()
        'Timer4.Start()
    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        Dim noRm, noReg, namaPasien, alamat, usia, notindakan, ket, dokter1, dokter2, noPermin, tglReg As String

        If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) And DataGridView1.CurrentCell.RowIndex >= 0 Then
            e.Handled = True
            e.SuppressKeyPress = True

            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex)

            If DataGridView1.CurrentCell.RowIndex = -1 Then
                Return
            End If

            noRm = row.Cells(0).Value
            noReg = row.Cells(1).Value.ToString
            namaPasien = row.Cells(2).Value.ToString
            unit = row.Cells(4).Value.ToString
            noPermin = row.Cells(5).Value.ToString
            usia = row.Cells(6).Value.ToString
            alamat = row.Cells(7).Value.ToString
            tglReg = row.Cells(8).Value.ToString
            ket = row.Cells(10).Value.ToString
            dokter1 = row.Cells(12).Value.ToString
            dokter2 = row.Cells(14).Value.ToString
            noTindakanRadiologi = row.Cells(15).Value.ToString

            txtNoRM.Text = noRm
            txtNoReg.Text = noReg
            txtNamaPasien.Text = namaPasien
            txtAlamat.Text = alamat
            txtNoPermintaan.Text = noPermin
            txtTglReg.Text = tglReg
            txtTglLahir.Text = usia
            txtKet.Text = ket
            txtDokter.Text = dokter1
            txtDokterPemeriksa.Text = dokter2
            txtNoTindakan.Text = noTindakanRadiologi

            txtKdInstalasi.Text = txtNoPermintaan.Text.Substring(0, 2)

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    txtInstalasi.Text = "RAWAT JALAN"
                Case "RI"
                    txtInstalasi.Text = "RAWAT INAP"
                Case "IGD"
                    txtInstalasi.Text = "IGD"
            End Select

            GroupBox2.Visible = True
            'DataGridView2.Columns.Clear()

            Call tampilDataSudahDitindakAll()
            Call warnaStatus()
            Call totalTarif()
            'Timer4.Start()
        End If

    End Sub

    Private Sub txtTglLahir_TextChanged(sender As Object, e As EventArgs) Handles txtTglLahir.TextChanged

        If txtTglLahir.Text = "" Then
            txtUsia.Text = ""
        Else
            Dim lahir As Date = txtTglLahir.Text
            txtUsia.Text = hitungUmur(lahir)
        End If
    End Sub

    Private Sub DataGridView2_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString = "PERMINTAAN" Then
            btnHasil.Enabled = False
        ElseIf DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString = "DALAM TINDAKAN" Or DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString = "SELESAI" Then
            'btnHasil.Enabled = True
        Else
            btnHasil.Enabled = False
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If txtNoRM.Text = "" Then
            MessageBox.Show("Masukkan No.RM Pasien", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Call cariDataPasien()
        End If
    End Sub

    Private Sub txtNoRM_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoRM.KeyDown
        If e.KeyCode = Keys.Enter And txtNoRM.Text = "" Then
            MessageBox.Show("Masukkan No.RM Pasien", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf e.KeyCode = Keys.Enter Then
            Call cariDataPasien()
        End If
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        'Tambah_Pasien.Ambil_Data = True
        'Tambah_Pasien.Form_Ambil_Data = "TambahPasien"
        'Tambah_Pasien.ShowDialog()

        Dim jenisPasienFrm As New JenisPasien
        jenisPasienFrm.ShowDialog()
    End Sub

    Private Sub txtKet_TextChanged(sender As Object, e As EventArgs) Handles txtKet.TextChanged
        'btnTindakan.Enabled = True
    End Sub

    Private Sub txtNoRM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoRM.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtJamDigi.Text = TimeOfDay
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        txtTglDigi.Text = Format(Now, “dd/MM/yyyy”)
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim Message As String
        'Dim nStart As Integer
        'Dim nLast As Integer

        'If Listener.Pending = True Then
        '    Message = ""
        '    client = Listener.AcceptTcpClient()
        '    Dim Reader As New StreamReader(client.GetStream())

        '    While Reader.Peek > -1
        '        Message &= Convert.ToChar(Reader.Read()).ToString
        '    End While

        'If Message.Contains("</>") Then
        '    nStart = InStr(Message, "</>") + 4
        '    nLast = InStr(Message, "<\>")
        '    Message = Mid(Message, nStart, nLast - nStart)
        'End If

        'ListBox1.Items.Add("Friend:- " + Message)
        'txtIpAddres2.Text = Message
        '    notif()
        'End If
    End Sub
    Sub notif()
        Dim objPopup As New PopupNotifier
        objPopup.Image = My.Resources.popup_info
        objPopup.ImagePadding = New Padding(7, 13, 5, 10)

        objPopup.HeaderColor = Color.Green
        objPopup.AnimationDuration = 1000
        objPopup.Delay = 10000
        objPopup.TitleFont = New Font("Arial", 18, FontStyle.Bold)
        objPopup.TitleColor = Color.Navy
        objPopup.TitleText = "Notification Alert"

        objPopup.ContentPadding = New Padding(5)
        objPopup.ContentFont = New Font("Arial", 12, FontStyle.Italic)
        objPopup.ContentText = "You get a message from Rawat Inap"
        objPopup.ContentColor = Color.Red
        objPopup.Popup()

        AddHandler objPopup.Click, AddressOf clickHandler
        AddHandler objPopup.Close, AddressOf closekHandler
    End Sub

    Private Sub closekHandler(sender As Object, e As EventArgs)
        MessageBox.Show("Close", "Message")
    End Sub

    Private Sub clickHandler(sender As Object, e As EventArgs)
        MessageBox.Show("Clicked", "Message")
        Call tampilDataAll()
    End Sub

    Private Sub btnRiwayat_Click(sender As Object, e As EventArgs) Handles btnRiwayat.Click
        pnlStats.Height = btnRiwayat.Height
        pnlStats.Top = btnRiwayat.Top

        RiwayatPasien.Ambil_Data = True
        RiwayatPasien.Form_Ambil_Data = "Riwayat"
        RiwayatPasien.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim konfirmasi As MsgBoxResult
        Dim tindakan As String
        idDetail = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString
        tindakan = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString

        If e.ColumnIndex = 9 Then
            Select Case DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                Case "PERMINTAAN"
                    konfirmasi = MsgBox("Apakah tindakan '" & tindakan & "' akan dimulai ?", vbQuestion + vbYesNo, "Laboratorium")
                    If konfirmasi = vbYes Then
                        Call ClickMulai()
                        'MsgBox(tindakan & " - Memulai tindakan", MsgBoxStyle.Information)
                    End If
                Case "DALAM TINDAKAN"
                    konfirmasi = MsgBox("Apakah tindakan '" & tindakan & "' sudah selesai ?", vbQuestion + vbYesNo, "Laboratorium")
                    If konfirmasi = vbYes Then
                        Call ClickSelesai(idDetail)
                        Call cekStatusSelesai()
                        'MsgBox(tindakan & " - Selesai", MsgBoxStyle.Information)
                    End If
                Case "SELESAI"
                    MsgBox("Jika hasil pemeriksaan selesai dan pembayaran 'LUNAS', maka pasien dapat segera dihubungi")
                    'konfirmasi = MsgBox("Apakah pembayaran '" & tindakan & "' sudah lunas ?", vbQuestion + vbYesNo)
                    'If konfirmasi = vbYes Then
                    '    MsgBox(tindakan & " - LUNAS", MsgBoxStyle.Information)
                    '    'Call ClickHasil()
                    'End If
            End Select
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        'Dim rowCount As Integer = 0
        'rowCount = DataGridView2.Rows.Count

        'Dim itemCount As Integer
        'For i As Integer = 0 To DataGridView2.Rows.Count - 1
        '    If DataGridView2.Rows(i).Cells(4).Value.ToString = "SELESAI" Then
        '        itemCount = itemCount + 1
        '    End If
        'Next

        ''MsgBox("Jumlah tindakan yg selesai : " & itemCount)

        'If itemCount = rowCount Then
        '    Call updateStatusRegPermintaan()
        '    'MsgBox("Update Status")
        '    Timer4.Stop()
        '    Call tampilDataAll()
        'Else
        '    'MsgBox("Masih ada tindakan yang belum terselesaikan")
        'End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Call tampilDataAll()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        DataGridView1.ColumnHeadersHeight = 40
        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.ForeColor = Color.Black
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.PaleTurquoise
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.EnableHeadersVisualStyles = False

        DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(9).Value.ToString = "PERMINTAAN" Then
                DataGridView1.Rows(i).Cells(9).Style.BackColor = Color.Orange
                DataGridView1.Rows(i).Cells(9).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(i).Cells(9).Value.ToString = "DALAM TINDAKAN" Then
                DataGridView1.Rows(i).Cells(9).Style.BackColor = Color.Green
                DataGridView1.Rows(i).Cells(9).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(i).Cells(9).Value.ToString = "SELESAI" Then
                DataGridView1.Rows(i).Cells(9).Style.BackColor = Color.Red
                DataGridView1.Rows(i).Cells(9).Style.ForeColor = Color.White
                'DataGridView1.Rows(i).Visible = False
            End If
        Next

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(17).Value.ToString = "BELUM LUNAS" Then
                DataGridView1.Rows(i).Cells(17).Style.BackColor = Color.Orange
                DataGridView1.Rows(i).Cells(17).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(i).Cells(17).Value.ToString = "LUNAS" Then
                DataGridView1.Rows(i).Cells(17).Style.BackColor = Color.Green
                DataGridView1.Rows(i).Cells(17).Style.ForeColor = Color.White
            End If
        Next

    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue
        DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        DataGridView2.ColumnHeadersHeight = 40
        DataGridView2.DefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        DataGridView2.DefaultCellStyle.ForeColor = Color.Black
        DataGridView2.DefaultCellStyle.SelectionBackColor = Color.PaleTurquoise
        DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView2.RowHeadersVisible = False
        DataGridView2.AllowUserToResizeRows = False
        DataGridView2.EnableHeadersVisualStyles = False

        DataGridView2.Columns(3).DefaultCellStyle.Format = "###,###,###"
        DataGridView2.Columns(5).DefaultCellStyle.Format = "HH:mm"
        DataGridView2.Columns(6).DefaultCellStyle.Format = "HH:mm"

        DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView2.Columns(5).Visible = False
        DataGridView2.Columns(6).Visible = False
        DataGridView2.Columns(7).Visible = False

        For j As Integer = 0 To DataGridView2.RowCount - 1
            If DataGridView2.Rows(j).Cells(4).Value.ToString = "PERMINTAAN" Then
                DataGridView2.Rows(j).Cells(4).Style.BackColor = Color.Orange
                DataGridView2.Rows(j).Cells(4).Style.ForeColor = Color.White
            ElseIf DataGridView2.Rows(j).Cells(4).Value.ToString = "DALAM TINDAKAN" Then
                DataGridView2.Rows(j).Cells(4).Style.BackColor = Color.Green
                DataGridView2.Rows(j).Cells(4).Style.ForeColor = Color.White
            ElseIf DataGridView2.Rows(j).Cells(4).Value.ToString = "SELESAI" Then
                DataGridView2.Rows(j).Cells(4).Style.BackColor = Color.Red
                DataGridView2.Rows(j).Cells(4).Style.ForeColor = Color.White
                'DataGridView2.Rows(i).Visible = False
            End If
        Next

        For i As Integer = 0 To DataGridView2.RowCount - 1
            DataGridView2.Rows(i).Cells(9).Style.BackColor = Color.DodgerBlue
            DataGridView2.Rows(i).Cells(9).Style.ForeColor = Color.White
        Next

        For k As Integer = 0 To DataGridView2.RowCount - 1
            If k Mod 2 = 0 Then
                DataGridView2.Rows(k).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView2.Rows(k).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next

        For Each column As DataGridViewColumn In DataGridView2.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Select Case txtKdInstalasi.Text
            Case "RJ"
                CetakBukti.Ambil_Data = True
                CetakBukti.Form_Ambil_Data = "Cetak"
                CetakBukti.Show()
            Case "RI"
                CetakBukti.Ambil_Data = True
                CetakBukti.Form_Ambil_Data = "Cetak"
                CetakBukti.Show()
            Case "IGD"
                CetakBukti.Ambil_Data = True
                CetakBukti.Form_Ambil_Data = "Cetak"
                CetakBukti.Show()
        End Select
    End Sub

    Private Sub btnCari_MouseLeave(sender As Object, e As EventArgs) Handles btnCari.MouseLeave
        Me.btnCari.BackColor = Color.DodgerBlue
    End Sub

    Private Sub btnCari_MouseEnter(sender As Object, e As EventArgs) Handles btnCari.MouseEnter
        Me.btnCari.BackColor = Color.FromArgb(30, 100, 255)
    End Sub

    Private Sub btnCetak_MouseLeave(sender As Object, e As EventArgs) Handles btnCetak.MouseLeave
        Me.btnCetak.BackColor = Color.DodgerBlue
    End Sub

    Private Sub btnCetak_MouseEnter(sender As Object, e As EventArgs) Handles btnCetak.MouseEnter
        Me.btnCetak.BackColor = Color.FromArgb(30, 100, 255)
    End Sub

    Private Sub btnRefresh_MouseLeave(sender As Object, e As EventArgs) Handles btnRefresh.MouseLeave
        Me.btnRefresh.BackColor = Color.DodgerBlue
    End Sub

    Private Sub btnRefresh_MouseEnter(sender As Object, e As EventArgs) Handles btnRefresh.MouseEnter
        Me.btnRefresh.BackColor = Color.FromArgb(30, 100, 255)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Timer5.Start()
        Call tampilDataAll()
    End Sub

    Private Sub DataGridView1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridView1.Rows(e.RowIndex).Selected = True
            ind = e.RowIndex
            DataGridView1.CurrentCell = DataGridView1.Rows(e.RowIndex).Cells(2)
            ContextMenuStrip1.Show(DataGridView1, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Click
        If Not DataGridView1.Rows(ind).IsNewRow Then
            Dim konfirmasi As MsgBoxResult
            konfirmasi = MsgBox("Apakah anda yakin ingin menghapus antrian tsb ?", vbQuestion + vbYesNo, "Konfirmasi")
            If konfirmasi = vbYes Then
                'MsgBox("Batal : " & DataGridView1.Rows(ind).Cells(5).Value.ToString)
                Call deletePermintaan(DataGridView1.Rows(ind).Cells(5).Value.ToString)
                Call deleteTindakan(DataGridView1.Rows(ind).Cells(15).Value.ToString)
                Call deleteAllDetail(DataGridView1.Rows(ind).Cells(15).Value.ToString)
                Call tampilDataAll()
                Call warnaStatus()
            End If
        End If
    End Sub

    Sub deletePermintaan(noDel As String)
        Try
            Call koneksiServer()
            Dim query As String = ""

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    query = "DELETE FROM t_registrasiradiologirajal WHERE noRegistrasiRadiologiRajal= '" & noDel & "'"
                Case "RI"
                    query = "DELETE FROM t_registrasiradiologiranap WHERE noRegistrasiRadiologiRanap= '" & noDel & "'"
                Case "IGD"
                    query = "DELETE FROM t_registrasiradiologirajal WHERE noRegistrasiRadiologiRajal= '" & noDel & "'"
            End Select

            cmd = New MySqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("Batal antrian berhasil", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Delete Antrian")
        End Try
    End Sub

    Sub deleteTindakan(noDel As String)
        Try
            Call koneksiServer()
            Dim query As String = ""

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    query = "DELETE FROM t_tindakanradiologirajal WHERE noTindakanRadiologiRajal= '" & noDel & "'"
                Case "RI"
                    query = "DELETE FROM t_tindakanradiologiranap WHERE noTindakanRadiologiRanap= '" & noDel & "'"
                Case "IGD"
                    query = "DELETE FROM t_tindakanradiologirajal WHERE noTindakanRadiologiRajal= '" & noDel & "'"
            End Select

            cmd = New MySqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            'MsgBox("Batal tindakan berhasil", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Delete Tindakan")
        End Try
    End Sub

    Sub deleteAllDetail(noDel As String)
        Try
            Call koneksiServer()
            Dim query As String = ""

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    query = "DELETE FROM t_detailtindakanradiologirajal WHERE noTindakanRadiologiRajal= '" & noDel & "'"
                Case "RI"
                    query = "DELETE FROM t_detailtindakanradiologiranap WHERE noTindakanRadiologiRanap= '" & noDel & "'"
                Case "IGD"
                    query = "DELETE FROM t_detailtindakanradiologirajal WHERE noTindakanRadiologiRajal= '" & noDel & "'"
            End Select

            cmd = New MySqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            'MsgBox("Batal detail berhasil", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Delete Detail")
        End Try
    End Sub

    Private Sub DataGridView2_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridView2.Rows(e.RowIndex).Selected = True
            ind = e.RowIndex
            DataGridView2.CurrentCell = DataGridView2.Rows(e.RowIndex).Cells(1)
            ContextMenuStrip2.Show(DataGridView2, e.Location)
            ContextMenuStrip2.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ContextMenuStrip2_Click(sender As Object, e As EventArgs) Handles ContextMenuStrip2.Click
        If Not DataGridView2.Rows(ind).IsNewRow Then
            Dim konfirmasi As MsgBoxResult
            Dim tarif, noTindakan As String
            tarif = DataGridView2.Rows(ind).Cells(3).Value.ToString
            noTindakan = DataGridView2.Rows(ind).Cells(8).Value.ToString
            konfirmasi = MsgBox("Apakah anda yakin ingin menghapus tindakan tsb ?", vbQuestion + vbYesNo, "Konfirmasi")
            If konfirmasi = vbYes Then
                'MsgBox("Batal : " & DataGridView2.Rows(ind).Cells(7).Value.ToString)
                Call deleteDetail(DataGridView2.Rows(ind).Cells(7).Value.ToString)
                Call updateAfterDelete(noTindakan, tarif)
                Call tampilDataSudahDitindakAll()
            End If
        End If
    End Sub

    Sub deleteDetail(idDel As String)
        Try
            Call koneksiServer()
            Dim query As String = ""

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    query = "DELETE FROM t_detailtindakanradiologirajal WHERE idTindakanRadiologiRajal= '" & idDel & "'"
                Case "RI"
                    query = "DELETE FROM t_detailtindakanradiologiranap WHERE idTindakanRadiologiRanap= '" & idDel & "'"
                Case "IGD"
                    query = "DELETE FROM t_detailtindakanradiologirajal WHERE idTindakanRadiologiRajal= '" & idDel & "'"
            End Select

            cmd = New MySqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("Hapus tindakan berhasil", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Delete")
        End Try
    End Sub

    Sub updateAfterDelete(noTindakanDel As String, tarif As String)
        Dim total As Integer
        total = Val(totalTarif() - tarif)
        Try
            Call koneksiServer()
            Dim str As String = ""

            Select Case txtKdInstalasi.Text
                Case "RJ"
                    str = "UPDATE t_tindakanradiologirajal
                              SET totalTindakanRadiologiRajal = '" & total & "'
                            WHERE noTindakanRadiologiRajal = '" & noTindakanDel & "'"
                Case "RI"
                    str = "UPDATE t_tindakanradiologiranap
                              SET totalTindakanRadiologiRanap = '" & total & "'
                            WHERE noTindakanRadiologiRanap = '" & noTindakanDel & "'"
                Case "IGD"
                    str = "UPDATE t_tindakanradiologirajal
                              SET totalTindakanRadiologiRajal = '" & total & "'
                            WHERE noTindakanRadiologiRajal = '" & noTindakanDel & "'"
            End Select

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Update dokter berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Update data gagal dilakukan.", MessageBoxIcon.Error, "Error Update After Delete")
        End Try

        conn.Close()
    End Sub

    Private Sub btnFilterTgl_Click(sender As Object, e As EventArgs) Handles btnFilterTgl.Click
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT * FROM vw_pasienradiologi
                                    WHERE (tglMasukRadiologiRajal BETWEEN '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "' 
                                      AND '" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker3.Value), "yyyy-MM-dd") & "')
                                      AND (totalTindakanRadiologiRajal IS NOT NULL AND totalTindakanRadiologiRajal != 0)
                                   ORDER BY tglMasukRadiologiRajal DESC", conn)
        'da = New MySqlDataAdapter("SELECT * FROM vw_pasienradiologi
        '                            ORDER BY tglMasukRadiologiRajal DESC", conn)
        ds = New DataSet
        da.Fill(ds, "vw_pasienradiologi")
        DataGridView1.DataSource = ds.Tables("vw_pasienradiologi")
        DataGridView1.ToString.ToUpper()

        Call aturDGV()
        Call warnaStatus()
    End Sub
End Class
