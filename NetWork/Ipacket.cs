using System;

namespace SPacket.SocketInstance
{
    /// <summary>
    ///  
    /// </summary>
    public enum PACKET_EXE
    {
        PACKET_EXE_ERROR = 0,
        PACKET_EXE_BREAK,
        PACKET_EXE_CONTINUE,
        PACKET_EXE_NOTREMOVE,
        PACKET_EXE_NOTREMOVE_ERROR,
    }
    /// <summary>
    /// ����ÿ����̳еĽӿ�
    /// </summary>
    public interface Ipacket
    {
        uint Execute(PacketDistributed packet);
    }
}