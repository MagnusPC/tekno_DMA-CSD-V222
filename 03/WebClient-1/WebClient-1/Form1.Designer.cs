namespace WebClient_1
{
    partial class FortuneCookie
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
            this.tbFortune = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFortune
            // 
            this.tbFortune.Location = new System.Drawing.Point(5, 5);
            this.tbFortune.Multiline = true;
            this.tbFortune.Name = "tbFortune";
            this.tbFortune.Size = new System.Drawing.Size(790, 441);
            this.tbFortune.TabIndex = 0;
            // 
            // FortuneCookie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbFortune);
            this.Name = "FortuneCookie";
            this.Text = "FortuneCookie";
            this.Load += new System.EventHandler(this.FortuneCookie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbFortune;
    }
}