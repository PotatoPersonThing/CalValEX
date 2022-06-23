using CalValEX.Buffs.LightPets;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace CalValEX.Items.LightPets
{
    public class DarksunSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Tooltip.SetDefault("Summons Darksun Spirits to follow you\n" + "Provides a gigantic amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 62;
            Item.damage = 0;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item117;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.buffType = ModContent.BuffType<DarksunSpiritBuff>();
            Item.rare = 11;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(108, 45, 199);
                }
            }
        }
    }
}