﻿using System.IO;
using Shared.Util;

namespace Shared.Network.GameServer
{
    public class BuyItemAnswer : OutPacket
    {
        public int ItemId;
        public int Quantity;
        public int Price;
        
        public override Packet CreatePacket()
        {
            return base.CreatePacket(Packets.BuyItemAck);
        }

        public override byte[] GetBytes()
        {
            using (var ms = new MemoryStream())
            {
                using (var bs = new BinaryWriterExt(ms))
                {
                    bs.Write(ItemId);
                    bs.Write(Quantity);
                    bs.Write(Price);
                }
                return ms.ToArray();
            }
        }
    }
}