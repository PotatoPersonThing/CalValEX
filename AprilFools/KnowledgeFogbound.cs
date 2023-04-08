using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
    [ExtendsFromMod("CalamityMod")]
    public class KnowledgeFogbound : CalamityMod.Items.LoreItems.LoreItem
    {
        public override string Lore =>
@"Undoubtedly one of the most threatening beings in Terraria, for even I nearly lost my life in my encounter with him.
Upon readying my final blow against the Death God, he cowardly split his soul from his body in hopes to evade his demise.
His incorporeal form returned to haunt me as the Fogbound, and attempted to cut my life short before I could formulate a strategic retreat.
Fortunately, however, he had a fatal weakness: as his physical body withered away, so too did the brain that his ghostly form still relied on.
Using his newfound lack of wits to my advantage, I led him into a carefully laid trap containing sealing runes placed by the Archmage.
It was a success. I swiftly sealed the spirit away inside the nearest object to myself, with fate deeming my jester an adequate vessel.
Ironic that of all the gods, it was the one who’s domain was Death that feared dying the most.";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("The Fogbound");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Cyan;
            Item.consumable = false;
        }

       /* public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<FogboundTrophy>().
                AddTile(TileID.Bookcases).
                Register();
        }*/
    }
}
