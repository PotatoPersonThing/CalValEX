using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Rarities;

namespace CalValEX.Items.LightPets
{
    [LegacyName("SupJewel")]
    public class SuperstitiousJewel : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item45;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LightPets.SupJewel.Bishop>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ModContent.RarityType<Aqua>();
            Item.buffType = ModContent.BuffType<Buffs.LightPets.SupJewelBuff>();
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}