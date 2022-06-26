using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Tiles.Abyss;

namespace CalValEX.Items.Tiles
{
    public class Ribrod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ribcage Wand");
            Tooltip.SetDefault("Places Sulphurous Ribs\n" + "Right click to change rib");
            SacrificeTotal = 1;
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

        public override bool CanUseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.altFunctionUse == 2)
                {
                    RibCount++;
                    if (RibCount > 4)
                    {
                        RibCount = 0;
                    }
                    Item.createTile = -1;
                    Item.useStyle = ItemUseStyleID.HoldUp;
                    Item.useAnimation = 30;
                    Item.useTime = 30;
                }
                else
                {
                    Item.useStyle = ItemUseStyleID.Swing;
                    Item.useTurn = true;
                    Item.useAnimation = 30;
                    Item.useTime = 30;
                    switch (RibCount)
                    {
                        case 0:
                            Item.createTile = ModContent.TileType<SulphurousRib2>();
                            return true;

                        case 1:
                            Item.createTile = ModContent.TileType<SulphurousRib3>();
                            return true;

                        case 2:
                            Item.createTile = ModContent.TileType<SulphurousRib4>();
                            return true;

                        case 3:
                            Item.createTile = ModContent.TileType<SulphurousRib5>();
                            return true;

                        case 4:
                            Item.createTile = ModContent.TileType<SulphurousRib1>();
                            return true;
                    }
                }
            }
            return true;
        }
    }
}