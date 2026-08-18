Imports ClosedXML.Excel
Imports System.IO

Public Class formTransacoes
    Private ReadOnly _repo As New TransacaoRepository()
    Private _paginaAtual As Integer = 1
    Private Const PageSize As Integer = 20
    Private _totalRegistros As Integer = 0
    Private _totalPaginas As Integer = 1

    Private Sub formTransacoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarFiltros()
        CarregarGrid()
    End Sub

    Private Sub ConfigurarFiltros()
        cboFiltroStatus.Items.Clear()
        cboFiltroStatus.Items.AddRange(New Object() {"Todos", "Pendente", "Aprovada", "Cancelada"})
        cboFiltroStatus.SelectedIndex = 0

        dtpFiltroInicio.ShowCheckBox = True
        dtpFiltroInicio.Checked = False
        dtpFiltroFim.ShowCheckBox = True
        dtpFiltroFim.Checked = False
    End Sub

    Private Sub CarregarGrid()
        Try
            Dim dataIni As DateTime? = If(dtpFiltroInicio.Checked, dtpFiltroInicio.Value.Date, CType(Nothing, DateTime?))
            Dim dataFim As DateTime? = If(dtpFiltroFim.Checked, dtpFiltroFim.Value.Date.AddDays(1).AddSeconds(-1), CType(Nothing, DateTime?))

            Dim valorTemp As Decimal
            Dim valorFiltro As Decimal? = Nothing

            If Decimal.TryParse(txtFiltroValor.Text.Trim(), valorTemp) Then
                valorFiltro = valorTemp
            End If

            Dim dt = _repo.ObterPaginado(
                txtFiltroCartao.Text,
                dataIni,
                dataFim,
                valorFiltro,
                cboFiltroStatus.SelectedItem.ToString(),
                _paginaAtual,
                PageSize,
                _totalRegistros
            )

            dgvTransacoes.DataSource = dt
            FormatarGrid()

            _totalPaginas = Math.Max(1, CInt(Math.Ceiling(_totalRegistros / CDbl(PageSize))))
            lblInfoPagina.Text = $"Página {_paginaAtual} de {_totalPaginas} (Total: {_totalRegistros} registros)"

            btnPaginaAnterior.Enabled = (_paginaAtual > 1)
            btnProximaPagina.Enabled = (_paginaAtual < _totalPaginas)

        Catch ex As Exception
            Logger.LogError(ex, "Erro ao carregar grid de transações.")
            MessageBox.Show("Erro ao carregar as transações. Verifique os logs.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatarGrid()
        If dgvTransacoes.Columns.Contains("Id_Transacao") Then
            dgvTransacoes.Columns("Id_Transacao").HeaderText = "ID"
            dgvTransacoes.Columns("Id_Transacao").Width = 70
        End If

        If dgvTransacoes.Columns.Contains("Numero_Cartao") Then
            dgvTransacoes.Columns("Numero_Cartao").HeaderText = "Cartão"
            dgvTransacoes.Columns("Numero_Cartao").Width = 140
        End If

        If dgvTransacoes.Columns.Contains("Valor_Transacao") Then
            dgvTransacoes.Columns("Valor_Transacao").HeaderText = "Valor (R$)"
            dgvTransacoes.Columns("Valor_Transacao").DefaultCellStyle.Format = "N2"
            dgvTransacoes.Columns("Valor_Transacao").Width = 100
        End If

        If dgvTransacoes.Columns.Contains("Data_Transacao") Then
            dgvTransacoes.Columns("Data_Transacao").HeaderText = "Data/Hora"
            dgvTransacoes.Columns("Data_Transacao").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
            dgvTransacoes.Columns("Data_Transacao").Width = 140
        End If

        If dgvTransacoes.Columns.Contains("Descricao") Then
            dgvTransacoes.Columns("Descricao").HeaderText = "Descrição"
            dgvTransacoes.Columns("Descricao").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        If dgvTransacoes.Columns.Contains("Status_Transacao") Then
            dgvTransacoes.Columns("Status_Transacao").HeaderText = "Status"
            dgvTransacoes.Columns("Status_Transacao").Width = 100
        End If
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Using formCadastro As New formCadastroTransacao()
            If formCadastro.ShowDialog(Me) = DialogResult.OK Then
                CarregarGrid()
            End If
        End Using
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AbrirEdicaoSelecionada()
    End Sub

    Private Sub dgvTransacoes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransacoes.CellDoubleClick
        If e.RowIndex >= 0 Then
            AbrirEdicaoSelecionada()
        End If
    End Sub

    Private Sub AbrirEdicaoSelecionada()
        If dgvTransacoes.CurrentRow Is Nothing OrElse dgvTransacoes.CurrentRow.Index < 0 Then
            MessageBox.Show("Selecione uma transação para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row = dgvTransacoes.CurrentRow
        Dim id As Long = Convert.ToInt64(row.Cells("Id_Transacao").Value)
        Dim cartao As String = row.Cells("Numero_Cartao").Value.ToString()
        Dim valor As Decimal = Convert.ToDecimal(row.Cells("Valor_Transacao").Value)
        Dim descricao As String = row.Cells("Descricao").Value.ToString()
        Dim status As String = row.Cells("Status_Transacao").Value.ToString()

        Using formEdicao As New formCadastroTransacao(id, cartao, valor, descricao, status)
            If formEdicao.ShowDialog(Me) = DialogResult.OK Then
                CarregarGrid()
            End If
        End Using
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If dgvTransacoes.CurrentRow Is Nothing OrElse dgvTransacoes.CurrentRow.Index < 0 Then
            MessageBox.Show("Selecione uma transação para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row = dgvTransacoes.CurrentRow
        Dim id As Long = Convert.ToInt64(row.Cells("Id_Transacao").Value)
        Dim status As String = row.Cells("Status_Transacao").Value.ToString()

        Dim resposta = MessageBox.Show($"Deseja realmente excluir a transação #{id} ({status})?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resposta = DialogResult.Yes Then
            Try
                _repo.Excluir(id)
                MessageBox.Show("Transação excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CarregarGrid()
            Catch ex As Exception
                Logger.LogError(ex, $"Erro ao excluir a transação #{id}")
                MessageBox.Show("Não foi possível excluir a transação. Detalhes gravados em log.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        _paginaAtual = 1
        CarregarGrid()
    End Sub

    Private Sub btnLimparFiltro_Click(sender As Object, e As EventArgs) Handles btnLimparFiltro.Click
        txtFiltroCartao.Clear()
        txtFiltroValor.Clear()
        cboFiltroStatus.SelectedIndex = 0
        dtpFiltroInicio.Checked = False
        dtpFiltroFim.Checked = False
        _paginaAtual = 1
        CarregarGrid()
    End Sub

    Private Sub btnProximaPagina_Click(sender As Object, e As EventArgs) Handles btnProximaPagina.Click
        If _paginaAtual < _totalPaginas Then
            _paginaAtual += 1
            CarregarGrid()
        End If
    End Sub

    Private Sub btnPaginaAnterior_Click(sender As Object, e As EventArgs) Handles btnPaginaAnterior.Click
        If _paginaAtual > 1 Then
            _paginaAtual -= 1
            CarregarGrid()
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Try
            Dim sfd As New SaveFileDialog() With {
                .Filter = "Planilha Excel (*.xlsx)|*.xlsx",
                .FileName = $"Relatorio_Transacoes_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            }

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim dt = _repo.ObterConsolidadoUltimoMes()

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Não existem transações registradas no último mês para exportação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Using wb As New XLWorkbook()
                    Dim ws = wb.Worksheets.Add(dt, "Transacoes_Consolidadas")

                    ws.Row(1).Style.Font.Bold = True
                    ws.Row(1).Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1)
                    ws.Row(1).Style.Font.FontColor = XLColor.White
                    ws.Columns().AdjustToContents()

                    wb.SaveAs(sfd.FileName)
                End Using

                MessageBox.Show("Relatório exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Logger.LogError(ex, "Erro ao exportar relatório consolidado para Excel.")
            MessageBox.Show("Erro ao exportar para Excel. Detalhes gravados no log.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTestaErro_Click(sender As Object, e As EventArgs) Handles btnTestaErro.Click
        Try
            Dim dividendo As Integer = 100
            Dim divisor As Integer = 0
            Dim resultado As Integer = dividendo \ divisor

        Catch ex As Exception
            Logger.LogError(ex, "Teste manual de captura e tratamento de log acionado pelo usuário.")

            MessageBox.Show("Uma falha simulada ocorreu e os detalhes foram registrados no arquivo de log com sucesso!",
                            "Simulação de Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try
    End Sub
End Class