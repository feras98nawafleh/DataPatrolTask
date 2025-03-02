namespace DP.UserRequestsDesktopApp
{
    partial class RequestForm
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
            this.requestCodeTextbox = new System.Windows.Forms.TextBox();
            this.requestCodeLabel = new System.Windows.Forms.Label();
            this.requestDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.requestDescriptionLabel = new System.Windows.Forms.Label();
            this.createRequestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // requestCodeTextbox
            // 
            this.requestCodeTextbox.Location = new System.Drawing.Point(178, 87);
            this.requestCodeTextbox.Name = "requestCodeTextbox";
            this.requestCodeTextbox.Size = new System.Drawing.Size(372, 20);
            this.requestCodeTextbox.TabIndex = 0;
            // 
            // requestCodeLabel
            // 
            this.requestCodeLabel.AutoSize = true;
            this.requestCodeLabel.Location = new System.Drawing.Point(87, 90);
            this.requestCodeLabel.Name = "requestCodeLabel";
            this.requestCodeLabel.Size = new System.Drawing.Size(75, 13);
            this.requestCodeLabel.TabIndex = 1;
            this.requestCodeLabel.Text = "Request Code";
            // 
            // requestDescriptionTextbox
            // 
            this.requestDescriptionTextbox.Location = new System.Drawing.Point(178, 156);
            this.requestDescriptionTextbox.Name = "requestDescriptionTextbox";
            this.requestDescriptionTextbox.Size = new System.Drawing.Size(372, 20);
            this.requestDescriptionTextbox.TabIndex = 2;
            // 
            // requestDescriptionLabel
            // 
            this.requestDescriptionLabel.AutoSize = true;
            this.requestDescriptionLabel.Location = new System.Drawing.Point(69, 159);
            this.requestDescriptionLabel.Name = "requestDescriptionLabel";
            this.requestDescriptionLabel.Size = new System.Drawing.Size(103, 13);
            this.requestDescriptionLabel.TabIndex = 3;
            this.requestDescriptionLabel.Text = "Request Description";
            // 
            // createRequestButton
            // 
            this.createRequestButton.Location = new System.Drawing.Point(334, 249);
            this.createRequestButton.Name = "createRequestButton";
            this.createRequestButton.Size = new System.Drawing.Size(75, 23);
            this.createRequestButton.TabIndex = 4;
            this.createRequestButton.Text = "Create Request";
            this.createRequestButton.UseVisualStyleBackColor = true;
            this.createRequestButton.Click += new System.EventHandler(this.createRequestButton_Click);
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createRequestButton);
            this.Controls.Add(this.requestDescriptionLabel);
            this.Controls.Add(this.requestDescriptionTextbox);
            this.Controls.Add(this.requestCodeLabel);
            this.Controls.Add(this.requestCodeTextbox);
            this.Name = "RequestForm";
            this.Text = "RequestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox requestCodeTextbox;
        private System.Windows.Forms.Label requestCodeLabel;
        private System.Windows.Forms.TextBox requestDescriptionTextbox;
        private System.Windows.Forms.Label requestDescriptionLabel;
        private System.Windows.Forms.Button createRequestButton;
    }
}