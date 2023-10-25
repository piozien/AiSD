namespace _18._10
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
            start = new Button();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(328, 326);
            start.Name = "start";
            start.Size = new Size(94, 29);
            start.TabIndex = 0;
            start.Text = "Rozpocznij";
            start.UseVisualStyleBackColor = true;
            start.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(start);
            Name = "Form1";
            Text = "sortowanie";
            ResumeLayout(false);
        }

        #endregion

        private Button start;
    }
}