using System.Collections;
using System.ComponentModel;
using System;
using System.Text;
using System.Net;
using UnityEngine;

#if UNITY_WP8
using UnityPortSocket;
#else
using System.Net.Sockets;
#endif
using System.Security;

namespace SPacket.Socket_API
{
    public class SocketAPI 
    {
        //客户端链接 
        public static Socket Connect(string ServerIP, int nPort, ref string result)
        {

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint tempRemoteIP = new IPEndPoint(IPAddress.Parse(ServerIP), nPort);
                EndPoint epTemp = (EndPoint)tempRemoteIP;
                socket.Connect(epTemp);
                return socket;
            }
            catch (SocketException e) { result = e.ToString(); }
            catch (ArgumentOutOfRangeException e) { result = e.ToString(); }
            catch (ArgumentNullException e) { result = e.ToString(); }
            catch (ObjectDisposedException e) { result = e.ToString(); }
            catch (InvalidOperationException e) { result = e.ToString(); }
            catch (SecurityException e) { result = e.ToString(); }
            catch (Exception e) { result = e.ToString(); }
            return null;

        }
        //发送 当前客户端 
        public static uint Send(Socket client, Byte[] buff, uint nLen, SocketFlags flags = SocketFlags.None)
        {
            try
            {
                return (uint)client.Send(buff, (int)nLen, flags);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
               
            }
            return 0xFFFFFFFF;
        }
        //关闭
        public static void Close(Socket ClientSocket)
        {
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Shutdown(SocketShutdown.Both);
                }
            }
            catch (SocketException e)
            {
               Debug.Log(e.ToString());
            }
            try
            {
                ClientSocket.Close();
            }
            catch (SocketException e)
            {
                Debug.Log(e.ToString());
            }
        }
        //接受
        public static uint Recv(Socket client, Byte[] buff, uint nLen, uint flags = 0)
        {

            try
            {

                uint bytes = 0;

                bytes = (uint)client.Receive(buff, (int)nLen, (SocketFlags)flags);
                // buff += Encoding.ASCII.GetString(bytesReceived, 0, bytes);

                return bytes;
            }
            catch (SocketException e)
            {
                Debug.Log(e.ToString());
            }
            return 0xFFFFFFFF;
        }

        public static uint available(Socket client)
        {
            return (uint)client.Available;
        }
    
    }

}

