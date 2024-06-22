using MiceGymSystem.Database;
using MySql.Data.MySqlClient;
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

        public int Login(string email, string senha)
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
                }
                else
                {
                    count = 0;
                }

                return count;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
