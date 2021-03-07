using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class PuppoCollar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doggo Collar");
            Tooltip
                .SetDefault("Summons a pet Chihuahua");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit55;
            item.shoot = mod.ProjectileType("Puppo");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.buffType = mod.BuffType("PuppoBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.overrideColor = new Color(107, 240, 255);
        }
    }
}