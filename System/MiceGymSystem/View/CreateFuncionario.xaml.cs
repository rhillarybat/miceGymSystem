using MiceGymSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiceGymSystem.View
{
    /// <summary>
    /// Lógica interna para CreateFuncionario.xaml
    /// </summary>
    public partial class CreateFuncionario : Window
    {
        Usuario usuario;      
        public CreateFuncionario(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNome.Text != "" && tbEmail.Text != "" && tbCpf.Text != "" && tbTelefone.Text != "" && tbCargo.Text != "" && tbExp.Text != "")
                {
                    //Setando informações na tabela cliente
                    Funcionario funcionario = new Funcionario();
                    funcionario.Nome = tbNome.Text;
                    funcionario.Email = tbEmail.Text;
                    funcionario.Cpf = tbCpf.Text;
                    funcionario.Telefone = tbTelefone.Text;
                    funcionario.Cargo = tbCargo.Text;
                    funcionario.Experiencia = tbExp.Text;

                    //Inserindo os Dados           
                    FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                    funcionarioDAO.Insert(funcionario);

                    tbNome.Clear();
                    tbEmail.Clear();
                    tbCpf.Clear();
                    tbTelefone.Clear();
                    tbExp.Clear();
                    tbCargo.Clear();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3008 : Contate o suporte", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente cancelar o cadastro?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                tbNome.Clear();
                tbEmail.Clear();
                tbCpf.Clear();
                tbTelefone.Clear();
                MessageBox.Show("Campos limpos com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente voltar ao menu?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuBaseForm form = new MenuBaseForm(usuario);
                form.Show();
                this.Close();
            }
        }
    }
}
