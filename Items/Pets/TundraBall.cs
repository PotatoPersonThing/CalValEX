using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class TundraBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tundra Ball");
            // Tooltip.SetDefault("A chew toy said to have the power to tame the angriest of dogs\n" + "Summons a very angry puppy");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item47;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Angrypup>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Doggobuff>();
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