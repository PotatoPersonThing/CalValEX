using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class PopUpShop : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/Item/MorshuBomb");
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<MorshuMount>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.DedicatedEX, tooltips);

        /*public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("ThiefsDime"));
            recipe.AddIngredient(ItemID.LargeRuby);
            recipe.AddIngredient(ItemID.RopeCoil, 5);
            recipe.AddIngredient(ItemID.Bomb, 10);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

        public override bool? UseItem(Player player)
        {
            if (Main.rand.NextFloat() < 0.33f)
            {
                Item.UseSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/Item/MorshuBomb");
            }
            else if (Main.rand.NextFloat() < 0.5f)
            {
                Item.UseSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/Item/MorshuRope");
            }
            else
            {
                Item.UseSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/Item/MorshuLamp");
            }
            return true;
        }
    }
}