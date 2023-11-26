namespace BubbleSort
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
            btn_BubbleSort = new Button();
            lbl_wynik = new Label();
            tbInput = new TextBox();
            SuspendLayout();
            // 
            // btn_BubbleSort
            // 
            btn_BubbleSort.Location = new Point(289, 365);
            btn_BubbleSort.Name = "btn_BubbleSort";
            btn_BubbleSort.Size = new Size(236, 29);
            btn_BubbleSort.TabIndex = 0;
            btn_BubbleSort.Text = "Start - BubbleSort";
            btn_BubbleSort.UseVisualStyleBackColor = true;
            btn_BubbleSort.Click += btn_BubbleSort_Click;
            // 
            // lbl_wynik
            // 
            lbl_wynik.AutoSize = true;
            lbl_wynik.Location = new Point(355, 156);
            lbl_wynik.Name = "lbl_wynik";
            lbl_wynik.Size = new Size(56, 20);
            lbl_wynik.TabIndex = 1;
            lbl_wynik.Text = "Wynik: ";
            // 
            // tbInput
            // 
            tbInput.Location = new Point(250, 275);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(302, 27);
            tbInput.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbInput);
            Controls.Add(lbl_wynik);
            Controls.Add(btn_BubbleSort);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_BubbleSort;
        private Label lbl_wynik;
        private TextBox tbInput;
    }
}
