using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class MeldosaurusRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 48;
            Item.height = 32;
            Item.rare = ItemRarityID.Master;
        }
        [JITWhenModsEnabled("CalamityMod")]
        public override bool CanUseItem(Player player)
        {
            if (CalValEX.CalamityActive)
            {
                Item.createTile = ModContent.TileType<MeldosaurusRelicPlaced>();
            }
            return true;
        }
    }
}