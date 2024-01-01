using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{ 
    [LegacyName("Pollution")]
    public class InkyPollution : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Inky Pollution");
            // Tooltip.SetDefault("Tis a shame what we do to the environment\n" + "Summons a baby squid");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit25;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.BabySquid>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.buffType = ModContent.BuffType<Buffs.Pets.BabySquidBuff>();
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