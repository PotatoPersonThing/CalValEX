using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalValEX.AprilFools
{
    [ExtendsFromMod("CalamityMod")]
    public class KnowledgeFogbound : ModItem //CalamityMod.Items.LoreItems.LoreItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Type] = true;
        }

      /* public override string Lore =>
@"Undoubtedly one of the most threatening beings in Terraria, for even I nearly lost my life in my encounter with him.
Upon readying my final blow against the Death God, he cowardly split his soul from his body in hopes to evade his demise.
His incorporeal form returned to haunt me as the Fogbound, and attempted to cut my life short before I could formulate a strategic retreat.
Fortunately, however, he had a fatal weakness: as his physical body withered away, so too did the brain that his ghostly form still relied on.
Using his newfound lack of wits to my advantage, I led him into a carefully laid trap containing sealing runes placed by the Archmage.
It was a success. I swiftly sealed the spirit away inside the nearest object to myself, with fate deeming my jester an adequate vessel.
Ironic that of all the gods, it was the one who’s domain was Death that feared dying the most.";*/

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Cyan;
            Item.consumable = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
            if (!Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
            {
                string tooltipString = Language.GetTextValue("Mods.CalValEX.Items.KnowledgeFogbound.ShortTooltip");

                if (line != null)
                    line.Text = tooltipString;
                return;
            }

            string tooltip = Language.GetTextValue("Mods.CalValEX.Items.KnowledgeFogbound.Lore");

            if (line != null)
                line.Text = tooltip;
        }
        public override bool CanUseItem(Player player) => false;

        public override Color? GetAlpha(Color lightColor) => Color.White;

       /* public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<FogboundTrophy>().
                AddTile(TileID.Bookcases).
                Register();
        }*/
    }
}
