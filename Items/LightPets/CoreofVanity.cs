using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CalValEX.Items.LightPets
{
    [LegacyName("VanityCore")]
    public class CoreofVanity : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item45;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.buffType = ModContent.BuffType<Buffs.LightPets.VanityCoreBuff>();
            Item.noUseGraphic = true;
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
            type = ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatBaby>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}