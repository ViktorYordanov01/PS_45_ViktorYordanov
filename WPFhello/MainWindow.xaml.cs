﻿using System;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.ScrollIntoView(david);
            peopleListBox.SelectedItem = james;

        }

        private void btnHelloToSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            string inputValue = "Здрасти, ";
            StringBuilder names = new StringBuilder();

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox && ((TextBox)item).Text.Length >= 2)
                {
                    names.Append(((TextBox)item).Text + " ");
                }
            }

            inputValue += names.ToString() + " !!!\nТова е твоята първа програма на Visual Studio 2022!";

            MessageBox.Show(inputValue);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Сигурни ли сте, че искате да затворите приложението",
                "Сообщение",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information
            );

            e.Cancel = result is MessageBoxResult.Cancel;
        }
    }
}