using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace HMVS
{
    public partial class LoginForm : Form
    {

        public static string User;
        public static string UsernameCall;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, EventArgs e)
        {

        }

        private void LoginUser()
        {
            string Username = "";
            Username = UsernameTextBox.Text;
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Angela\\Documents\\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter Sda = new SqlDataAdapter("Select Count(*) From Login where Username='" + Username + "' and Password ='" + PasswordTextBox.Text + "'", con);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            //This compares the users input to the data in the database

            if (dt.Rows[0][0].ToString() == "1")
            {
                User = Username;
                UsernameCall = User;
                this.Hide();
                MikuRoom mikuRoomForm = new MikuRoom(User);
                mikuRoomForm.Show();
                //If the usename and password are correct, it opens the main menu

            }
            else
            {
                MessageBox.Show("Incorrect username or password! Please try again!");
                //If the username and password don't match an error message is displayed
            }
        }
       
    }   

}
