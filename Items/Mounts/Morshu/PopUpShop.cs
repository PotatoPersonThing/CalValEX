using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class PopUpShop : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pop-up Shop");
            Tooltip.SetDefault("Summons a rideable Morshu" +
                "\nConsumes a copper coin from the coin slots every 5 seconds and becomes super-sonic" +
                "\nIf there are no copper coins in the coin slots then morshu becomes crippled");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/MorshuBomb");
            item.noMelee = true;
            item.mountType = ModContent.MountType<MorshuMount>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.DedicatedEX, tooltips);

        public override void AddRecipes()
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
        }

        public override bool UseItem(Player player)
        {
            if (Main.rand.NextFloat() < 0.33f)
            {
                item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/MorshuBomb");
            }
            else if (Main.rand.NextFloat() < 0.5f)
            {
                item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/MorshuRope");
            }
            else
            {
                item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/MorshuLamp");
            }
            return true;
        }
    }
}