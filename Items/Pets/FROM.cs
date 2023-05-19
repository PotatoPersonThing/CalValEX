using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class FROM : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frog-Only Memory");
            /* Tooltip
                .SetDefault("Summons a virtual private entity\n" + "'There's also a serial code...?'"); */
            Item.ResearchUnlockCount = 1;
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

        [JITWhenModsEnabled("CalamityMod")]
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (CalValEX.CalamityActive)
                ArsenalTooltip(tooltips);
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public static void ArsenalTooltip(List<TooltipLine> tooltips)
        {
            CalamityMod.Items.CalamityGlobalItem.InsertKnowledgeTooltip(tooltips, 3);
        }
    }
}