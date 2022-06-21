using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    [LegacyName("WetBubble")]
    public class StrangeMusicNote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Music Note");
            Tooltip.SetDefault("An elemental's favorite sound!\n" + "Summons a Vibrant Siren Child");
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Elementals.BabyWaterClone>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Elementals.MoistBuff>();
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