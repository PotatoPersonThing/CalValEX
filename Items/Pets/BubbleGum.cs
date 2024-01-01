using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class BubbleGum : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bubble Gum");
            /* Tooltip
                .SetDefault("Summons a divine entity"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item111;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.George>();
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;
            Item.buffType = ModContent.BuffType<Buffs.Pets.GeorgeBuff>();
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