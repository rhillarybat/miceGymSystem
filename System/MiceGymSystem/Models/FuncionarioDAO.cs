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
    internal class FuncionarioDAO
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Funcionario funcionario)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"INSERT INTO Funcionario VALUES (null, '{funcionario.Nome}', '{funcionario.Cpf}', '{funcionario.Cargo}', '{funcionario.Email}', '{funcionario.Telefone}', '{funcionario.Experiencia}');";

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

        public List<Funcionario> List(string busca)
        {
            try
            {
                List<Funcionario> listFunc = new List<Funcionario>();

                var query = conn.Query();

                if (busca == null)
                {
                    query.CommandText = "SELECT * FROM Funcionario;";
                }
                else
                {
                    query.CommandText = $"SELECT * FROM Funcionario WHERE (nome_fun LIKE '%{busca}%');";
                }

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listFunc.Add(new Funcionario()
                    {
                        Id = reader.GetInt32("id_fun"),
                        Nome = DAOHelper.GetString(reader, "nome_fun"),
                        Cpf = DAOHelper.GetString(reader, "cpf_fun"),
                        Email = DAOHelper.GetString(reader, "email_fun"),
                        Telefone = DAOHelper.GetString(reader, "telefone_fun"),
                        Cargo = DAOHelper.GetString(reader, "cargo_fun"),
                        Experiencia = DAOHelper.GetString(reader, "experiencia_fun"),
                    });
                }

                return listFunc;
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
        public void Update(Funcionario funcionario)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"UPDATE Funcionario SET nome_fun = '{funcionario.Nome}', email_fun = '{funcionario.Email}', cpf_fun = '{funcionario.Cpf}', telefone_fun = '{funcionario.Telefone}', cargo_fun = '{funcionario.Cargo}', experiencia_fun = '{funcionario.Experiencia}' WHERE id_cli = '{funcionario.Id}';";

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

        public void Delete(Funcionario funcionario)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = $"DELETE FROM Funcionario WHERE id_cli = '{funcionario.Id}';";

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
