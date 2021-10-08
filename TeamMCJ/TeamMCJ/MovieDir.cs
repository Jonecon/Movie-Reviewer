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
    public partial class MovieDir : Form
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
        public MovieDir()
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
                labelUserEmail.Text = FormLogin.email;

                //Display all featured movie
                LoadHomeButton();

            }
            catch(Exception eMovieDir)
            {
                //Display error
                MessageBox.Show("Error Movie Directory: " + eMovieDir.Message, "Error");
                this.Close();
            }
        }

        private void LoadHomeButton()
        {
            ListviewMovieDir.Items.Clear();
            ImgListMovieDir.Images.Clear();
            index = 0;

            //Get all the movie title from Movie table
            OSQL.selectQuery("SELECT Title, movieimg, movie_id FROM Movie FETCH NEXT 30 ROWS ONLY");

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                //while there's still row to read
                while (OSQL.reader.Read())
                {
                    //put movie titles and imgs in the listview
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
            //if it did not returns data
            else
            {
                String msg = "No Movies in the database to display";
                ListViewItem noData = new ListViewItem(msg, 0);

                ListviewMovieDir.Items.Add(noData);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string search = TextboxSearch.Text;

            if (search == "")
            {
                LoadHomeButton();
                return;
            }

            //Get all the movie title from Movie table
            OSQL.selectQuery("SELECT Title, movieimg, Movie_id FROM Movie WHERE Title LIKE '"+ search +"' FETCH NEXT 30 ROWS ONLY");

            ListviewMovieDir.Items.Clear();
            ImgListMovieDir.Images.Clear();
            index = 0;

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                //while there's still row to read
                while (OSQL.reader.Read())
                {
                    //put movie titles and imgs in the listview
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
            //if it did not returns data
            else
            {
                String msg = "No Movies in the database to display";
                imgPath = "..\\..\\..\\Imgs\\imSad.png";
                id = "-1";

                ImgListMovieDir.Images.Add(Image.FromFile(imgPath));
                ListViewItem noData = new ListViewItem(msg, 0);
                noData.SubItems.Add(id);

                ListviewMovieDir.Items.Add(noData);
            }

            TextboxSearch.Clear();
        }

        private void ListviewMovieDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListviewMovieDir.SelectedItems.Count != 0)
            {
                movieID = int.Parse(ListviewMovieDir.SelectedItems[0].SubItems[1].Text);

                if (!(movieID == -1))
                {
                    //closes FormLogin and open FormMovieDir
                    Hide();
                    MovieDetail movieDets = new MovieDetail();
                    movieDets.ShowDialog();
                    //this.Close();
                }
            }
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            LoadHomeButton();
        }
    }
}
