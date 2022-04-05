using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    public class Minihote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miniature Elemental Heart");
            Tooltip.SetDefault("Its like you're running a daycare or something...\n" + "Summons all of the Miniature Elementals");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = false;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Elementals.rarebrimling>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.expert = true;
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Elementals.minihotebuff>();
            Item.noUseGraphic = true;
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}