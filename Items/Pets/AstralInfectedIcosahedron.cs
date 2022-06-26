using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("AstDie")]
    public class AstralInfectedIcosahedron : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Infected Icosahedron");
            Tooltip.SetDefault("Roll for initiative!\n" + "Transforms into an Aureophage");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item117;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.AstPhage>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 6;
            Item.buffType = ModContent.BuffType<Buffs.Pets.PhageBuff>();
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