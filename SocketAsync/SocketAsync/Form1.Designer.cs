namespace SocketAsync
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
            this.btnAcceptIncomingAsync = new System.Windows.Forms.Button();
            this.txtMessageToClient = new System.Windows.Forms.TextBox();
            this.lblMessageToClent = new System.Windows.Forms.Label();
            this.btnSendMessageToClient = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAcceptIncomingAsync
            // 
            this.btnAcceptIncomingAsync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAcceptIncomingAsync.Location = new System.Drawing.Point(11, 207);
            this.btnAcceptIncomingAsync.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAcceptIncomingAsync.Name = "btnAcceptIncomingAsync";
            this.btnAcceptIncomingAsync.Size = new System.Drawing.Size(71, 31);
            this.btnAcceptIncomingAsync.TabIndex = 0;
            this.btnAcceptIncomingAsync.Text = "Start Server";
            this.btnAcceptIncomingAsync.UseVisualStyleBackColor = true;
            this.btnAcceptIncomingAsync.Click += new System.EventHandler(this.btnAcceptIncomingAsync_Click);
            // 
            // txtMessageToClient
            // 
            this.txtMessageToClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageToClient.Location = new System.Drawing.Point(130, 159);
            this.txtMessageToClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMessageToClient.Name = "txtMessageToClient";
            this.txtMessageToClient.Size = new System.Drawing.Size(363, 20);
            this.txtMessageToClient.TabIndex = 1;
            // 
            // lblMessageToClent
            // 
            this.lblMessageToClent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessageToClent.AutoSize = true;
            this.lblMessageToClent.Location = new System.Drawing.Point(9, 162);
            this.lblMessageToClent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessageToClent.Name = "lblMessageToClent";
            this.lblMessageToClent.Size = new System.Drawing.Size(106, 13);
            this.lblMessageToClent.TabIndex = 2;
            this.lblMessageToClent.Text = "Message to all client:";
            // 
            // btnSendMessageToClient
            // 
            this.btnSendMessageToClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendMessageToClient.Location = new System.Drawing.Point(422, 207);
            this.btnSendMessageToClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendMessageToClient.Name = "btnSendMessageToClient";
            this.btnSendMessageToClient.Size = new System.Drawing.Size(71, 31);
            this.btnSendMessageToClient.TabIndex = 3;
            this.btnSendMessageToClient.Text = "Send";
            this.btnSendMessageToClient.UseVisualStyleBackColor = true;
            this.btnSendMessageToClient.Click += new System.EventHandler(this.btnSendMessageToClient_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopServer.Location = new System.Drawing.Point(92, 207);
            this.btnStopServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(71, 31);
            this.btnStopServer.TabIndex = 4;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(501, 153);
            this.txtConsole.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 248);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnSendMessageToClient);
            this.Controls.Add(this.lblMessageToClent);
            this.Controls.Add(this.txtMessageToClient);
            this.Controls.Add(this.btnAcceptIncomingAsync);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcceptIncomingAsync;
        private System.Windows.Forms.TextBox txtMessageToClient;
        private System.Windows.Forms.Label lblMessageToClent;
        private System.Windows.Forms.Button btnSendMessageToClient;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.TextBox txtConsole;
    }
}

