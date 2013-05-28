using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Chat
{
    public partial class frmCliente : Form
    {
        // Trata o nome do usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;
        
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;
        
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            // se não esta conectando aguarda a conexão
            if (Conectado == false)
            {
                // Inicializa a conexão
                InicializaConexao();
            }
            else // Se esta conectado entao desconecta
            {
                FechaConexao("Desconectado a pedido do usuário.");
            }
        }

        private void InicializaConexao()
        {
            // Trata o endereço IP informado em um objeto IPAdress
            enderecoIP = IPAddress.Parse(txIp.Text);
            
            // Inicia uma nova conexão TCP com o servidor chat
            tcpServidor = new TcpClient();
            tcpServidor.Connect(enderecoIP, 2502);
            
            // AJuda a verificar se estamos conectados ou não
            Conectado = true;
            
            // Prepara o formulário
            NomeUsuario = txUser.Text;
            
            // Desabilita e habilita os campos apropriados
            txIp.Enabled = false;
            txUser.Enabled = false;
            txMsg.Enabled = true;
            btnEnviar.Enabled = true;
            btnConectar.Text = "Desconectado";
            
            // Envia o nome do usuário ao servidor
            stwEnviador = new StreamWriter(tcpServidor.GetStream());
            stwEnviador.WriteLine(txUser.Text);
            stwEnviador.Flush();
            //Inicia a thread para receber mensagens e nova comunicação
            mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
            mensagemThread.Start();
        }

        private void RecebeMensagens()
        {
            // recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            
            // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else // Se o primeiro caractere não for 1 a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }
            
            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                // exibe mensagems no Textbox
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            txLog.AppendText(strMensagem + "\r\n");
        }

        // Envia a mensagem para o servidor
        private void EnviaMensagem()
        {
            if (txMsg.Lines.Length >= 1)
            { //escreve a mensagem da caixa de texto
                stwEnviador.WriteLine(txMsg.Text);
                stwEnviador.Flush();
                txMsg.Lines = null;
            }
            txMsg.Text = "";
        }

        // Fecha a conexão com o servidor
        private void FechaConexao(string Motivo)
        {
            // Mostra o motivo porque a conexão encerrou
            txLog.AppendText(Motivo + "\r\n");
            // Habilita e desabilita os controles apropriados no formulario
            txIp.Enabled = true;
            txUser.Enabled = true;
            txMsg.Enabled = false;
            btnEnviar.Enabled = false;
            btnConectar.Text = "Conectado";
            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado == true)
            {
                // Fecha as conexões, streams, etc...
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviaMensagem();
        }

        private void txMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se pressionou a tecla Enter
            if (e.KeyChar == (char)13)
            {
                EnviaMensagem();
            }
        }


    }
}
