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
    /// Lógica interna para ListFornecedor.xaml
    /// </summary>
    public partial class ListFornecedor : Window
    {
        Usuario usuario;
        Fornecedor selectedItem;
        public ListFornecedor(Usuario user)
        {
            InitializeComponent();
            CarregarLista(null);
            usuario = user;
            lbNomeUser.Text = usuario.Nome;
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

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgvList.SelectedItem != null)
            {
                selectedItem = (Fornecedor)this.dgvList.SelectedItem;
                CreateFornecedor form = new CreateFornecedor(usuario, "U", selectedItem);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor antes de atualizar!");
            }
            
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Deseja realmente deletar o registro?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    selectedItem = (Fornecedor)this.dgvList.SelectedItem;
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    fornecedorDAO.Delete(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma fornecedor antes de deletar!");
            }
        }
        private void CarregarLista(string textoBusca)
        {
            FornecedorDAO fornecedorDAO = new FornecedorDAO();

            dgvList.ItemsSource = fornecedorDAO.List(textoBusca);
        }

        private void tbBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            CarregarLista(tbBusca.Text);
        }
    }
}
