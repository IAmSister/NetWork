using System;
using Google.ProtocolBuffers;
using System.Collections;
namespace SPacket.SocketInstance
{
    public class GC_LOGIN_RETHandler : Ipacket
    {
        //add�� �ߵ�����
        public uint Execute(PacketDistributed ipacket)
        {
            //�������ع�������
            GC_LOGIN_RET packet = (GC_LOGIN_RET)ipacket;
            if (null == packet)
            {
                return (uint)PACKET_EXE.PACKET_EXE_ERROR;
            }
            //���ݴ���
            LoginData.UpdateLoginData(packet);
            return (uint)PACKET_EXE.PACKET_EXE_CONTINUE;
        }
    }
}
   
