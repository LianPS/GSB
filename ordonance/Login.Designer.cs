namespace ordonance
{
    partial class Login
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
            textBox_email = new TextBox();
            textBox_pswrd = new TextBox();
            button_login = new Button();
            button_sin = new Button();
            label1_email = new Label();
            label1_pswld = new Label();
            SuspendLayout();
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(94, 66);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(125, 27);
            textBox_email.TabIndex = 0;
            // 
            // textBox_pswrd
            // 
            textBox_pswrd.Location = new Point(94, 132);
            textBox_pswrd.Name = "textBox_pswrd";
            textBox_pswrd.Size = new Size(125, 27);
            textBox_pswrd.TabIndex = 1;
            // 
            // button_login
            // 
            button_login.Location = new Point(94, 210);
            button_login.Name = "button_login";
            button_login.Size = new Size(125, 29);
            button_login.TabIndex = 2;
            button_login.Text = "login";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += buttonLogin_Click;
            // 
            // button_sin
            // 
            button_sin.Location = new Point(94, 264);
            button_sin.Name = "button_sin";
            button_sin.Size = new Size(125, 29);
            button_sin.TabIndex = 3;
            button_sin.Text = "créé un compte";
            button_sin.UseVisualStyleBackColor = true;
            button_sin.Click += button_sin_Click;
            // 
            // label1_email
            // 
            label1_email.AutoSize = true;
            label1_email.Location = new Point(94, 43);
            label1_email.Name = "label1_email";
            label1_email.Size = new Size(46, 20);
            label1_email.TabIndex = 4;
            label1_email.Text = "Login";
            // 
            // label1_pswld
            // 
            label1_pswld.AutoSize = true;
            label1_pswld.Location = new Point(94, 109);
            label1_pswld.Name = "label1_pswld";
            label1_pswld.Size = new Size(74, 20);
            label1_pswld.TabIndex = 5;
            label1_pswld.Text = "Passworld";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 339);
            Controls.Add(label1_pswld);
            Controls.Add(label1_email);
            Controls.Add(button_sin);
            Controls.Add(button_login);
            Controls.Add(textBox_pswrd);
            Controls.Add(textBox_email);
            Name = "Login";
            Text = "LoginForm";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_email;
        private TextBox textBox_pswrd;
        private Button button_login;
        private Button button_sin;
        private Label label1_email;
        private Label label1_pswld;
    }
}