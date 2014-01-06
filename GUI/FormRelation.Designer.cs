namespace GUI
{
    partial class FormRelation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxElements = new System.Windows.Forms.TextBox();
            this.groupBoxRelation = new System.Windows.Forms.GroupBox();
            this.radioButtonPuissance = new System.Windows.Forms.RadioButton();
            this.radioButtonEgalite = new System.Windows.Forms.RadioButton();
            this.radioButtonDivise = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelOrdre = new System.Windows.Forms.Panel();
            this.labelMinimaux = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMinimum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMaximaux = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaximum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEquivalence = new System.Windows.Forms.Label();
            this.panelHasse = new System.Windows.Forms.Panel();
            this.buttonCalcul = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxRelation.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelOrdre.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPartition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxElements);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elements";
            // 
            // checkBoxPartition
            // 
            this.checkBoxPartition.AutoSize = true;
            this.checkBoxPartition.Location = new System.Drawing.Point(11, 70);
            this.checkBoxPartition.Name = "checkBoxPartition";
            this.checkBoxPartition.Size = new System.Drawing.Size(146, 29);
            this.checkBoxPartition.TabIndex = 2;
            this.checkBoxPartition.Text = "Partitions?";
            this.checkBoxPartition.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elements";
            // 
            // textBoxElements
            // 
            this.textBoxElements.Location = new System.Drawing.Point(113, 33);
            this.textBoxElements.Name = "textBoxElements";
            this.textBoxElements.Size = new System.Drawing.Size(283, 31);
            this.textBoxElements.TabIndex = 0;
            // 
            // groupBoxRelation
            // 
            this.groupBoxRelation.Controls.Add(this.radioButtonPuissance);
            this.groupBoxRelation.Controls.Add(this.radioButtonEgalite);
            this.groupBoxRelation.Controls.Add(this.radioButtonDivise);
            this.groupBoxRelation.Location = new System.Drawing.Point(12, 138);
            this.groupBoxRelation.Name = "groupBoxRelation";
            this.groupBoxRelation.Size = new System.Drawing.Size(429, 149);
            this.groupBoxRelation.TabIndex = 3;
            this.groupBoxRelation.TabStop = false;
            this.groupBoxRelation.Text = "Relation";
            // 
            // radioButtonPuissance
            // 
            this.radioButtonPuissance.AutoSize = true;
            this.radioButtonPuissance.Location = new System.Drawing.Point(7, 102);
            this.radioButtonPuissance.Name = "radioButtonPuissance";
            this.radioButtonPuissance.Size = new System.Drawing.Size(143, 29);
            this.radioButtonPuissance.TabIndex = 2;
            this.radioButtonPuissance.TabStop = true;
            this.radioButtonPuissance.Tag = "2";
            this.radioButtonPuissance.Text = "Puissance";
            this.radioButtonPuissance.UseVisualStyleBackColor = true;
            // 
            // radioButtonEgalite
            // 
            this.radioButtonEgalite.AutoSize = true;
            this.radioButtonEgalite.Location = new System.Drawing.Point(7, 66);
            this.radioButtonEgalite.Name = "radioButtonEgalite";
            this.radioButtonEgalite.Size = new System.Drawing.Size(109, 29);
            this.radioButtonEgalite.TabIndex = 1;
            this.radioButtonEgalite.TabStop = true;
            this.radioButtonEgalite.Tag = "1";
            this.radioButtonEgalite.Text = "Égalité";
            this.radioButtonEgalite.UseVisualStyleBackColor = true;
            // 
            // radioButtonDivise
            // 
            this.radioButtonDivise.AutoSize = true;
            this.radioButtonDivise.Location = new System.Drawing.Point(7, 31);
            this.radioButtonDivise.Name = "radioButtonDivise";
            this.radioButtonDivise.Size = new System.Drawing.Size(102, 29);
            this.radioButtonDivise.TabIndex = 0;
            this.radioButtonDivise.TabStop = true;
            this.radioButtonDivise.Tag = "0";
            this.radioButtonDivise.Text = "Divise";
            this.radioButtonDivise.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelOrdre);
            this.groupBox3.Location = new System.Drawing.Point(12, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 243);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Propriétés";
            // 
            // panelOrdre
            // 
            this.panelOrdre.Controls.Add(this.labelMinimaux);
            this.panelOrdre.Controls.Add(this.label2);
            this.panelOrdre.Controls.Add(this.labelMinimum);
            this.panelOrdre.Controls.Add(this.label3);
            this.panelOrdre.Controls.Add(this.labelMaximaux);
            this.panelOrdre.Controls.Add(this.label4);
            this.panelOrdre.Controls.Add(this.labelMaximum);
            this.panelOrdre.Controls.Add(this.label5);
            this.panelOrdre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrdre.Location = new System.Drawing.Point(3, 27);
            this.panelOrdre.Name = "panelOrdre";
            this.panelOrdre.Size = new System.Drawing.Size(407, 213);
            this.panelOrdre.TabIndex = 9;
            this.panelOrdre.Visible = false;
            // 
            // labelMinimaux
            // 
            this.labelMinimaux.AutoSize = true;
            this.labelMinimaux.Location = new System.Drawing.Point(150, 131);
            this.labelMinimaux.Name = "labelMinimaux";
            this.labelMinimaux.Size = new System.Drawing.Size(19, 25);
            this.labelMinimaux.TabIndex = 7;
            this.labelMinimaux.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Maximum :";
            // 
            // labelMinimum
            // 
            this.labelMinimum.AutoSize = true;
            this.labelMinimum.Location = new System.Drawing.Point(150, 106);
            this.labelMinimum.Name = "labelMinimum";
            this.labelMinimum.Size = new System.Drawing.Size(19, 25);
            this.labelMinimum.TabIndex = 6;
            this.labelMinimum.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Maximaux :";
            // 
            // labelMaximaux
            // 
            this.labelMaximaux.AutoSize = true;
            this.labelMaximaux.Location = new System.Drawing.Point(150, 41);
            this.labelMaximaux.Name = "labelMaximaux";
            this.labelMaximaux.Size = new System.Drawing.Size(19, 25);
            this.labelMaximaux.TabIndex = 5;
            this.labelMaximaux.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Minimum :";
            // 
            // labelMaximum
            // 
            this.labelMaximum.AutoSize = true;
            this.labelMaximum.Location = new System.Drawing.Point(150, 16);
            this.labelMaximum.Name = "labelMaximum";
            this.labelMaximum.Size = new System.Drawing.Size(19, 25);
            this.labelMaximum.TabIndex = 4;
            this.labelMaximum.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Minimaux :";
            // 
            // labelEquivalence
            // 
            this.labelEquivalence.Location = new System.Drawing.Point(447, 12);
            this.labelEquivalence.Name = "labelEquivalence";
            this.labelEquivalence.Size = new System.Drawing.Size(366, 104);
            this.labelEquivalence.TabIndex = 8;
            this.labelEquivalence.Text = "Cette relation est une relation d\'équivalence, il n\'y a donc pas de maximum/minim" +
    "um";
            this.labelEquivalence.Visible = false;
            // 
            // panelHasse
            // 
            this.panelHasse.Location = new System.Drawing.Point(15, 629);
            this.panelHasse.Name = "panelHasse";
            this.panelHasse.Size = new System.Drawing.Size(268, 136);
            this.panelHasse.TabIndex = 9;
            // 
            // buttonCalcul
            // 
            this.buttonCalcul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcul.Location = new System.Drawing.Point(12, 293);
            this.buttonCalcul.Name = "buttonCalcul";
            this.buttonCalcul.Size = new System.Drawing.Size(134, 69);
            this.buttonCalcul.TabIndex = 10;
            this.buttonCalcul.Text = "Calcul";
            this.buttonCalcul.UseVisualStyleBackColor = true;
            // 
            // FormRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 877);
            this.Controls.Add(this.buttonCalcul);
            this.Controls.Add(this.panelHasse);
            this.Controls.Add(this.labelEquivalence);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxRelation);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRelation";
            this.Text = "Relation d\'ordre";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxRelation.ResumeLayout(false);
            this.groupBoxRelation.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panelOrdre.ResumeLayout(false);
            this.panelOrdre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxElements;
        public System.Windows.Forms.RadioButton radioButtonDivise;
        public System.Windows.Forms.RadioButton radioButtonEgalite;
        public System.Windows.Forms.CheckBox checkBoxPartition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labelMinimaux;
        public System.Windows.Forms.Label labelMinimum;
        public System.Windows.Forms.Label labelMaximaux;
        public System.Windows.Forms.Label labelMaximum;
        public System.Windows.Forms.Label labelEquivalence;
        public System.Windows.Forms.Panel panelOrdre;
        public System.Windows.Forms.RadioButton radioButtonPuissance;
        public System.Windows.Forms.Panel panelHasse;
        public System.Windows.Forms.Button buttonCalcul;
        public System.Windows.Forms.GroupBox groupBoxRelation;
    }
}

