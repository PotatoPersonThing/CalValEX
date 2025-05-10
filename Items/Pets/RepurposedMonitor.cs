using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class RepurposedMonitor : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item15;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.RepairBot>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = CalamityID.CalRarityID.DarkOrange;
            Item.buffType = ModContent.BuffType<Buffs.Pets.RepurposedMonitorBuff>();
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}