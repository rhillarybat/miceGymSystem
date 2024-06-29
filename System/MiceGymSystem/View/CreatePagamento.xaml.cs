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
using static System.Net.Mime.MediaTypeNames;

namespace MiceGymSystem.View
{
    /// <summary>
    /// Lógica interna para CreatePagamento.xaml
    /// </summary>
    public partial class CreatePagamento : Window
    {
        Usuario usuario;
        public CreatePagamento(Usuario user)
        {
            InitializeComponent();
            usuario = user;
            DadosCb();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbValor.Text != "" && cbCliente.Text != "" && cbFormaPag.Text != "")
                {
                    //Setando informações na tabela cliente
                    if (cbCliente.SelectedItem is Cliente selectedItem){
                        Pagamento pagamento = new Pagamento();
                        pagamento.FormaPgto = cbFormaPag.SelectedItem.ToString();
                        pagamento.Data = dtData.SelectedDate;
                        pagamento.Cliente = selectedItem;
                        pagamento.Valor = Convert.ToDouble(tbValor.Text);

                        //Inserindo os Dados           
                        PagamentoDAO pagamentoDAO = new PagamentoDAO();
                        pagamentoDAO.Insert(pagamento);

                        tbValor.Clear();
                        //dtData.SelectedDate = new DateTime();
                        cbFormaPag.SelectedIndex = 0;
                        cbCliente.SelectedIndex = 0;
                    }
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
                tbValor.Clear();
                //dtData.SelectedDate = new DateTime();
                cbFormaPag.SelectedIndex = 0;
                cbCliente.SelectedIndex = 0;
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

        public void DadosCb()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            cbCliente.ItemsSource = clienteDAO.List(null);
            cbCliente.DisplayMemberPath = "Nome";
        }
    }
}
