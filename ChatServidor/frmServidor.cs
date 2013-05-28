using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace ChatServidor
{
    public partial class frmServidor : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);

        public frmServidor()
        {
            InitializeComponent();
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            // Analisa o endereço IP do servidor informado no textbox
            IPAddress enderecoIP = IPAddress.Parse(txIp.Text);

            // Cria uma nova instância do objeto ChatServidor

            ChatServidor mainServidor = new ChatServidor(enderecoIP);

            // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
            ChatServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

            // Inicia o atendimento das conexões
            mainServidor.IniciaAtendimento();

            // Mostra que nos iniciamos o atendimento para conexões
            txLog.AppendText("Monitorando as conexões...\r\n");
        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }

        private void AtualizaStatus(string strMensagem)
        {
            txLog.AppendText(strMensagem + "\r\n");
        }
    }
}
