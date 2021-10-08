Imports MySql.Data.MySqlClient
Public Class Tindakan

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnTindakan.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub tampilData()
        Call koneksiServer()
        da = New MySqlDataAdapter("CALL tampilTindakanRad('" & txtKelas.Text & "')", conn)
        ds = New DataSet
        da.Fill(ds, "vw_tindakanrad")
        BunifuDgv1.DataSource = ds.Tables("vw_tindakanrad")
        conn.Close()
    End Sub

    Sub aturDGV()
        Try
            BunifuDgv1.Columns(0).Width = 70
            BunifuDgv1.Columns(1).Width = 300
            BunifuDgv1.Columns(2).Width = 130
            BunifuDgv1.Columns(0).HeaderText = "KODE"
            BunifuDgv1.Columns(1).HeaderText = "TINDAKAN"
            BunifuDgv1.Columns(2).HeaderText = "TARIF"
            BunifuDgv1.Columns(2).DefaultCellStyle.Format = "###,###,###"
            BunifuDgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            BunifuDgv1.DefaultCellStyle.ForeColor = Color.Black
            BunifuDgv1.DefaultCellStyle.SelectionForeColor = Color.Black

            dgv2.DefaultCellStyle.ForeColor = Color.Black
            dgv2.DefaultCellStyle.SelectionForeColor = Color.Black

            For i = 0 To BunifuDgv1.RowCount - 1
                If i Mod 2 = 0 Then
                    BunifuDgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    BunifuDgv1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                End If
            Next

            For i = 0 To dgv2.RowCount - 1
                If i Mod 2 = 0 Then
                    dgv2.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    dgv2.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Sub autoNoTindakanRanap()
        Dim noTindakanRad As String

        Try
            Call koneksiServer()
            Dim query As String
            query = "SELECT SUBSTR(noTindakanRadiologiRanap,18,4) FROM t_tindakanradiologiranap ORDER BY CAST(SUBSTR(noTindakanRadiologiRanap,18,4) AS UNSIGNED) DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noTindakanRad = "TRAD" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoTindakan.Text = noTindakanRad
            Else
                noTindakanRad = "TRAD" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoTindakan.Text = noTindakanRad
            End If
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub autoNoTindakanRajal()
        Dim noTindakanRad As String

        Try
            Call koneksiServer()
            Dim query As String
            query = "SELECT SUBSTR(noTindakanRadiologiRajal,18,4) FROM t_tindakanradiologirajal ORDER BY CAST(SUBSTR(noTindakanRadiologiRajal,18,4) AS UNSIGNED) DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noTindakanRad = "TRAD" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoTindakan.Text = noTindakanRad
            Else
                noTindakanRad = "TRAD" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoTindakan.Text = noTindakanRad
            End If
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub autoNoTindakanLuar()
        Dim noTindakanRad As String

        Try
            Call koneksiServer()
            Dim query As String
            query = "SELECT SUBSTR(noTindakanRadiologi,18,4) FROM t_tindakanradiologi ORDER BY CAST(SUBSTR(noTindakanRadiologi,18,4) AS UNSIGNED) DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noTindakanRad = "TRAD" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoTindakan.Text = noTindakanRad
            Else
                noTindakanRad = "TRAD" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoTindakan.Text = noTindakanRad
            End If
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub transferSelected()
        Call koneksiServer()
        Dim dt As New DataTable
        Dim dr As New System.Windows.Forms.DataGridViewRow

        Dim R As DataRow = dt.NewRow

        For Each dr In Me.BunifuDgv1.SelectedRows
            dgv2.Rows.Add(1)
            dgv2.Rows(dgv2.RowCount - 1).Cells(0).Value = txtNoPermintaan.Text
            dgv2.Rows(dgv2.RowCount - 1).Cells(1).Value = txtNoTindakan.Text
            dgv2.Rows(dgv2.RowCount - 1).Cells(2).Value = dr.Cells(0).Value.ToString
            dgv2.Rows(dgv2.RowCount - 1).Cells(3).Value = dr.Cells(1).Value.ToString
            dgv2.Rows(dgv2.RowCount - 1).Cells(4).Value = dr.Cells(2).Value.ToString
            dgv2.Rows(dgv2.RowCount - 1).Cells(5).Value = datePermintaan.Text
            dgv2.Rows(dgv2.RowCount - 1).Cells(6).Value = txtKdDokter.Text
            dgv2.Rows(dgv2.RowCount - 1).Cells(7).Value = txtDokter.Text
            dgv2.Rows(dgv2.RowCount - 1).Cells(8).Value = dr.Cells(2).Value.ToString
            dgv2.Rows(dgv2.RowCount - 1).Cells(9).Value = txtNoReg.Text
            dgv2.Rows(dgv2.RowCount - 1).Cells(10).Value = "PERMINTAAN"
            dgv2.Update()
        Next

        For i As Integer = 0 To dgv2.RowCount - 1
            If dgv2.Rows(i).Cells(10).Value.ToString = "PERMINTAAN" Then
                dgv2.Rows(i).Cells(10).Style.BackColor = Color.Orange
                dgv2.Rows(i).Cells(10).Style.ForeColor = Color.White
            End If
        Next

        conn.Close()
    End Sub

    Sub totalTarif()
        Dim totTarif As Long = 0

        For i As Integer = 0 To dgv2.Rows.Count - 1
            totTarif = totTarif + Val(dgv2.Rows(i).Cells(4).Value)
        Next
        txtTotalTarif.Text = totTarif
    End Sub

    Sub addTindakanRajal()
        Call koneksiServer()

        Try
            Dim str As String = ""

            str = "insert into t_tindakanradiologirajal(noTindakanRadiologiRajal,noRegistrasiRadiologiRajal,
                                                        totalTindakanRadiologiRajal,statusPembayaran) 
                   values ('" & txtNoTindakan.Text & "','" & txtNoPermintaan.Text & "','" & txtTotalTarif.Text & "','BELUM LUNAS')"

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Tindakan Radiologi berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - Insert Tindakan Radiologi gagal dilakukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub addTindakanRanap()
        Call koneksiServer()

        Try
            Dim str As String = ""

            str = "insert into t_tindakanradiologiranap(noTindakanRadiologiRanap,noRegistrasiRadiologiRanap,
                                                        totalTindakanRadiologiRanap,statusPembayaran) 
                   values ('" & txtNoTindakan.Text & "','" & txtNoPermintaan.Text & "','" & txtTotalTarif.Text & "','BELUM LUNAS')"

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Tindakan Radiologi berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - Insert Tindakan Radiologi gagal dilakukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub addTindakanLuar()
        Call koneksiServer()

        Try
            Dim str As String = ""

            str = "insert into t_tindakanradiologi(noTindakanRadiologi,noRegistrasiRadiologi,
                                                        totalTindakanRadiologi,statusPembayaran) 
                   values ('" & txtNoTindakan.Text & "','" & txtNoPermintaan.Text & "','" & txtTotalTarif.Text & "','BELUM LUNAS')"

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Tindakan Radiologi berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - Insert Tindakan Radiologi gagal dilakukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateDetailRanap()
        Call koneksiServer()

        Try
            Dim str1 As String
            Dim val0, val1, val2, val3, val4 As String
            str1 = "insert into t_detailtindakanradiologiranap
                              (noTindakanRadiologiRanap,kdTarif,tindakan,tarif,jumlahTindakan,totalTarif,statusTindakan) 
                       values (@noTindakanRadiologiRanap,@kdTarif,@tindakan,@tarif,'1',@totalTarif,'SELESAI')"
            cmd = New MySqlCommand(str1, conn)

            For i As Integer = 0 To dgv2.Rows.Count - 1

                val0 = dgv2.Rows(i).Cells(1).Value
                val1 = dgv2.Rows(i).Cells(2).Value
                val2 = dgv2.Rows(i).Cells(3).Value
                val3 = dgv2.Rows(i).Cells(4).Value
                val4 = dgv2.Rows(i).Cells(4).Value

                cmd.Parameters.AddWithValue("@noTindakanRadiologiRanap", val0)
                cmd.Parameters.AddWithValue("@kdTarif", val1)
                cmd.Parameters.AddWithValue("@tindakan", val2)
                cmd.Parameters.AddWithValue("@tarif", val3)
                cmd.Parameters.AddWithValue("@totalTarif", val4)

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            Next
            'MessageBox.Show("Detail Tindakan Radiologi berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            cmd.Dispose()
        End Try
        conn.Close()

    End Sub

    Sub updateDetailRajal()
        Call koneksiServer()

        Try
            Dim str1 As String
            Dim val0, val1, val2, val3, val4 As String
            str1 = "insert into t_detailtindakanradiologirajal
                              (noTindakanRadiologiRajal,kdTarif,tindakan,tarif,jumlahTindakan,totalTarif,statusTindakan) 
                       values (@noTindakanRadiologiRajal,@kdTarif,@tindakan,@tarif,'1',@totalTarif,'SELESAI')"
            cmd = New MySqlCommand(str1, conn)

            For i As Integer = 0 To dgv2.Rows.Count - 1

                val0 = dgv2.Rows(i).Cells(1).Value
                val1 = dgv2.Rows(i).Cells(2).Value
                val2 = dgv2.Rows(i).Cells(3).Value
                val3 = dgv2.Rows(i).Cells(4).Value
                val4 = dgv2.Rows(i).Cells(4).Value

                cmd.Parameters.AddWithValue("@noTindakanRadiologiRajal", val0)
                cmd.Parameters.AddWithValue("@kdTarif", val1)
                cmd.Parameters.AddWithValue("@tindakan", val2)
                cmd.Parameters.AddWithValue("@tarif", val3)
                cmd.Parameters.AddWithValue("@totalTarif", val4)

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            Next
            'MessageBox.Show("Detail Tindakan Radiologi berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            cmd.Dispose()
        End Try
        conn.Close()

    End Sub

    Sub updateDetailLuar()
        Call koneksiServer()

        Try
            Dim str1 As String
            Dim val0, val1, val2, val3, val4 As String
            str1 = "insert into t_detailtindakanradiologi
                              (noTindakanRadiologi,kdTarif,tindakan,tarif,jumlahTindakan,totalTarif,statusTindakan) 
                       values (@noTindakanRadiologi,@kdTarif,@tindakan,@tarif,'1',@totalTarif,'SELESAI')"
            cmd = New MySqlCommand(str1, conn)

            For i As Integer = 0 To dgv2.Rows.Count - 1

                val0 = dgv2.Rows(i).Cells(1).Value
                val1 = dgv2.Rows(i).Cells(2).Value
                val2 = dgv2.Rows(i).Cells(3).Value
                val3 = dgv2.Rows(i).Cells(4).Value
                val4 = dgv2.Rows(i).Cells(4).Value

                cmd.Parameters.AddWithValue("@noTindakanRadiologi", val0)
                cmd.Parameters.AddWithValue("@kdTarif", val1)
                cmd.Parameters.AddWithValue("@tindakan", val2)
                cmd.Parameters.AddWithValue("@tarif", val3)
                cmd.Parameters.AddWithValue("@totalTarif", val4)

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            Next
            'MessageBox.Show("Detail Tindakan Radiologi berhasil disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            cmd.Dispose()
        End Try
        conn.Close()

    End Sub

    Sub caridata()
        Call koneksiServer()

        Dim query As String
        query = "SELECT kdTarif, tindakan, tarif FROM vw_tindakanrad WHERE kelas = '" & txtKelas.Text & "' AND tindakan LIKE '%" & txtCari.Text & "%'"
        da = New MySqlDataAdapter(query, conn)

        Dim str As New DataTable
        str.Clear()
        da.Fill(str)
        BunifuDgv1.DataSource = str

        conn.Close()
    End Sub


    Private Sub Tindakan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.Manual
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        pnlStats.Height = btnTindakan.Height
        pnlStats.Top = btnTindakan.Top

        btnTindakan.BackColor = Color.DodgerBlue

        Dim jk As String = ""

        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Tindakan RS"
                    txtNoRM.Text = Tambah_Pasien.txtNoRM.Text
                    txtNoReg.Text = Tambah_Pasien.txtNoReg.Text
                    txtNamaPasien.Text = Tambah_Pasien.txtNamaPasien.Text
                    txtAlamat.Text = Tambah_Pasien.txtAlamat.Text
                    txtUsia.Text = Tambah_Pasien.txtUmurJk.Text
                    txtKdDokter.Text = Tambah_Pasien.txtKdDokter.Text
                    txtDokter.Text = Tambah_Pasien.txtDokter.Text
                    txtRs.Text = "RSU KARSA HUSADA BATU"
                    txtInst.Text = Tambah_Pasien.txtInst.Text
                    txtUnit.Text = Tambah_Pasien.txtUnitAsal.Text
                    dateReg.Text = Tambah_Pasien.datePermintaan.Text
                    txtNoPermintaan.Text = Tambah_Pasien.txtNoPermintaan.Text
                    txtKetKlinis.Text = Tambah_Pasien.txtKetKlinis.Text
                    txtKelas.Text = Tambah_Pasien.txtKelas.Text
                Case "Tindakan Luar"
                    txtNoRM.Text = TambahPasienLuar.txtNoRM.Text
                    txtNoReg.Text = TambahPasienLuar.txtNoReg.Text
                    txtNamaPasien.Text = TambahPasienLuar.txtNamaPasien.Text
                    txtAlamat.Text = TambahPasienLuar.txtAlamat.Text
                    If TambahPasienLuar.txtJk.Text = "L" Then
                        jk = "LAKI-LAKI"
                    ElseIf TambahPasienLuar.txtJk.Text = "L" Then
                        jk = "PEREMPUAN"
                    End If
                    txtUsia.Text = TambahPasienLuar.txtUmur.Text & " / " & jk
                    txtDokter.Text = TambahPasienLuar.txtDokter.Text
                    txtRs.Text = TambahPasienLuar.txtRs.Text
                    txtInst.Text = TambahPasienLuar.txtInst.Text
                    txtUnit.Text = TambahPasienLuar.txtUnitAsal.Text
                    txtKelas.Text = "KELAS I"
                    dateReg.Text = TambahPasienLuar.datePermintaan.Text
                    txtNoPermintaan.Text = TambahPasienLuar.txtNoPermintaan.Text
                    txtKetKlinis.Text = TambahPasienLuar.txtKetKlinis.Text
            End Select
        End If

        Select Case txtInst.Text
            Case "RAWAT JALAN"
                Call autoNoTindakanRajal()
            Case "RAWAT INAP"
                Call autoNoTindakanRanap()
            Case "IGD"
                Call autoNoTindakanRajal()
                txtKelas.Text = "KELAS I"
            Case "PASIEN LUAR"
                Call autoNoTindakanLuar()
        End Select

        Call tampilData()
        Call aturDGV()
        Call totalTarif()
    End Sub

    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        Dim konfirmasi As MsgBoxResult

        konfirmasi = MsgBox("Apakah tindakan sudah disimpan ?", vbQuestion + vbYesNo, "EXIT")
        If konfirmasi = vbYes Then
            Form1.pnlStats.Height = Form1.btnDash.Height
            Form1.pnlStats.Top = Form1.btnDash.Top
            Form1.btnDash.BackColor = Color.DodgerBlue
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnTindakan_Click(sender As Object, e As EventArgs) Handles btnTindakan.Click
        pnlStats.Height = btnTindakan.Height
        pnlStats.Top = btnTindakan.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dim konfirmasi As MsgBoxResult

        konfirmasi = MsgBox("Apakah tindakan sudah disimpan ?", vbQuestion + vbYesNo, "EXIT")
        If konfirmasi = vbYes Then
            Form1.pnlStats.Height = Form1.btnDash.Height
            Form1.pnlStats.Top = Form1.btnDash.Top
            Form1.btnDash.BackColor = Color.DodgerBlue
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnPilihOk_Click(sender As Object, e As EventArgs) Handles btnPilihOk.Click
        Call transferSelected()

        If dgv2.Rows.Count > 0 Then
            Me.btnSimpan.Enabled = True
        Else
            Me.btnSimpan.Enabled = False
        End If

        Call totalTarif()
    End Sub

    Private Sub btnPilihCancel_Click(sender As Object, e As EventArgs) Handles btnPilihCancel.Click
        Dim drDgv As New DataGridViewRow
        For Each drDgv In Me.dgv2.SelectedRows
            dgv2.Rows.Remove(drDgv)
        Next

        If dgv2.Rows.Count > 0 Then
            Me.btnSimpan.Enabled = True
        Else
            Me.btnSimpan.Enabled = False
        End If

        Call totalTarif()
    End Sub

    Sub deleteTindakanRanap(id As String)
        Call koneksiServer()
        Dim query As String
        query = "DELETE FROM t_detailtindakanradiologiranap WHERE idTindakanRadiologiRanap = '" & id & "'"
        cmd = New MySqlCommand(query, conn)
        cmd.ExecuteNonQuery()

        Call totalTarif()
        conn.Close()
    End Sub

    Sub deleteTindakanRajal(id As String)
        Call koneksiServer()
        Dim query As String
        query = "DELETE FROM t_detailtindakanradiologirajal WHERE idTindakanRadiologiRajal = '" & id & "'"
        cmd = New MySqlCommand(query, conn)
        cmd.ExecuteNonQuery()

        Call totalTarif()
        conn.Close()
    End Sub

    Sub deleteTindakanLuar(id As String)
        Call koneksiServer()
        Dim query As String
        query = "DELETE FROM t_detailtindakanradiologi WHERE idTindakanRadiologi = '" & id & "'"
        cmd = New MySqlCommand(query, conn)
        cmd.ExecuteNonQuery()

        Call totalTarif()
        conn.Close()
    End Sub

    Private Sub txtCari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call caridata()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        Select Case txtInst.Text
            Case "RAWAT JALAN"
                Call addTindakanRajal()
                Call updateDetailRajal()
            Case "RAWAT INAP"
                Call addTindakanRanap()
                Call updateDetailRanap()
            Case "IGD"
                Call addTindakanRajal()
                Call updateDetailRajal()
            Case "PASIEN LUAR"
                Call addTindakanLuar()
                Call updateDetailLuar()
        End Select

        dgv2.Rows.Clear()
        Me.Close()

        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Form1.btnDash.BackColor = Color.DodgerBlue
        Form1.Show()
        Call Form1.tampilDataAll()
    End Sub

    Private Sub BunifuDgv1_KeyDown(sender As Object, e As KeyEventArgs) Handles BunifuDgv1.KeyDown
        If e.KeyCode = Keys.Enter And BunifuDgv1.CurrentCell.RowIndex >= 0 Then
            e.Handled = True
            e.SuppressKeyPress = True

            Dim row As DataGridViewRow
            row = Me.BunifuDgv1.Rows(BunifuDgv1.CurrentCell.RowIndex)

            If BunifuDgv1.CurrentCell.RowIndex = -1 Then
                Return
            End If

            Call transferSelected()
            Call totalTarif()
            btnSimpan.Enabled = True
        End If
    End Sub

    Private Sub dgv2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgv2.RowPostPaint
        Dim dg As DataGridView = DirectCast(sender, DataGridView)
        ' Current row record
        Dim rowNumber As String = (e.RowIndex + 1).ToString()

        ' Position text
        Dim size As SizeF = e.Graphics.MeasureString(rowNumber, Me.Font)
        If dg.RowHeadersWidth < CInt(size.Width + 20) Then
            dg.RowHeadersWidth = CInt(size.Width + 20)
        End If

        ' Use default system text brush
        Dim b As Brush = SystemBrushes.ControlText

        ' Draw row number
        e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub BunifuDgv1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles BunifuDgv1.CellFormatting
        For i = 0 To BunifuDgv1.RowCount - 1
            If i Mod 2 = 0 Then
                BunifuDgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                BunifuDgv1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next
    End Sub

    Private Sub dgv2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv2.CellFormatting
        dgv2.Columns(4).DefaultCellStyle.Format = "###,###,###"
        dgv2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        For k As Integer = 0 To dgv2.RowCount - 1
            If k Mod 2 = 0 Then
                dgv2.Rows(k).DefaultCellStyle.BackColor = Color.White
            Else
                dgv2.Rows(k).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next
    End Sub

    Private Sub dgv2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv2.RowsAdded
        Call totalTarif()
    End Sub

    Private Sub dgv2_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv2.RowsRemoved
        If dgv2.Rows.Count = 0 Then
            Me.btnSimpan.Enabled = False
        Else
            Me.btnSimpan.Enabled = True
        End If

        Call totalTarif()
    End Sub

    Private Sub txtKelas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtKelas.SelectedIndexChanged
        Call tampilData()
    End Sub
End Class