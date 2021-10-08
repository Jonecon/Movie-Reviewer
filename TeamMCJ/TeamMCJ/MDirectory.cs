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
    public partial class MDirectory : Form
    {
        //Declaring Global Variables
        public static string movieID;
        private static int index = 0;
        private static string title = "";
        private static string imgPath = "";
        private static string id = "";

        public MDirectory()
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
                labelUserEmail.Text = MLogin.email;

                //Display all featured movie
                PopulateDirectory("");

            }
            catch (Exception eMDirectory)
            {
                //Display error
                MessageBox.Show("Error Movie Directory: " + eMDirectory.Message, "Error");
                this.Close();
            }
        }

        /// <summary>
        /// Go Back to ChooseDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                PopulateDirectory("");
                return;
            }

            //Get first 30 movie title, image path, and movie id from Movie table that is like 'search'
            PopulateDirectory(search);

            TextboxSearch.Clear();
        }

        /// <summary>
        /// Display all featured movie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, EventArgs e)
        {
            PopulateDirectory("");
        }

        /// <summary>
        /// Populate Directory list with given query
        /// </summary>
        private void PopulateDirectory(string _title)
        {
            //Clears all lists
            ListviewMovieDir.Items.Clear();
            ImgListMovieDir.Images.Clear();
            int indexd;
            index = 0;

            //get the movie collection and all document from the collection (initialize)
            var movieColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Movie");
            var movieDoc = movieColl.Find(new BsonDocument()).ToList();

            //if nothing to search
            if (_title == "")
            {
                //get all documents from the movie collection
                movieDoc = movieColl.Find(new BsonDocument()).ToList();
            }
            else
            {
                //var filter = Builders<BsonDocument>.Filter.Eq("title", _title);
                //movieDoc = movieColl.Find(filter).ToList();

                movieDoc = movieColl.Find("{ $text: { $search: \"title: " + _title + "\"} }").ToList();
            }

            //if it returns data
            if (movieDoc.Count != 0)
            {
                //for every document from the collection
                for (indexd = 0; indexd < movieDoc.Count; indexd++)
                {
                    id = movieDoc[indexd].GetElement("_id").Value.ToString();
                    title = movieDoc[indexd].GetElement("title").Value.ToString();
                    imgPath = "..\\..\\..\\" + movieDoc[indexd].GetElement("imagepath").Value.ToString();

                    //put movie titles and imgs to the listview/imagelist
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
                movieID = ListviewMovieDir.SelectedItems[0].SubItems[1].Text;

                //if movie id != -1
                if (!(movieID.Equals("-1")))
                {
                    //close FormODirectory and open FormOMovDets
                    Hide();
                    MMovDets movieDets = new MMovDets();
                    movieDets.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
