namespace SPacket.SocketInstance
{

    public class PacketFactoryManagerInstance : PacketFactoryManager
    {
        /// <summary>
        /// 初始化的时候监听消息号
        /// </summary>
        /// <returns></returns>
        public override bool Init()
        {
            //添加工厂
            AddFactory(new GC_LOGIN_RET_PF());
            //监听
            AddPacketHander(MessageID.PACKET_GC_LOGIN_RET, new GC_LOGIN_RETHandler());
            return true;
        }
    }
}

