using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class BottledSulphurousWater : ModItem {
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 30;
        }

        public override void SetDefaults() {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item3;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.value = 20;
            Item.maxStack = Item.CommonMaxStack;
            Item.buffType = CalValEX.CalamityActive ? CalValEX.CalamityBuff("SulphuricPoisoning") : BuffID.Venom;
            Item.buffTime = 3600;
        }
    }
}