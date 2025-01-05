using CalValEX.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class OgliveBranch : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (CalValEX.CalamityActive)
                ItemID.Sets.ShimmerTransformToItem[CalValEX.CalamityItem("BloodyVein")] = Type;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCDeath4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Birdscule>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ModContent.RarityType<Aqua>();
            Item.buffType = ModContent.BuffType<Buffs.Pets.BirdsculeBuff>();
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