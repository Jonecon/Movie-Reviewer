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
    public partial class MMovDets : Form
    {
        //Declaring Global Variables
        private static List<PictureBox> ratingStars;
        private static ObjectId oid;
        private static int index;
        private static bool hasRating = false;
        private static int rating = 0;

        public MMovDets()
        {
            InitializeComponent();

            try
            {
                //Declaring and Setting Variable
                //--form setting
                ListviewDandP.FullRowSelect = true;
                listViewScreenWriter.FullRowSelect = true;
                listViewActors.FullRowSelect = true;
                //--adding stars to the list
                ratingStars = new List<PictureBox>();
                ratingStars.Add(pictureBoxStar1);
                ratingStars.Add(pictureBoxStar2);
                ratingStars.Add(pictureBoxStar3);
                ratingStars.Add(pictureBoxStar4);
                ratingStars.Add(pictureBoxStar5);
                //--setting stars their default images
                pictureBoxStar1.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
                pictureBoxStar2.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
                pictureBoxStar3.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
                pictureBoxStar4.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
                pictureBoxStar5.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
                //--variables to use
                string name = "";
                string role = "";
                //initialize
                labelTitle.Text = "";
                labelSummary.Text = "";
                labelReleaseDate.Text = "";
                labelDuration.Text = "";
                labelAvg.Text = "";

                //set the rating
                updateRating();

                //get all the collection
                var movieColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Movie");
                var genreColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Genre");
                var crewColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Crew");

                //get movie document with movie id == id
                var moviefilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(MDirectory.movieID));
                var movieDoc = movieColl.Find(moviefilter).ToList();

                //if it returns data
                if (movieDoc.Count != 0)
                {
                    /// SETTING MOVIE TITLE, SUMMARY, RELEASEDATE, DURATION, AND IMAGEPATH ///

                    labelTitle.Text = movieDoc[0].GetElement("title").Value.ToString();
                    labelSummary.Text = movieDoc[0].GetElement("summary").Value.ToString();
                    labelReleaseDate.Text = DateTime.Parse(movieDoc[0].GetElement("releasedate").Value.ToString()).ToString("dd/MMMM/yyyy");
                    labelDuration.Text = movieDoc[0].GetElement("movieduration").Value.ToString() + " minutes";
                    pictureBoxMovie.ImageLocation = "..\\..\\..\\" + movieDoc[0].GetElement("imagepath").Value.ToString();

                    /// SETTING MOVIE GENRE ///

                    //if this document has genre element
                    if (movieDoc[0].Contains("genre"))
                    {
                        //make the value into bsonarray
                        var genre = movieDoc[0].GetElement("genre").Value.AsBsonArray;

                        //for every item on the array
                        for (index = 0; index < genre.Count; index++)
                        {
                            //get the value of genre_id
                            oid = ObjectId.Parse(genre[index].ToBsonDocument().GetValue("genre_id").ToString());

                            //get genre document with genre id == id
                            var genrefilter = Builders<BsonDocument>.Filter.Eq("_id", oid);
                            var genreDoc = genreColl.Find(genrefilter).ToList();

                            //displaying genre
                            if (index == 0)
                            {
                                labelGenre.Text = genreDoc[0].GetElement("gname").Value.ToString();
                            }
                            else
                            {
                                labelGenre.Text += ", " + genreDoc[0].GetElement("gname").Value.ToString();
                            }
                        }
                    }

                    /// SETTING MOVIE PRODUCER/S AND DIRECTOR/S ///

                    //if this document has prodANDdir element
                    if (movieDoc[0].Contains("prodANDdir"))
                    {
                        //make the value into bsonarray
                        var pandds = movieDoc[0].GetElement("prodANDdir").Value.AsBsonArray;

                        //for every item on the array
                        for (index = 0; index < pandds.Count; index++)
                        {
                            //get the value of crew_id
                            oid = ObjectId.Parse(pandds[index].ToBsonDocument().GetValue("crew_id").ToString());

                            //get crew document with crew id == id
                            var crewfilter = Builders<BsonDocument>.Filter.Eq("_id", oid);
                            var crewDoc = crewColl.Find(crewfilter).ToList();

                            //populate the listview
                            name = crewDoc[0].GetElement("FirstName").Value.ToString();
                            name += " " + crewDoc[0].GetElement("LastName").Value.ToString();
                            role = pandds[index].ToBsonDocument().GetValue("pname").ToString();

                            ListViewItem dANDp = new ListViewItem(name, 0);
                            dANDp.SubItems.Add(role);

                            ListviewDandP.Items.Add(dANDp);
                        }
                    }

                    /// SETTING MOVIE SCREENWRITER/S ///

                    //if this document has screenwriter element
                    if (movieDoc[0].Contains("screenwriter"))
                    {
                        //make the value into bsonarray
                        var screenwriters = movieDoc[0].GetElement("screenwriter").Value.AsBsonArray;

                        //for every item on the array
                        for (index = 0; index < screenwriters.Count; index++)
                        {
                            //get the value of crew_id
                            oid = ObjectId.Parse(screenwriters[index].ToBsonDocument().GetValue("crew_id").ToString());

                            //get crew document with crew id == id
                            var crewfilter = Builders<BsonDocument>.Filter.Eq("_id", oid);
                            var crewDoc = crewColl.Find(crewfilter).ToList();

                            //populate the listview
                            name = crewDoc[0].GetElement("FirstName").Value.ToString();
                            name += " " + crewDoc[0].GetElement("LastName").Value.ToString();

                            ListViewItem writer = new ListViewItem(name, 0);

                            listViewScreenWriter.Items.Add(writer);
                        }
                    }

                    /// SETTING MOVIE ACTOR/S ///

                    //if this document has actor element
                    if (movieDoc[0].Contains("actor"))
                    {
                        //make the value into bsonarray
                        var actors = movieDoc[0].GetElement("actor").Value.AsBsonArray;

                        //for every item on the array
                        for (index = 0; index < actors.Count; index++)
                        {
                            //get the value of crew_id
                            oid = ObjectId.Parse(actors[index].ToBsonDocument().GetValue("crew_id").ToString());

                            //get crew document with crew id == id
                            var crewfilter = Builders<BsonDocument>.Filter.Eq("_id", oid);
                            var crewDoc = crewColl.Find(crewfilter).ToList();

                            //populate the listview
                            name = crewDoc[0].GetElement("FirstName").Value.ToString();
                            name += " " + crewDoc[0].GetElement("LastName").Value.ToString();
                            role = actors[index].ToBsonDocument().GetValue("char_name").ToString();

                            ListViewItem actor = new ListViewItem(name, 0);
                            actor.SubItems.Add(role);

                            listViewActors.Items.Add(actor);
                        }
                    }
                }
            }
            catch (Exception eMmovDets)
            {
                //show error
                MessageBox.Show("Error Movie Detail: " + eMmovDets.Message, "Error");
                this.Close();
            }
        }

        /// <summary>
        /// Updates the image of the stars according to the user's rating
        /// </summary>
        public void updateRating()
        {
            //get Movie collection
            var movieColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Movie");

            //get movie document with movie id == id
            var moviefilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(MDirectory.movieID));
            var movieDoc = movieColl.Find(moviefilter).ToList();

            List<int> ratings = new List<int>();

            /// SETTING MOVIE RATING ///
            
            //if this document has rating_review element
            if (movieDoc[0].Contains("rating_review"))
            {
                //make the value into bsonarray
                var raANDre = movieDoc[0].GetElement("rating_review").Value.AsBsonArray;

                //for every item on the array
                for (index = 0; index < raANDre.Count; index++)
                {
                    //find the users email
                    var email = raANDre[index].ToBsonDocument().GetValue("user_email").ToString();
                    if (email.CompareTo(MLogin.email) == 0)
                    {
                        //if this document has rating element
                        if (raANDre[index].ToBsonDocument().Contains("rating"))
                        {
                            hasRating = true;
                            rating = int.Parse(raANDre[index].ToBsonDocument().GetValue("rating").ToString());
                        }
                    }

                    //if this document has rating element
                    if (raANDre[index].ToBsonDocument().Contains("rating"))
                    {
                        //add to the list
                        ratings.Add(int.Parse(raANDre[index].ToBsonDocument().GetValue("rating").ToString()));
                    }  
                }

                //if list is not empty
                if (ratings.Count != 0)
                {
                    //get the average
                    labelAvg.Text = Queryable.Average(ratings.AsQueryable()).ToString("##");
                }
            }
            else
            {
                rating = 0;
                hasRating = false;
            }

            //change the star to coloured images == to rating
            for (int i = 0; i < rating; i++)
            {
                ratingStars[i].ImageLocation = "..\\..\\..\\Imgs\\star_fill.png";
            }

            //change the rest to non coloured images
            for (int i = rating; i < 5; i++)
            {
                ratingStars[i].ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
            }
        }

        /// <summary>
        /// Sets the rating of the movie given by the user
        /// </summary>
        /// <param name="rating"></param>
        private void setRating(int rating)
        {
            //get Movie collection
            var movieColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Movie");

            //create a builder
            var builder = Builders<BsonDocument>.Filter;

            //if users already gave a rating
            if (hasRating)
            {
                //where id == id and rating_review.user_email == user email
                var moviefilter = builder.Eq("_id", ObjectId.Parse(MDirectory.movieID)) & builder.Eq("rating_review.user_email", MLogin.email);

                //update the rating_review.rating
                var update = Builders<BsonDocument>.Update.Set("rating_review.$.rating", rating);
                var result = movieColl.UpdateOne(moviefilter, update);
            }
            //if havnt
            else
            {
                //get movie document with movie id == id
                var moviefilter = builder.Eq("_id", ObjectId.Parse(MDirectory.movieID));
                var movieDoc = movieColl.Find(moviefilter).ToList();

                //if this document already has rating_review element
                if (movieDoc[0].Contains("rating_review"))
                {
                    //make the value into bsonarray
                    var raANDre = movieDoc[0].GetElement("rating_review").Value.AsBsonArray;

                    //for every item on the array
                    for (index = 0; index < raANDre.Count; index++)
                    {
                        //find the users email
                        var email = raANDre[index].ToBsonDocument().GetValue("user_email").ToString();
                        if (email.CompareTo(MLogin.email) == 0)
                        {
                            //where id == id and rating_review.user_email == user email
                            moviefilter = builder.Eq("_id", ObjectId.Parse(MDirectory.movieID)) & builder.Eq("rating_review.user_email", MLogin.email);

                            //update document
                            var update = Builders<BsonDocument>.Update.Set("rating_review.$.rating", rating);
                            var result = movieColl.UpdateOne(moviefilter, update, new UpdateOptions { IsUpsert = true });

                            //break loop
                            index = raANDre.Count;
                        }
                    }
                }
                //if this document doesnt have rating_review element
                else
                {
                    //create a bsondocument with user_email, rcomment, and rating element
                    BsonDocument newRating = new BsonDocument();
                    newRating.Add("user_email", MLogin.email);
                    newRating.Add("rcomment", "");
                    newRating.Add("rating", rating);

                    //create an bsonarray and add the bsondocument
                    BsonArray newArray = new BsonArray();
                    newArray.Add(newRating);

                    //update document
                    var update = Builders<BsonDocument>.Update.Set("rating_review", newArray);
                    var result = movieColl.UpdateOne(moviefilter, update, new UpdateOptions { IsUpsert = true });
                }
            }

            updateRating();
        }

        /// <summary>
        /// Closes FormOMovDets and open FormODirectory 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Hide();
            MDirectory movieDir = new MDirectory();
            movieDir.ShowDialog();
            this.Close();
        }

        private void ButtonReview_Click(object sender, EventArgs e)
        {

            MReview movieReview = new MReview(this);
            movieReview.ShowDialog();
        }

        /// <summary>
        /// Set rating to 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStar1_Click(object sender, EventArgs e)
        {
            setRating(1);
        }

        /// <summary>
        /// Set rating to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStar2_Click(object sender, EventArgs e)
        {
            setRating(2);
        }

        /// <summary>
        /// Set rating to 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStar3_Click(object sender, EventArgs e)
        {
            setRating(3);
        }

        /// <summary>
        /// Set rating to 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStar4_Click(object sender, EventArgs e)
        {
            setRating(4);
        }

        /// <summary>
        /// Set rating to 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStar5_Click(object sender, EventArgs e)
        {
            setRating(5);
        }
    }
}
