using System.Collections.Generic;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers.ClassSpecific
{
    public class ClassSpecificLayerUtil : ModPlayer
    {
        public List<ClassSpecificVanityData> data;

        public override void Load()
        {
            data = new()
            {
                new ClassSpecificVanityData("CalValEX/Items/Equips/Hats/Draedon/", "CalValEX/Items/Equips/Shirts/Draedon/", "DraedonHelmet", "DraedonChestplate"),
                //add more here!
            };
        }

        public override void Unload()
        {
            if (data != null)
            {
                data.Clear();
            }

            data = null;
        }

        public bool HasClassSpecificHeadVanity()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (Player.head == EquipLoader.GetEquipSlot(Mod, data[i].HeadName, EquipType.Head))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasClassSpecificBodyVanity()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (Player.body == EquipLoader.GetEquipSlot(Mod, data[i].BodyName, EquipType.Body))
                {
                    return true;
                }
            }
            return false;
        }

        public (string, string) GetCurrentHeadData()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (Player.head == EquipLoader.GetEquipSlot(Mod, data[i].HeadName, EquipType.Head))
                {
                    return (data[i].HeadName, data[i].PathToHead);
                }
            }
            return (null, null);
        }

        public (string, string) GetCurrentBodyData()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (Player.body == EquipLoader.GetEquipSlot(Mod, data[i].BodyName, EquipType.Body))
                {
                    return (data[i].BodyName, data[i].PathToBody);
                }
            }
            return (null, null);
        }
    }
}
