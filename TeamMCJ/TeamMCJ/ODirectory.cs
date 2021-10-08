using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamMCJ
{
    public partial class ODirectory : Form
    {
        //Declaring Global Variables
        public static int movieID;
        private static int index = 0;
        private static string title = "";
        private static string imgPath = "";
        private static string id = "";

        /// <summary>
        /// Load Movie Directory Form
        /// </summary>
        public ODirectory()
        {
            InitializeComponent();

            try
            {
                //Initializing components
                this.AcceptButton = buttonSearch;

                //Set ImageList and Listview Properties
                ImgListMovieDir.ImageSize = new Size(150, 200);
                ImgListMovieDir.ColorDepth = ColorDepth.Depth32Bit;

                //Show user their email
                labelUserEmail.Text = OLogin.email;

                //Display all featured movie
                PopulateDirectory("SELECT Title, movieimg, movie_id FROM Movie FETCH NEXT 30 ROWS ONLY");

            }
            catch(Exception eODirectory)
            {
                //Display error
                MessageBox.Show("Error Movie Directory: " + eODirectory.Message, "Error");
                this.Close();
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            //closes FormMDirectory and open FormChooseDB
            Hide();
            ChooseDB chooseDB = new ChooseDB();
            chooseDB.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Searches movie title from the movie table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            //set variables
            string search = TextboxSearch.Text.Trim();

            //if nothing to search
            if (search == "")
            {
                //Display all featured movie
                PopulateDirectory("SELECT Title, movieimg, movie_id FROM Movie FETCH NEXT 30 ROWS ONLY");
                return;
            }

            //Get first 30 movie title, image path, and movie id from Movie table that is like 'search'
            PopulateDirectory("SELECT Title, movieimg, Movie_id FROM Movie WHERE Title LIKE '" + search + "' FETCH NEXT 30 ROWS ONLY");

            TextboxSearch.Clear();
        }

        /// <summary>
        /// Display all featured movie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, EventArgs e)
        {
            PopulateDirectory("SELECT Title, movieimg, movie_id FROM Movie FETCH NEXT 30 ROWS ONLY");
        }

        /// <summary>
        /// Populate Directory list with given query
        /// </summary>
        private void PopulateDirectory(string selectQuery)
        {
            //Clears all lists
            ListviewMovieDir.Items.Clear();
            ImgListMovieDir.Images.Clear();
            index = 0;

            //do select query
            OSQL.selectQuery(selectQuery);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                //while there's still row to read
                while (OSQL.reader.Read())
                {
                    //put movie titles and imgs to the listview/imagelist
                    title = OSQL.reader.GetString(0);
                    imgPath = "..\\..\\..\\" + OSQL.reader.GetString(1);
                    id = OSQL.reader.GetValue(2).ToString();

                    ImgListMovieDir.Images.Add(Image.FromFile(imgPath));
                    ListViewItem movie = new ListViewItem(title, index);
                    movie.SubItems.Add(id);

                    ListviewMovieDir.Items.Add(movie);

                    index++;
                }
            }
            //if it did not return data
            else
            {
                string msg = "No Movies in the database to display";
                imgPath = "..\\..\\..\\Imgs\\imSad.png";
                id = "-1";

                ImgListMovieDir.Images.Add(Image.FromFile(imgPath));
                ListViewItem noData = new ListViewItem(msg, 0);
                noData.SubItems.Add(id);

                ListviewMovieDir.Items.Add(noData);
            }
        }

        /// <summary>
        /// Display Movie details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListviewMovieDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if there's no selected item
            if (ListviewMovieDir.SelectedItems.Count != 0)
            {
                //get movie id
                movieID = int.Parse(ListviewMovieDir.SelectedItems[0].SubItems[1].Text);

                //if movie id != -1
                if (!(movieID == -1))
                {
                    //close FormODirectory and open FormOMovDets
                    Hide();
                    OMovDets movieDets = new OMovDets();
                    movieDets.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
