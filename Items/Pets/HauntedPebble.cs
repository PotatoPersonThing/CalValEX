using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class HauntedPebble : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Haunted Pebble");
            /* Tooltip
                .SetDefault("'Spookay~'\n" + "Summons a Phantom Debris larvae"); */
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 36;
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit33;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.PhantomPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.buffType = ModContent.BuffType<Buffs.Pets.DebrisPet>();
            Item.noUseGraphic = true;
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