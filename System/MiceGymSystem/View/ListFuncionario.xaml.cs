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
    /// Lógica interna para ListFuncionario.xaml
    /// </summary>
    public partial class ListFuncionario : Window
    {
        Usuario usuario;
        Funcionario selectedItem;
        public ListFuncionario(Usuario user)
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
                selectedItem = (Funcionario)this.dgvList.SelectedItem;
                CreateFuncionario form = new CreateFuncionario(usuario, "U", selectedItem);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário antes de atualizar!");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Deseja realmente deletar o registro?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    selectedItem = (Funcionario)this.dgvList.SelectedItem;
                    FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                    funcionarioDAO.Delete(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma funcionário antes de deletar!");
            }
        }

        private void tbBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            CarregarLista(tbBusca.Text);
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
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

            dgvList.ItemsSource = funcionarioDAO.List(textoBusca);
        }
    }
}
