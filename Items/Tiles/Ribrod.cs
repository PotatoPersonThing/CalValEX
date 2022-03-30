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
            Item.maxStack = 1;
            Item.width = 16;
            Item.height = 28;
            Item.rare = ItemRarityID.LightRed;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTurn = true;
            Item.autoReuse = false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        private int RibCount;

        /*public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                RibCount++;
                if (RibCount > 3)
                {
                    RibCount = 0;
                }
                Item.createTile = -1;
                Item.useStyle = ItemUseStyleID.HoldingUp;
                Item.useAnimation = 30;
                Item.useTime = 30;
            }
            else
            {
                Item.useStyle = ItemUseStyleID.SwingThrow;
                Item.useTurn = true;
                Item.useAnimation = 30;
                Item.useTime = 30;
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                switch (RibCount)
                {
                    case 0:
                        Item.createTile = calamityMod.TileType("SulphurousRib2");
                        return true;

                    case 1:
                        Item.createTile = calamityMod.TileType("SulphurousRib3");
                        return true;

                    case 2:
                        Item.createTile = calamityMod.TileType("SulphurousRib4");
                        return true;

                    case 3:
                        Item.createTile = calamityMod.TileType("SulphurousRib5");
                        return true;
                }
            }
            return true;
        }*/
    }
}