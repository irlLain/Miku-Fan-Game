using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMVS
{
    public partial class CreateUserForm : Form
    {
        public static string User;
       
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void CreateUserClick(object sender, EventArgs e)
        {
            string valid = "false";
            CheckFields(valid);

            if (valid == "true")
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Morgan\\Documents\\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30;");

                SqlCommand cmd = new SqlCommand(@"INSERT Login(USERNAME,PASSWORD) VALUES ('" + UsernameTextBox.Text + "', '" + PasswordTextBox.Text + "')", con);
                //This is the command to add user data to the database
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd2 = new SqlCommand(@"INSERT dbo.Inventory([USER], [LEEK], [VEGETABLEJUICE], [PIZZA], [MIKUCHARM], [LIGHTSTICK], [FIGURE]) VALUES ('" + UsernameTextBox.Text + "', ' 0 ', ' 0 ', ' 0 ', ' 0 ', ' 0 ', ' 0 ')", con);
                //This is the command to add inventory data to the database
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Created User: " + User);
                this.Hide();
                MikuRoom mikuRoomForm = new MikuRoom(User);
                mikuRoomForm.Show();
            }
        }

        private void CheckFields(string valid)
        {
            String Username = "";
            String Password = "";
            String ConfirmPassword = "";
            
            //These are the needed variable for the form

            Username = UsernameTextBox.Text;
            Password = PasswordTextBox.Text;
            ConfirmPassword = ConfirmPasswordTextbox.Text;
            ///These lines save the users inputs into the necassary values

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            ///Checks to see if the textboxes have been filled
            {
                MessageBox.Show("Error! A field is empty!");
                valid = "false";
            }
            else if (Password != ConfirmPassword)
            ///Checks to see if both usernames are the same
            {
                MessageBox.Show("Error! Passwords do not match!");
                valid = "false";
            }

            return;
        }
    }
}
