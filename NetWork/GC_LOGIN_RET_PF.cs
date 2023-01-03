using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPacket.SocketInstance;
using Google.ProtocolBuffers;

public class GC_LOGIN_RET_PF : PacketFactory
{
    public MessageID GetPacketID()
    {
        return MessageID.PACKET_GC_LOGIN_RET;
    }
}
public class GC_LOGIN_RET : PacketDistributed
{
    public enum LOGINRESULT
    {
        SUCCESS = 1,
        ACCOUNTVERIFYFAIL = 2,
        READROLELISTFAIL = 3,
        ALREADYLOGIN = 4,
        QUEUEFULL = 5,
        NEEDFORCEENTER = 6,
        PACKETNOTMATCH = 7,
        VERSIONNOTMATCH = 8,
    }
    public override bool IsInitialized()
    {
        throw new System.NotImplementedException();
    }

    public override PacketDistributed MergeFrom(CodedInputStream input, PacketDistributed _Inst)
    {
        throw new System.NotImplementedException();
    }

    public override int SerializedSize()
    {
        throw new System.NotImplementedException();
    }

    public override void WriteTo(CodedOutputStream data)
    {
        throw new System.NotImplementedException();
    }
}
