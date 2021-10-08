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
    public partial class OReview : Form
    {
        //Declaring Global Variables
        List<PictureBox> ratingStars;
        OMovDets _dets;
        private static bool hasReview = false;
        private static int rating = 0;
        private static string review = "";

        public OReview(OMovDets dets)
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
            if ( richTextBoxReview.Text.Trim() != "" ) {

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
        private void updateRating()
        {
            //Get the rating of the users for the movie selected
            OSQL.selectQuery("SELECT Rating FROM review WHERE email ='" + OLogin.email + "' AND movie_id =" + ODirectory.movieID);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                OSQL.reader.Read();

                hasReview = true;

                //if rating is not null
                if (!Convert.IsDBNull(OSQL.reader.GetValue(0)))
                {
                    //convert it into int
                    rating = int.Parse(OSQL.reader.GetValue(0).ToString());
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
        }

        /// <summary>
        /// Sets the rating of the movie given by the user
        /// </summary>
        /// <param name="rating"></param>
        private void setRating(int rating)
        {
            //if users already gave a rating
            if (hasReview)
            {
                //Update the movie rating of the users 
                OSQL.executeQuery("UPDATE review SET rating = " + rating + " WHERE email ='" + OLogin.email + "' AND movie_id =" + ODirectory.movieID);
            }
            else
            {
                //Add a movie rating for the user
                OSQL.executeQuery("insert into Review(Email, movie_id, rating) values('" + OLogin.email + "', " + ODirectory.movieID + ", " + rating + ")");
            }

            updateRating();
        }

        /// <summary>
        /// Populate the review list
        /// </summary>
        private void updateReview()
        {
            //Get all email and review of the selected movie
            OSQL.selectQuery("SELECT Email, RComment FROM review WHERE movie_id =" + ODirectory.movieID);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                //while there's still row to read
                while (OSQL.reader.Read())
                {
                    //populate the listview
                    string email = OSQL.reader.GetValue(0).ToString();
                    review = OSQL.reader.GetValue(1).ToString();

                    ListViewGroup reviewGroup = new ListViewGroup(email);
                    ListViewItem reviewItem = new ListViewItem(review);
                    reviewItem.Group = reviewGroup;

                    ListviewReview.Groups.Add(reviewGroup);
                    ListviewReview.Items.Add(reviewItem);
                }
            }
        }

        /// <summary>
        /// Update or insert a review for the selected movie from the user
        /// </summary>
        /// <param name="comment"></param>
        private void setReview(string comment)
        {
            //if users already gave a review
            if (hasReview)
            {
                //Update the movie review of the users
                OSQL.executeQuery("UPDATE review SET RComment = '" + comment + "' WHERE email ='" + OLogin.email + "' AND movie_id =" + ODirectory.movieID);
            }
            else
            {
                //Add a movie review for the user
                OSQL.executeQuery("insert into Review(Email, movie_id, RComment) values('" + OLogin.email + "', " + ODirectory.movieID + ", '" + comment + "')");
            }

            updateRating();
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
