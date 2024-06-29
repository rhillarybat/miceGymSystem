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
using MiceGymSystem.Models;

namespace MiceGymSystem.View
{
    /// <summary>
    /// Lógica interna para MenuBaseForm.xaml
    /// </summary>
    /// 
    public partial class MenuBaseForm : Window
    {
        Usuario usuario;
        public MenuBaseForm(Usuario user)
        {
            InitializeComponent();
            usuario = user;

            lbNomeUser.Text = usuario.Nome;
        }

        private void btCliente_Click(object sender, RoutedEventArgs e)
        {
            CreateCliente form = new CreateCliente(usuario);
            form.Show();
            this.Close();
        }

        private void btFornecedor_Click(object sender, RoutedEventArgs e)
        {
            CreateFornecedor form = new CreateFornecedor(usuario);
            form.Show();
            this.Close();
        }

        private void btPagamento_Click(object sender, RoutedEventArgs e)
        {
            CreatePagamento form = new CreatePagamento(usuario);
            form.Show();
            this.Close();
        }

        private void btFuncionario_Click(object sender, RoutedEventArgs e)
        {
            CreateFuncionario form = new CreateFuncionario(usuario);
            form.Show();
            this.Close();
        }

        private void btEquipamento_Click(object sender, RoutedEventArgs e)
        {
            CreateEquipamentos form = new CreateEquipamentos(usuario);
            form.Show();
            this.Close();
        }
    }
}
