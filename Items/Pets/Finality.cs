using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("TerminusStone")]
    public class Finality : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Finality");
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("The stone before was merely a shell for the true creation, \nthe Creator's first and favorite source of entertainment\n" + "Summons a pet Rock");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item117;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.TerminalRock>();
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = CalamityID.CalRarityID.HotPink;
            Item.buffType = ModContent.BuffType<Buffs.Pets.TerminalRockBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}