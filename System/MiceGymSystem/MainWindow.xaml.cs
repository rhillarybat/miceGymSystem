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
            if (tbEmail.Text != "" && tbSenha.Password != "")
            {
                if (user.Login(tbEmail.Text, tbSenha.Password) == 1)
                {
                    MessageBox.Show("Acho!");
                }
                else
                {
                    MessageBox.Show("N Acho!");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }
    }
}
