using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class BigWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Perforator Mask");
            Tooltip.SetDefault("''In the anne-lead.'");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.value = Item.sellPrice(0, 0, 2, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 4;
            item.accessory = true;
            item.vanity = true;
        }
    }
}