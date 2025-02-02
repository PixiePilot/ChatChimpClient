﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UserClient;
namespace Networking {

    class EntryPoint {
        //on launch
        public struct initPacket {
            //length package
            int len { get; set; }
            public ushort responseState { get; set; }
        }
        //initialize socket
        static void Main(string[] args) {
            initSocket();
            Console.ReadLine();
        }
        //connect
        static void initSocket() {
            Client client = new Client("192.168.137.1", 25565);
            client.connect();
        }

        static void startReceiving( Client client)
        {
            EndPoint remoteEndPoint = client.getConn().RemoteEndPoint!;
            client.getConn().BeginReceiveFrom(client.getBuffer(), 0, client.getBuffer().Length, SocketFlags.None, ref remoteEndPoint, handlePacket, client);
        }

        static void handlePacket( IAsyncResult result) {

        }
    }
}