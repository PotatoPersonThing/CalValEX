using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class DryShrimp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun Dried Shrimp");
            Tooltip.SetDefault("A crispy snack favored by Cnidrions");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item2;
            item.shoot = mod.ProjectileType("BabyCnidrion");
            item.value = Item.sellPrice(0, 0, 5, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 2;
            item.buffType = mod.BuffType("CnidBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}