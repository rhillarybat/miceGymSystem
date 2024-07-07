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

        public List<Cliente> List(string busca)
        {
            try
            {
                List<Cliente> listCli = new List<Cliente>();

                var query = conn.Query();

                if (busca == null)
                {
                    query.CommandText = "SELECT * FROM Cliente;";
                }
                else
                {
                    query.CommandText = $"SELECT * FROM Cliente WHERE (nome_cli LIKE '%{busca}%');";
                }

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listCli.Add(new Cliente()
                    {
                        Id = reader.GetInt32("id_cli"),
                        Nome = DAOHelper.GetString(reader, "nome_cli"),
                        Cpf = DAOHelper.GetString(reader, "cpf_cli"),
                        Email = DAOHelper.GetString(reader, "email_cli"),
                        Telefone = DAOHelper.GetString(reader, "telefone_cli"),
                    });
                }

                return listCli;
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
        public void Update(Cliente cliente)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"UPDATE Cliente SET nome_cli = '{cliente.Nome}', email_cli = '{cliente.Email}', cpf_cli = '{cliente.Cpf}', telefone_cli = '{cliente.Telefone}' WHERE id_cli = '{cliente.Id}';";
                
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

        public void Delete(Cliente cliente)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"DELETE FROM Cliente WHERE id_cli = '{cliente.Id}';";

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
