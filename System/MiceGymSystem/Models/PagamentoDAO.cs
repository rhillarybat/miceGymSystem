using MiceGymSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiceGymSystem.Models
{
    internal class PagamentoDAO
    {
        private static Conexao conn;

        public PagamentoDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Pagamento pagamento)
        {
            try
            {
                
                var query = conn.Query();
                query.CommandText = $"INSERT INTO Pagamento VALUES (null, '{pagamento.FormaPgto}', '{pagamento.Valor}', '{pagamento.Data?.ToString("yyyy-MM-dd")}', '{pagamento.Cliente.Id}');";

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
                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro 3007 : Contate o suporte!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
