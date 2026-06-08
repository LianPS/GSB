namespace tools_médecin
{
    partial class OrdonnanceEditForm
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            txtPosologie = new TextBox();
            txtDuree = new TextBox();
            btnAjouterLigne = new Button();
            dgvLignes = new DataGridView();
            btnValider = new Button();
            Medicament = new Label();
            Posologie = new Label();
            Durée = new Label();
            cmbMedicament = new ComboBox();
            btnSupprimerLigne = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLignes).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(27, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(213, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 1;
            // 
            // txtPosologie
            // 
            txtPosologie.Location = new Point(27, 146);
            txtPosologie.Name = "txtPosologie";
            txtPosologie.Size = new Size(125, 27);
            txtPosologie.TabIndex = 3;
            // 
            // txtDuree
            // 
            txtDuree.Location = new Point(27, 195);
            txtDuree.Name = "txtDuree";
            txtDuree.Size = new Size(125, 27);
            txtDuree.TabIndex = 4;
            // 
            // btnAjouterLigne
            // 
            btnAjouterLigne.Location = new Point(174, 93);
            btnAjouterLigne.Name = "btnAjouterLigne";
            btnAjouterLigne.Size = new Size(94, 29);
            btnAjouterLigne.TabIndex = 5;
            btnAjouterLigne.Text = "Ajouté";
            btnAjouterLigne.UseVisualStyleBackColor = true;
            // 
            // dgvLignes
            // 
            dgvLignes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLignes.Location = new Point(12, 255);
            dgvLignes.Name = "dgvLignes";
            dgvLignes.RowHeadersWidth = 51;
            dgvLignes.Size = new Size(479, 188);
            dgvLignes.TabIndex = 6;
            // 
            // btnValider
            // 
            btnValider.Location = new Point(174, 144);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(94, 29);
            btnValider.TabIndex = 7;
            btnValider.Text = "Validé";
            btnValider.UseVisualStyleBackColor = true;
            // 
            // Medicament
            // 
            Medicament.AutoSize = true;
            Medicament.Location = new Point(27, 71);
            Medicament.Name = "Medicament";
            Medicament.Size = new Size(92, 20);
            Medicament.TabIndex = 8;
            Medicament.Text = "Medicament";
            // 
            // Posologie
            // 
            Posologie.AutoSize = true;
            Posologie.Location = new Point(27, 124);
            Posologie.Name = "Posologie";
            Posologie.Size = new Size(74, 20);
            Posologie.TabIndex = 9;
            Posologie.Text = "Posologie";
            // 
            // Durée
            // 
            Durée.AutoSize = true;
            Durée.Location = new Point(27, 176);
            Durée.Name = "Durée";
            Durée.Size = new Size(49, 20);
            Durée.TabIndex = 10;
            Durée.Text = "Durée";
            // 
            // cmbMedicament
            // 
            cmbMedicament.FormattingEnabled = true;
            cmbMedicament.Location = new Point(27, 94);
            cmbMedicament.Name = "cmbMedicament";
            cmbMedicament.Size = new Size(125, 28);
            cmbMedicament.TabIndex = 11;
            // 
            // btnSupprimerLigne
            // 
            btnSupprimerLigne.Location = new Point(314, 94);
            btnSupprimerLigne.Name = "btnSupprimerLigne";
            btnSupprimerLigne.Size = new Size(94, 29);
            btnSupprimerLigne.TabIndex = 12;
            btnSupprimerLigne.Text = "Supprimé";
            btnSupprimerLigne.UseVisualStyleBackColor = true;
            btnSupprimerLigne.Click += btnSupprimerLigne_Click;
            // 
            // OrdonnanceEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 450);
            Controls.Add(btnSupprimerLigne);
            Controls.Add(cmbMedicament);
            Controls.Add(Durée);
            Controls.Add(Posologie);
            Controls.Add(Medicament);
            Controls.Add(btnValider);
            Controls.Add(dgvLignes);
            Controls.Add(btnAjouterLigne);
            Controls.Add(txtDuree);
            Controls.Add(txtPosologie);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Name = "OrdonnanceEditForm";
            Text = "Ordonnance Editeur";
            Load += OrdonnanceEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLignes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txtPosologie;
        private System.Windows.Forms.TextBox txtDuree;
        private System.Windows.Forms.Button btnAjouterLigne;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label Medicament;
        private System.Windows.Forms.Label Posologie;
        private System.Windows.Forms.Label Durée;
        private ComboBox cmbMedicament;
        private Button btnSupprimerLigne;
    }
}