namespace TeamMCJ
{
    partial class MDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelUserEmail = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.TextboxSearch = new System.Windows.Forms.TextBox();
            this.ListviewMovieDir = new System.Windows.Forms.ListView();
            this.cTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImgListMovieDir = new System.Windows.Forms.ImageList(this.components);
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.Location = new System.Drawing.Point(905, 867);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(93, 27);
            this.buttonHome.TabIndex = 22;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.ButtonHome_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(595, 77);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(65, 29);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // labelUserEmail
            // 
            this.labelUserEmail.AutoSize = true;
            this.labelUserEmail.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserEmail.Location = new System.Drawing.Point(825, 84);
            this.labelUserEmail.Name = "labelUserEmail";
            this.labelUserEmail.Size = new System.Drawing.Size(59, 18);
            this.labelUserEmail.TabIndex = 21;
            this.labelUserEmail.Text = "UserEmail";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.Location = new System.Drawing.Point(12, 83);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(44, 19);
            this.labelSearch.TabIndex = 20;
            this.labelSearch.Text = "Search";
            // 
            // TextboxSearch
            // 
            this.TextboxSearch.BackColor = System.Drawing.Color.LavenderBlush;
            this.TextboxSearch.Location = new System.Drawing.Point(62, 81);
            this.TextboxSearch.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TextboxSearch.Name = "TextboxSearch";
            this.TextboxSearch.Size = new System.Drawing.Size(527, 23);
            this.TextboxSearch.TabIndex = 17;
            // 
            // ListviewMovieDir
            // 
            this.ListviewMovieDir.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.ListviewMovieDir.BackColor = System.Drawing.Color.LavenderBlush;
            this.ListviewMovieDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListviewMovieDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cTitle});
            this.ListviewMovieDir.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListviewMovieDir.HideSelection = false;
            this.ListviewMovieDir.LargeImageList = this.ImgListMovieDir;
            this.ListviewMovieDir.Location = new System.Drawing.Point(12, 113);
            this.ListviewMovieDir.Name = "ListviewMovieDir";
            this.ListviewMovieDir.Size = new System.Drawing.Size(986, 747);
            this.ListviewMovieDir.TabIndex = 19;
            this.ListviewMovieDir.UseCompatibleStateImageBehavior = false;
            this.ListviewMovieDir.SelectedIndexChanged += new System.EventHandler(this.ListviewMovieDir_SelectedIndexChanged);
            // 
            // cTitle
            // 
            this.cTitle.Width = 300;
            // 
            // ImgListMovieDir
            // 
            this.ImgListMovieDir.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListMovieDir.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListMovieDir.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(806, 867);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(93, 27);
            this.buttonBack.TabIndex = 23;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // MDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 907);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelUserEmail);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.TextboxSearch);
            this.Controls.Add(this.ListviewMovieDir);
            this.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MDirectory";
            this.Text = "MongoDB - Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelUserEmail;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox TextboxSearch;
        private System.Windows.Forms.ListView ListviewMovieDir;
        private System.Windows.Forms.ColumnHeader cTitle;
        private System.Windows.Forms.ImageList ImgListMovieDir;
        private System.Windows.Forms.Button buttonBack;
    }
}