using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class PhantomJar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom in a Jar");
            Tooltip
                .SetDefault("'Don't even think about it.'\n" + "Summons a Phantom Spirit to light your way\n" + "Provides a large amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DD2PetGhost);
            item.UseSound = SoundID.NPCHit54;
            item.shoot = mod.ProjectileType("PhantomSpirit");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Green;
            item.buffType = mod.BuffType("PhantomBuff");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(0, 255, 0); //change the color accordingly to above
                }
            }
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            recipe.AddIngredient(ItemID.WispinaBottle);
            recipe.AddIngredient(calamityMod.ItemType("RuinousSoul"), 3);
            recipe.AddIngredient(calamityMod.ItemType("Phantoplasm"), 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}