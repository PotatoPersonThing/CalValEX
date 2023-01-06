using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Critters;
using CalamityMod;
using CalamityMod.CustomRecipes;
using CalamityMod.Items;

namespace CalValEX.Items.Pets
{
    public class FROM : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frog-Only Memory");
            Tooltip
                .SetDefault("Summons a virtual private entity\n" + "'There's also a serial code...?'");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item111;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MechaGeorge>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.expert = true;
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.Pets.MechaGeorgeBuff>();
        }

	    public override void ModifyTooltips(List<TooltipLine> tooltips) => CalamityGlobalItem.InsertKnowledgeTooltip(tooltips, 3);

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}