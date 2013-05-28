using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServidor
{
    class Conexao
    {
        // Ocorre quando um novo cliente é aceito
        private void AceitaCliente()
        {
            srReceptor = new System.IO.StreamReader(tcpCliente.GetStream());
            swEnviador = new System.IO.StreamWriter(tcpCliente.GetStream());
            // Lê a informação da conta do cliente
            usuarioAtual = srReceptor.ReadLine();
            // temos uma resposta do cliente
            if (usuarioAtual != "")
            {
                // Armazena o nome do usuário na hash table
                if (ChatServidor.htUsuarios.Contains(usuarioAtual) == true)
                {
                    // 0 => significa não conectado
                    swEnviador.WriteLine("0|Este nome de usuário já existe.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else if (usuarioAtual == "Administrator")
                {
                    // 0 => não conectado
                    swEnviador.WriteLine("0|Este nome de usuário é reservado.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else
                {
                    // 1 => conectou com sucesso
                    swEnviador.WriteLine("1");
                    swEnviador.Flush();
                    // Inclui o usuário na hash table e inicia a escuta de suas mensagens
                    ChatServidor.IncluiUsuario(tcpCliente, usuarioAtual);
                }
            }
            else
            {
                FechaConexao();
                return;
            }
            //
            try
            {
                // Continua aguardando por uma mensagem do usuário
                while ((strResposta = srReceptor.ReadLine()) != "")
                {
                    // Se for inválido remove-o
                    if (strResposta == null)
                    {
                        ChatServidor.RemoveUsuario(tcpCliente);
                    }
                    else
                    {
                        // envia a mensagem para todos os outros usuários
                        ChatServidor.EnviaMensagem(usuarioAtual, strResposta);
                    }
                }
            }
            catch
            {
                // Se houve um problema com este usuário desconecta-o
                ChatServidor.RemoveUsuario(tcpCliente);
            }
        }
    }
}

    