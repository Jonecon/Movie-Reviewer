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
    public partial class OLogin : Form
    {
        //Declaring Global Variables
        public static string email;

        /// <summary>
        /// Load Login Form
        /// </summary>
        public OLogin()
        {
            InitializeComponent();

            //Initializing components
            this.AcceptButton = ButtonLogIn;

            //Hide the password visually and set its max chars to 25 and 50
            TextboxPassword.PasswordChar = '*';
            TextboxPassword.MaxLength = 25;
            TextboxEmail.MaxLength = 50;

            //Debugging
            //TextboxEmail.Text = "meecah.mec@gmail.com";
            //TextboxPassword.Text = "imPreti";
            //End Debugging
        }

        /// <summary>
        /// Initialises all textboxes to blank text
        /// Re focus to first text box
        /// </summary>
        public void initialiseTextBoxes()
        {
            //Foreach controls
            foreach (Control c in this.Controls)
            {
                //if its a textbox
                if (c is TextBox)
                {
                    //clears it
                    (c as TextBox).Clear();
                }
            }

            //Makes Email Textbox the focus
            TextboxEmail.Focus();
        }

        /// <summary>
        /// Check if email and password match
        /// if yes, display......
        /// if no, warn the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaring and Setting Variables
                email = TextboxEmail.Text.Trim();
                string password = TextboxPassword.Text.Trim();

                //If there's no email and/or password
                if (email.Equals("") || password.Equals(""))
                {
                    //Display Invalid Input Warning
                    MessageBox.Show("Enter Valid Username and Password", "Invalid Input");
                    initialiseTextBoxes();
                    return;
                }

                //Get all the users data with the email given
                OSQL.selectQuery("SELECT * FROM AppUser WHERE email ='" + email + "'");

                //If we have run into someone trying to inject
                //reader is null
                if (OSQL.reader == null)
                {
                    //Display Warning
                    MessageBox.Show("Sorry we can't log you in right now, try again later!", "Login Failed");
                    initialiseTextBoxes();
                    return;
                }

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //While there is rows to read
                    while (OSQL.reader.Read())
                    {
                        //If the username and password match
                        if (password.Equals(OSQL.reader.GetString(1)))
                        {
                            //closes FormChooseDB and open FormLogin
                            Hide(); 
                            ODirectory movieDir = new ODirectory();
                            movieDir.ShowDialog();
                            this.Close();
                        }
                        //if wrong password
                        else
                        {
                            MessageBox.Show("Incorrect login details. Try again.", "Login Fail");
                            initialiseTextBoxes();
                            return;
                        }
                    }
                }
                //if it did not return data
                else
                {
                    //Display Warning
                    MessageBox.Show("Incorrect login details. Try again.", "Login Fail");
                    initialiseTextBoxes();
                    return;
                }
            }
            catch (Exception eOLogin)
            {
                //Display error
                MessageBox.Show("Error Log-In: " + eOLogin.Message, "Error");
                this.Close();
            }
        }

        /// <summary>
        /// Clear all of the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            initialiseTextBoxes();
        }
    }
}
