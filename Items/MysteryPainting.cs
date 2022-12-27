using CalValEX.Items.Tiles.Paintings;
using Terraria;
using Terraria.GameContent.ItemDropRules;
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
            SacrificeTotal = 3;
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

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
            int[] paintings = new int[]
            {
                ModContent.ItemType<BlazingConflict>(),
                ModContent.ItemType<CalamiteaTime>(),
                ModContent.ItemType<CirrusBooze>(),
                ModContent.ItemType<Clam>(),
                ModContent.ItemType<CosmicTerror>(),
                ModContent.ItemType<LostSouls>(),
                ModContent.ItemType<NotLikeHome>(),
                ModContent.ItemType<VVanities>(),
                ModContent.ItemType<Scourgy>(),
                ModContent.ItemType<SleepingGiant>(),
                ModContent.ItemType<Snouts>(),
                ModContent.ItemType<SundayAfternoon>(),
                ModContent.ItemType<SwearingShroom>(),
                ModContent.ItemType<TheGreatSandworm>(),
                ModContent.ItemType<TheYhar>(),
                ModContent.ItemType<Duality>(),
                ModContent.ItemType<RogueExtractor>(),
                ModContent.ItemType<Espelho>(),
                ModContent.ItemType<DarkMagic>(),
                ModContent.ItemType<Frozen>(),
                ModContent.ItemType<UnholyTrip>(),
                ModContent.ItemType<AccidentalAbominationn>(),
                ModContent.ItemType<Plague22>(),
                ModContent.ItemType<CalamityFriends>(),
                ModContent.ItemType<WilliamPainting>(),
                ModContent.ItemType<ModIconPainting>(),
                ModContent.ItemType<CalamityPaint>(),
                ModContent.ItemType<CalamityPaintRetold>(),
                ModContent.ItemType<OldModIconPainting>(),
                ModContent.ItemType<DraedonPopcorn>(),
                ModContent.ItemType<EyeofXeroc>(),
                ModContent.ItemType<UCMMPainting>(),
                ModContent.ItemType<OldUCMMPainting>(),
                ModContent.ItemType<WormHeaven>(),
                ModContent.ItemType<GallusYharus>(),
            };

            itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, paintings));
		}
    }
}