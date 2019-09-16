using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistence
{
    public class PessoaDAL : Conexao
    {
        //Regras de négocio da nossa aplicação


        public void Gravar(Pessoa p)
        {
            try
            {
                //Abrir a conexao
                AbrirConexao();

                //Querie do INSERT
                Cmd = new SqlCommand(@"INSERT INTO Pessoa (Nome, Endereco, Email) VALUES (@Nome, @Endereco, @Email)", Con);


                Cmd.Parameters.AddWithValue("@Nome", p.Nome);
                Cmd.Parameters.AddWithValue("@Endereco", p.Endereco);
                Cmd.Parameters.AddWithValue("@Email", p.Email);

                Cmd.ExecuteNonQuery();//Vai ser executado esse nosso método


            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao gravar cliente: {ex.Message}");
            }
            finally
            {

                FecharConexao();

            }

        }


        //Método Update
        public void Atualizar(Pessoa p)
        {
            try
            {
                AbrirConexao();

                Cmd = new SqlCommand(@"UPDATE Pessoa SET Nome = @Nome, Endereco = @Endereco
                Email = @Email WHERE Codigo = @Codigo", Con);


                Cmd.Parameters.AddWithValue("@Nome", p.Nome);
                Cmd.Parameters.AddWithValue("@Endereco", p.Endereco);
                Cmd.Parameters.AddWithValue("@Email", p.Email);
                Cmd.Parameters.AddWithValue("@Codigo", p.Codigo);


                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao atualizar o Cliente: {ex.Message}");
            }
            finally
            {
                FecharConexao();
            }


        }


        //Método para excluir dados
        public void Excluir(int Codigo)
        {

            try
            {

                AbrirConexao();

                Cmd = new SqlCommand(@"DELETE FROM Pessoa WHERE Codigo = @Codigo", Con);

                Cmd.Parameters.AddWithValue("@Codigo", Codigo);


                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao excluir o cliente: {ex.Message}");

            }
            finally
            {

                FecharConexao();


            }


        }



        //Método para obter um cliente por Id
        public Pessoa PesquisarPorCodigo(int Codigo)
        {
            try
            {
                AbrirConexao();


                Cmd = new SqlCommand(@"SELECT * FROM Pessoa WHERE Codigo = @Codigo ", Con);

                Cmd.Parameters.AddWithValue("@Codigo", Codigo);

                //Criando um espaço na memória
                Pessoa p = null;

                if (Dr.Read())
                {

                    p = new Pessoa();

                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = (Dr["Nome"]).ToString();
                    p.Endereco = (Dr["Endereco"]).ToString();
                    p.Email = (Dr["Email"]).ToString();



                }

                return p;

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar obter cliente por Id: {ex.Message}");
            }
            finally
            {

                FecharConexao();

            }


        }


        //Método Listar todos os cliente
        public List<Pessoa> Listar()
        {

            try
            {

                AbrirConexao();

                Cmd = new SqlCommand(@"SELECT * FROM Pessoa", Con);

                Dr = Cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>();

                while (Dr.Read())
                {

                    Pessoa p = new Pessoa();


                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = (Dr["Nome"]).ToString();
                    p.Endereco = (Dr["Endereco"]).ToString();
                    p.Email = (Dr["Email"]).ToString();


                    lista.Add(p);
                }
                
                return lista;

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao listar Clientes: {ex.Message}");

            }
            finally
            {

                FecharConexao();

            }


        }


    }
}
