<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCadastroTransacao
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtId = New TextBox()
        txtNumeroCartao = New TextBox()
        txtValor = New TextBox()
        txtDescricao = New TextBox()
        cboStatus = New ComboBox()
        btnSalvar = New Button()
        btnCancelar = New Button()
        SuspendLayout()
        ' 
        ' txtId
        ' 
        txtId.Location = New Point(79, 52)
        txtId.Name = "txtId"
        txtId.ReadOnly = True
        txtId.Size = New Size(125, 27)
        txtId.TabIndex = 0
        ' 
        ' txtNumeroCartao
        ' 
        txtNumeroCartao.Location = New Point(246, 52)
        txtNumeroCartao.MaxLength = 16
        txtNumeroCartao.Name = "txtNumeroCartao"
        txtNumeroCartao.Size = New Size(125, 27)
        txtNumeroCartao.TabIndex = 1
        ' 
        ' txtValor
        ' 
        txtValor.Location = New Point(427, 52)
        txtValor.Name = "txtValor"
        txtValor.Size = New Size(125, 27)
        txtValor.TabIndex = 2
        ' 
        ' txtDescricao
        ' 
        txtDescricao.Location = New Point(79, 107)
        txtDescricao.MaxLength = 255
        txtDescricao.Multiline = True
        txtDescricao.Name = "txtDescricao"
        txtDescricao.Size = New Size(659, 70)
        txtDescricao.TabIndex = 3
        ' 
        ' cboStatus
        ' 
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FormattingEnabled = True
        cboStatus.Location = New Point(587, 52)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(151, 28)
        cboStatus.TabIndex = 4
        ' 
        ' btnSalvar
        ' 
        btnSalvar.Location = New Point(89, 209)
        btnSalvar.Name = "btnSalvar"
        btnSalvar.Size = New Size(94, 29)
        btnSalvar.TabIndex = 5
        btnSalvar.Text = "Salvar"
        btnSalvar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(200, 209)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(94, 29)
        btnCancelar.TabIndex = 6
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' formCadastroTransacao
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(790, 277)
        Controls.Add(btnCancelar)
        Controls.Add(btnSalvar)
        Controls.Add(cboStatus)
        Controls.Add(txtDescricao)
        Controls.Add(txtValor)
        Controls.Add(txtNumeroCartao)
        Controls.Add(txtId)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "formCadastroTransacao"
        StartPosition = FormStartPosition.CenterParent
        Text = "Dados da Transação"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtId As TextBox
    Friend WithEvents txtNumeroCartao As TextBox
    Friend WithEvents txtValor As TextBox
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
End Class
