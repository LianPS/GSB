namespace ordonance
{
    partial class PatientListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            btnOrdonnances = new Button();
            textBox7 = new TextBox();
            button_suppr = new Button();
            button4_créer = new Button();
            domainUpDown_sex = new DomainUpDown();
            label1_pnom = new Label();
            label3_nom = new Label();
            label4_ddn = new Label();
            label5_poid = new Label();
            label6_taille = new Label();
            label7_patholigies = new Label();
            label8_numdesecu = new Label();
            dgvPatients = new DataGridView();
            txtRecherche = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(38, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(189, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(38, 96);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(189, 96);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(343, 96);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(94, 27);
            textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(189, 147);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 8;
            // 
            // btnOrdonnances
            // 
            btnOrdonnances.Location = new Point(12, 387);
            btnOrdonnances.Name = "btnOrdonnances";
            btnOrdonnances.Size = new Size(113, 29);
            btnOrdonnances.TabIndex = 9;
            btnOrdonnances.Tag = "";
            btnOrdonnances.Text = "Ordonnance";
            btnOrdonnances.UseVisualStyleBackColor = true;
            btnOrdonnances.Click += ordonnance_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(38, 199);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 10;
            // 
            // button_suppr
            // 
            button_suppr.Location = new Point(137, 386);
            button_suppr.Name = "button_suppr";
            button_suppr.Size = new Size(166, 29);
            button_suppr.TabIndex = 11;
            button_suppr.Text = "supprimer un patient";
            button_suppr.UseVisualStyleBackColor = true;
            button_suppr.Click += button_suppr_Click_1;
            // 
            // button4_créer
            // 
            button4_créer.Location = new Point(309, 386);
            button4_créer.Name = "button4_créer";
            button4_créer.Size = new Size(128, 29);
            button4_créer.TabIndex = 12;
            button4_créer.Text = "créer un patient";
            button4_créer.UseVisualStyleBackColor = true;
            button4_créer.Click += button4_créer_Click;
            // 
            // domainUpDown_sex
            // 
            domainUpDown_sex.Location = new Point(38, 148);
            domainUpDown_sex.Name = "domainUpDown_sex";
            domainUpDown_sex.Size = new Size(58, 27);
            domainUpDown_sex.TabIndex = 14;
            domainUpDown_sex.Text = "sex";
            domainUpDown_sex.SelectedItemChanged += domainUpDown_sex_SelectedItemChanged;
            // 
            // label1_pnom
            // 
            label1_pnom.AutoSize = true;
            label1_pnom.Location = new Point(38, 10);
            label1_pnom.Name = "label1_pnom";
            label1_pnom.Size = new Size(61, 20);
            label1_pnom.TabIndex = 16;
            label1_pnom.Text = "prénom";
            // 
            // label3_nom
            // 
            label3_nom.AutoSize = true;
            label3_nom.Location = new Point(189, 10);
            label3_nom.Name = "label3_nom";
            label3_nom.Size = new Size(42, 20);
            label3_nom.TabIndex = 18;
            label3_nom.Text = "Nom";
            // 
            // label4_ddn
            // 
            label4_ddn.AutoSize = true;
            label4_ddn.Location = new Point(38, 73);
            label4_ddn.Name = "label4_ddn";
            label4_ddn.Size = new Size(127, 20);
            label4_ddn.TabIndex = 19;
            label4_ddn.Text = "date de naissence";
            // 
            // label5_poid
            // 
            label5_poid.AutoSize = true;
            label5_poid.Location = new Point(189, 73);
            label5_poid.Name = "label5_poid";
            label5_poid.Size = new Size(40, 20);
            label5_poid.TabIndex = 20;
            label5_poid.Text = "poid";
            // 
            // label6_taille
            // 
            label6_taille.AutoSize = true;
            label6_taille.Location = new Point(343, 73);
            label6_taille.Name = "label6_taille";
            label6_taille.Size = new Size(42, 20);
            label6_taille.TabIndex = 21;
            label6_taille.Text = "taille";
            // 
            // label7_patholigies
            // 
            label7_patholigies.AutoSize = true;
            label7_patholigies.Location = new Point(189, 129);
            label7_patholigies.Name = "label7_patholigies";
            label7_patholigies.Size = new Size(88, 20);
            label7_patholigies.TabIndex = 22;
            label7_patholigies.Text = "pathologies";
            // 
            // label8_numdesecu
            // 
            label8_numdesecu.AutoSize = true;
            label8_numdesecu.Location = new Point(38, 181);
            label8_numdesecu.Name = "label8_numdesecu";
            label8_numdesecu.Size = new Size(114, 20);
            label8_numdesecu.TabIndex = 23;
            label8_numdesecu.Text = "numéro de sécu";
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(-3, 232);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.Size = new Size(470, 149);
            dgvPatients.TabIndex = 24;
            dgvPatients.CellContentDoubleClick += dgvPatients_CellDoubleClick;
            // 
            // txtRecherche
            // 
            txtRecherche.Location = new Point(285, 199);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(152, 27);
            txtRecherche.TabIndex = 25;
            txtRecherche.TextChanged += txtRecherche_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 199);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 26;
            label1.Text = "Recherche :";
            // 
            // PatientListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 428);
            Controls.Add(label1);
            Controls.Add(txtRecherche);
            Controls.Add(dgvPatients);
            Controls.Add(label8_numdesecu);
            Controls.Add(label7_patholigies);
            Controls.Add(label6_taille);
            Controls.Add(label5_poid);
            Controls.Add(label4_ddn);
            Controls.Add(label3_nom);
            Controls.Add(label1_pnom);
            Controls.Add(domainUpDown_sex);
            Controls.Add(button4_créer);
            Controls.Add(button_suppr);
            Controls.Add(textBox7);
            Controls.Add(btnOrdonnances);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "PatientListForm";
            Text = "Liste des patients";
            Load += liste_patients_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button button_suppr;
        private Button button4_créer;
        private DomainUpDown domainUpDown_sex;
        private Label label1_pnom;
        private Label label3_nom;
        private Label label4_ddn;
        private Label label5_poid;
        private Label label6_taille;
        private Label label7_patholigies;
        private Label label8_numdesecu;
        private DataGridView dgvPatients;
        protected Button btnOrdonnances;
        private TextBox txtRecherche;
        private Label label1;
    }
}
