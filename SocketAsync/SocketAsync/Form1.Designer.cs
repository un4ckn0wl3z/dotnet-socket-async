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
            this.btnAcceptIncomingAsync.Location = new System.Drawing.Point(21, 255);
            this.btnAcceptIncomingAsync.Name = "btnAcceptIncomingAsync";
            this.btnAcceptIncomingAsync.Size = new System.Drawing.Size(95, 38);
            this.btnAcceptIncomingAsync.TabIndex = 0;
            this.btnAcceptIncomingAsync.Text = "Start Server";
            this.btnAcceptIncomingAsync.UseVisualStyleBackColor = true;
            this.btnAcceptIncomingAsync.Click += new System.EventHandler(this.btnAcceptIncomingAsync_Click);
            // 
            // txtMessageToClient
            // 
            this.txtMessageToClient.Location = new System.Drawing.Point(173, 196);
            this.txtMessageToClient.Name = "txtMessageToClient";
            this.txtMessageToClient.Size = new System.Drawing.Size(496, 22);
            this.txtMessageToClient.TabIndex = 1;
            // 
            // lblMessageToClent
            // 
            this.lblMessageToClent.AutoSize = true;
            this.lblMessageToClent.Location = new System.Drawing.Point(12, 199);
            this.lblMessageToClent.Name = "lblMessageToClent";
            this.lblMessageToClent.Size = new System.Drawing.Size(140, 17);
            this.lblMessageToClent.TabIndex = 2;
            this.lblMessageToClent.Text = "Message to all client:";
            this.lblMessageToClent.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSendMessageToClient
            // 
            this.btnSendMessageToClient.Location = new System.Drawing.Point(562, 255);
            this.btnSendMessageToClient.Name = "btnSendMessageToClient";
            this.btnSendMessageToClient.Size = new System.Drawing.Size(95, 38);
            this.btnSendMessageToClient.TabIndex = 3;
            this.btnSendMessageToClient.Text = "Send";
            this.btnSendMessageToClient.UseVisualStyleBackColor = true;
            this.btnSendMessageToClient.Click += new System.EventHandler(this.btnSendMessageToClient_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(122, 255);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(95, 38);
            this.btnStopServer.TabIndex = 4;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(669, 187);
            this.txtConsole.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 305);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnSendMessageToClient);
            this.Controls.Add(this.lblMessageToClent);
            this.Controls.Add(this.txtMessageToClient);
            this.Controls.Add(this.btnAcceptIncomingAsync);
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

