using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class CharredChopper : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Charred Chopper");
            // Tooltip.SetDefault("A burning knife measuring a thousand degrees!\n" + "Summons a decapitated Sulphurous Fishron that inhaled Scoria fumes");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit14;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.ScoriaDuke>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.PureGreen;
            Item.buffType = ModContent.BuffType<Buffs.Pets.ScorchingFuryshronBuff>();
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