using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class DriedMandible : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dried Locket");
            Tooltip.SetDefault("'There's a worm wriggling in it'\n" + "Summons a Desert Pest");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit13;
            item.shoot = mod.ProjectileType("DesertHead");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.buffType = mod.BuffType("DesertBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("DesertHead");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}