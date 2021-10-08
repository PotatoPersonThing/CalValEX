using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Shield)]
    public class ExodiumMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exodium Orbiter");
            Tooltip.SetDefault("A world revolving");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.accessory = true;
            item.vanity = true;
        }
    }
}