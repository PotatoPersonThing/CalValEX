using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class MidWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Medium Perforator Mask");
            Tooltip.SetDefault("''Worming its way to the top!'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 1, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 4;
            item.accessory = true;
            item.vanity = true;
        }
    }
}