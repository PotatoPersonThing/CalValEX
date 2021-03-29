using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class MissingFang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotten Key");
            Tooltip.SetDefault("The key to pacifying a microbial cluster");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit13;
            item.shoot = mod.ProjectileType("Hiveling");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.buffType = mod.BuffType("HivelingBuff");
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