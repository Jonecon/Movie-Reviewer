namespace TeamMCJ
{
    partial class MLogin
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
            this.ButtonClearAll = new System.Windows.Forms.Button();
            this.ButtonLogIn = new System.Windows.Forms.Button();
            this.TextboxPassword = new System.Windows.Forms.TextBox();
            this.TextboxEmail = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonClearAll
            // 
            this.ButtonClearAll.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClearAll.Location = new System.Drawing.Point(211, 154);
            this.ButtonClearAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonClearAll.Name = "ButtonClearAll";
            this.ButtonClearAll.Size = new System.Drawing.Size(93, 35);
            this.ButtonClearAll.TabIndex = 12;
            this.ButtonClearAll.Text = "Clear";
            this.ButtonClearAll.UseVisualStyleBackColor = true;
            this.ButtonClearAll.Click += new System.EventHandler(this.ButtonClearAll_Click);
            // 
            // ButtonLogIn
            // 
            this.ButtonLogIn.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogIn.Location = new System.Drawing.Point(310, 154);
            this.ButtonLogIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonLogIn.Name = "ButtonLogIn";
            this.ButtonLogIn.Size = new System.Drawing.Size(96, 35);
            this.ButtonLogIn.TabIndex = 11;
            this.ButtonLogIn.Text = "Log In";
            this.ButtonLogIn.UseVisualStyleBackColor = true;
            this.ButtonLogIn.Click += new System.EventHandler(this.ButtonLogIn_Click);
            // 
            // TextboxPassword
            // 
            this.TextboxPassword.BackColor = System.Drawing.Color.LavenderBlush;
            this.TextboxPassword.Location = new System.Drawing.Point(211, 121);
            this.TextboxPassword.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TextboxPassword.Name = "TextboxPassword";
            this.TextboxPassword.Size = new System.Drawing.Size(195, 23);
            this.TextboxPassword.TabIndex = 10;
            // 
            // TextboxEmail
            // 
            this.TextboxEmail.BackColor = System.Drawing.Color.LavenderBlush;
            this.TextboxEmail.Location = new System.Drawing.Point(211, 86);
            this.TextboxEmail.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TextboxEmail.Name = "TextboxEmail";
            this.TextboxEmail.Size = new System.Drawing.Size(195, 23);
            this.TextboxEmail.TabIndex = 9;
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPassword.Location = new System.Drawing.Point(146, 123);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(59, 19);
            this.LabelPassword.TabIndex = 14;
            this.LabelPassword.Text = "Password";
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEmail.Location = new System.Drawing.Point(167, 88);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(38, 19);
            this.LabelEmail.TabIndex = 13;
            this.LabelEmail.Text = "Email";
            // 
            // MLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 231);
            this.Controls.Add(this.ButtonClearAll);
            this.Controls.Add(this.ButtonLogIn);
            this.Controls.Add(this.TextboxPassword);
            this.Controls.Add(this.TextboxEmail);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelEmail);
            this.Font = new System.Drawing.Font("Sitka Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MLogin";
            this.Text = "MongoDB - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonClearAll;
        private System.Windows.Forms.Button ButtonLogIn;
        private System.Windows.Forms.TextBox TextboxPassword;
        private System.Windows.Forms.TextBox TextboxEmail;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.Label LabelEmail;
    }
}