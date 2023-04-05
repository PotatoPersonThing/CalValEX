using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("DryShrimp")]
    public class SunDriedShrimp : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sun Dried Shrimp");
            // Tooltip.SetDefault("A crispy snack favored by Cnidrions\n" + "Summons a little sick sneeze dragon");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item2;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.BabyCnidrion>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Item.rare = 2;
            Item.buffType = ModContent.BuffType<Buffs.Pets.CnidBuff>();
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