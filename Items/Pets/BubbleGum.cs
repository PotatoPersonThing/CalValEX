using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class BubbleGum : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bubble Gum");
            Tooltip
                .SetDefault("Summons a divine entity");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.Item111;
            item.shoot = mod.ProjectileType("George");
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.rare = 11;
            item.expert = true;
            item.buffType = mod.BuffType("GeorgeBuff");
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