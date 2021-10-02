using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class ClawShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clawshroom");
            Tooltip.SetDefault("Snip snap!\n" + "Summons a small Crabulon");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item2;
            item.shoot = mod.ProjectileType("SmolCrab");
            item.value = Item.sellPrice(0, 1, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 3;
            item.buffType = mod.BuffType("CrabBuff");
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