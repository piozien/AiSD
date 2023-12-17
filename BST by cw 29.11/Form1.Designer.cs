namespace BST_by_cw_29._11
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
            StartBST = new Button();
            SuspendLayout();
            // 
            // StartBST
            // 
            StartBST.Location = new Point(252, 329);
            StartBST.Name = "StartBST";
            StartBST.Size = new Size(273, 29);
            StartBST.TabIndex = 0;
            StartBST.Text = "Drzewo binarne";
            StartBST.UseVisualStyleBackColor = true;
            StartBST.Click += StartBST_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartBST);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button StartBST;
    }
}
