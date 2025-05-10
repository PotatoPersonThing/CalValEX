/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class LumpyItem : ModItem
    {
        public override string Texture => "CalValEX/Projectiles/Plushies/ItsReal";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumpy");
            Tooltip
                .SetDefault("He's very lumpy\n" + "Summons a blob that mimics the first minion it comes in contact with");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit41;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LumpyBase");
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 8;
            Item.buffType = ModContent.BuffType<Buffs.Pets.LumpyBuff");
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}*/