using CalValEX.Items.Tiles.Paintings;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class MysteryPainting : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystery Painting");
            Tooltip.SetDefault("<right> for a random painting");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 9999;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int choice = Main.rand.Next(34);
            if (choice == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<BlazingConflict>());
            }
            else if (choice == 1)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CalamiteaTime>());
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CirrusBooze>());
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Clam>());
            }
            else if (choice == 4)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CosmicTerror>());
            }
            else if (choice == 5)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<LostSouls>());
            }
            else if (choice == 6)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<NotLikeHome>());
            }
            else if (choice == 7)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<VVanities>());
            }
            else if (choice == 8)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Scourgy>());
            }
            else if (choice == 9)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<SleepingGiant>());
            }
            else if (choice == 10)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Snouts>());
            }
            else if (choice == 11)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<SundayAfternoon>());
            }
            else if (choice == 12)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<SwearingShroom>());
            }
            else if (choice == 13)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<TheGreatSandworm>());
            }
            else if (choice == 14)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<TheYhar>());
            }
            else if (choice == 15)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Duality>());
            }
            else if (choice == 16)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<RogueExtractor>());
            }
            else if (choice == 17)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Espelho>());
            }
            else if (choice == 18)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<DarkMagic>());
            }
            else if (choice == 19)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Frozen>());
            }
            else if (choice == 20)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<UnholyTrip>());
            }
            else if (choice == 21)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<AccidentalAbominationn>());
            }
            else if (choice == 22)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Plague22>());
            }
            else if (choice == 23)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CalamityFriends>());
            }
            else if (choice == 24)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<WilliamPainting>());
            }
            else if (choice == 25)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<ModIconPainting>());
            }
            else if (choice == 26)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CalamityPaint>());
            }
            else if (choice == 27)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CalamityPaintRetold>());
            }
            else if (choice == 28)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<OldModIconPainting>());
            }
            else if (choice == 29)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<DraedonPopcorn>());
            }
            else if (choice == 30)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<EyeofXeroc>());
            }
            else if (choice == 31)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<UCMMPainting>());
            }
            else if (choice == 32)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<OldUCMMPainting>());
            }
            else
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<WormHeaven>());
            }
        }
    }
}