using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Plants
{
    public class AcidGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Acid Tape Dispenser");
            // Tooltip.SetDefault("Places an infinite amount of Sulphurous Vines");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.width = 16;
            Item.height = 28;
            Item.rare = ItemRarityID.LightRed;
        }

        public override bool CanUseItem(Player player)
        {
            if (CalValEX.CalamityActive)
            {
                Item.createTile = CalValEX.CalamityTile("SulphurousVines");
            }
            return true;
        }
    }
}