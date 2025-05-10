using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;

namespace CalValEX.Items.Tiles
{
    public class PolterRemote : ModItem
    {
        public override string Texture => "CalValEX/Items/Tiles/PolterCable";
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 32;
            Item.rare = CalamityID.CalRarityID.PureGreen;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.autoReuse = false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            Vector2 tileMouse = Main.MouseWorld / 16;
            if (TileEntity.ByPosition.ContainsKey(new Point16((int)tileMouse.X, (int)tileMouse.Y)))
            {
                if (TileEntity.ByPosition[new Point16((int)tileMouse.X, (int)tileMouse.Y)].type == ModContent.TileEntityType<PolterCableTE>())
                {
                    SoundEngine.PlaySound(SoundID.Item14);
                    PolterCableTE cable = TileEntity.ByPosition[new Point16((int)tileMouse.X, (int)tileMouse.Y)] as PolterCableTE;
                    bool shift = Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift);
                    bool ctrl = Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl);
                    int amount = 1;
                    if (shift && ctrl)
                        amount = 50;
                    else if (shift)
                        amount = 5;
                    else if (ctrl)
                        amount = 10;
                    if (player.altFunctionUse == 2)
                    {
                        cable.channel -= amount;
                    }
                    else
                    {
                        cable.channel += amount;
                    }
                    Main.NewText("Phantom Mine at " + cable.Position.X + ", " + cable.Position.Y + "'s channel changed to " + cable.channel);
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}