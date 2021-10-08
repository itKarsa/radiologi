<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CetakBukti
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.vw_datapasienradiologiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CetakNota = New Radiologi.CetakNota()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.vw_datapasienradiologiTableAdapter = New Radiologi.CetakNotaTableAdapters.vw_datapasienradiologiTableAdapter()
        CType(Me.vw_datapasienradiologiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CetakNota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vw_datapasienradiologiBindingSource
        '
        Me.vw_datapasienradiologiBindingSource.DataMember = "vw_datapasienradiologi"
        Me.vw_datapasienradiologiBindingSource.DataSource = Me.CetakNota
        '
        'CetakNota
        '
        Me.CetakNota.DataSetName = "CetakNota"
        Me.CetakNota.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "CetakBuktiPembayaran"
        ReportDataSource1.Value = Me.vw_datapasienradiologiBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Radiologi.BuktiPemeriksaan.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(440, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'vw_datapasienradiologiTableAdapter
        '
        Me.vw_datapasienradiologiTableAdapter.ClearBeforeFill = True
        '
        'CetakBukti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "CetakBukti"
        Me.Text = "CetakBukti"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.vw_datapasienradiologiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CetakNota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents vw_datapasienradiologiBindingSource As BindingSource
    Friend WithEvents CetakNota As CetakNota
    Friend WithEvents vw_datapasienradiologiTableAdapter As CetakNotaTableAdapters.vw_datapasienradiologiTableAdapter
End Class
