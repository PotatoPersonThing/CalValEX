using CalValEX.Buffs.Pets;
using CalValEX.Projectiles.Pets;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("YharexsLetter")]
    public class AstraEGGeldon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AstraEGGeldon");
            Tooltip.SetDefault("'Now you can stop asking how I was born'\nSummons an edgy amalgamate to accompany you");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.shoot = ModContent.ProjectileType<CalamityBABY>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.buffType = ModContent.BuffType<CalamityBABYBuff>();
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player myPlayer = Main.player[i];
                if (myPlayer.active)
                {
                    myPlayer.GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit = false;
                }
            }
            return true;
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCDeath4, player.position);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position.Y -= 50f;
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.OverrideColor = new Color(107, 240, 255);
        }
    }
}