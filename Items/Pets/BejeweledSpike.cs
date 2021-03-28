using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class BejeweledSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bejeweled Spike");
            Tooltip.SetDefault("'A blend of every flavor combined into one package'\n" + "This item is unfinished");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit31;
            item.shoot = mod.ProjectileType("BejeweledScuttler");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.expert = true;
            item.buffType = mod.BuffType("BejeweledBuff");
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