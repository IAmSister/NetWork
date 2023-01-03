namespace SPacket.SocketInstance
{

    public class PacketFactoryManagerInstance : PacketFactoryManager
    {
        /// <summary>
        /// ��ʼ����ʱ�������Ϣ��
        /// </summary>
        /// <returns></returns>
        public override bool Init()
        {
            //��ӹ���
            AddFactory(new GC_LOGIN_RET_PF());
            //����
            AddPacketHander(MessageID.PACKET_GC_LOGIN_RET, new GC_LOGIN_RETHandler());
            return true;
        }
    }
}

