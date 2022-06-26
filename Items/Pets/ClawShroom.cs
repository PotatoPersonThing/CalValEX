using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class ClawShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clawshroom");
            Tooltip.SetDefault("Snip snap!\n" + "Summons a small Crabulon");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item2;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.SmolCrab>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
            Item.buffType = ModContent.BuffType<Buffs.Pets.CrabBuff>();
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