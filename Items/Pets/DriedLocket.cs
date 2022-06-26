using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("DriedMandible")]
    public class DriedLocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dried Locket");
            Tooltip.SetDefault("'There's a worm wriggling in it'\n" + "Summons a Desert Pest");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit13;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.DesertPet>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.buffType = ModContent.BuffType<Buffs.Pets.DesertBuff>();
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