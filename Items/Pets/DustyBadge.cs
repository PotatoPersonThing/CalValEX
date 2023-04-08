using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("CrushedCore")]
    public class DustyBadge : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dusty Badge");
            // Tooltip.SetDefault("Looks tasty\n" + "Summons the Great Sand Shark's Great Grandson");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit21;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.GrandPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.Pets.GrandBuff>();
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
