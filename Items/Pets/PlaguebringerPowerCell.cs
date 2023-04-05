using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("BeeCan")]
    public class PlaguebringerPowerCell : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Plaguebringer Power Cell");
            // Tooltip.SetDefault("Full of vitamin Bee!\n" + "Summons a miniature Plaguebringer");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.PBGmini>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.buffType = ModContent.BuffType<Buffs.Pets.BeeBuff>();
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