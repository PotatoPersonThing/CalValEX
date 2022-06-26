using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Pets
{
    [LegacyName("GoozmaPetItem")]
    public class IonizedJellyCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ionized Jelly Crystal");
            Tooltip.SetDefault("Summons the pinnacle of slime evolution\n" +
                "\n" +
                "\n" +
                "Did you ever hear the tragedy of Goozma The Amorphous Deity? I thought not. It's not a story the Tyrant would tell you.\n" +
                "It's a Overseer legend. Goozma was the ultimate evolution of all slimes, so powerful it could influence the cells that comprise all other slime.\n" +
                "It could even create new slime gods, with affinities to the world's biomes.\n" +
                "The energy of the world is a pathway to many abilities some consider to be unnatural.\n" +
                "It became so powerful that the only thing it was afraid of was losing it's power, which eventually, of course, it did.\n" +
                "Unfortunately, Goozma's power grew so great for it to become a temporal anomaly.\n" +
                "A temporal anomaly which a power beyond our universe had no choice but to erase, so that it never existed in the first place.\n" +
                "Ironic. The very growth in power which made Goozma a deity in the first place, was also the cause of its demise");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 8));
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            SacrificeTotal = 1;
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.shoot = ProjectileType<Projectiles.Pets.GoozmaPet>();
            Item.buffType = BuffType<Buffs.Pets.GoozmaBuff>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item81;
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}