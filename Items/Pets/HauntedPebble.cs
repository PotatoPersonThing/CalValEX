using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class HauntedPebble : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Haunted Pebble");
            Tooltip
                .SetDefault("'Spookay~'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit33;
            item.shoot = mod.ProjectileType("PhantomPet");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.buffType = mod.BuffType("DebrisPet");
            item.noUseGraphic = true;
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