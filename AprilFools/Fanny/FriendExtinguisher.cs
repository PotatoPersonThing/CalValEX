using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Fanny
{
    public class FriendExtinguisher : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item14;
            Item.consumable = false;
            Item.value = Item.buyPrice(gold: 22);
        }

        public override bool? UseItem(Player player)
        {
            FannyManager.fannyEnabled = !FannyManager.fannyEnabled;
            CalValEXWorld.fannyOverride = CalValEXWorld.fannyOverride == 1 ? 2 : 1;
            CalValEXWorld.UpdateWorldBool();
            return true;
        }
    }
}