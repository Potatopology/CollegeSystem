namespace CollegeSystem
{
    partial class Main
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
            this.btnDept = new System.Windows.Forms.Button();
            this.btnTeamLead = new System.Windows.Forms.Button();
            this.btnEmp = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDept
            // 
            this.btnDept.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDept.FlatAppearance.BorderSize = 3;
            this.btnDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDept.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDept.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDept.Location = new System.Drawing.Point(415, 307);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(140, 57);
            this.btnDept.TabIndex = 5;
            this.btnDept.Text = "Department";
            this.btnDept.UseVisualStyleBackColor = true;
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // btnTeamLead
            // 
            this.btnTeamLead.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnTeamLead.FlatAppearance.BorderSize = 3;
            this.btnTeamLead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeamLead.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamLead.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnTeamLead.Location = new System.Drawing.Point(415, 206);
            this.btnTeamLead.Name = "btnTeamLead";
            this.btnTeamLead.Size = new System.Drawing.Size(140, 57);
            this.btnTeamLead.TabIndex = 4;
            this.btnTeamLead.Text = "Team Lead";
            this.btnTeamLead.UseVisualStyleBackColor = true;
            this.btnTeamLead.Click += new System.EventHandler(this.btnTeamLead_Click);
            // 
            // btnEmp
            // 
            this.btnEmp.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnEmp.FlatAppearance.BorderSize = 3;
            this.btnEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmp.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnEmp.Location = new System.Drawing.Point(415, 105);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(140, 57);
            this.btnEmp.TabIndex = 3;
            this.btnEmp.Text = "Employee";
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(592, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 172;
            this.btnExit.Text = "x";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CollegeSystem.Properties.Resources.pic;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 464);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 173;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDept);
            this.Controls.Add(this.btnTeamLead);
            this.Controls.Add(this.btnEmp);
            this.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDept;
        private System.Windows.Forms.Button btnTeamLead;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

