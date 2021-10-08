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
    public partial class OMovDets : Form
    {
        //Declaring Global Variables
        private static List<PictureBox> ratingStars;
        private static bool hasRating = false;
        private static int rating = 0;

        public OMovDets()
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

                //Get all the movie detail from Movie table of the movie selected
                OSQL.selectQuery("SELECT * FROM Movie WHERE movie_id = " + ODirectory.movieID);

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    OSQL.reader.Read();

                    labelTitle.Text = OSQL.reader.GetValue(1).ToString();
                    labelSummary.Text = OSQL.reader.GetValue(2).ToString();
                    labelReleaseDate.Text = DateTime.Parse(OSQL.reader.GetValue(3).ToString()).ToString("dd/MMMM/yyyy");
                    labelDuration.Text = OSQL.reader.GetValue(4).ToString() + " minutes";
                    pictureBoxMovie.ImageLocation = "..\\..\\..\\" + OSQL.reader.GetValue(5).ToString();
                }

                //Get all type of genre of the movie selected
                OSQL.selectQuery("SELECT gname FROM Genre WHERE gname IN (SELECT gname FROM TypeOfMovie WHERE movie_id IN ( SELECT movie_id FROM movie WHERE movie_id = " + ODirectory.movieID + "))");

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    OSQL.reader.Read();
                    labelGenre.Text = OSQL.reader.GetValue(0).ToString();

                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        labelGenre.Text += ", " + OSQL.reader.GetValue(0).ToString();
                    }
                }

                //Get all producers' and directors' name of the movie selected
                OSQL.selectQuery("SELECT crew.firstname, crew.lastname, typeofprod.pname FROM crew, producer, TypeOfProd WHERE crew.crew_id IN (SELECT crew_id FROM stars WHERE movie_id =" + ODirectory.movieID + ") AND producer.crew_id = crew.crew_id AND typeofprod.crew_id = crew.crew_id");

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        //populate the listview
                        name = OSQL.reader.GetValue(0).ToString();
                        name += " " + OSQL.reader.GetValue(1).ToString();
                        role = OSQL.reader.GetValue(2).ToString();

                        ListViewItem dANDp = new ListViewItem(name, 0);
                        dANDp.SubItems.Add(role);

                        ListviewDandP.Items.Add(dANDp);
                    }
                }

                //Get all the writers' name of the movie selected
                OSQL.selectQuery("SELECT crew.firstname, crew.lastname FROM crew, screenwriter WHERE crew.crew_id IN (SELECT crew_id FROM stars WHERE movie_id =" + ODirectory.movieID + ") AND screenwriter.crew_id = crew.crew_id");
                name = "";
                role = "";

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        //populate the listview
                        name = OSQL.reader.GetValue(0).ToString();
                        name += " " + OSQL.reader.GetValue(1).ToString();

                        ListViewItem writer = new ListViewItem(name, 0);

                        listViewScreenWriter.Items.Add(writer);
                    }
                }

                //Get all the actor's name and movie characters' name of the movie selected
                OSQL.selectQuery("SELECT crew.firstname, crew.lastname, movcharacter.char_name FROM crew, actor, movcharacter WHERE crew.crew_id IN (SELECT crew_id FROM stars WHERE movie_id =" + ODirectory.movieID + ") AND actor.crew_id = crew.crew_id AND movcharacter.crew_id = crew.crew_id");
                name = "";
                role = "";

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        //populate the listview
                        name = OSQL.reader.GetValue(0).ToString();
                        name += " " + OSQL.reader.GetValue(1).ToString();
                        role = OSQL.reader.GetValue(2).ToString();

                        ListViewItem actor = new ListViewItem(name, 0);
                        actor.SubItems.Add(role);

                        listViewActors.Items.Add(actor);
                    }
                }
            }
            catch (Exception eOmovDets)
            {
                //show error
                MessageBox.Show("Error Movie Detail: " + eOmovDets.Message, "Error");
                this.Close();
            }
        }

        /// <summary>
        /// Updates the image of the stars according to the user's rating
        /// </summary>
        public void updateRating()
        {
            //Get average rating of the movie selected
            OSQL.selectQuery("SELECT AVG(rating) FROM review Where movie_id = " + ODirectory.movieID + " GROUP BY movie_id");

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                OSQL.reader.Read();

                labelAvg.Text = OSQL.reader.GetValue(0).ToString();
            }

            //Get the rating of the users for the movie selected
            OSQL.selectQuery("SELECT Rating FROM review WHERE email ='" + OLogin.email + "' AND movie_id =" + ODirectory.movieID);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                OSQL.reader.Read();

                hasRating = true;

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
            if (hasRating)
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
        /// Closes FormOMovDets and open FormODirectory 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Hide();
            ODirectory movieDir = new ODirectory();
            movieDir.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Open FormOReview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReview_Click(object sender, EventArgs e)
        {
            OReview movieReview = new OReview(this);
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
        /// Set rating to 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStar5_Click(object sender, EventArgs e)
        {
            setRating(5);
        }
    }
}
