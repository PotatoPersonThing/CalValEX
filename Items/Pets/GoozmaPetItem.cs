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

namespace CalValEX.Items.Pets
{
    public class GoozmaPetItem : ModItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Ionized Jelly Canister");
            Tooltip.SetDefault("Summons the pinnacle of slime evolution\n" +
                "\n" +
                "\n" +
                "Did you ever hear the tragedy of Goozma The Amorphous Deity? I thought not. It's not a story the Tyrant would tell you.\n" +
                "It's a Overseer legend. Goozma was the ultimate evolution of all slimes, so powerful it could influence the cells that comprise all other slime.\n" +
                "It could even create new slime gods, with affinities to the world's biomes.\n" +
                "The energy of the world is a pathway to many abilities some consider to be unnatural.\n" +
                "It became so powerful… the only thing it was afraid of was losing it's power, which eventually, of course, it did.\n" +
                "Unfortunately, Goozma's power grew so great for it to become a temporal anomaly.\n" +
                "A temporal anomaly which a power beyond our universe had no choice but to erase, so that it never existed in the first place.\n" +
                "Ironic. The very growth in power which made Goozma a deity in the first place, was also the cause of its demise");
        }

        public override string Texture => "CalValEX/Items/Pets/GoozmaPetItemPlaceholderSprite";

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = ProjectileType<Projectiles.Pets.GoozmaPet>();
            item.buffType = BuffType<Buffs.Pets.GoozmaBuff>();
        }

        public override void AddRecipes() //Someone else do this
        {

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

