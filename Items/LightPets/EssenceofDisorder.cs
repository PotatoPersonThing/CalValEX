using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    [LegacyName("ChaosEssence")]
    public class EssenceofDisorder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Disorder");
            Tooltip
                .SetDefault("Summons a pair of Heat Spirits to light your way \n" + "Provides a moderate amount of light in the abyss\n" + "'Come burn with me'");
            SacrificeTotal = 1;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item45;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.buffType = ModContent.BuffType<Buffs.LightPets.HeatBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

       public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatBaby>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            type = ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}