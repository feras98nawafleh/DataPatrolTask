namespace DP.APIClient
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
            this.startThreadButton = new System.Windows.Forms.Button();
            this.stopThreadsButton = new System.Windows.Forms.Button();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.endpointLabel = new System.Windows.Forms.Label();
            this.listViewListeners = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonUnregister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startThreadButton
            // 
            this.startThreadButton.Location = new System.Drawing.Point(155, 91);
            this.startThreadButton.Name = "startThreadButton";
            this.startThreadButton.Size = new System.Drawing.Size(173, 23);
            this.startThreadButton.TabIndex = 0;
            this.startThreadButton.Text = "Start Threads";
            this.startThreadButton.UseVisualStyleBackColor = true;
            this.startThreadButton.Click += new System.EventHandler(this.startThreadButton_Click);
            // 
            // stopThreadsButton
            // 
            this.stopThreadsButton.Location = new System.Drawing.Point(431, 91);
            this.stopThreadsButton.Name = "stopThreadsButton";
            this.stopThreadsButton.Size = new System.Drawing.Size(173, 23);
            this.stopThreadsButton.TabIndex = 1;
            this.stopThreadsButton.Text = "Stop Threads";
            this.stopThreadsButton.UseVisualStyleBackColor = true;
            this.stopThreadsButton.Click += new System.EventHandler(this.stopThreadsButton_Click);
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Location = new System.Drawing.Point(155, 36);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(449, 20);
            this.endpointTextBox.TabIndex = 2;
            // 
            // endpointLabel
            // 
            this.endpointLabel.AutoSize = true;
            this.endpointLabel.Location = new System.Drawing.Point(111, 39);
            this.endpointLabel.Name = "endpointLabel";
            this.endpointLabel.Size = new System.Drawing.Size(27, 13);
            this.endpointLabel.TabIndex = 3;
            this.endpointLabel.Text = "API:";
            // 
            // listViewListeners
            // 
            this.listViewListeners.HideSelection = false;
            this.listViewListeners.Location = new System.Drawing.Point(155, 152);
            this.listViewListeners.Name = "listViewListeners";
            this.listViewListeners.Size = new System.Drawing.Size(449, 233);
            this.listViewListeners.TabIndex = 4;
            this.listViewListeners.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(357, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(8, 8);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(155, 391);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(173, 23);
            this.buttonRegister.TabIndex = 6;
            this.buttonRegister.Text = "Register new Listener";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonUnregister
            // 
            this.buttonUnregister.Location = new System.Drawing.Point(431, 391);
            this.buttonUnregister.Name = "buttonUnregister";
            this.buttonUnregister.Size = new System.Drawing.Size(173, 23);
            this.buttonUnregister.TabIndex = 7;
            this.buttonUnregister.Text = "Unregister Selected Listener";
            this.buttonUnregister.UseVisualStyleBackColor = true;
            this.buttonUnregister.Click += new System.EventHandler(this.buttonUnregister_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.buttonUnregister);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listViewListeners);
            this.Controls.Add(this.endpointLabel);
            this.Controls.Add(this.endpointTextBox);
            this.Controls.Add(this.stopThreadsButton);
            this.Controls.Add(this.startThreadButton);
            this.Name = "Random Numbers Broadcaster";
            this.Text = "Random Numbers Broadcaster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startThreadButton;
        private System.Windows.Forms.Button stopThreadsButton;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.Label endpointLabel;
        private System.Windows.Forms.ListView listViewListeners;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonUnregister;
    }
}

