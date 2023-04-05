using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    [LegacyName("SkeetCrest")]
    public class EssenceofYeet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit51;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LightPets.Skeetyeet>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.buffType = ModContent.BuffType<Buffs.LightPets.YeetBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}