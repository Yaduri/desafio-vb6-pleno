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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
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
        txtNumeroCartao.Location = New Point(228, 52)
        txtNumeroCartao.MaxLength = 16
        txtNumeroCartao.Name = "txtNumeroCartao"
        txtNumeroCartao.Size = New Size(174, 27)
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(79, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(22, 20)
        Label1.TabIndex = 7
        Label1.Text = "Id"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(228, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(133, 20)
        Label2.TabIndex = 8
        Label2.Text = "Número do Cartão"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(427, 29)
        Label3.Name = "Label3"
        Label3.Size = New Size(43, 20)
        Label3.TabIndex = 9
        Label3.Text = "Valor"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(587, 29)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 20)
        Label4.TabIndex = 10
        Label4.Text = "Status"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(79, 84)
        Label5.Name = "Label5"
        Label5.Size = New Size(74, 20)
        Label5.TabIndex = 11
        Label5.Text = "Descrição"
        ' 
        ' formCadastroTransacao
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(790, 277)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
