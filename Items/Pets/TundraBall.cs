using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class TundraBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tundra Ball");
            Tooltip.SetDefault("A chew toy said to have the power to tame the angriest of dogs\n" + "Summons a very angry puppy");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item47;
            item.shoot = mod.ProjectileType("Angrypup");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.buffType = mod.BuffType("Doggobuff");
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