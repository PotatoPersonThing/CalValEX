using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class FROM : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item111;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MechaGeorge>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.expert = true;
            Item.rare = ItemRarityID.Lime;
            Item.buffType = ModContent.BuffType<Buffs.Pets.MechaGeorgeBuff>();
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (CalValEX.CalamityActive)
                ArsenalTooltip(tooltips);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public static void ArsenalTooltip(List<TooltipLine> tooltips)
        {
            CalamityMod.Items.CalamityGlobalItem.InsertKnowledgeTooltip(tooltips, 3);
        }
    }
}