<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        GroupBox1 = New GroupBox()
        txtFiltroCartao = New TextBox()
        dtpFiltroInicio = New DateTimePicker()
        dtpFiltroFim = New DateTimePicker()
        txtFiltroValor = New TextBox()
        cboFiltroStatus = New ComboBox()
        btnFiltrar = New Button()
        btnLimparFiltro = New Button()
        GroupBox2 = New GroupBox()
        btnNovo = New Button()
        btnEditar = New Button()
        btnExcluir = New Button()
        btnExportarExcel = New Button()
        dgvTransacoes = New DataGridView()
        btnPaginaAnterior = New Button()
        btnProximaPagina = New Button()
        lblInfoPagina = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnLimparFiltro)
        GroupBox1.Controls.Add(btnFiltrar)
        GroupBox1.Controls.Add(cboFiltroStatus)
        GroupBox1.Controls.Add(txtFiltroValor)
        GroupBox1.Controls.Add(dtpFiltroFim)
        GroupBox1.Controls.Add(dtpFiltroInicio)
        GroupBox1.Controls.Add(txtFiltroCartao)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 148)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Filtros de consulta"
        ' 
        ' txtFiltroCartao
        ' 
        txtFiltroCartao.Location = New Point(27, 91)
        txtFiltroCartao.MaxLength = 16
        txtFiltroCartao.Name = "txtFiltroCartao"
        txtFiltroCartao.Size = New Size(125, 27)
        txtFiltroCartao.TabIndex = 0
        ' 
        ' dtpFiltroInicio
        ' 
        dtpFiltroInicio.Checked = False
        dtpFiltroInicio.Location = New Point(27, 45)
        dtpFiltroInicio.Name = "dtpFiltroInicio"
        dtpFiltroInicio.ShowCheckBox = True
        dtpFiltroInicio.Size = New Size(250, 27)
        dtpFiltroInicio.TabIndex = 1
        ' 
        ' dtpFiltroFim
        ' 
        dtpFiltroFim.Checked = False
        dtpFiltroFim.Location = New Point(317, 45)
        dtpFiltroFim.Name = "dtpFiltroFim"
        dtpFiltroFim.ShowCheckBox = True
        dtpFiltroFim.Size = New Size(250, 27)
        dtpFiltroFim.TabIndex = 2
        ' 
        ' txtFiltroValor
        ' 
        txtFiltroValor.Location = New Point(169, 91)
        txtFiltroValor.Name = "txtFiltroValor"
        txtFiltroValor.Size = New Size(125, 27)
        txtFiltroValor.TabIndex = 3
        ' 
        ' cboFiltroStatus
        ' 
        cboFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboFiltroStatus.FormattingEnabled = True
        cboFiltroStatus.Location = New Point(317, 91)
        cboFiltroStatus.Name = "cboFiltroStatus"
        cboFiltroStatus.Size = New Size(151, 28)
        cboFiltroStatus.TabIndex = 4
        ' 
        ' btnFiltrar
        ' 
        btnFiltrar.Location = New Point(619, 45)
        btnFiltrar.Name = "btnFiltrar"
        btnFiltrar.Size = New Size(94, 29)
        btnFiltrar.TabIndex = 5
        btnFiltrar.Text = "Filtrar"
        btnFiltrar.UseVisualStyleBackColor = True
        ' 
        ' btnLimparFiltro
        ' 
        btnLimparFiltro.Location = New Point(619, 100)
        btnLimparFiltro.Name = "btnLimparFiltro"
        btnLimparFiltro.Size = New Size(94, 29)
        btnLimparFiltro.TabIndex = 6
        btnLimparFiltro.Text = "Limpar Filtro"
        btnLimparFiltro.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnExportarExcel)
        GroupBox2.Controls.Add(btnExcluir)
        GroupBox2.Controls.Add(btnEditar)
        GroupBox2.Controls.Add(btnNovo)
        GroupBox2.Location = New Point(12, 166)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(119, 377)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "GroupBox2"
        ' 
        ' btnNovo
        ' 
        btnNovo.Location = New Point(6, 26)
        btnNovo.Name = "btnNovo"
        btnNovo.Size = New Size(94, 29)
        btnNovo.TabIndex = 0
        btnNovo.Text = "Novo"
        btnNovo.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(6, 61)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(94, 29)
        btnEditar.TabIndex = 1
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnExcluir
        ' 
        btnExcluir.Location = New Point(6, 96)
        btnExcluir.Name = "btnExcluir"
        btnExcluir.Size = New Size(94, 29)
        btnExcluir.TabIndex = 2
        btnExcluir.Text = "Excluir"
        btnExcluir.UseVisualStyleBackColor = True
        ' 
        ' btnExportarExcel
        ' 
        btnExportarExcel.Location = New Point(6, 131)
        btnExportarExcel.Name = "btnExportarExcel"
        btnExportarExcel.Size = New Size(94, 29)
        btnExportarExcel.TabIndex = 3
        btnExportarExcel.Text = "Exportar"
        btnExportarExcel.UseVisualStyleBackColor = True
        ' 
        ' dgvTransacoes
        ' 
        dgvTransacoes.AllowUserToAddRows = False
        dgvTransacoes.AllowUserToDeleteRows = False
        dgvTransacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransacoes.Location = New Point(137, 175)
        dgvTransacoes.MultiSelect = False
        dgvTransacoes.Name = "dgvTransacoes"
        dgvTransacoes.ReadOnly = True
        dgvTransacoes.RowHeadersWidth = 51
        dgvTransacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTransacoes.Size = New Size(651, 313)
        dgvTransacoes.TabIndex = 2
        ' 
        ' btnPaginaAnterior
        ' 
        btnPaginaAnterior.Location = New Point(137, 510)
        btnPaginaAnterior.Name = "btnPaginaAnterior"
        btnPaginaAnterior.Size = New Size(94, 29)
        btnPaginaAnterior.TabIndex = 3
        btnPaginaAnterior.Text = "< Anterior"
        btnPaginaAnterior.UseVisualStyleBackColor = True
        ' 
        ' btnProximaPagina
        ' 
        btnProximaPagina.Location = New Point(694, 510)
        btnProximaPagina.Name = "btnProximaPagina"
        btnProximaPagina.Size = New Size(94, 29)
        btnProximaPagina.TabIndex = 4
        btnProximaPagina.Text = "Próxima >"
        btnProximaPagina.UseVisualStyleBackColor = True
        ' 
        ' lblInfoPagina
        ' 
        lblInfoPagina.AutoSize = True
        lblInfoPagina.Location = New Point(358, 514)
        lblInfoPagina.Name = "lblInfoPagina"
        lblInfoPagina.Size = New Size(221, 20)
        lblInfoPagina.TabIndex = 5
        lblInfoPagina.Text = "Página 1 de 1 (Total: 0 registros)"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 555)
        Controls.Add(lblInfoPagina)
        Controls.Add(btnProximaPagina)
        Controls.Add(btnPaginaAnterior)
        Controls.Add(dgvTransacoes)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "Form1"
        Text = "Form1"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLimparFiltro As Button
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents cboFiltroStatus As ComboBox
    Friend WithEvents txtFiltroValor As TextBox
    Friend WithEvents dtpFiltroFim As DateTimePicker
    Friend WithEvents dtpFiltroInicio As DateTimePicker
    Friend WithEvents txtFiltroCartao As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents dgvTransacoes As DataGridView
    Friend WithEvents btnPaginaAnterior As Button
    Friend WithEvents btnProximaPagina As Button
    Friend WithEvents lblInfoPagina As Label

End Class
