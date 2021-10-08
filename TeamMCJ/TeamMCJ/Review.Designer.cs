namespace TeamMCJ
{
    partial class Review
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
            this.richTextBoxReview = new System.Windows.Forms.RichTextBox();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.ListviewReview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBoxStar5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxStar4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxStar3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxStar2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxStar1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxReview
            // 
            this.richTextBoxReview.Location = new System.Drawing.Point(12, 66);
            this.richTextBoxReview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxReview.MaxLength = 500;
            this.richTextBoxReview.Name = "richTextBoxReview";
            this.richTextBoxReview.Size = new System.Drawing.Size(493, 173);
            this.richTextBoxReview.TabIndex = 0;
            this.richTextBoxReview.Text = "";
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.AutoSize = true;
            this.labelReleaseDate.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReleaseDate.Location = new System.Drawing.Point(385, 243);
            this.labelReleaseDate.MaximumSize = new System.Drawing.Size(300, 0);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(120, 19);
            this.labelReleaseDate.TabIndex = 18;
            this.labelReleaseDate.Text = "Limit: 500 characters";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(412, 268);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(93, 47);
            this.buttonSubmit.TabIndex = 25;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // ListviewReview
            // 
            this.ListviewReview.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.ListviewReview.BackColor = System.Drawing.Color.LavenderBlush;
            this.ListviewReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListviewReview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ListviewReview.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListviewReview.HideSelection = false;
            this.ListviewReview.Location = new System.Drawing.Point(12, 330);
            this.ListviewReview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListviewReview.Name = "ListviewReview";
            this.ListviewReview.Size = new System.Drawing.Size(493, 570);
            this.ListviewReview.TabIndex = 26;
            this.ListviewReview.TileSize = new System.Drawing.Size(493, 40);
            this.ListviewReview.UseCompatibleStateImageBehavior = false;
            this.ListviewReview.View = System.Windows.Forms.View.Tile;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 493;
            // 
            // pictureBoxStar5
            // 
            this.pictureBoxStar5.Location = new System.Drawing.Point(469, 12);
            this.pictureBoxStar5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxStar5.Name = "pictureBoxStar5";
            this.pictureBoxStar5.Size = new System.Drawing.Size(36, 46);
            this.pictureBoxStar5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStar5.TabIndex = 41;
            this.pictureBoxStar5.TabStop = false;
            this.pictureBoxStar5.Click += new System.EventHandler(this.PictureBoxStar5_Click);
            // 
            // pictureBoxStar4
            // 
            this.pictureBoxStar4.Location = new System.Drawing.Point(427, 12);
            this.pictureBoxStar4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxStar4.Name = "pictureBoxStar4";
            this.pictureBoxStar4.Size = new System.Drawing.Size(36, 46);
            this.pictureBoxStar4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStar4.TabIndex = 40;
            this.pictureBoxStar4.TabStop = false;
            this.pictureBoxStar4.Click += new System.EventHandler(this.PictureBoxStar4_Click);
            // 
            // pictureBoxStar3
            // 
            this.pictureBoxStar3.Location = new System.Drawing.Point(385, 12);
            this.pictureBoxStar3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxStar3.Name = "pictureBoxStar3";
            this.pictureBoxStar3.Size = new System.Drawing.Size(36, 46);
            this.pictureBoxStar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStar3.TabIndex = 39;
            this.pictureBoxStar3.TabStop = false;
            this.pictureBoxStar3.Click += new System.EventHandler(this.PictureBoxStar3_Click);
            // 
            // pictureBoxStar2
            // 
            this.pictureBoxStar2.Location = new System.Drawing.Point(343, 12);
            this.pictureBoxStar2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxStar2.Name = "pictureBoxStar2";
            this.pictureBoxStar2.Size = new System.Drawing.Size(36, 46);
            this.pictureBoxStar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStar2.TabIndex = 38;
            this.pictureBoxStar2.TabStop = false;
            this.pictureBoxStar2.Click += new System.EventHandler(this.PictureBoxStar2_Click);
            // 
            // pictureBoxStar1
            // 
            this.pictureBoxStar1.Location = new System.Drawing.Point(301, 12);
            this.pictureBoxStar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxStar1.Name = "pictureBoxStar1";
            this.pictureBoxStar1.Size = new System.Drawing.Size(36, 46);
            this.pictureBoxStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStar1.TabIndex = 37;
            this.pictureBoxStar1.TabStop = false;
            this.pictureBoxStar1.Click += new System.EventHandler(this.PictureBoxStar1_Click);
            // 
            // Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 913);
            this.Controls.Add(this.pictureBoxStar5);
            this.Controls.Add(this.pictureBoxStar4);
            this.Controls.Add(this.pictureBoxStar3);
            this.Controls.Add(this.pictureBoxStar2);
            this.Controls.Add(this.pictureBoxStar1);
            this.Controls.Add(this.ListviewReview);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelReleaseDate);
            this.Controls.Add(this.richTextBoxReview);
            this.Font = new System.Drawing.Font("Sitka Display", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Review";
            this.Text = "Review";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxReview;
        private System.Windows.Forms.Label labelReleaseDate;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.ListView ListviewReview;
        private System.Windows.Forms.PictureBox pictureBoxStar5;
        private System.Windows.Forms.PictureBox pictureBoxStar4;
        private System.Windows.Forms.PictureBox pictureBoxStar3;
        private System.Windows.Forms.PictureBox pictureBoxStar2;
        private System.Windows.Forms.PictureBox pictureBoxStar1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}