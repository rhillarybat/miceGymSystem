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
    /// Lógica interna para CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Setando informações na tabela cliente
                Usuario usuario = new Usuario();
                usuario.Nome = tbNome.Text;
                usuario.Email = tbEmail.Text;
                usuario.Cpf = tbCpf.Text;
                usuario.Telefone = tbNome.Text;
                usuario.Senha = tbSenha.Password;

                //Inserindo os Dados           
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.Insert(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3008 : Contate o suporte");
            }
        }
    }
}
