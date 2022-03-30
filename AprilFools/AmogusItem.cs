using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
    public class AmogusItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (CalValEX.month == 4)
            {
                DisplayName.SetDefault("Stratus Astronaut");
                Tooltip.SetDefault("'amogus'\nHe seems to really hate alien dinosaurs");
                Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
            }
            else
            {
                DisplayName.SetDefault("Polus Communicator");
                Tooltip.SetDefault("'summons a Stratus Astronaut'\nUNOBTAINABLE\nCheating this item in may have disastrous consequences");
            }
            
        }

        public override string Texture => (CalValEX.month == 4 ? "CalValEX/AprilFools/AmogusItem" : "CalValEX/AprilFools/AmogusItemReal");

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 36;
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/AmogusScream");
            Item.shoot = ModContent.ProjectileType<Amogus>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<AmogusBuff>();
            Item.noUseGraphic = true;
            Item.expert = true;
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