using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Scuttlers
{
    public class AmberStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amber Geode");
            Tooltip
                .SetDefault("May contain a scuttler");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit31;
            item.shoot = mod.ProjectileType("AmberPet");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.buffType = mod.BuffType("AmberBuff");
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