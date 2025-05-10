using CalValEX.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("FluffyFur", "SparrowMeat")]
    public class ExtraFluffyFeatherClump : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit51;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MiniDoge>();
            Item.value = Item.sellPrice(5, 9, 6, 6);
            Item.buffType = ModContent.BuffType<Buffs.Pets.MiniDogeBuff>();
            Item.rare = ModContent.RarityType<Aqua>();
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}