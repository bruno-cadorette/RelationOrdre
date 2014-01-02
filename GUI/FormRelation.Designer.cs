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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxElements = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonEgalite = new System.Windows.Forms.RadioButton();
            this.radioButtonDivise = new System.Windows.Forms.RadioButton();
            this.buttonHasse = new System.Windows.Forms.Button();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPartition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxElements);
            this.groupBox1.Location = new System.Drawing.Point(23, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elements";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonEgalite);
            this.groupBox2.Controls.Add(this.radioButtonDivise);
            this.groupBox2.Location = new System.Drawing.Point(23, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 239);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Relation";
            // 
            // radioButtonEgalite
            // 
            this.radioButtonEgalite.AutoSize = true;
            this.radioButtonEgalite.Location = new System.Drawing.Point(7, 66);
            this.radioButtonEgalite.Name = "radioButtonEgalite";
            this.radioButtonEgalite.Size = new System.Drawing.Size(109, 29);
            this.radioButtonEgalite.TabIndex = 1;
            this.radioButtonEgalite.TabStop = true;
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
            this.radioButtonDivise.Text = "Divise";
            this.radioButtonDivise.UseVisualStyleBackColor = true;
            // 
            // buttonHasse
            // 
            this.buttonHasse.Location = new System.Drawing.Point(23, 443);
            this.buttonHasse.Name = "buttonHasse";
            this.buttonHasse.Size = new System.Drawing.Size(166, 75);
            this.buttonHasse.TabIndex = 4;
            this.buttonHasse.Text = "Diagramme de Hasse";
            this.buttonHasse.UseVisualStyleBackColor = true;
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
            // FormRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 877);
            this.Controls.Add(this.buttonHasse);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRelation";
            this.Text = "Relation d\'ordre";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox textBoxElements;
        public System.Windows.Forms.RadioButton radioButtonDivise;
        public System.Windows.Forms.RadioButton radioButtonEgalite;
        public System.Windows.Forms.Button buttonHasse;
        public System.Windows.Forms.CheckBox checkBoxPartition;
    }
}

