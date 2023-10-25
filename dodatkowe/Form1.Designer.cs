namespace dodatkowe
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.NumericA = new System.Windows.Forms.NumericUpDown();
            this.NumericB = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumericA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericB)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(340, 205);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(89, 94);
            this.start.TabIndex = 0;
            this.start.Text = "Rozpocznij dodawanie";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // NumericA
            // 
            this.NumericA.Location = new System.Drawing.Point(152, 242);
            this.NumericA.Name = "NumericA";
            this.NumericA.Size = new System.Drawing.Size(120, 22);
            this.NumericA.TabIndex = 1;
            this.NumericA.ValueChanged += new System.EventHandler(this.NumericA_ValueChanged);
            // 
            // NumericB
            // 
            this.NumericB.Location = new System.Drawing.Point(469, 242);
            this.NumericB.Name = "NumericB";
            this.NumericB.Size = new System.Drawing.Size(120, 22);
            this.NumericB.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NumericA);
            this.Controls.Add(this.NumericB);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.NumericUpDown NumericA;
        private System.Windows.Forms.NumericUpDown NumericB;
    }
}

