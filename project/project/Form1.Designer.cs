namespace project
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
            label1 = new Label();
            text = new TextBox();
            goHash = new Button();
            label2 = new Label();
            result = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(564, 50);
            label1.TabIndex = 0;
            label1.Text = "Введите текст для хеширования";
            // 
            // text
            // 
            text.Font = new Font("Segoe UI", 22F);
            text.Location = new Point(110, 77);
            text.Name = "text";
            text.Size = new Size(358, 51);
            text.TabIndex = 1;
            // 
            // goHash
            // 
            goHash.Font = new Font("Segoe UI", 22F);
            goHash.Location = new Point(151, 152);
            goHash.Name = "goHash";
            goHash.Size = new Size(267, 53);
            goHash.TabIndex = 2;
            goHash.Text = "Захешировать";
            goHash.UseVisualStyleBackColor = true;
            goHash.Click += goHash_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F);
            label2.Location = new Point(195, 249);
            label2.Name = "label2";
            label2.Size = new Size(185, 50);
            label2.TabIndex = 3;
            label2.Text = "Результат";
            // 
            // result
            // 
            result.Font = new Font("Segoe UI", 22F);
            result.Location = new Point(12, 309);
            result.Name = "result";
            result.Size = new Size(550, 51);
            result.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 372);
            Controls.Add(result);
            Controls.Add(label2);
            Controls.Add(goHash);
            Controls.Add(text);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox text;
        private Button goHash;
        private Label label2;
        private TextBox result;
    }
}
