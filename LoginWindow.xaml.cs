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

namespace ISIPGorlanovWPF
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = Lists.usersBDL.FirstOrDefault(u =>
                u.Email == txtEmail.Text.Trim() &&
                u.Password == txtPassword.Password &&
                u.IsActive == true);

            if (user != null)
            {
                App.CurrentUserId = user.ID;
                App.CurrentRoleId = user.RoleID;
                App.CurrentFullName = user.FullName;

                new MainWindow().Show();
                Close();
            }
            else
                MessageBox.Show("Неверный email или пароль");
        }
    }
}
