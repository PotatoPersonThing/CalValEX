using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalValEX.Items.Equips.Backs
{
    [AutoloadEquip(EquipType.Back)]
    
    public class BackpackServer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Backpack Server");
            Tooltip.SetDefault("'Draedon's eyes are on you'");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 34;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = ItemRarityID.Purple;;
            item.accessory = true;
            item.vanity = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
            recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"));
            recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"));
recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("LaboratoryConsole"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            }
        }      
    }
}
