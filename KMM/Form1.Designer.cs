namespace KMM
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBefore = new System.Windows.Forms.PictureBox();
            this.pictureAfter = new System.Windows.Forms.PictureBox();
            this.kmmButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.Information = new System.Windows.Forms.Label();
            this.k3mButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-2, -2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBefore);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureAfter);
            this.splitContainer1.Size = new System.Drawing.Size(853, 505);
            this.splitContainer1.SplitterDistance = 427;
            this.splitContainer1.TabIndex = 3;
            // 
            // pictureBefore
            // 
            this.pictureBefore.Location = new System.Drawing.Point(0, 0);
            this.pictureBefore.Name = "pictureBefore";
            this.pictureBefore.Size = new System.Drawing.Size(419, 505);
            this.pictureBefore.TabIndex = 0;
            this.pictureBefore.TabStop = false;
            // 
            // pictureAfter
            // 
            this.pictureAfter.Location = new System.Drawing.Point(3, 0);
            this.pictureAfter.Name = "pictureAfter";
            this.pictureAfter.Size = new System.Drawing.Size(419, 505);
            this.pictureAfter.TabIndex = 0;
            this.pictureAfter.TabStop = false;
            // 
            // kmmButton
            // 
            this.kmmButton.Location = new System.Drawing.Point(897, 30);
            this.kmmButton.Name = "kmmButton";
            this.kmmButton.Size = new System.Drawing.Size(75, 23);
            this.kmmButton.TabIndex = 1;
            this.kmmButton.Text = "KMM";
            this.kmmButton.UseVisualStyleBackColor = true;
            this.kmmButton.Click += new System.EventHandler(this.kmmButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(897, 427);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Information
            // 
            this.Information.AutoSize = true;
            this.Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Information.Location = new System.Drawing.Point(857, 176);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(111, 17);
            this.Information.TabIndex = 5;
            this.Information.Text = "Waiting for input";
            // 
            // k3mButton
            // 
            this.k3mButton.Location = new System.Drawing.Point(897, 94);
            this.k3mButton.Name = "k3mButton";
            this.k3mButton.Size = new System.Drawing.Size(75, 23);
            this.k3mButton.TabIndex = 6;
            this.k3mButton.Text = "K3M";
            this.k3mButton.UseVisualStyleBackColor = true;
            this.k3mButton.Click += new System.EventHandler(this.k3mButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 503);
            this.Controls.Add(this.k3mButton);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.kmmButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button kmmButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.PictureBox pictureBefore;
        private System.Windows.Forms.PictureBox pictureAfter;
        private System.Windows.Forms.Label Information;
        private System.Windows.Forms.Button k3mButton;
    }
}

