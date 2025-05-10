using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;

namespace CalValEX.Items.Tiles
{
    public class PolterRemoteChainer : ModItem
    {
        (int, int) e = new(0, 0);
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
                    PolterCableTE cable = TileEntity.ByPosition[new Point16((int)tileMouse.X, (int)tileMouse.Y)] as PolterCableTE;
                    if (player.altFunctionUse == 2)
                    {
                        if (new Point16(e.Item1, e.Item2) != cable.Position)         
                        {
                            if (TileEntity.ByPosition.ContainsKey(new Point16(e.Item1, e.Item2)))
                            {
                                if (TileEntity.ByPosition[new Point16(e.Item1, e.Item2)].type == ModContent.TileEntityType<PolterCableTE>())
                                {
                                    PolterCableTE mycable = TileEntity.ByPosition[new Point16(e.Item1, e.Item2)] as PolterCableTE;
                                    if (!mycable.toChainedCords.Contains((cable.Position.X, cable.Position.Y)) && !cable.toChainedCords.Contains((mycable.Position.X, mycable.Position.Y)))
                                    {
                                        mycable.toChainedCords.Add((cable.Position.X, cable.Position.Y));
                                        Main.NewText("Phantom Mine at " + cable.Position.X + ", " + cable.Position.Y + " chained to Phantom Mine at " + mycable.Position.X + ", " + mycable.Position.Y);
                                        SoundEngine.PlaySound(SoundID.Item14);
                                    }
                                    else
                                    {
                                        Main.NewText("Phantom Mines already chained!");
                                    }
                                }
                                else
                                {
                                    Main.NewText("No chain found! 2");
                                }
                            }
                            else
                            {
                                Main.NewText("No chain found!");
                            }
                        }
                        else
                        {
                            Main.NewText("Cannot chain the same mine!");
                        }
                    }
                    else
                    {
                        e = (cable.Position.X, cable.Position.Y);
                        Main.NewText("Starting chain at " + cable.Position.X + ", " + cable.Position.Y);
                        SoundEngine.PlaySound(SoundID.Item14);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}