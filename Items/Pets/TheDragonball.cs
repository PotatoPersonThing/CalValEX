using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("OrbSummon")]
    public class TheDragonball : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Dragonball");
            /* Tooltip
                .SetDefault("Uh oh\n" + "Summons a spherical Dragonfolly\n"+"Causes failed dragon clones to have identity crises"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit51;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Dragonball>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = ModContent.BuffType<Buffs.Pets.OrbBuff>();
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