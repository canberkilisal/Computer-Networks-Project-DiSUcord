using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        // server socket
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // lists of users connected into server, IF100 channel and SPS101 channel respectively
        List<ConnectedClient> connectedClients = new List<ConnectedClient>();
        List<ConnectedClient> if100Clients = new List<ConnectedClient>();
        List<ConnectedClient> sps101Clients = new List<ConnectedClient>();

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        // button to start listening on the port given by user
        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            // checks for whether given port number is integer or not
            // port number is taken from user via 'text_port'
            if (Int32.TryParse(text_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                // maximum 100 clients allowed simultaneously
                serverSocket.Listen(100);

                listening = true;
                button_listen.Enabled = false;

                // starting a new thread for handling new connections
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs_server_activity.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs_server_activity.AppendText("Please check port number!\n");
                text_port.Clear();
            }

        }

        // handling new connections
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    // accepting client connection
                    Socket newClient = serverSocket.Accept();
                    
                    // starting a new thread for handling client connections
                    Thread clientConnectThread = new Thread(() => ClientConnect(newClient));
                    clientConnectThread.Start();                    
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs_server_activity.AppendText("A client failed to connect!\n"); 
                    }

                }
            }
        }

        // handling client connection
        // basically function for username control
        private void ClientConnect(Socket newClient)
        {
            try
            {
                // receive username from the client
                Byte[] buffer = new Byte[64];
                newClient.Receive(buffer);

                string usrname = Encoding.Default.GetString(buffer);
                usrname = usrname.Substring(0, usrname.IndexOf("\0"));

                // checks if username already exists
                if (connectedClients.Exists(c => c.username == usrname))
                {
                    // sending error message to the client that username exists
                    string usernameError = "$$USERNAMEERROR$$";
                    Byte[] bufferUsernameError = Encoding.Default.GetBytes(usernameError);
                    newClient.Send(bufferUsernameError);

                    logs_server_activity.AppendText("A client failed to connect!\n");
                    newClient.Close();
                }
                else
                {
                    // creating 'connectedClient' and adding to the list
                    ConnectedClient connectedClient = new ConnectedClient(newClient, usrname);
                    connectedClients.Add(connectedClient);
                    
                    // sending success message to the client
                    string usernameSuccess = "$$SUCCESS$$";
                    Byte[] bufferUsernameSuccess = Encoding.Default.GetBytes(usernameSuccess);
                    newClient.Send(bufferUsernameSuccess);

                    logs_server_activity.AppendText(usrname + " connected the server!\n");

                    // starting a new thread for handling client messages
                    Thread clientThread = new Thread(() => Receive(connectedClient));
                    clientThread.Start();
                }
            }
            catch
            {
                if (!terminating)
                {
                    logs_server_activity.AppendText("A client failed to connect\n");
                }
                newClient.Close();
            }
            // displaying connected users on server, subscribed users on IF100, subscribed users on SPS101 
            BroadcastClientLists();
        }

        // handling client messages
        // for channel subscribtions and unsubscribtions receives special code and sends special code
        //      $$SUBIF100$$ -> (if received)user wants to the subscribe channel IF100 / (if sent)user successfully subscribed to the channel IF100
        //      $$UNSUBIF100$$ -> (if received)user wants to the unsubscribe channel IF100 / (if sent)user successfully unsubscribed to the channel IF100
        //      $$SUBSPS101$$ -> (if received)user wants to the subscribe channel SPS101 / (if sent)user successfully subscribed to the channel SPS101
        //      $$UNSUBSPS101$$ -> (if received)user wants to the unsubscribe channel SPS101 / (if sent)user successfully unsubscribed to the channel SPS101
        // for sending message to the subscribed channel receives message that contains special code at the beginning and relay that message to all subsribers
        //      $$IF100$$ -> special code for channel IF100 communication
        //      $$SPS101$$ -> special code for channel SPS101 communication
        private void Receive(ConnectedClient thisClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    // receiving client message
                    Byte[] buffer = new Byte[64];
                    thisClient.clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if (incomingMessage == "$$SUBIF100$$")
                    {
                        // dispalying successfull subscription to the channel IF100
                        logs_if100_activity.AppendText(thisClient.username + ": subscribed to the IF100!\n");
                        if100Clients.Add(thisClient);

                        string outgoingMessage = "$$SUBIF100$$";
                        Byte[] bufferOutgoingMessage = Encoding.Default.GetBytes(outgoingMessage);
                        thisClient.clientSocket.Send(bufferOutgoingMessage);
                    }
                    else if (incomingMessage == "$$SUBSPS101$$")
                    {
                        // dispalying successfull subscription to the channel SPS101
                        logs_sps101_activity.AppendText(thisClient.username + ": subscribed to the SPS101!\n");
                        sps101Clients.Add(thisClient);

                        string outgoingMessage = "$$SUBSPS101$$";
                        Byte[] bufferOutgoingMessage = Encoding.Default.GetBytes(outgoingMessage);
                        thisClient.clientSocket.Send(bufferOutgoingMessage);
                    }
                    else if (incomingMessage == "$$UNSUBIF100$$")
                    {
                        // dispalying successfull unsubscription to the channel IF100
                        logs_if100_activity.AppendText(thisClient.username + ": unsubscribed to the IF100!\n");
                        if100Clients.Remove(thisClient);

                        string outgoingMessage = "$$UNSUBIF100$$";
                        Byte[] bufferOutgoingMessage = Encoding.Default.GetBytes(outgoingMessage);
                        thisClient.clientSocket.Send(bufferOutgoingMessage);
                    }
                    else if (incomingMessage == "$$UNSUBSPS101$$")
                    {
                        // dispalying successfull unsubscription to the channel SPS101
                        logs_sps101_activity.AppendText(thisClient.username + ": unsubscribed to the SPS101!\n");
                        sps101Clients.Remove(thisClient);

                        string outgoingMessage = "$$UNSUBSPS101$$";
                        Byte[] bufferOutgoingMessage = Encoding.Default.GetBytes(outgoingMessage);
                        thisClient.clientSocket.Send(bufferOutgoingMessage);
                    }
                    else if (incomingMessage.Substring(0,9) == "$$IF100$$")
                    {
                        // displaying client message sent to the channel IF100
                        logs_if100_activity.AppendText(thisClient.username + ": " + incomingMessage.Substring(9) + "\n");

                        string broadcastMessage = incomingMessage.Substring(0, 9) + thisClient.username + ": " + incomingMessage.Substring(9);

                        // broadcasting client message to the all channel IF100 subscribers
                        Byte[] bufferBroadcast = Encoding.Default.GetBytes(broadcastMessage);
                        foreach (ConnectedClient client in if100Clients)
                        {
                            client.clientSocket.Send(bufferBroadcast);
                        }
                    }
                    else if (incomingMessage.Substring(0, 10) == "$$SPS101$$")
                    {
                        // displaying client message sent to the channel SPS101
                        logs_sps101_activity.AppendText(thisClient.username + ": " + incomingMessage.Substring(10) + "\n");

                        string broadcastMessage = incomingMessage.Substring(0, 10) + thisClient.username + ": " + incomingMessage.Substring(10);

                        // broadcasting client message to the all channel SPS101 subscribers
                        Byte[] bufferBroadcast = Encoding.Default.GetBytes(broadcastMessage);
                        foreach (ConnectedClient client in sps101Clients)
                        {
                            client.clientSocket.Send(bufferBroadcast);
                        }
                    }
                    else
                    {
                        logs_server_activity.AppendText("Invalid request from " + thisClient.username + "\n");
                    } 
                }
                // if user disconnects, server unsubscribes client from all channels and server
                catch
                {
                    if (!terminating)
                    {
                        if (if100Clients.Exists(c => c == thisClient))
                        {
                            logs_if100_activity.AppendText(thisClient.username + ": unsubscribed to the IF100!\n");
                            if100Clients.Remove(thisClient);
                        }
                        if (sps101Clients.Exists(c => c == thisClient))
                        {
                            logs_sps101_activity.AppendText(thisClient.username + ": unsubscribed to the SPS101!\n");
                            sps101Clients.Remove(thisClient);
                        }
                        logs_server_activity.AppendText(thisClient.username + " has disconnected!\n");
                    }
                    thisClient.clientSocket.Close();
                    connectedClients.Remove(thisClient);
                    connected = false;
                }
                // displaying connected users on server, subscribed users on IF100, subscribed users on SPS101 
                BroadcastClientLists();
            }
        }

        // displaying connected users on server, subscribed users on IF100, subscribed users on SPS101 
        private void BroadcastClientLists()
        {
            logs_server_user.Clear();
            logs_if100_user.Clear();
            logs_sps101_user.Clear();

            List<string> connectedClientNames = connectedClients.Select(client => client.username).ToList();
            List<string> if100ClientNames = if100Clients.Select(client => client.username).ToList();
            List<string> sps101ClientNames = sps101Clients.Select(client => client.username).ToList();

            foreach (string connectedClient in connectedClientNames)
            {
                logs_server_user.AppendText(connectedClient + " is active!\n");
            }
            foreach (string connectedClient in if100ClientNames)
            {
                logs_if100_user.AppendText(connectedClient + " is active!\n");
            }
            foreach (string connectedClient in sps101ClientNames)
            {
                logs_sps101_user.AppendText(connectedClient + " is active!\n");
            }
        }

        // class to bind sockets and usernames
        private class ConnectedClient
        {
            public Socket clientSocket;
            public string username;

            public ConnectedClient(Socket socket, string usrname)
            {
                this.clientSocket = socket;
                this.username = usrname;
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}
