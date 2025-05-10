using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace CalValEX.Items
{
    public class DustyGuitar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.consumable = false;
            Item.UseSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/Item/Banjo");
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 130;
            Item.useTime = 130;
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.value = 20;
            Item.maxStack = 1;
            Item.useTurn = true;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            // Don't move at the start
            if (player.itemAnimation > 110)
            {
                player.compositeFrontArm.stretch = Player.CompositeArmStretchAmount.Full;
                player.compositeFrontArm.rotation = MathHelper.PiOver4 * -player.direction;
                return;
            }
            // How long it takes for the player to do one swipe
            int swipeSpeed = 7;
            int swipePeriod = player.itemAnimation % swipeSpeed;
            // Alternate between up and down swipes
            bool up = player.itemAnimation % (swipeSpeed * 2) > swipeSpeed;
            // How far the player's arm moves
            float rotationDist = MathHelper.PiOver4 * 1.2f;
            float min = up ? 0 : rotationDist;
            float max = up ? rotationDist : 0;
            float rot = MathHelper.Lerp(min, max, swipePeriod / (float)swipeSpeed) - (player.direction == 1 ? player.direction : 0);

            // When to do the final big swipe
            float finale = 50;
            // Perform the final big swipe
            if (player.itemAnimation <= finale)
            {
                float comp = player.itemAnimation / (float)finale;
                float finalMin = player.direction == 1 ? rotationDist : -rotationDist;
                float finalMax = player.direction == 1 ? -rotationDist : rotationDist;
                rot = MathHelper.Lerp(finalMin, finalMax, MathF.Pow(comp, 5));
            }

            player.compositeFrontArm.stretch = Player.CompositeArmStretchAmount.Full;
            player.compositeFrontArm.rotation = rot;
        }
    }
}