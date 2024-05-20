using CalValEX.Buffs.LightPets;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CalValEX.CalamityID;

namespace CalValEX.Items.LightPets
{
    public class DarksunSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.ResearchUnlockCount = 1;
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
            Item.rare = CalRarityID.Violet;
        }
    }
}