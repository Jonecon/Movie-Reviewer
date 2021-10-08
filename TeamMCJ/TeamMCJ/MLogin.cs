using MongoDB.Bson;
using MongoDB.Driver;
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
    public partial class MLogin : Form
    {
        //Declaring Global Variables
        public static string email;

        public MLogin()
        {
            InitializeComponent();

            //Initializing components
            this.AcceptButton = ButtonLogIn;

            //Hide the password visually and set its max chars to 25 and 50
            TextboxPassword.PasswordChar = '*';
            TextboxPassword.MaxLength = 25;
            TextboxEmail.MaxLength = 50;

            //Debugging
            TextboxEmail.Text = "meecah.mec@gmail.com";
            TextboxPassword.Text = "imPreti";
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

                //get the user collection
                var usersColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Users");

                //get a document with email element == email
                var filter = Builders<BsonDocument>.Filter.Eq("email", email);
                var userDoc = usersColl.Find(filter).ToList();

                //if it returns data
                if (userDoc.Count != 0)
                {
                    if (userDoc[0].GetElement("password").Value.Equals(password))
                    {
                        //closes FormChooseDB and open FormLogin
                        Hide();
                        MDirectory movieDir = new MDirectory();
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
                //if it did not return data
                else
                {
                    //Display Warning
                    MessageBox.Show("Incorrect login details. Try again.", "Login Fail");
                    initialiseTextBoxes();
                    return;
                }
            }
            catch (Exception eMLogin)
            {
                //Display error
                MessageBox.Show("Error Log-In: " + eMLogin.Message, "Error");
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
