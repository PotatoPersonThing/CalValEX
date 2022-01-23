/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class LumpyItem : ModItem
    {
        public override string Texture => "CalValEX/Projectiles/Plushies/ItsReal";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumpy");
            Tooltip
                .SetDefault("He's very lumpy\n" + "Summons a blob that mimics the first minion it comes in contact with");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit41;
            item.shoot = mod.ProjectileType("LumpyBase");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 8;
            item.buffType = mod.BuffType("LumpyBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}*/