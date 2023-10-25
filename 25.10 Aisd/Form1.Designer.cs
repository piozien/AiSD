namespace _25._10_Aisd
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
            tbInput = new TextBox();
            btnBubbleSort = new Button();
            lblWynik = new Label();
            SuspendLayout();
            // 
            // tbInput
            // 
            tbInput.Location = new Point(260, 170);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(231, 27);
            tbInput.TabIndex = 0;
            // 
            // btnBubbleSort
            // 
            btnBubbleSort.Location = new Point(310, 307);
            btnBubbleSort.Name = "btnBubbleSort";
            btnBubbleSort.Size = new Size(125, 51);
            btnBubbleSort.TabIndex = 2;
            btnBubbleSort.Text = "Start";
            btnBubbleSort.UseVisualStyleBackColor = true;
            // 
            // lblWynik
            // 
            lblWynik.AutoSize = true;
            lblWynik.Location = new Point(347, 252);
            lblWynik.Name = "lblWynik";
            lblWynik.Size = new Size(50, 20);
            lblWynik.TabIndex = 3;
            lblWynik.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWynik);
            Controls.Add(btnBubbleSort);
            Controls.Add(tbInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbInput;
        private Button btnBubbleSort;
        private Label lblWynik;
    }
}