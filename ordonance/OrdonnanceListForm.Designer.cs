namespace tools_médecin
{
    partial class OrdonnanceListForm
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
            dgvOrdonnances = new DataGridView();
            dgvLignes = new DataGridView();
            btnNouvelleOrdonnance = new Button();
            btnEnregistrerPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrdonnances).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLignes).BeginInit();
            SuspendLayout();
            // 
            // dgvOrdonnances
            // 
            dgvOrdonnances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdonnances.Location = new Point(12, 12);
            dgvOrdonnances.Name = "dgvOrdonnances";
            dgvOrdonnances.RowHeadersWidth = 51;
            dgvOrdonnances.Size = new Size(526, 188);
            dgvOrdonnances.TabIndex = 0;
            dgvOrdonnances.CellClick += dgvOrdonnances_CellClick;
            dgvOrdonnances.CellDoubleClick += dgvOrdonnances_CellDoubleClick;
            // 
            // dgvLignes
            // 
            dgvLignes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLignes.Location = new Point(12, 206);
            dgvLignes.Name = "dgvLignes";
            dgvLignes.RowHeadersWidth = 51;
            dgvLignes.Size = new Size(526, 188);
            dgvLignes.TabIndex = 1;
            // 
            // btnNouvelleOrdonnance
            // 
            btnNouvelleOrdonnance.Location = new Point(12, 409);
            btnNouvelleOrdonnance.Name = "btnNouvelleOrdonnance";
            btnNouvelleOrdonnance.Size = new Size(182, 29);
            btnNouvelleOrdonnance.TabIndex = 2;
            btnNouvelleOrdonnance.Text = "Nouvelle_Ordonnance";
            btnNouvelleOrdonnance.UseVisualStyleBackColor = true;
            btnNouvelleOrdonnance.Click += btnNouvelleOrdonnance_Click;
            // 
            // btnEnregistrerPDF
            // 
            btnEnregistrerPDF.Location = new Point(230, 409);
            btnEnregistrerPDF.Name = "btnEnregistrerPDF";
            btnEnregistrerPDF.Size = new Size(182, 29);
            btnEnregistrerPDF.TabIndex = 3;
            btnEnregistrerPDF.Text = "Enregistrer en PDF";
            btnEnregistrerPDF.UseVisualStyleBackColor = true;
            btnEnregistrerPDF.Click += btnEnregistrerPDF_Click;
            // 
            // OrdonnanceListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 450);
            Controls.Add(btnEnregistrerPDF);
            Controls.Add(btnNouvelleOrdonnance);
            Controls.Add(dgvLignes);
            Controls.Add(dgvOrdonnances);
            Name = "OrdonnanceListForm";
            Text = "Liste d'ordonnance";
            Load += OrdonnanceListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrdonnances).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLignes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdonnances;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Button btnNouvelleOrdonnance;
        private Button btnEnregistrerPDF;
    }
}