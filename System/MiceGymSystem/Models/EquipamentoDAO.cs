using MiceGymSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiceGymSystem.Models
{
    internal class EquipamentoDAO
    {
        private static Conexao conn;

        public EquipamentoDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Equipamento equipamento)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"INSERT INTO Equipamentos VALUES (null, '{equipamento.Nome}', '{equipamento.Valor}', '{equipamento.Quantidade}', '{equipamento.Descricao}', '{equipamento.Codigo}');";

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
