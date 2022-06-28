using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace CalValEX.Items.Tiles
{
    public class Help : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stuck Orthocera");
            Tooltip
                .SetDefault("Help me\n" + "Can be fed Green Mushrooms");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Helplaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 5;
        }
        public override void OnResearched(bool fullyResearched)
        {
            CombatText.NewText(new Rectangle((int)Main.LocalPlayer.position.X, (int)Main.LocalPlayer.position.Y, Main.LocalPlayer.width, Main.LocalPlayer.height), Color.Red, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA", true);
        }
    }
}
