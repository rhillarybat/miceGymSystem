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
    /// Lógica interna para CreateEquipamentos.xaml
    /// </summary>
    public partial class CreateEquipamentos : Window
    {
        Usuario usuario;
        public CreateEquipamentos(Usuario user)
        {
            InitializeComponent();
            usuario = user;
            lbNomeUser.Text = usuario.Nome;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNome.Text != "" && tbCod.Text != "" && tbDesc.Text != "" && tbQuantidade.Text != "" && tbValor.Text != "")
                {
                    //Setando informações na tabela cliente
                    Equipamento equipamento = new Equipamento();
                    equipamento.Nome = tbNome.Text;
                    equipamento.Codigo = tbCod.Text;
                    equipamento.Descricao = tbDesc.Text;
                    equipamento.Quantidade = Convert.ToInt32(tbQuantidade.Text);
                    equipamento.Valor = Convert.ToDouble(tbValor.Text);

                    //Inserindo os Dados           
                    EquipamentoDAO equipamentoDAO = new EquipamentoDAO();
                    equipamentoDAO.Insert(equipamento);

                    tbNome.Clear();
                    tbCod.Clear();
                    tbDesc.Clear();
                    tbQuantidade.Clear();
                    tbValor.Clear();
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
                tbNome.Clear();
                tbCod.Clear();
                tbDesc.Clear();
                tbQuantidade.Clear();
                tbValor.Clear();
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
