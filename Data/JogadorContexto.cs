using Microsoft.Data.Sqlite;

namespace text_wars;

public class JogadorContexto
{
    private string _stringDeConexao = "Data source=TextWars.db";

    public string StringDeConexao
    {
        get
        {
            return _stringDeConexao;
        }
    }

    public void CriaTabela()
    {
        using (var conexao = new SqliteConnection(_stringDeConexao))
        {
            conexao.Open();

            var comando = conexao.CreateCommand();
            //comando.CommandText =
            //@"
            //    CREATE TABLE IF";
        }
    }

    // Construtor
    public JogadorContexto()
    {

    }
}