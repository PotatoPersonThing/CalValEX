using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("MissingFang", "RottenKey")]
    public class Corruppuccino : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rotten Key");
            // Tooltip.SetDefault("The key to pacifying a microbial cluster\n" + "Summons a chunk of The Hive Mind");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit13;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Hiveling>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<Buffs.Pets.HivelingBuff>();
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