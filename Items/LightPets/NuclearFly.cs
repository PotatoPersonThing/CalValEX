using CalValEX.Items.Critters;
using CalValEX.Items.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class NuclearFly : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Fly");
            Tooltip
                .SetDefault("'Ascension'\n" + "Summons a Grand Entity\n" + "Provides a large amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit49;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LightPets.Godrge>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.expert = true;
            Item.buffType = ModContent.BuffType<Buffs.LightPets.GodrgeBuff>();
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