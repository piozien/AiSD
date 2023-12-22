namespace dijkstry
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
            DijkstryBT = new Button();
            SuspendLayout();
            // 
            // DijkstryBT
            // 
            DijkstryBT.Location = new Point(270, 365);
            DijkstryBT.Name = "DijkstryBT";
            DijkstryBT.Size = new Size(268, 46);
            DijkstryBT.TabIndex = 0;
            DijkstryBT.Text = "Dijkstry";
            DijkstryBT.UseVisualStyleBackColor = true;
            DijkstryBT.Click += DijkstryBT_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DijkstryBT);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button DijkstryBT;
    }
}
