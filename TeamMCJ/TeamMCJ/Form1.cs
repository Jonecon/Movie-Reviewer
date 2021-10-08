using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamMCJ
{
    public partial class Form1 : Form
    {
        public static string email;

        public Form1()
        {
            InitializeComponent();
            //This line of code allows us to obscure the password visually and limit the max chars in textbox
            textBoxPassword.PasswordChar = '*';     //password character to hide password characters
            textBoxPassword.MaxLength = 20;         //max textbox character count
            textBoxUserName.MaxLength = 20;         //Added this because my username is limited to 20 characters too
            this.AcceptButton = buttonLogin;
        }

        /// <summary>
        /// Initialises all textboxes to blank text
        /// Re focus to first text box
        /// </summary>
        public void initialiseTextBoxes()
        {
            //goes through and clears all of the textboxes
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Clear();
                }
            }
            //makes next place user types the text box
            textBoxUserName.Focus();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Variables to be used: 1x bool, 4x string
            bool loggedIn = false;
            string username = "", password = "";


            try
            {
                //Try get the username and password.
                username = textBoxUserName.Text.Trim();
                password = textBoxPassword.Text.Trim();

                //If the password or username is missing ask the user to enter that information.
                if (username.Equals("") || password.Equals(""))
                {
                    //Give the user an error message and return from this method having done nothing.
                    MessageBox.Show("Please make sure you etner a Username and Password");
                    return;
                }
            }
            catch
            {
                //Error message, more useful when you are storing numbers etc. into the database.
                MessageBox.Show("Username or Password given is in an incorrect format.");
                return;
            }

            //Select everything from the Manager table.
            OSQL.selectQuery("SELECT * FROM AppUser");
            //If this query has returned data
            if (OSQL.read.HasRows)
            {
                //While there is rows to read.
                while (OSQL.read.Read())
                {
                    //If the username and password match the user input.
                    if (username.Equals(OSQL.read.GetString(0)) && password.Equals(OSQL.read.GetString(0)))
                    {
                        email = OSQL.read.GetString(0);
                        //Set login to true and break the loop.
                        loggedIn = true;
                        break;
                    }
                }
            }
            else
            {
                //The query returned no data, tell the user that that there are no logins.
                MessageBox.Show("No managers have been registered");
                return;
            }

            //if logged in display a success message
            if (loggedIn)
            {
                MessageBox.Show("You have successfully logged in as: " + username);
                //Since we are logged in Hide this window and show the LoggedIn form
                initialiseTextBoxes();
                //LoggedIn lg = new LoggedIn(this);
                //lg.Show();
                //this.Hide(); //Had to make this hide because I couldn't figure out how to change the shutdown 
                //            //to when the last form closes cause to switch from when first form closes
            }
            else
            {
                //message stating we couldn't log in
                MessageBox.Show("Login attempt unsuccessful! Please check details");
                textBoxUserName.Focus();
                return;
            }
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            initialiseTextBoxes();
        }
    }
}
