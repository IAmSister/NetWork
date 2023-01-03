using System;
using System.Collections.Generic;
using System.Net;
#if UNITY_WP8
using UnityPortSocket;
#else
using System.Net.Sockets;
#endif
using System.Collections;


namespace SPacket.SocketInstance
{
    public interface PacketFactory
    {
        MessageID GetPacketID();
    }
    public abstract class PacketFactoryManager
    {
        protected Hashtable m_Factories = new Hashtable();
        protected Dictionary<MessageID, Ipacket> m_HandlerDic = new Dictionary<MessageID, Ipacket>();

        public abstract bool Init();

        /// <summary>
        /// 获取Handle
        /// </summary>
        /// <param name="nMID"></param>
        /// <returns></returns>
        public Ipacket GetPacketHandler(MessageID nMID)
        {
            if (m_HandlerDic.ContainsKey(nMID))
            {
                return m_HandlerDic[nMID] as Ipacket;
            }
            return null;
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="pPacket"></param>
        public void RemovePacket(Ipacket pPacket)
        {
            if (pPacket == null) return;
        }
        /// <summary>
        /// 添加工厂
        /// </summary>
        /// <param name="pFactory"></param>
        protected void AddFactory(PacketFactory pFactory)
        {
            if (!m_Factories.ContainsKey(pFactory.GetPacketID()))
            {
                m_Factories.Add(pFactory.GetPacketID(), pFactory);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="nMID"></param>
        /// <param name="packetHander"></param>
        protected void AddPacketHander(MessageID nMID, Ipacket packetHander)
        {
            if (!m_HandlerDic.ContainsKey(nMID))
            {
                m_HandlerDic.Add(nMID, packetHander);
            }
        }


   

    }
}

