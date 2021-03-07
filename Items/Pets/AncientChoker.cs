using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class AncientChoker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skull Cluster");
            Tooltip
                .SetDefault("Two skulls pop out of the pile with glowing eyes");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit41;
            item.shoot = mod.ProjectileType("Pillager");
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 8;
            item.buffType = mod.BuffType("PillagerBuff");
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