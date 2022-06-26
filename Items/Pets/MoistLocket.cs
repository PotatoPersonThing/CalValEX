using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace CalValEX.Items.Pets
{
    [LegacyName("AquaticHide")]
    public class MoistLocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moist Locket");
            Tooltip.SetDefault("'There's a worm wriggling in it'\n" + "Summons a small Aquatic Pest");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit13;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.AquaPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 6;
            Item.buffType = ModContent.BuffType<Buffs.Pets.AquaBuff>();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}