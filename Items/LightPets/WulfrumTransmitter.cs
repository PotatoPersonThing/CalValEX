using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    [LegacyName("PylonRemote")]
    public class WulfrumTransmitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Transmitter");
            SacrificeTotal = 1;
            Tooltip
                .SetDefault("'It's making a lot of dial up noises'\n" + "Summons a Prototype Wulfrum Pylon\n" + "Provides a small amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit41;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumPylon>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.buffType = ModContent.BuffType<Buffs.LightPets.PylonBuff>();
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