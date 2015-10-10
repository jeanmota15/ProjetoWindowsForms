using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Crud3CamadasMota
{
    public class BairroDal
    {
        private SqlConnection minhaConexao;

        public BairroDal()
        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Bairro"].ConnectionString);
            minhaConexao.Open();
        }

        public DataTable ListaBairro()
        {
            DataTable dtBairro = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(" select * from Bairro ", minhaConexao);
                SqlDataAdapter daBairro = new SqlDataAdapter();
                daBairro.SelectCommand = cmd;
                daBairro.Fill(dtBairro);
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
            finally
            {
                minhaConexao.Close();
            }
            return dtBairro;
        }

        public void GravaBairroDal(BairroModel bairroModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" insert into Bairro (Nome) values (@nome) ", minhaConexao);
                cmd.Parameters.AddWithValue("@nome", bairroModel.Nome);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
            finally
            {
                minhaConexao.Close();
            }     
        }

        public void AlteraBairroDal(BairroModel bairroModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" update Bairro set Nome = @nome where Id = @id ", minhaConexao);
                cmd.Parameters.AddWithValue("@nome", bairroModel.Nome);
                cmd.Parameters.AddWithValue("@id", bairroModel.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
            finally
            {
                minhaConexao.Close();
            }
        }

        public void ExcluirBairroDal(BairroModel bairroModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" delete from Bairro where Id = @id ", minhaConexao);
                cmd.Parameters.AddWithValue("@id", bairroModel.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
            finally
            {
                minhaConexao.Close();
            }
        }

        public BairroModel Pesquisar(string pesquisar)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" select * from Bairro where Nome like '" + pesquisar + "%'", minhaConexao);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                BairroModel obj_bairro = new BairroModel();

                while (reader.Read())
                {
                    obj_bairro.Id = int.Parse(reader["Id"].ToString());
                    obj_bairro.Nome = reader["Nome"].ToString();
                }
                return obj_bairro;
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
            finally
            {
                minhaConexao.Close();
            }
        }
    }
}
