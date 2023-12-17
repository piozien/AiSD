namespace dodawanie_w_słupku
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
            a = new NumericUpDown();
            b = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)a).BeginInit();
            ((System.ComponentModel.ISupportInitialize)b).BeginInit();
            SuspendLayout();
            // 
            // StartBT
            // 
            StartBT.Location = new Point(346, 349);
            StartBT.Name = "StartBT";
            StartBT.Size = new Size(94, 29);
            StartBT.TabIndex = 0;
            StartBT.Text = "StartBT";
            StartBT.UseVisualStyleBackColor = true;
            StartBT.Click += StartBT_Click;
            // 
            // a
            // 
            a.Location = new Point(209, 295);
            a.Name = "a";
            a.Size = new Size(150, 27);
            a.TabIndex = 1;
            // 
            // b
            // 
            b.Location = new Point(439, 295);
            b.Name = "b";
            b.Size = new Size(150, 27);
            b.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(b);
            Controls.Add(a);
            Controls.Add(StartBT);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)a).EndInit();
            ((System.ComponentModel.ISupportInitialize)b).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button StartBT;
        private NumericUpDown a;
        private NumericUpDown b;
    }
}
