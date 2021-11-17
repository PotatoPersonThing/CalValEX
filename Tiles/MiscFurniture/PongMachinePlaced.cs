using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles;


namespace CalValEX.Tiles.MiscFurniture
{
    internal class PongMachinePlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Pong Machine");
            AddMapEntry(new Color(0, 118, 49), name);
            disableSmartCursor = true;
        }

        public override bool NewRightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.pongactive == false)
            {
                modPlayer.pongactive = true;
                Projectile.NewProjectile(player.position.X + player.width / 2 - 400, player.position.Y + player.height / 2 - 240,
                    0f, 0f, ModContent.ProjectileType<Projectiles.Pong.PongUI>(), 0, 0f, player.whoAmI);
            }
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player localPlayer = Main.LocalPlayer;
            localPlayer.noThrow = 2;
            localPlayer.showItemIcon = true;
            localPlayer.showItemIcon2 = ModContent.ItemType<PongMachine>();
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<PongMachine>());
        }
    }
}