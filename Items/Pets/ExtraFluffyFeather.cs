using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("FluffyFeather")]
    public class ExtraFluffyFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Extra Fluffy Feather");
            // Tooltip.SetDefault("Attracts the last of a species\n" + "Summons a mini birb");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit51;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MiniBumble>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = ModContent.BuffType<Buffs.Pets.MiniBumbleBuff>();
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