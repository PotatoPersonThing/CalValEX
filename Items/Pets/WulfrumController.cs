using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets.Wulfrum;

namespace CalValEX.Items.Pets
{
    public class WulfrumController : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<WulfrumDrone>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<Buffs.Pets.WulfrumArmy>();
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}