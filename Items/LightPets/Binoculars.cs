using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class Binoculars : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Binoculars");
            Tooltip.SetDefault("You can see something in the distance\n" + "Summons a Sightseeing Tour\n" + "Provides a moderate amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LightPets.SeerS>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.buffType = ModContent.BuffType<Buffs.LightPets.SeerBuff>();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
       public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
       {
            type = ModContent.ProjectileType<Projectiles.Pets.LightPets.SeerS>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            type = ModContent.ProjectileType<Projectiles.Pets.LightPets.SeerM>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            type = ModContent.ProjectileType<Projectiles.Pets.LightPets.SeerL>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
       }
    }
}