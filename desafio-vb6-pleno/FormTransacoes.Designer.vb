<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTransacoes
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
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        btnLimparFiltro = New Button()
        btnFiltrar = New Button()
        cboFiltroStatus = New ComboBox()
        txtFiltroValor = New TextBox()
        dtpFiltroFim = New DateTimePicker()
        dtpFiltroInicio = New DateTimePicker()
        txtFiltroCartao = New TextBox()
        GroupBox2 = New GroupBox()
        btnExportarExcel = New Button()
        btnExcluir = New Button()
        btnEditar = New Button()
        btnNovo = New Button()
        dgvTransacoes = New DataGridView()
        btnPaginaAnterior = New Button()
        btnProximaPagina = New Button()
        lblInfoPagina = New Label()
        btnTestaErro = New Button()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(btnLimparFiltro)
        GroupBox1.Controls.Add(btnFiltrar)
        GroupBox1.Controls.Add(cboFiltroStatus)
        GroupBox1.Controls.Add(txtFiltroValor)
        GroupBox1.Controls.Add(dtpFiltroFim)
        GroupBox1.Controls.Add(dtpFiltroInicio)
        GroupBox1.Controls.Add(txtFiltroCartao)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(958, 158)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Filtros de consulta"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(522, 92)
        Label5.Name = "Label5"
        Label5.Size = New Size(49, 20)
        Label5.TabIndex = 11
        Label5.Text = "Status"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(317, 91)
        Label4.Name = "Label4"
        Label4.Size = New Size(43, 20)
        Label4.TabIndex = 10
        Label4.Text = "Valor"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(27, 92)
        Label3.Name = "Label3"
        Label3.Size = New Size(133, 20)
        Label3.TabIndex = 9
        Label3.Text = "Número do Cartão"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(423, 24)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 20)
        Label2.TabIndex = 8
        Label2.Text = "Data Final"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(27, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(84, 20)
        Label1.TabIndex = 7
        Label1.Text = "Data Inicial"
        ' 
        ' btnLimparFiltro
        ' 
        btnLimparFiltro.Location = New Point(799, 91)
        btnLimparFiltro.Name = "btnLimparFiltro"
        btnLimparFiltro.Size = New Size(100, 50)
        btnLimparFiltro.TabIndex = 6
        btnLimparFiltro.Text = "Limpar Filtro"
        btnLimparFiltro.UseVisualStyleBackColor = True
        ' 
        ' btnFiltrar
        ' 
        btnFiltrar.Location = New Point(799, 26)
        btnFiltrar.Name = "btnFiltrar"
        btnFiltrar.Size = New Size(100, 50)
        btnFiltrar.TabIndex = 5
        btnFiltrar.Text = "Filtrar"
        btnFiltrar.UseVisualStyleBackColor = True
        ' 
        ' cboFiltroStatus
        ' 
        cboFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboFiltroStatus.FormattingEnabled = True
        cboFiltroStatus.Location = New Point(522, 115)
        cboFiltroStatus.Name = "cboFiltroStatus"
        cboFiltroStatus.Size = New Size(151, 28)
        cboFiltroStatus.TabIndex = 4
        ' 
        ' txtFiltroValor
        ' 
        txtFiltroValor.Location = New Point(317, 114)
        txtFiltroValor.Name = "txtFiltroValor"
        txtFiltroValor.Size = New Size(111, 27)
        txtFiltroValor.TabIndex = 3
        ' 
        ' dtpFiltroFim
        ' 
        dtpFiltroFim.Checked = False
        dtpFiltroFim.Location = New Point(423, 47)
        dtpFiltroFim.Name = "dtpFiltroFim"
        dtpFiltroFim.ShowCheckBox = True
        dtpFiltroFim.Size = New Size(250, 27)
        dtpFiltroFim.TabIndex = 2
        ' 
        ' dtpFiltroInicio
        ' 
        dtpFiltroInicio.Checked = False
        dtpFiltroInicio.Location = New Point(27, 47)
        dtpFiltroInicio.Name = "dtpFiltroInicio"
        dtpFiltroInicio.ShowCheckBox = True
        dtpFiltroInicio.Size = New Size(250, 27)
        dtpFiltroInicio.TabIndex = 1
        ' 
        ' txtFiltroCartao
        ' 
        txtFiltroCartao.Location = New Point(27, 115)
        txtFiltroCartao.MaxLength = 16
        txtFiltroCartao.Name = "txtFiltroCartao"
        txtFiltroCartao.Size = New Size(218, 27)
        txtFiltroCartao.TabIndex = 0
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnTestaErro)
        GroupBox2.Controls.Add(btnExportarExcel)
        GroupBox2.Controls.Add(btnExcluir)
        GroupBox2.Controls.Add(btnEditar)
        GroupBox2.Controls.Add(btnNovo)
        GroupBox2.Location = New Point(12, 189)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(119, 367)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Ações"
        ' 
        ' btnExportarExcel
        ' 
        btnExportarExcel.Location = New Point(14, 174)
        btnExportarExcel.Name = "btnExportarExcel"
        btnExportarExcel.Size = New Size(94, 29)
        btnExportarExcel.TabIndex = 3
        btnExportarExcel.Text = "Exportar"
        btnExportarExcel.UseVisualStyleBackColor = True
        ' 
        ' btnExcluir
        ' 
        btnExcluir.Location = New Point(14, 126)
        btnExcluir.Name = "btnExcluir"
        btnExcluir.Size = New Size(94, 29)
        btnExcluir.TabIndex = 2
        btnExcluir.Text = "Excluir"
        btnExcluir.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(14, 76)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(94, 29)
        btnEditar.TabIndex = 1
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnNovo
        ' 
        btnNovo.Location = New Point(14, 28)
        btnNovo.Name = "btnNovo"
        btnNovo.Size = New Size(94, 29)
        btnNovo.TabIndex = 0
        btnNovo.Text = "Novo"
        btnNovo.UseVisualStyleBackColor = True
        ' 
        ' dgvTransacoes
        ' 
        dgvTransacoes.AllowUserToAddRows = False
        dgvTransacoes.AllowUserToDeleteRows = False
        dgvTransacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransacoes.Location = New Point(137, 198)
        dgvTransacoes.MultiSelect = False
        dgvTransacoes.Name = "dgvTransacoes"
        dgvTransacoes.ReadOnly = True
        dgvTransacoes.RowHeadersWidth = 51
        dgvTransacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTransacoes.Size = New Size(833, 358)
        dgvTransacoes.TabIndex = 2
        ' 
        ' btnPaginaAnterior
        ' 
        btnPaginaAnterior.Location = New Point(137, 566)
        btnPaginaAnterior.Name = "btnPaginaAnterior"
        btnPaginaAnterior.Size = New Size(94, 29)
        btnPaginaAnterior.TabIndex = 3
        btnPaginaAnterior.Text = "< Anterior"
        btnPaginaAnterior.UseVisualStyleBackColor = True
        ' 
        ' btnProximaPagina
        ' 
        btnProximaPagina.Location = New Point(876, 566)
        btnProximaPagina.Name = "btnProximaPagina"
        btnProximaPagina.Size = New Size(94, 29)
        btnProximaPagina.TabIndex = 4
        btnProximaPagina.Text = "Próxima >"
        btnProximaPagina.UseVisualStyleBackColor = True
        ' 
        ' lblInfoPagina
        ' 
        lblInfoPagina.AutoSize = True
        lblInfoPagina.Location = New Point(464, 566)
        lblInfoPagina.Name = "lblInfoPagina"
        lblInfoPagina.Size = New Size(221, 20)
        lblInfoPagina.TabIndex = 5
        lblInfoPagina.Text = "Página 1 de 1 (Total: 0 registros)"
        ' 
        ' btnTestaErro
        ' 
        btnTestaErro.Location = New Point(14, 321)
        btnTestaErro.Name = "btnTestaErro"
        btnTestaErro.Size = New Size(94, 29)
        btnTestaErro.TabIndex = 4
        btnTestaErro.Text = "Testar Log"
        btnTestaErro.UseVisualStyleBackColor = True
        ' 
        ' FormTransacoes
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 603)
        Controls.Add(lblInfoPagina)
        Controls.Add(btnProximaPagina)
        Controls.Add(btnPaginaAnterior)
        Controls.Add(dgvTransacoes)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        MinimumSize = New Size(950, 600)
        Name = "FormTransacoes"
        StartPosition = FormStartPosition.CenterScreen
        Text = "XYZ Administradora de Cartões - Gestão de Transações"
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTestaErro As Button

End Class
