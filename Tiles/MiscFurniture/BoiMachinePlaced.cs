using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles;


namespace CalValEX.Tiles.MiscFurniture
{
    public class BoiMachinePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Boi Machine");
            AddMapEntry(new Color(0, 118, 49), name);
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.boiactive == false)
            {
                modPlayer.boihealth = 3;
                modPlayer.boiactive = true;
                 Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), new Vector2(player.position.X + player.width / 2 - 400, player.position.Y + player.height / 2 - 240),
                     new Vector2(0, 0), ModContent.ProjectileType<Projectiles.Boi.BoiUI>(), 0, 0, player.whoAmI,0 ,0);
            }
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player localPlayer = Main.LocalPlayer;
            localPlayer.noThrow = 2;
            localPlayer.cursorItemIconEnabled = true;
            localPlayer.cursorItemIconID = ModContent.ItemType<BoiMachine>();
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<BoiMachine>());
        }
    }
}