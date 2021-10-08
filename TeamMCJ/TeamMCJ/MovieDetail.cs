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
    public partial class MovieDetail : Form
    {
        bool hasRating = false;

        List<PictureBox> ratingStars = new List<PictureBox>();
        int rating = 0;

        public MovieDetail()
        {
            InitializeComponent();

            ListviewDandP.FullRowSelect = true;
            listViewScreenWriter.FullRowSelect = true;
            listViewActors.FullRowSelect = true;

            string name = "";
            string role = "";

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

                //Get all the movie detail from Movie table
                OSQL.selectQuery("SELECT * FROM Movie WHERE movie_id = " + MovieDir.movieID);

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

                //Get all the movie detail from Movie table
                OSQL.selectQuery("SELECT AVG(rating) FROM review Where movie_id = " + MovieDir.movieID + " GROUP BY movie_id");

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    OSQL.reader.Read();

                    labelAvg.Text = OSQL.reader.GetValue(0).ToString();
                }

                //Get all the movie detail from Movie table
                OSQL.selectQuery("SELECT gname FROM Genre WHERE gname IN (SELECT gname FROM TypeOfMovie WHERE movie_id IN ( SELECT movie_id FROM movie WHERE movie_id = " + MovieDir.movieID + "))");

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

                //Get all the movie detail from Movie table
                OSQL.selectQuery("SELECT crew.firstname, crew.lastname, typeofprod.pname FROM crew, producer, TypeOfProd WHERE crew.crew_id IN (SELECT crew_id FROM stars WHERE movie_id =" + MovieDir.movieID + ") AND producer.crew_id = crew.crew_id AND typeofprod.crew_id = crew.crew_id");

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        //
                        name = OSQL.reader.GetValue(0).ToString();
                        name += " " + OSQL.reader.GetValue(1).ToString();
                        role = OSQL.reader.GetValue(2).ToString();

                        ListViewItem dANDp = new ListViewItem(name, 0);
                        dANDp.SubItems.Add(role);

                        ListviewDandP.Items.Add(dANDp);
                    }
                }

                //Get all the movie detail from Movie table
                OSQL.selectQuery("SELECT crew.firstname, crew.lastname FROM crew, screenwriter WHERE crew.crew_id IN (SELECT crew_id FROM stars WHERE movie_id =" + MovieDir.movieID + ") AND screenwriter.crew_id = crew.crew_id");
                name = "";
                role = "";

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        //
                        name = OSQL.reader.GetValue(0).ToString();
                        name += " " + OSQL.reader.GetValue(1).ToString();

                        ListViewItem writer = new ListViewItem(name, 0);

                        listViewScreenWriter.Items.Add(writer);
                    }
                }

                //Get all the movie detail from Movie table
                OSQL.selectQuery("SELECT crew.firstname, crew.lastname, movcharacter.char_name FROM crew, actor, movcharacter WHERE crew.crew_id IN (SELECT crew_id FROM stars WHERE movie_id =" + MovieDir.movieID + ") AND actor.crew_id = crew.crew_id AND movcharacter.crew_id = crew.crew_id");
                name = "";
                role = "";

                //if it returns data
                if (OSQL.reader.HasRows)
                {
                    //while there's still row to read
                    while (OSQL.reader.Read())
                    {
                        //
                        name = OSQL.reader.GetValue(0).ToString();
                        name += " " + OSQL.reader.GetValue(1).ToString();
                        role = OSQL.reader.GetValue(2).ToString();

                        ListViewItem actor = new ListViewItem(name, 0);
                        actor.SubItems.Add(role);

                        listViewActors.Items.Add(actor);
                    }
                }
            }
            catch (Exception eMovieDetail)
            {
                //show error
                MessageBox.Show("Error Movie Detail: " + eMovieDetail.Message, "Error");
                this.Close();
            }
        }

        public void updateRating()
        {
            //Get all the movie detail from Movie table
            OSQL.selectQuery("SELECT Rating FROM review WHERE email ='" + FormLogin.email + "' AND movie_id =" + MovieDir.movieID);

            //if it returns data
            if (OSQL.reader.HasRows)
            {
                OSQL.reader.Read();

                hasRating = true;

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

        private void setRating(int rating)
        {
            if(hasRating)
            {
                //Get all the movie detail from Movie table
                OSQL.executeQuery("UPDATE review SET rating = " + rating + " WHERE email ='" + FormLogin.email + "' AND movie_id =" + MovieDir.movieID);
            }
            else
            {
                //Get all the movie detail from Movie table
                OSQL.executeQuery("insert into Review(Email, movie_id, rating) values('" + FormLogin.email + "', "+ MovieDir.movieID + ", " + rating +")");
            }

            updateRating();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            //closes FormMovieDetail and open FormMovieDir
            Hide();
            MovieDir movieDir = new MovieDir();
            movieDir.ShowDialog();
            this.Close();
        }

        private void ButtonReview_Click(object sender, EventArgs e)
        {
            Review movieReview = new Review(this);
            movieReview.ShowDialog();
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
