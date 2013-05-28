namespace Chat
{
    partial class frmCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.txIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txUser = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txMsg = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Servidor:";
            // 
            // txIp
            // 
            this.txIp.Location = new System.Drawing.Point(80, 18);
            this.txIp.Name = "txIp";
            this.txIp.Size = new System.Drawing.Size(186, 20);
            this.txIp.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario:";
            // 
            // txUser
            // 
            this.txUser.Location = new System.Drawing.Point(80, 44);
            this.txUser.Name = "txUser";
            this.txUser.Size = new System.Drawing.Size(186, 20);
            this.txUser.TabIndex = 1;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(280, 42);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 2;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txMsg
            // 
            this.txMsg.Location = new System.Drawing.Point(15, 306);
            this.txMsg.Name = "txMsg";
            this.txMsg.Size = new System.Drawing.Size(257, 20);
            this.txMsg.TabIndex = 1;
            this.txMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMsg_KeyPress);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(280, 304);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txLog
            // 
            this.txLog.Location = new System.Drawing.Point(12, 70);
            this.txLog.Multiline = true;
            this.txLog.Name = "txLog";
            this.txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txLog.Size = new System.Drawing.Size(343, 230);
            this.txLog.TabIndex = 1;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 343);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txMsg);
            this.Controls.Add(this.txLog);
            this.Controls.Add(this.txUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txIp);
            this.Controls.Add(this.label1);
            this.Name = "frmCliente";
            this.Text = "Chat: Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txUser;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txMsg;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txLog;
    }
}

