using System;
using System.IO;


namespace SPacket.SocketInstance
{
	/// <summary>
	/// 网络返回消息 后抛出异常消息
	/// </summary>
    public class PacketException : IOException
    {
        internal PacketException(string message)
        : base(message)
        {
        }
		internal static PacketException PacketReadError(string msg)
		{
			return new PacketException("PacketException ReadError:" + msg);
		}

		internal static PacketException PacketExecuteError(string msg)
		{
			return new PacketException("PacketException ExecuteError:" + msg);
		}

		internal static PacketException PacketCreateError(string msg)
		{
			return new PacketException("PacketException CreateError:" + msg);
		}

	}


}
