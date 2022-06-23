using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class OldMirage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Mirage Balloon");
            Tooltip.SetDefault("'Keep away from the ocean'\n'Balloons are nasty pollutants'");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 42;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}