using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace CalValEX.Items.LightPets
{
    public class AntarcticEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antarctic Essence");
            Tooltip.SetDefault("Summons a cosmetic shield of Cryogen's ice around you");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("Lightshield");
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = mod.BuffType("LightshieldBuff");
            item.rare = ItemRarityID.Pink;
            
        }
        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}