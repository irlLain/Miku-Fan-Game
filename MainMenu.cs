using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMVS
{
    public partial class MainMenu : Form
    {
        private void DisplayLogin(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            //This allows the user to log in by displaying the login form
        }

        private void DisplayCreateUser(object sender, EventArgs e)
        {
            this.Hide();
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.Show();
            //This allows the user to create a new account by taking them to the create a user form
        }
    }
}
