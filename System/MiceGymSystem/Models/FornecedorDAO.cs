using MiceGymSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiceGymSystem.Models
{
    internal class FornecedorDAO
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Fornecedor fornecedor)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"INSERT INTO Fornecedor VALUES (null, '{fornecedor.Fantasia}', '{fornecedor.Cnpj}', '{fornecedor.Endereco}', '{fornecedor.Bairro}', '{fornecedor.Email}', '{fornecedor.Telefone}', '{fornecedor.Numero}');";

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
