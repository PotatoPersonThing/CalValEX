using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class AstralStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geminga");
            Tooltip.SetDefault("A highly condensed star\n" + "Summons a swarm of 11 lesser star deities");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("DeusPet");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 9;
            item.buffType = mod.BuffType("DeusBuff");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        private int scourge2 = 180;

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("DeusPet");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("DeusPetSmall");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}