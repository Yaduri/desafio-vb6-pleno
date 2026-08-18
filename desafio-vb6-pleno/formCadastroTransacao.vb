Public Class formCadastroTransacao
    Private ReadOnly _repo As New TransacaoRepository()
    Private _idEdicao As Long? = Nothing
    Private _statusOriginal As String = String.Empty

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Construtor para modo de Edição.
    ''' </summary>
    Public Sub New(id As Long, cartao As String, valor As Decimal, descricao As String, status As String)
        Me.New()
        _idEdicao = id
        _statusOriginal = status

        txtId.Text = id.ToString()
        txtNumeroCartao.Text = cartao
        txtValor.Text = valor.ToString("N2")
        txtDescricao.Text = descricao
        cboStatus.SelectedItem = status
    End Sub

    Private Sub formCadastroTransacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cboStatus.Items.Count = 0 Then
            cboStatus.Items.AddRange(New Object() {"Pendente", "Aprovada", "Cancelada"})
        End If

        If Not _idEdicao.HasValue Then
            Me.Text = "Nova Transação"
            cboStatus.SelectedItem = "Pendente"
        Else
            Me.Text = $"Editar Transação #{_idEdicao.Value}"

            ' Regra de Negócio: Bloquear edição se status for 'Aprovada'
            If String.Equals(_statusOriginal, "Aprovada", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Transações com status 'Aprovada' não podem ser editadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                BloquearCampos()
            End If
        End If
    End Sub

    Private Sub BloquearCampos()
        txtNumeroCartao.ReadOnly = True
        txtValor.ReadOnly = True
        txtDescricao.ReadOnly = True
        cboStatus.Enabled = False
        btnSalvar.Enabled = False
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            ' Validações de Entrada
            Dim cartao As String = txtNumeroCartao.Text.Trim()
            If cartao.Length <> 16 OrElse Not Long.TryParse(cartao, Nothing) Then
                MessageBox.Show("O número do cartão deve conter exatamente 16 dígitos numéricos.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNumeroCartao.Focus()
                Return
            End If

            Dim valor As Decimal
            If Not Decimal.TryParse(txtValor.Text, valor) OrElse valor <= 0 Then
                MessageBox.Show("O valor da transação deve ser um número decimal positivo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtValor.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtDescricao.Text) Then
                MessageBox.Show("A descrição é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDescricao.Focus()
                Return
            End If

            If cboStatus.SelectedItem Is Nothing Then
                MessageBox.Show("Selecione um status para a transação.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim status As String = cboStatus.SelectedItem.ToString()

            If Not _idEdicao.HasValue Then
                ' Inserção
                _repo.Inserir(cartao, valor, txtDescricao.Text.Trim(), status)
                MessageBox.Show("Transação cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Edição (Proteção adicional)
                If String.Equals(_statusOriginal, "Aprovada", StringComparison.OrdinalIgnoreCase) Then
                    MessageBox.Show("Transações com status 'Aprovada' não podem ser alteradas!", "Regra de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                _repo.Atualizar(_idEdicao.Value, cartao, valor, txtDescricao.Text.Trim(), status)
                MessageBox.Show("Transação atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            Logger.LogError(ex, "Erro ao salvar dados no formCadastroTransacao.")
            MessageBox.Show("Ocorreu um erro ao salvar os dados. Detalhes gravados no log.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class