using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class AncientChoker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skull Cluster");
            Tooltip
                .SetDefault("Two skulls pop out of the pile with glowing eyes\n" + "Summons a miniature necrotic flesh golem");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit41;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Pillager>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 8;
            Item.buffType = ModContent.BuffType<Buffs.Pets.PillagerBuff>();
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