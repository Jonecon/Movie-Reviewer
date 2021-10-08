namespace TeamMCJ
{
    partial class ChooseDB
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
            this.ButtonOracle = new System.Windows.Forms.Button();
            this.buttonMongoDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonOracle
            // 
            this.ButtonOracle.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOracle.Location = new System.Drawing.Point(112, 72);
            this.ButtonOracle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonOracle.Name = "ButtonOracle";
            this.ButtonOracle.Size = new System.Drawing.Size(173, 34);
            this.ButtonOracle.TabIndex = 6;
            this.ButtonOracle.Text = "Oracle";
            this.ButtonOracle.UseVisualStyleBackColor = true;
            this.ButtonOracle.Click += new System.EventHandler(this.ButtonOracle_Click);
            // 
            // buttonMongoDB
            // 
            this.buttonMongoDB.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMongoDB.Location = new System.Drawing.Point(291, 72);
            this.buttonMongoDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMongoDB.Name = "buttonMongoDB";
            this.buttonMongoDB.Size = new System.Drawing.Size(173, 34);
            this.buttonMongoDB.TabIndex = 7;
            this.buttonMongoDB.Text = "MongoDB";
            this.buttonMongoDB.UseVisualStyleBackColor = true;
            this.buttonMongoDB.Click += new System.EventHandler(this.ButtonMongoDB_Click);
            // 
            // ChooseDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 137);
            this.Controls.Add(this.buttonMongoDB);
            this.Controls.Add(this.ButtonOracle);
            this.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChooseDB";
            this.Text = "TeamMCJ - Choose Database ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOracle;
        private System.Windows.Forms.Button buttonMongoDB;
    }
}