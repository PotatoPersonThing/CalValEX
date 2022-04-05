using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class DigestedWormFood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meaty Worm Tumor");
            Tooltip.SetDefault("May contain tied worms\n" + "Summons a ball of flesh with a small Perforator sticking out");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit9;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Fistuloid>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
            Item.buffType = ModContent.BuffType<Buffs.Pets.FistuloidBuff>();
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