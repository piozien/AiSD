namespace SelectSort
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
            SelectSort = new Button();
            tbInput = new TextBox();
            lblWynik = new Label();
            SuspendLayout();
            // 
            // SelectSort
            // 
            SelectSort.Location = new Point(293, 348);
            SelectSort.Name = "SelectSort";
            SelectSort.Size = new Size(201, 29);
            SelectSort.TabIndex = 0;
            SelectSort.Text = "Select";
            SelectSort.UseVisualStyleBackColor = true;
            SelectSort.Click += SelectSort_Click;
            // 
            // tbInput
            // 
            tbInput.Location = new Point(263, 295);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(275, 27);
            tbInput.TabIndex = 1;
            // 
            // lblWynik
            // 
            lblWynik.AutoSize = true;
            lblWynik.Location = new Point(352, 210);
            lblWynik.Name = "lblWynik";
            lblWynik.Size = new Size(50, 20);
            lblWynik.TabIndex = 2;
            lblWynik.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWynik);
            Controls.Add(tbInput);
            Controls.Add(SelectSort);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SelectSort;
        private TextBox tbInput;
        private Label lblWynik;
    }
}
