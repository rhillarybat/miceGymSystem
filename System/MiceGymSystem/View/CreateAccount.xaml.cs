﻿using MiceGymSystem.Models;
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
                if (tbNome.Text != "" && tbEmail.Text != "" && tbCpf.Text != "" && tbTelefone.Text != "" && tbSenha.Password != "") {
                    Usuario usuario = new Usuario();
                    usuario.Nome = tbNome.Text;
                    usuario.Email = tbEmail.Text;
                    usuario.Cpf = tbCpf.Text;
                    usuario.Telefone = tbTelefone.Text;
                    usuario.Senha = tbSenha.Password;

                    //Inserindo os Dados           
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    usuarioDAO.Insert(usuario);
                    tbNome.Clear();
                    tbEmail.Clear();
                    tbCpf.Clear();
                    tbTelefone.Clear();
                    tbSenha.Clear();
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
            if(result == MessageBoxResult.Yes)
            {
                tbNome.Clear();
                tbEmail.Clear();
                tbCpf.Clear();
                tbTelefone.Clear();
                tbSenha.Clear();
                MessageBox.Show("Campos limpos com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente voltar ao login?", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow form = new MainWindow();
                form.Show();
                this.Close();
            }
        }
    }
}
