using System.Collections.Generic; // Required for List<>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFBasics
{
    public partial class MainWindow : Window
    {
        private List<string> user_descriptions = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddUser()
        {
            
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);

                if (!string.IsNullOrWhiteSpace(txtBoxProfile.Text))
                {
                    user_descriptions.Add(txtBoxProfile.Text);
                }
                else {
                    user_descriptions.Add("No details provided.");
                };

                    txtName.Clear();
                txtBoxProfile.Clear();
                txtName.Focus();
            }
        }

        private void RemoveUser()
        {
            int selectedIndex = lstNames.SelectedIndex;

            if (selectedIndex != -1)
            {
                user_descriptions.RemoveAt(selectedIndex);

                lstNames.Items.RemoveAt(selectedIndex);

                txtProfile.Text = "";
            }
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

        private void ButtonRemoveName_Click(object sender, RoutedEventArgs e)
        {
            RemoveUser();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddUser();
            }
        }

        private void lstNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                RemoveUser();
            }
            else if (e.Key == Key.Enter) {
                ButtonGetDetails_Click(sender, e);
            }
        }

        private void ButtonGetDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lstNames.SelectedIndex != -1)
            {
                int index = lstNames.SelectedIndex;

                if (index < user_descriptions.Count)
                {
                    txtProfile.Text = user_descriptions[index];
                }
            }
        }

        private void txtBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                AddUser();
            }
        }

        private void lstNames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ButtonGetDetails_Click(sender, e);
        }

        private void ButtonDevCreds_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by Shayne McNeil January 11, 2026. You can contact me at shaynemcneil.dev or linkedin.com/shayne-mcneil");
        }
    }
}