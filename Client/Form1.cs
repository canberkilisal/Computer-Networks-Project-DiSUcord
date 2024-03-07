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

namespace Client
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        // button for connecting to the server
        // client enters:
        //      IP -> text_ip
        //      portnNum -> text_port
        //      username -> text_username
        private void button_srv_connect_Click(object sender, EventArgs e)
        {
            int portNum;
            IPAddress IP;

            // check for IP Address format
            if (IPAddress.TryParse(text_ip.Text, out IP))
            {
                // check for port number format
                if (Int32.TryParse(text_port.Text, out portNum))
                {
                    // check for whether username is empty or not
                    if (text_username.Text.Length != 0)
                    {
                        // disabling connect button during connection attempt
                        button_srv_connect.Enabled = false;
                        logs_server.AppendText("Trying to connect to the server!\nPlease wait...\n");

                        // starting a thread for connection attempt 
                        // allows responsiveness during connection attempt
                        Task.Run(() =>
                        {
                            try
                            {
                                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                clientSocket.Connect(IP, portNum);

                                string username = text_username.Text;
                                Byte[] buffer = Encoding.Default.GetBytes(username);
                                clientSocket.Send(buffer);


                                connected = true;

                                Thread receiveThread = new Thread(Receive);
                                receiveThread.Start();

                            }
                            catch
                            {
                                logs_server.AppendText("Could not connect to the server!\n");
                                // after unsuccessfull connection allows user to connect again
                                button_srv_connect.Enabled = true;
                            }
                        });
                    }
                    else
                    {
                        logs_server.AppendText("Please enter username!\n");
                    }
                }
                else
                {
                    logs_server.AppendText("Invalid port number format!\n");
                    text_port.Clear();
                }
            }
            else
            {
                logs_server.AppendText("Invalid IP address format!\n");
                text_ip.Clear();
            }
        }

        // function to handle receiving messages from server
        // receives a special code indicating status information
        //      $$USERNAMEERROR$$ -> username exists error
        //      $$SUCCESS$$ -> successfull connection to the server
        //      $$SUBIF100$$ -> successfull subscription to the channel IF100
        //      $$UNSUBIF100$$ -> successfull unsubscription to the channel IF100
        //      $$SUBSPS101$$ -> successfull subscription to the channel SPS101
        //      $$UNSUBSPS101$$ -> successfull unsubscription to the channel SPS101
        // receives a message message that contains special code at the beginning
        //      $$IF100$$ -> special code for channel IF100 communication
        //      $$SPS101$$ -> special code for channel SPS101 communication 
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));


                    if (incomingMessage == "$$USERNAMEERROR$$")
                    {
                        logs_server.AppendText("Server: Username exists! Try different username.\n");
                        clientSocket.Close();
                        connected = false;
                        // enables the connection button
                        button_srv_connect.Enabled = true;
                    }
                    else if (incomingMessage == "$$SUCCESS$$")
                    {
                        logs_server.AppendText("Server: Succesfully connected to the server!\n");
                        // disables the connection button and enables the subscription buttons
                        button_srv_connect.Enabled = false;
                        button_subs_if100.Enabled = true;
                        button_subs_sps101.Enabled = true;
                    }
                    else if(incomingMessage == "$$SUBIF100$$")
                    {
                        logs_server.AppendText("Server: Succesfully subscribed to the IF100!\n");
                        // disables the IF100 subscription button and enables the textbox, send button and unsubscription button for IF100
                        button_subs_if100.Enabled = false;
                        button_unsubs_if100.Enabled = true;
                        text_if100.Enabled = true;
                        button_send_if100.Enabled = true;
                    }
                    else if (incomingMessage == "$$UNSUBIF100$$")
                    {
                        logs_server.AppendText("Server: Succesfully unsubscribed to the IF100!\n");
                        // clears IF100 chat log
                        logs_if100.Clear();
                        // enables the IF100 subscription button and disables the textbox, send button and unsubscription button for IF100
                        button_subs_if100.Enabled = true;
                        button_unsubs_if100.Enabled = false;
                        text_if100.Enabled = false;
                        button_send_if100.Enabled = false;
                    }
                    else if (incomingMessage == "$$SUBSPS101$$")
                    {
                        logs_server.AppendText("Server: Succesfully subscribed to the SPS101!\n");
                        // disables the SUBSPS101 subscription button and enables the textbox, send button and unsubscription button for SUBSPS101
                        button_subs_sps101.Enabled = false;
                        button_unsubs_sps101.Enabled = true;
                        text_sps101.Enabled = true;
                        button_send_sps101.Enabled = true;
                    }
                    else if (incomingMessage == "$$UNSUBSPS101$$")
                    {
                        logs_server.AppendText("Server: Succesfully unsubscribed to the SPS101!\n");
                        // clears SPS101 chat log
                        logs_sps101.Clear();
                        // enables the SPS101 subscription button and disables the textbox, send button and unsubscription button for SPS101
                        button_subs_sps101.Enabled = true;
                        button_unsubs_sps101.Enabled = false;
                        text_sps101.Enabled = false;
                        button_send_sps101.Enabled = false;
                    }
                    else if (incomingMessage.Substring(0, 9) == "$$IF100$$")
                    {
                        // displays client messages sent to channel IF100
                        logs_if100.AppendText(incomingMessage.Substring(9) + "\n");
                    }
                    else if (incomingMessage.Substring(0, 10) == "$$SPS101$$")
                    {
                        // displays client messages sent to channel SPS101
                        logs_sps101.AppendText(incomingMessage.Substring(10) + "\n");
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs_server.AppendText("The server has disconnected!\n");
                        // enables the connection button
                        button_srv_connect.Enabled = true;

                        // disables controls related to channels
                        text_if100.Enabled = false;
                        button_subs_if100.Enabled = false;
                        button_unsubs_if100.Enabled = false;
                        button_send_if100.Enabled = false;

                        text_sps101.Enabled = false;
                        button_subs_sps101.Enabled = false;
                        button_unsubs_sps101.Enabled = false;
                        button_send_sps101.Enabled = false;
                    }
                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        // sends special code for subscribing channel IF100
        private void button_subs_if100_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "$$SUBIF100$$";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            catch
            {
                logs_server.AppendText("Failed to subscribe IF100!\n");
            }
        }

        // sends special code for unsubscribing channel IF100
        private void button_unsubs_if100_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "$$UNSUBIF100$$";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            catch
            {
                logs_server.AppendText("Failed to unsubscribe IF100!\n");
            }
        }

        // sends message that contains special code at the beginning to the channel IF100
        private void button_send_if100_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "$$IF100$$" + text_if100.Text;
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                text_if100.Clear();
            }
            catch
            {
                logs_server.AppendText("Failed to send message to IF100!\n");
            }
        }

        // sends special code for subscribing channel SPS101
        private void button_subs_sps101_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "$$SUBSPS101$$";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            catch
            {
                logs_server.AppendText("Failed to subscribe SPS101!\n");
            }
        }

        // sends special code for unsubscribing channel SPS101
        private void button_unsubs_sps101_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "$$UNSUBSPS101$$";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            catch
            {
                logs_server.AppendText("Failed to unsubscribe SPS101!\n");
            }
        }

        // sends message that contains special code at the beginning to the channel SPS101
        private void button_send_sps101_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "$$SPS101$$" + text_sps101.Text;
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                text_sps101.Clear();
            }
            catch
            {
                logs_server.AppendText("Failed to send message to SPS101!\n");
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}
