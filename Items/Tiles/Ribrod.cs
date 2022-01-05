using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class Ribrod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ribcage Wand");
            Tooltip.SetDefault("Places Sulphurous Ribs\n" + "Right click to change rib");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.width = 16;
            item.height = 28;
            item.rare = ItemRarityID.LightRed;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 30;
            item.useTurn = true;
            item.autoReuse = false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        private int RibCount;

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                RibCount++;
                if (RibCount > 3)
                {
                    RibCount = 0;
                }
                item.createTile = -1;
                item.useStyle = ItemUseStyleID.HoldingUp;
                item.useAnimation = 30;
                item.useTime = 30;
            }
            else
            {
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.useTurn = true;
                item.useAnimation = 30;
                item.useTime = 30;
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                switch (RibCount)
                {
                    case 0:
                        item.createTile = calamityMod.TileType("SulphurousRib2");
                        return true;

                    case 1:
                        item.createTile = calamityMod.TileType("SulphurousRib3");
                        return true;

                    case 2:
                        item.createTile = calamityMod.TileType("SulphurousRib4");
                        return true;

                    case 3:
                        item.createTile = calamityMod.TileType("SulphurousRib5");
                        return true;
                }
            }
            return true;
        }
    }
}