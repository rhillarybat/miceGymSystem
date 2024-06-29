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
    /// Lógica interna para CreateFornecedor.xaml
    /// </summary>
    public partial class CreateFornecedor : Window
    {
        Usuario usuario;
        public CreateFornecedor(Usuario user)
        {
            InitializeComponent();
            usuario = user;
            lbNomeUser.Text = usuario.Nome;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbFantasia.Text != "" && tbEmail.Text != "" && tbCnpj.Text != "" && tbTelefone.Text != "" && tbEndereco.Text != "" && tbBairro.Text != "" && tbNum.Text != "")
                {
                    //Setando informações na tabela cliente
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.Fantasia = tbFantasia.Text;
                    fornecedor.Email = tbEmail.Text;
                    fornecedor.Cnpj = tbCnpj.Text;
                    fornecedor.Telefone = tbTelefone.Text;
                    fornecedor.Endereco = tbEndereco.Text;
                    fornecedor.Bairro = tbBairro.Text;
                    fornecedor.Numero = tbNum.Text;

                    //Inserindo os Dados           
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    fornecedorDAO.Insert(fornecedor);

                    tbFantasia.Clear();
                    tbEmail.Clear();
                    tbCnpj.Clear();
                    tbTelefone.Clear();
                    tbBairro.Clear();
                    tbEndereco.Clear();
                    tbNum.Clear();

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
                tbFantasia.Clear();
                tbEmail.Clear();
                tbCnpj.Clear();
                tbTelefone.Clear();
                tbBairro.Clear();
                tbEndereco.Clear();
                tbNum.Clear();
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
