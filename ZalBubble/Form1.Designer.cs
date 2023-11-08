namespace ZalBubble
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
            lbl_wynik = new Label();
            tbInput = new TextBox();
            btn_BubbleSort = new Button();
            SuspendLayout();
            // 
            // lbl_wynik
            // 
            lbl_wynik.AutoSize = true;
            lbl_wynik.Location = new Point(330, 274);
            lbl_wynik.Name = "lbl_wynik";
            lbl_wynik.Size = new Size(50, 20);
            lbl_wynik.TabIndex = 0;
            lbl_wynik.Text = "label1";
            // 
            // tbInput
            // 
            tbInput.Location = new Point(241, 183);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(253, 27);
            tbInput.TabIndex = 1;
            // 
            // btn_BubbleSort
            // 
            btn_BubbleSort.Location = new Point(302, 346);
            btn_BubbleSort.Name = "btn_BubbleSort";
            btn_BubbleSort.Size = new Size(94, 29);
            btn_BubbleSort.TabIndex = 2;
            btn_BubbleSort.Text = "button1";
            btn_BubbleSort.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_BubbleSort);
            Controls.Add(tbInput);
            Controls.Add(lbl_wynik);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_wynik;
        private TextBox tbInput;
        private Button btn_BubbleSort;
    }
}