using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using CalValEX.Rarities;

namespace CalValEX.Items.Pets
{
    [LegacyName("Ectogasm")]
    public class BleuBlob : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit1;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.CoolBlueSignut>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ModContent.RarityType<Aqua>();
            Item.buffType = ModContent.BuffType<Buffs.Pets.CoolBlueBuff>();
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}