
namespace EmployeeManager
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.txt_s_Re_Enter = new System.Windows.Forms.TextBox();
            this.btn_Signup = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_s_Password = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_s_MailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_s_Username = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_s_LastName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_s_firstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_s_Re_Enter
            // 
            this.txt_s_Re_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_s_Re_Enter.Location = new System.Drawing.Point(521, 316);
            this.txt_s_Re_Enter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_s_Re_Enter.Name = "txt_s_Re_Enter";
            this.txt_s_Re_Enter.PasswordChar = '*';
            this.txt_s_Re_Enter.ShortcutsEnabled = false;
            this.txt_s_Re_Enter.Size = new System.Drawing.Size(203, 29);
            this.txt_s_Re_Enter.TabIndex = 6;
            this.txt_s_Re_Enter.TextChanged += new System.EventHandler(this.txt_s_Re_Enter_TextChanged);
            // 
            // btn_Signup
            // 
            this.btn_Signup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Signup.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Signup.ForeColor = System.Drawing.Color.White;
            this.btn_Signup.Location = new System.Drawing.Point(257, 439);
            this.btn_Signup.Name = "btn_Signup";
            this.btn_Signup.Size = new System.Drawing.Size(370, 50);
            this.btn_Signup.TabIndex = 7;
            this.btn_Signup.Text = "Signup";
            this.btn_Signup.UseVisualStyleBackColor = false;
            this.btn_Signup.Click += new System.EventHandler(this.btn_Signup_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(326, 319);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 25);
            this.label11.TabIndex = 49;
            this.label11.Text = "Re-enter password";
            // 
            // txt_s_Password
            // 
            this.txt_s_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_s_Password.Location = new System.Drawing.Point(521, 260);
            this.txt_s_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_s_Password.Name = "txt_s_Password";
            this.txt_s_Password.PasswordChar = '*';
            this.txt_s_Password.ShortcutsEnabled = false;
            this.txt_s_Password.Size = new System.Drawing.Size(203, 29);
            this.txt_s_Password.TabIndex = 5;
            this.txt_s_Password.TextChanged += new System.EventHandler(this.txt_s_Password_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(326, 263);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 25);
            this.label12.TabIndex = 47;
            this.label12.Text = "Password";
            // 
            // txt_s_MailAddress
            // 
            this.txt_s_MailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_s_MailAddress.Location = new System.Drawing.Point(521, 204);
            this.txt_s_MailAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_s_MailAddress.Name = "txt_s_MailAddress";
            this.txt_s_MailAddress.Size = new System.Drawing.Size(203, 29);
            this.txt_s_MailAddress.TabIndex = 4;
            this.txt_s_MailAddress.TextChanged += new System.EventHandler(this.txt_s_MailAddress_TextChanged);
            this.txt_s_MailAddress.Leave += new System.EventHandler(this.txt_s_MailAddress_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(326, 207);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 25);
            this.label8.TabIndex = 45;
            this.label8.Text = "Mail Address";
            // 
            // txt_s_Username
            // 
            this.txt_s_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_s_Username.Location = new System.Drawing.Point(521, 148);
            this.txt_s_Username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_s_Username.Name = "txt_s_Username";
            this.txt_s_Username.Size = new System.Drawing.Size(203, 29);
            this.txt_s_Username.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(326, 151);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 25);
            this.label9.TabIndex = 43;
            this.label9.Text = "Username";
            // 
            // txt_s_LastName
            // 
            this.txt_s_LastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_s_LastName.Location = new System.Drawing.Point(521, 92);
            this.txt_s_LastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_s_LastName.Name = "txt_s_LastName";
            this.txt_s_LastName.Size = new System.Drawing.Size(203, 29);
            this.txt_s_LastName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(326, 95);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "Last Name";
            // 
            // txt_s_firstName
            // 
            this.txt_s_firstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_s_firstName.Location = new System.Drawing.Point(521, 36);
            this.txt_s_firstName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_s_firstName.Name = "txt_s_firstName";
            this.txt_s_firstName.Size = new System.Drawing.Size(203, 29);
            this.txt_s_firstName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(326, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "First Name";
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(740, 260);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 29);
            this.checkBox1.TabIndex = 52;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Image = global::EmployeeManager.Properties.Resources.employee_manager;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Signup
            // 
            this.AcceptButton = this.btn_Signup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(22)))));
            this.BackgroundImage = global::EmployeeManager.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt_s_Re_Enter);
            this.Controls.Add(this.btn_Signup);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_s_Password);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_s_MailAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_s_Username);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_s_LastName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_s_firstName);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Signup_FormClosed);
            this.Load += new System.EventHandler(this.Signup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_s_Re_Enter;
        private System.Windows.Forms.Button btn_Signup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_s_Password;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_s_MailAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_s_Username;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_s_LastName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_s_firstName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}