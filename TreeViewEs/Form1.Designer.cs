namespace TreeViewEs
{
    partial class Form1
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
            treeView1 = new TreeView();
            btnCaricaFile1 = new Button();
            btnPulisciAlbero = new Button();
            btnCaricaFile2 = new Button();
            lblCaricamento = new Label();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(362, 426);
            treeView1.TabIndex = 0;
            // 
            // btnCaricaFile1
            // 
            btnCaricaFile1.Location = new Point(425, 112);
            btnCaricaFile1.Name = "btnCaricaFile1";
            btnCaricaFile1.Size = new Size(89, 40);
            btnCaricaFile1.TabIndex = 1;
            btnCaricaFile1.Text = "Carica File \"Figlio-Padre\"";
            btnCaricaFile1.UseVisualStyleBackColor = true;
            btnCaricaFile1.Click += btnCaricaFile1_Click;
            // 
            // btnPulisciAlbero
            // 
            btnPulisciAlbero.Location = new Point(635, 112);
            btnPulisciAlbero.Name = "btnPulisciAlbero";
            btnPulisciAlbero.Size = new Size(75, 40);
            btnPulisciAlbero.TabIndex = 2;
            btnPulisciAlbero.Text = "Ripulisci Albero";
            btnPulisciAlbero.UseVisualStyleBackColor = true;
            btnPulisciAlbero.Click += btnPulisciAlbero_Click;
            // 
            // btnCaricaFile2
            // 
            btnCaricaFile2.Location = new Point(535, 112);
            btnCaricaFile2.Name = "btnCaricaFile2";
            btnCaricaFile2.Size = new Size(75, 40);
            btnCaricaFile2.TabIndex = 3;
            btnCaricaFile2.Text = "Carica File \"-\"";
            btnCaricaFile2.UseVisualStyleBackColor = true;
            btnCaricaFile2.Click += btnCaricaFile2_Click;
            // 
            // lblCaricamento
            // 
            lblCaricamento.AutoSize = true;
            lblCaricamento.Location = new Point(425, 169);
            lblCaricamento.Name = "lblCaricamento";
            lblCaricamento.Size = new Size(0, 15);
            lblCaricamento.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCaricamento);
            Controls.Add(btnCaricaFile2);
            Controls.Add(btnPulisciAlbero);
            Controls.Add(btnCaricaFile1);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button btnCaricaFile1;
        private Button btnPulisciAlbero;
        private Button btnCaricaFile2;
        private Label lblCaricamento;
    }
}
