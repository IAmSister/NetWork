using System;
using Google.ProtocolBuffers;
using System.Collections;
namespace SPacket.SocketInstance
{
    public class GC_LOGIN_RETHandler : Ipacket
    {
        //add后 走到这里
        public uint Execute(PacketDistributed ipacket)
        {
            //服务器回过来的类
            GC_LOGIN_RET packet = (GC_LOGIN_RET)ipacket;
            if (null == packet)
            {
                return (uint)PACKET_EXE.PACKET_EXE_ERROR;
            }
            //数据处理
            LoginData.UpdateLoginData(packet);
            return (uint)PACKET_EXE.PACKET_EXE_CONTINUE;
        }
    }
}
   
