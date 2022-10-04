using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMVS
{
    public partial class MikuRoom : Form
    {
        public static int MikuPoints;
        public static int AffinityLevel;
        public static int AffinityPoints;
        public MikuRoom(string User)
        {
            InitializeComponent();
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Angela\\Documents\\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30;");
            DataTable dtbl = new DataTable();
            string query = "SELECT MIKUPOINTS FROM Login WHERE USERNAME = '" + User + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sqlcon.Open();
            sda.Fill(dtbl);
            sqlcon.Close();
            MikuPoints = (int)dtbl.Rows[0][0];
            MikuPointsNumberLabel.Text = Convert.ToString(MikuPoints);
            //Displays the users currency at the top of the form

            AffinityLevelCalculation(User);
            AffinityLevelLabel.Text = Convert.ToString(AffinityLevel);
            AffinityLevelBar.Value = AffinityLevel;
            //Displays the affinity progress on a progress bar

            switch (MikuMood)
            {
                case "Neutral":
                    NeutralSprite.Show();
                    HappySprite.Hide();
                    SadSprite.Hide();
                    AngrySprite.Hide();
                    break;
                case "Happy":
                    HappySprite.Show();
                    SadSprite.Hide();
                    AngrySprite.Hide();
                    NeutralSprite.Hide();
                    break;
                case "Sad":
                    SadSprite.Show();
                    AngrySprite.Hide();
                    NeutralSprite.Hide();
                    HappySprite.Hide();
                    break;
                case "Angry":
                    AngrySprite.Show();
                    NeutralSprite.Hide();
                    HappySprite.Hide();
                    SadSprite.Hide();
                    break;

            }
            //Sprites change depending on Mikus mood
        }

        private void TalkButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TalkForm TalkMenu = new TalkForm(User);
            TalkMenu.Show();
            //Displays the talk form when the button is clicked
        }
        private void PlayGameButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameMenuForm Gamemenu = new GameMenuForm();
            Gamemenu.Show();
            ///Displays the game menu when the user clicks the play games button           
        }

        private void ViewInventoryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryForm inventoryForm = new InventoryForm(User);
            inventoryForm.Show();
            ///This takes the user to the inventory menu when the inventory button is clicked
        }
        private void ShopButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShopForm shopForm = new ShopForm(User);
            shopForm.Show();
            ///This displays the shop form when the shop button is clicked
        }

        public static void AffinityLevelCalculation(string User)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Angela\\Documents\\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30;");
            DataTable dtbl = new DataTable();
            string query = "SELECT AFFINITYPOINTS FROM Login WHERE USERNAME = '" + User + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sqlcon.Open();
            sda.Fill(dtbl);
            sqlcon.Close();
            AffinityPoints = (int)dtbl.Rows[0][0];

            if (AffinityPoints < 250)
            {
                AffinityLevel = 0;
            }
            else if (300 > AffinityPoints && AffinityPoints >= 250)
            {
                AffinityLevel = 1;
            }
            else if (400 > AffinityPoints && AffinityPoints >= 300)
            {
                AffinityLevel = 2;
            }
            else if (600 > AffinityPoints && AffinityPoints >= 400)
            {
                AffinityLevel = 3;
            }
            else if (900 > AffinityPoints && AffinityPoints >= 600)
            {
                AffinityLevel = 4;
            }
            else if (1300 > AffinityPoints && AffinityPoints >= 900)
            {
                AffinityLevel = 5;
            }
            else if (1800 > AffinityPoints && AffinityPoints >= 1300)
            {
                AffinityLevel = 6;
            }
            else if (2500 > AffinityPoints && AffinityPoints >= 1800)
            {
                AffinityLevel = 7;
            }
            else if (4000 > AffinityPoints && AffinityPoints >= 2500)
            {
                AffinityLevel = 8;
            }
            else if (5000 > AffinityPoints && AffinityPoints >= 4000)
            {
                AffinityLevel = 9;
            }
            else if (AffinityPoints >= 5000)
            {
                AffinityLevel = 10;
            }
        }
        private void SaveExitButton_Click(object sender, EventArgs e, string User)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Angela\\Documents\\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30;");
            //UPDATE MIKUPOINTS, AFFINITYLEVEL, AFFINITYPOINTS VALUES ('" + MikuPoints + "', '" + AffinityLevel + "','"+AffinityPoints+ "' FROM Login WHERE USERNAME = '" + User + "')
            SqlCommand cmd = new SqlCommand(@"UPDATE Login SET MIKUPOINTS = '" + MikuPoints + "', AFFINITYLEVEL = '" + AffinityLevel + "', AFFINITYPOINTS = '" + AffinityPoints + "' WHERE USERNAME = '" + User + "'", con);
            //This is the command to updare the user data to the database when they want to quit the program
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Application.Exit();
        }
    }
}
