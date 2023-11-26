namespace Binarne_drzewo_przeszukiwań_BST
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
            StartBT = new Button();
            tbInput = new TextBox();
            SuspendLayout();
            // 
            // StartBT
            // 
            StartBT.Location = new Point(342, 395);
            StartBT.Name = "StartBT";
            StartBT.Size = new Size(94, 29);
            StartBT.TabIndex = 0;
            StartBT.Text = "Start";
            StartBT.UseVisualStyleBackColor = true;
            StartBT.Click += button1_Click;
            // 
            // tbInput
            // 
            tbInput.Location = new Point(253, 298);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(269, 27);
            tbInput.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbInput);
            Controls.Add(StartBT);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartBT;
        private TextBox tbInput;
    }
}
