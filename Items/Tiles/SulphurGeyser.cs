using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles
{
    public class SulphurGeyser : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steam Geyser");
            // Tooltip.SetDefault("Hazardous! Be careful!\n" + "Right click to cycle between variants");
            Item.ResearchUnlockCount = 1;
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
                    if (RibCount > 2)
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
                Item.createTile = CalValEX.CalamityTile("SteamGeyser1");
                            return true;

                        case 1:
                Item.createTile = CalValEX.CalamityTile("SteamGeyser2");
                            return true;

                        case 2:
                Item.createTile = CalValEX.CalamityTile("SteamGeyser3");
                            return true;
                    }
                }
            }
            return true;
        }
    }
}