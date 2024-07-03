using MiceGymSystem.Models;
using Mysqlx.Notice;
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
    /// Lógica interna para ListCliente.xaml
    /// </summary>
    public partial class ListCliente : Window
    {
        Usuario usuario;
        Cliente selectedItem;
        public ListCliente(Usuario user)
        {
            InitializeComponent();
            CarregarLista(null);
            usuario = user;
            lbNomeUser.Text = usuario.Nome;
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgvList.SelectedItem != null)
            {
                selectedItem = (Cliente)this.dgvList.SelectedItem;
                CreateCliente form = new CreateCliente(usuario, "U", selectedItem);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione uma cliente antes de atualizar!");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Deseja realmente deletar o registro?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    selectedItem = (Cliente)this.dgvList.SelectedItem;
                    ClienteDAO clienteDAO = new ClienteDAO();
                    clienteDAO.Delete(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma cliente antes de deletar!");
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente voltar ao menu?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuBaseConsulta form = new MenuBaseConsulta(usuario);
                form.Show();
                this.Close();
            }
        }

        private void CarregarLista(string textoBusca)
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            dgvList.ItemsSource = clienteDAO.List(textoBusca);
        }

        private void tbBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            CarregarLista(tbBusca.Text);
        }
    }
}
