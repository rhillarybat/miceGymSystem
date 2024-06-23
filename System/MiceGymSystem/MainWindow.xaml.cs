using MiceGymSystem.Models;
using MiceGymSystem.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiceGymSystem
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onTeste(object sender, MouseButtonEventArgs e)
        {
            
            MessageBox.Show("Teste");
        }

        private void btEntrar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioDAO user = new UsuarioDAO();
            Usuario objUser = new Usuario();

            if (tbEmail.Text != "" && tbSenha.Password != "")
            {
                string email = tbEmail.Text;
                string senha = tbSenha.Password;
                objUser = user.Login(email, senha);

                if (user.count == 1)
                {
                    MenuBaseForm form = new MenuBaseForm(objUser);
                    form.Show();
                    this.Close();
                }
                else
                {                    
                    MessageBox.Show("Usuário ou Senha incorretos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {               
                MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btNewAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btNewAccount_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            CreateAccount form = new CreateAccount();
            form.Show();
            this.Close();
        }
    }
}
