using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Items.Pets;
using CalValEX.Items.Equips.Balloons;

namespace CalValEX.Items.LightPets
{
    public class SupJewel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Superstitious Jewel");
            Tooltip.SetDefault("Summons an elemental and a miasma to follow you, emitting a crazy amount of light.\n" + "Provides a colossal amount of light in the abyss\n" + "'It looks like glass, but the magic is real.'" );
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.Item45;
            item.shoot = mod.ProjectileType("Bishop");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Purple;
            item.buffType = mod.BuffType("SupJewelBuff");
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
                    tooltipLine.overrideColor = new Color(107, 240, 255); //change the color accordingly to above
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

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("Bishop");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(calamityMod.ItemType("AscendantSpiritEssence"), 5);
                recipe.AddIngredient(ModContent.ItemType<DarksunSigil>());
                recipe.AddIngredient(ModContent.ItemType<CryoStick>());
                recipe.AddIngredient(ModContent.ItemType<PhantomJar>());
                recipe.AddIngredient(ModContent.ItemType<HolyTorch>());
                recipe.AddIngredient(ModContent.ItemType<ShuttleBalloon>());
                recipe.AddIngredient(ItemID.CrystalShard, 20);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}