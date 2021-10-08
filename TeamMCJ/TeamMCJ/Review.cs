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
    
    public partial class Review : Form
    {
        List<PictureBox> ratingStars = new List<PictureBox>();
        MovieDetail _dets;
        bool hasReview = false;
        int rating;
        string review = "";

        public Review(MovieDetail dets)
        {
            InitializeComponent();

            //set
            this.AcceptButton = buttonSubmit;
            _dets = dets;

            ratingStars.Add(pictureBoxStar1);
            ratingStars.Add(pictureBoxStar2);
            ratingStars.Add(pictureBoxStar3);
            ratingStars.Add(pictureBoxStar4);
            ratingStars.Add(pictureBoxStar5);

            pictureBoxStar1.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
            pictureBoxStar2.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
            pictureBoxStar3.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
            pictureBoxStar4.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
            pictureBoxStar5.ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";

            try
            {
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

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if ( richTextBoxReview.Text.Trim() != "" ) {

                setReview(richTextBoxReview.Text);
            }

            _dets.updateRating();
            this.Close();
        }

        private void updateRating()
        {
            //Get all the movie detail from Movie table
            OSQL.selectQuery("SELECT Rating FROM review WHERE email ='" + FormLogin.email + "' AND movie_id =" + MovieDir.movieID);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                OSQL.reader.Read();

                hasReview = true;
                //rating = int.Parse(OSQL.reader.GetValue(0).ToString());
                if (!Convert.IsDBNull(OSQL.reader.GetValue(0)))
                {
                    rating = int.Parse(OSQL.reader.GetValue(0).ToString());
                }

                for (int i = 0; i < rating; i++)
                {
                    ratingStars[i].ImageLocation = "..\\..\\..\\Imgs\\star_fill.png";
                }

                for (int i = rating; i < 5; i++)
                {
                    ratingStars[i].ImageLocation = "..\\..\\..\\Imgs\\star_empty.png";
                }
            }
        }

        private void updateReview()
        {
            //Get all the movie detail from Movie table
            OSQL.selectQuery("SELECT Email, RComment FROM review WHERE movie_id =" + MovieDir.movieID);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                //while there's still row to read
                while (OSQL.reader.Read())
                {
                    string email = OSQL.reader.GetValue(0).ToString();
                    review = OSQL.reader.GetValue(1).ToString();

                    //decimal reviewCount = review.Length;
                    //ListviewReview.TileSize = new Size(493, (int)(Math.Ceiling(reviewCount / 100)*15));

                    ListViewGroup reviewGroup = new ListViewGroup(email);
                    ListViewItem reviewItem = new ListViewItem(review);
                    reviewItem.Group = reviewGroup;

                    ListviewReview.Groups.Add(reviewGroup);
                    ListviewReview.Items.Add(reviewItem);
                }
            }
        }

        private void setRating(int rating)
        {
            if (hasReview)
            {
                //Get all the movie detail from Movie table
                OSQL.executeQuery("UPDATE review SET rating = " + rating + " WHERE email ='" + FormLogin.email + "' AND movie_id =" + MovieDir.movieID);
            }
            else
            {
                //Get all the movie detail from Movie table
                OSQL.executeQuery("insert into Review(Email, movie_id, rating) values('" + FormLogin.email + "', " + MovieDir.movieID + ", " + rating + ")");
            }

            updateRating();
        }

        private void setReview(string comment)
        {
            if (hasReview)
            {
                //Get all the movie detail from Movie table
                OSQL.executeQuery("UPDATE review SET RComment = '" + comment + "' WHERE email ='" + FormLogin.email + "' AND movie_id =" + MovieDir.movieID);
            }
            else
            {
                //Get all the movie detail from Movie table
                OSQL.executeQuery("insert into Review(Email, movie_id, RComment) values('" + FormLogin.email + "', " + MovieDir.movieID + ", '" + comment + "')");
            }

            updateRating();
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
