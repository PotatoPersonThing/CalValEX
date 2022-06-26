using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("DiscardedCollar")]
    public class DecayingFishtail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decaying Fishtail");
            Tooltip
                .SetDefault("Summons a pet catfish...?\n"+"Only an unholy nightmarish abomination would want something this putrid");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit55;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Catfish>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
            Item.buffType = ModContent.BuffType<Buffs.Pets.CatfishBuff>();
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