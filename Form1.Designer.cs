namespace WebScraping_wf.cs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.LoadHtml = new System.Windows.Forms.Button();
            this.ShowHtmlRawRB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(12, 12);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(586, 20);
            this.UrlTextBox.TabIndex = 0;
            // 
            // LoadHtml
            // 
            this.LoadHtml.Location = new System.Drawing.Point(12, 38);
            this.LoadHtml.Name = "LoadHtml";
            this.LoadHtml.Size = new System.Drawing.Size(126, 23);
            this.LoadHtml.TabIndex = 1;
            this.LoadHtml.Text = "Load Web Page";
            this.LoadHtml.UseVisualStyleBackColor = true;
            this.LoadHtml.Click += new System.EventHandler(this.LoadHtml_Click);
            // 
            // ShowHtmlRawRB
            // 
            this.ShowHtmlRawRB.AutoSize = true;
            this.ShowHtmlRawRB.Location = new System.Drawing.Point(144, 41);
            this.ShowHtmlRawRB.Name = "ShowHtmlRawRB";
            this.ShowHtmlRawRB.Size = new System.Drawing.Size(101, 17);
            this.ShowHtmlRawRB.TabIndex = 2;
            this.ShowHtmlRawRB.TabStop = true;
            this.ShowHtmlRawRB.Text = "Show Raw Html";
            this.ShowHtmlRawRB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 450);
            this.Controls.Add(this.ShowHtmlRawRB);
            this.Controls.Add(this.LoadHtml);
            this.Controls.Add(this.UrlTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Button LoadHtml;
        private System.Windows.Forms.RadioButton ShowHtmlRawRB;
    }
}

