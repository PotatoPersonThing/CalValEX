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
            item.width = 26;
            item.height = 42;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.accessory = true;
            item.vanity = true;
        }
    }
}