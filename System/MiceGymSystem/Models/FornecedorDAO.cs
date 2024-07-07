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

        public List<Fornecedor> List(string busca)
        {
            try
            {
                List<Fornecedor> listFor = new List<Fornecedor>();

                var query = conn.Query();

                if (busca == null)
                {
                    query.CommandText = "SELECT * FROM Fornecedor;";
                }
                else
                {
                    query.CommandText = $"SELECT * FROM Fornecedor WHERE (fantasia_forn LIKE '%{busca}%');";
                }

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listFor.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_forn"),
                        Fantasia = DAOHelper.GetString(reader, "fantasia_forn"),
                        Cnpj = DAOHelper.GetString(reader, "cnpj_forn"),
                        Email = DAOHelper.GetString(reader, "email_forn"),
                        Telefone = DAOHelper.GetString(reader, "telefone_forn"),
                        Endereco = DAOHelper.GetString(reader, "endereco_forn"),
                        Bairro = DAOHelper.GetString(reader, "bairro_forn"),
                        Numero = DAOHelper.GetString(reader, "numero_forn"),
                    });
                }

                return listFor;
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
        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"UPDATE Fornecedor SET fantasia_forn = '{fornecedor.Fantasia}', email_forn = '{fornecedor.Email}', cnpj_forn = '{fornecedor.Cnpj}', telefone_forn = '{fornecedor.Telefone}', endereco_forn = '{fornecedor.Endereco}', bairro_forn = '{fornecedor.Bairro}', numero_forn = '{fornecedor.Numero}' WHERE id_cli = '{fornecedor.Id}';";

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

        public void Delete(Fornecedor fornecedor)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"DELETE FROM Fornecedor WHERE id_cli = '{fornecedor.Id}';";

                int linesSave = query.ExecuteNonQuery();

                if (linesSave > 0)
                {
                    MessageBox.Show("Registro deletado com Sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao deletar registro!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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
