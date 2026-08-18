Imports System.Configuration
Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class TransacaoRepository
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("SqlConnectionString").ConnectionString

    ''' <summary>
    ''' Executa a Stored Procedure sp_ListarTransacoesPaginadas retornando o DataTable da página e a contagem total via OUTPUT.
    ''' </summary>
    Public Function ObterPaginado(numeroCartao As String, dataInicio As DateTime?, dataFim As DateTime?, valor As Decimal?, status As String, pageNumber As Integer, pageSize As Integer, ByRef totalRegistros As Integer) As DataTable
        Dim dt As New DataTable()

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("sp_ListarTransacoesPaginadas", conn)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Numero_Cartao", If(String.IsNullOrWhiteSpace(numeroCartao), DBNull.Value, numeroCartao.Trim()))
                cmd.Parameters.AddWithValue("@Data_Inicial", If(dataInicio.HasValue, dataInicio.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@Data_Final", If(dataFim.HasValue, dataFim.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@Valor_Transacao", If(valor.HasValue, valor.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@Status_Transacao", If(String.IsNullOrWhiteSpace(status) OrElse status = "Todos", DBNull.Value, status))
                cmd.Parameters.AddWithValue("@PageNumber", pageNumber)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)

                Dim pTotal As New SqlParameter("@TotalRegistros", SqlDbType.Int) With {
                    .Direction = ParameterDirection.Output
                }
                cmd.Parameters.Add(pTotal)

                conn.Open()
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using

                If pTotal.Value IsNot DBNull.Value Then
                    totalRegistros = Convert.ToInt32(pTotal.Value)
                Else
                    totalRegistros = 0
                End If
            End Using
        End Using

        Return dt
    End Function

    ''' <summary>
    ''' Insere uma nova transação e retorna o ID gerado automaticamente.
    ''' </summary>
    Public Function Inserir(numeroCartao As String, valor As Decimal, descricao As String, status As String) As Long
        Const sql As String = "
            INSERT INTO Transacoes (Numero_Cartao, Valor_Transacao, Data_Transacao, Descricao, Status_Transacao)
            OUTPUT INSERTED.Id_Transacao
            VALUES (@Numero_Cartao, @Valor_Transacao, GETDATE(), @Descricao, @Status_Transacao);"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Numero_Cartao", numeroCartao)
                cmd.Parameters.AddWithValue("@Valor_Transacao", valor)
                cmd.Parameters.AddWithValue("@Descricao", descricao)
                cmd.Parameters.AddWithValue("@Status_Transacao", status)

                conn.Open()
                Return Convert.ToInt64(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Atualiza uma transação existente.
    ''' </summary>
    Public Sub Atualizar(id As Long, numeroCartao As String, valor As Decimal, descricao As String, status As String)
        Const sql As String = "
            UPDATE Transacoes 
            SET Numero_Cartao = @Numero_Cartao,
                Valor_Transacao = @Valor_Transacao,
                Descricao = @Descricao,
                Status_Transacao = @Status_Transacao
            WHERE Id_Transacao = @Id_Transacao;"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Id_Transacao", id)
                cmd.Parameters.AddWithValue("@Numero_Cartao", numeroCartao)
                cmd.Parameters.AddWithValue("@Valor_Transacao", valor)
                cmd.Parameters.AddWithValue("@Descricao", descricao)
                cmd.Parameters.AddWithValue("@Status_Transacao", status)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Exclui uma transação pelo identificador.
    ''' </summary>
    Public Sub Excluir(id As Long)
        Const sql As String = "DELETE FROM Transacoes WHERE Id_Transacao = @Id_Transacao;"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Id_Transacao", id)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Consulta a View consolidada para as transações do último mês.
    ''' </summary>
    Public Function ObterConsolidadoUltimoMes() As DataTable
        Dim dt As New DataTable()
        Const sql As String = "
            SELECT Id_Transacao, Numero_Cartao, Valor_Transacao, Data_Transacao, Descricao, Status_Transacao, Categoria 
            FROM vw_TransacoesConsolidadas
            WHERE Data_Transacao >= DATEADD(MONTH, -1, GETDATE())
            ORDER BY Data_Transacao DESC;"

        Using conn As New SqlConnection(connectionString)
            Using da As New SqlDataAdapter(sql, conn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function
End Class