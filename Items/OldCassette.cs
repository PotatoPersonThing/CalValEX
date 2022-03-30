using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class OldCassette : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Cassette");
            Tooltip.SetDefault("Favorite this item to activate player afterimages\n" + "'It contains some edgy anime episodes from the 90's'");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 20));
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = false;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 36;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.armorEffectDrawShadow = true;
                player.armorEffectDrawOutlines = true;
                //player.GetModPlayer<CalValEXPlayer>().cassette = true;
            }
        }
    }
}