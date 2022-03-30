using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class AstrumDeusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blighted Deus Mask");
            Tooltip.SetDefault("'A faded star reignited.'");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.vanity = true;
            Terraria.ID.ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
    }
}