using CalValEX.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("FluffyFur", "SparrowMeat")]
    public class ExtraFluffyFeatherClump : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Extra Fluffy Feather Clump");
            // Tooltip.SetDefault("ISEJFDOIJNJSNFDGUISDBJNGSDJG\nSummons beasts, so horrific, that you will die");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit51;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MiniDoge>();
            Item.value = Item.sellPrice(5, 9, 6, 6);
            Item.buffType = ModContent.BuffType<Buffs.Pets.MiniDogeBuff>();
            Item.rare = ModContent.RarityType<Aqua>();
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