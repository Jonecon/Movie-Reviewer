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
    public partial class MReview : Form
    {
        //Declaring Global Variables
        List<PictureBox> ratingStars;
        MMovDets _dets;
        private static int index;
        private static bool hasReview = false;
        private static int rating = 0;
        private static string review = "";

        public MReview(MMovDets dets)
        {
            InitializeComponent();

            try
            {
                //Declaring and Setting Variable
                //--initializing components
                this.AcceptButton = buttonSubmit;
                _dets = dets;
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

                updateRating();
                updateReview();
            }
            catch (Exception eReview)
            {
                //show error
                MessageBox.Show("Error Movie Detail: " + eReview.Message, "Error");
                this.Close();
            }
        }

        /// <summary>
        /// Sets Rating and Review of the user to Selected Movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //if not empty string
            if (richTextBoxReview.Text.Trim() != "")
            {

                //set review
                setReview(richTextBoxReview.Text);
            }

            //update rating in the OMovDets
            _dets.updateRating();
            this.Close();
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
                            hasReview = true;
                            rating = int.Parse(raANDre[index].ToBsonDocument().GetValue("rating").ToString());
                        }

                        //break loop
                        index = raANDre.Count;
                    }
                }
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

            //get movie document with movie id == id
            var builder = Builders<BsonDocument>.Filter;

            //if users already gave a rating
            if (hasReview)
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
                var moviefilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(MDirectory.movieID));
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
                    //get movie document with movie id == id
                    moviefilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(MDirectory.movieID));

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

        private void setReview(string comment)
        {
            //get Movie collection
            var movieColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Movie");

            //create a builder
            var builder = Builders<BsonDocument>.Filter;

            //if users already gave a rating
            if (hasReview)
            {
                //where id == id and rating_review.user_email == user email
                var moviefilter = builder.Eq("_id", ObjectId.Parse(MDirectory.movieID)) & builder.Eq("rating_review.user_email", MLogin.email);

                //update the rating_review.rating
                var update = Builders<BsonDocument>.Update.Set("rating_review.$.rcomment", comment);
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
                            var update = Builders<BsonDocument>.Update.Set("rating_review.$.rcomment", comment);
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
                    newRating.Add("rcomment", comment);
                    newRating.Add("rating", 0);

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

        private void updateReview()
        {
            //get Movie collection
            var movieColl = MDB.dbTeammcj.GetCollection<BsonDocument>("Movie");

            //get movie document with movie id == id
            var moviefilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(MDirectory.movieID));
            var movieDoc = movieColl.Find(moviefilter).ToList();

            /// SETTING MOVIE COMMENT/S ///

            //if this document has actor element
            if (movieDoc[0].Contains("rating_review"))
            {
                //make the value into bsonarray
                var raANDre = movieDoc[0].GetElement("rating_review").Value.AsBsonArray;

                //for every item on the array
                for (index = 0; index < raANDre.Count; index++)
                {
                    //populate the listview
                    string email = raANDre[index].ToBsonDocument().GetValue("user_email").ToString();
                    review = raANDre[index].ToBsonDocument().GetValue("rcomment").ToString();

                    ListViewGroup reviewGroup = new ListViewGroup(email);
                    ListViewItem reviewItem = new ListViewItem(review);
                    reviewItem.Group = reviewGroup;

                    ListviewReview.Groups.Add(reviewGroup);
                    ListviewReview.Items.Add(reviewItem);
                }
            }
        }

        private void PictureBoxStar1_Click(object sender, EventArgs e)
        {
            setRating(1);
        }

        private void PictureBoxStar2_Click(object sender, EventArgs e)
        {
            setRating(2);
        }

        private void PictureBoxStar3_Click(object sender, EventArgs e)
        {
            setRating(3);
        }

        private void PictureBoxStar4_Click(object sender, EventArgs e)
        {
            setRating(4);
        }

        private void PictureBoxStar5_Click(object sender, EventArgs e)
        {
            setRating(5);
        }
    }
}
