using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("Drock")]
    public class DespairMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Despair Mask");
            // Tooltip.SetDefault("It reeks of depression\n" + "Summons a sad rock");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit41;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Dstone>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
            Item.buffType = ModContent.BuffType<Buffs.Pets.SadStoneBuff>();
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