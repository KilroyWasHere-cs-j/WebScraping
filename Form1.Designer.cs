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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.LoadHtml = new System.Windows.Forms.Button();
            this.ShowHtmlRawRB = new System.Windows.Forms.RadioButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.showConfigbtn = new System.Windows.Forms.Button();
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
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 85);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1840, 797);
            this.webBrowser1.TabIndex = 3;
            // 
            // showConfigbtn
            // 
            this.showConfigbtn.Location = new System.Drawing.Point(251, 38);
            this.showConfigbtn.Name = "showConfigbtn";
            this.showConfigbtn.Size = new System.Drawing.Size(75, 23);
            this.showConfigbtn.TabIndex = 4;
            this.showConfigbtn.Text = "Show Config";
            this.showConfigbtn.UseVisualStyleBackColor = true;
            this.showConfigbtn.Click += new System.EventHandler(this.showConfigbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1855, 885);
            this.Controls.Add(this.showConfigbtn);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.ShowHtmlRawRB);
            this.Controls.Add(this.LoadHtml);
            this.Controls.Add(this.UrlTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button showConfigbtn;
    }
}

