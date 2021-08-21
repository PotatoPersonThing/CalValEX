using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class SmallWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Perforator Mask");
            Tooltip.SetDefault("'The worm-st one of the bunch'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 4;
            item.accessory = true;
            item.vanity = true;
        }
    }
}