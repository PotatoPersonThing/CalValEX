using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("OldTennisBall")]
    public class RottenHotdog : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotten Hotdog");
            Tooltip.SetDefault("'Delicious...'\n" + "Summons a Pitbull puppy\n" + "Barks when any rare enemies are nearby");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit29;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Buppy>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.buffType = ModContent.BuffType<Buffs.Pets.BuppyBuff>();
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