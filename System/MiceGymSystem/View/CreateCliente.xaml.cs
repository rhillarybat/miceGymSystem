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
    /// Lógica interna para CreateCliente.xaml
    /// </summary>
    public partial class CreateCliente : Window
    {
        Usuario usuario;
        string tipo;
        Cliente cliente;
        public CreateCliente(Usuario user, string tipo, Cliente cliente)
        {
            InitializeComponent();

            usuario = user;
            this.tipo = tipo;   
            this.cliente = cliente;
            lbNomeUser.Text = usuario.Nome;

            if (tipo == "U")
            {
                tbNome.Text = cliente.Nome;
                tbEmail.Text = cliente.Email;
                tbCpf.Text = cliente.Cpf;
                tbTelefone.Text = cliente.Telefone;
                lbTitulo.Text = "Atualizar Cliente";
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

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNome.Text != "" && tbEmail.Text != "" && tbCpf.Text != "" && tbTelefone.Text != "")
                {
                    //Setando informações na tabela cliente
                    Cliente cliente = new Cliente();
                    cliente.Nome = tbNome.Text;
                    cliente.Email = tbEmail.Text;
                    cliente.Cpf = tbCpf.Text;
                    cliente.Telefone = tbTelefone.Text;

                    //Inserindo os Dados           
                    ClienteDAO clienteDAO = new ClienteDAO();
                    if (tipo == "I")
                    {
                        clienteDAO.Insert(cliente);
                    }
                    else
                    {
                        cliente.Id = this.cliente.Id;
                        clienteDAO.Update(cliente);
                    }
                    

                    tbNome.Clear();
                    tbEmail.Clear();
                    tbCpf.Clear();
                    tbTelefone.Clear();
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
    }
}
