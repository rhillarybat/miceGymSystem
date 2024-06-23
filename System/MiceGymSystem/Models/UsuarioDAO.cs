using MiceGymSystem.Database;
using MySql.Data.MySqlClient;
using SISCAN.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiceGymSystem.Models
{
    internal class UsuarioDAO
    {
        private static Conexao conn;
        public int count;

        public UsuarioDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Usuario user)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"INSERT INTO Usuario VALUES (null, '{user.Nome}', '{user.Senha}', '{user.Email}', '{user.Cpf}', '{user.Telefone}');";  

                //MySqlDataReader reader = query.ExecuteReader();
                int linesSave = query.ExecuteNonQuery();

                if (linesSave > 0)
                {
                    //MessageBox.Show("");
                    MessageBox.Show("Registro Salvo com Sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {                    
                    MessageBox.Show("Erro ao salvar registro!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);                
                MessageBox.Show("Erro 3007 : Contate o suporte!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public Usuario Login(string email, string senha)
        {
            try
            {
                Usuario usuario = new Usuario();
                var query = conn.Query();

                query.CommandText = $"SELECT * FROM Usuario WHERE ((email_user = '{email}') AND (senha_user = '{senha}'));";


                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    count = 1;

                    while (reader.Read())
                    {
                        usuario.Id = reader.GetInt32("id_user");
                        usuario.Nome = DAOHelper.GetString(reader, "nome_user");
                    }
                }
                else
                {
                    count = 0;
                }

                return usuario;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
