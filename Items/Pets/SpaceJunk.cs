using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("JellyBottle")]
    public class SpaceJunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Space Junk");
            // Tooltip.SetDefault("Summons the forgotten blob of the astral meteor\n" + "Summons a small remnant of the Astrageldon Slime");
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item117;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.StarJelly>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.buffType = ModContent.BuffType<Buffs.Pets.JellyBuff>();
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