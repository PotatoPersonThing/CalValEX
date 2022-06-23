using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class DraedonBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draedon Thorax");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = 1;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Terraria.ID.ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }
    }
}