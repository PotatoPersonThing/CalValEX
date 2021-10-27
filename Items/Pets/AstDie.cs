using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class AstDie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Infected Icosahedron");
            Tooltip.SetDefault("Roll for initiative!\n" + "Transforms into an Aureophage");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.Item117;
            item.shoot = mod.ProjectileType("AstPhage");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 6;
            item.buffType = mod.BuffType("PhageBuff");
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