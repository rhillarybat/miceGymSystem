using MiceGymSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiceGymSystem.Models
{
    internal class ClienteDAO
    {
        private static Conexao conn;  

        public ClienteDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Cliente cliente)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"INSERT INTO Cliente VALUES (null, '{cliente.Nome}', '{cliente.Email}', '{cliente.Cpf}', '{cliente.Telefone}');";

                int linesSave = query.ExecuteNonQuery();

                if (linesSave > 0)
                {
                    MessageBox.Show("Registro Salvo com Sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao salvar registro!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3007 : Contate o suporte!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
