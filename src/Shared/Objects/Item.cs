﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Shared.Network;
using Shared.Util;

namespace Shared.Objects
{
    public class IUnit
    {
        public uint AssistA;
        public uint AssistB;
        public uint Belonging;
        public uint Box;

        public uint ExpireTick;

        public int Random;

        /*
        struct XiStrItemUnit
        {
          int StackNum;
          int Random;
          unsigned int AssistA;
          unsigned int AssistB;
          unsigned int Box;
          unsigned int Belonging;
          int Upgrade;
          int UpgradePoint;
          unsigned int ExpireTick;
        };
        */
        public int StackNum;

        public int Upgrade;
        public int UpgradePoint;
    }

    public class ItemData
    {
        public ushort Slot;
        /*
        struct $46506E0D494CF120A19388EB37177777
        {
          unsigned __int16 State;
          unsigned __int16 Slot;
        };
        union $90E2572CC35A071924DAD0BC1A98978B
        {
          $46506E0D494CF120A19388EB37177777 __s0;
                unsigned int StateVar;
            };
        */

        public ushort State;

        public uint StateVar;
    }

    public class Item : BinaryWriterExt.ISerializable
    {
        /*
        struct XiStrMyItem
        {
          unsigned int CarID;
          $90E2572CC35A071924DAD0BC1A98978B Itm;
          XiStrItemUnit ItemUnit;
          unsigned int TableIdx;
          unsigned int InvenIdx;
        };
        */
        public uint CarID;

        public uint InvenIdx;

        public ItemData Itm;
        public IUnit iunit;

        public uint TableIdx;

        public Item()
        {
            Itm = new ItemData();
            iunit = new IUnit();
        }

        public void Serialize(BinaryWriterExt writer)
        {
            writer.Write(CarID);

            writer.Write(Itm.State);
            writer.Write(Itm.Slot);
            writer.Write(Itm.StateVar);

            writer.Write(iunit.StackNum);
            writer.Write(iunit.Random);

            writer.Write(iunit.AssistA);
            writer.Write(iunit.AssistB);

            writer.Write(iunit.Box);
            writer.Write(iunit.Belonging);

            writer.Write(iunit.Upgrade);
            writer.Write(iunit.UpgradePoint);

            writer.Write(iunit.ExpireTick);


            writer.Write(TableIdx);
            writer.Write(InvenIdx);

            Log.Debug("Bufferlength: " + writer.GetBuffer().Length);
        }
    }
}