using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("CryoStick")]
    public class CoolShades : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cool Shades");
            Tooltip.SetDefault("Rad\n" + "Summons a miniature Cryogen");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MiniCryo>();
            Item.buffType = ModContent.BuffType<Buffs.Pets.ChilledOut>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
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