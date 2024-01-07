namespace Algorytm_Kruskala
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
            Algorytm_Kruskala = new Button();
            SuspendLayout();
            // 
            // Algorytm_Kruskala
            // 
            Algorytm_Kruskala.BackgroundImageLayout = ImageLayout.None;
            Algorytm_Kruskala.Location = new Point(294, 350);
            Algorytm_Kruskala.Name = "Algorytm_Kruskala";
            Algorytm_Kruskala.Size = new Size(191, 29);
            Algorytm_Kruskala.TabIndex = 0;
            Algorytm_Kruskala.Text = "Algorytm Kruskala";
            Algorytm_Kruskala.UseVisualStyleBackColor = true;
            Algorytm_Kruskala.Click += Algorytm_Kruskala_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Algorytm_Kruskala);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button Algorytm_Kruskala;
    }
}
