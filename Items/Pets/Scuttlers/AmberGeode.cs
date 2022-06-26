using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Scuttlers
{
    [LegacyName("AmberStone")]
    public class AmberGeode : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amber Geode");
            Tooltip
                .SetDefault("May contain a scuttler");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit31;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Scuttlers.AmberPet>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Scuttlers.AmberBuff>();
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