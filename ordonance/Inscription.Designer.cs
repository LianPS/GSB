namespace liste_patients
{
    partial class Inscription
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
            textBox1_email1 = new TextBox();
            button1_creataccount = new Button();
            textBox2_pasworld1 = new TextBox();
            textBox3_confirme_pasworld = new TextBox();
            label1_email = new Label();
            label2_pasworld = new Label();
            label3_pasworld1 = new Label();
            SuspendLayout();
            // 
            // textBox1_email1
            // 
            textBox1_email1.Location = new Point(12, 64);
            textBox1_email1.Name = "textBox1_email1";
            textBox1_email1.Size = new Size(180, 27);
            textBox1_email1.TabIndex = 0;
            // 
            // button1_creataccount
            // 
            button1_creataccount.Location = new Point(12, 274);
            button1_creataccount.Name = "button1_creataccount";
            button1_creataccount.Size = new Size(125, 29);
            button1_creataccount.TabIndex = 1;
            button1_creataccount.Text = "créer";
            button1_creataccount.UseVisualStyleBackColor = true;
            button1_creataccount.Click += button1_creataccount_Click;
            // 
            // textBox2_pasworld1
            // 
            textBox2_pasworld1.Location = new Point(12, 142);
            textBox2_pasworld1.Name = "textBox2_pasworld1";
            textBox2_pasworld1.Size = new Size(125, 27);
            textBox2_pasworld1.TabIndex = 2;
            // 
            // textBox3_confirme_pasworld
            // 
            textBox3_confirme_pasworld.Location = new Point(12, 210);
            textBox3_confirme_pasworld.Name = "textBox3_confirme_pasworld";
            textBox3_confirme_pasworld.Size = new Size(125, 27);
            textBox3_confirme_pasworld.TabIndex = 3;
            // 
            // label1_email
            // 
            label1_email.AutoSize = true;
            label1_email.Location = new Point(12, 41);
            label1_email.Name = "label1_email";
            label1_email.Size = new Size(46, 20);
            label1_email.TabIndex = 4;
            label1_email.Text = "email";
            // 
            // label2_pasworld
            // 
            label2_pasworld.AutoSize = true;
            label2_pasworld.Location = new Point(12, 119);
            label2_pasworld.Name = "label2_pasworld";
            label2_pasworld.Size = new Size(98, 20);
            label2_pasworld.TabIndex = 5;
            label2_pasworld.Text = "mot de passe";
            // 
            // label3_pasworld1
            // 
            label3_pasworld1.AutoSize = true;
            label3_pasworld1.Location = new Point(12, 187);
            label3_pasworld1.Name = "label3_pasworld1";
            label3_pasworld1.Size = new Size(208, 20);
            label3_pasworld1.TabIndex = 6;
            label3_pasworld1.Text = "confirmation du mot de passe";
            label3_pasworld1.Click += label3_Click;
            // 
            // Inscription
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 350);
            Controls.Add(label3_pasworld1);
            Controls.Add(label2_pasworld);
            Controls.Add(label1_email);
            Controls.Add(textBox3_confirme_pasworld);
            Controls.Add(textBox2_pasworld1);
            Controls.Add(button1_creataccount);
            Controls.Add(textBox1_email1);
            Name = "Inscription";
            Text = "Page d'inscriptioncs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1_email1;
        private Button button1_creataccount;
        private TextBox textBox2_pasworld1;
        private TextBox textBox3_confirme_pasworld;
        private Label label1_email;
        private Label label2_pasworld;
        private Label label3_pasworld1;
    }
}