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
    /// Lógica interna para MenuBaseConsulta.xaml
    /// </summary>
    public partial class MenuBaseConsulta : Window
    {
        Usuario usuario;
        public MenuBaseConsulta(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lbNomeUser.DataContext = usuario.Nome;
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

        private void btCliente_Click(object sender, RoutedEventArgs e)
        {
            ListCliente form = new ListCliente(usuario);
            form.Show();
            this.Close();
        }
    }
}