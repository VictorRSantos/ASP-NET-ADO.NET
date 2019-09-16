using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //ADO.NET => SQl SERVER

namespace DAL.Persistence
{
    public class Conexao
    {
        //Atributos:
        //Protected só pode ser acessada atraves de herança
        protected SqlConnection Con;//É utilizado para estabelecer a conexão com SQL Server
        protected SqlCommand Cmd;//É utilizado para escrever executar comando do banco 
        protected SqlDataReader Dr;//É utilizado para ler registro obtidos de queries


        //Métodos - Abrir Conexão
        protected void AbrirConexao()
        {
            try
            {
                //Connection String
                Con = new SqlConnection("Data Source=DESKTOP;Initial Catalog=master;Integrated Security=True");
                //Abri a conexao com banco de dados
                Con.Open();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Métodos - Fechar Conexão
        protected void FecharConexao()
        {
            try
            {
                Con.Close();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
