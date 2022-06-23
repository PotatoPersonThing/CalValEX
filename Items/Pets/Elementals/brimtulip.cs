using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    public class brimtulip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rare Brimtulip");
            Tooltip.SetDefault("An elemental's favorite flower!\n" + "Summons a Rare Brimling");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("rarebrimling");
            item.value = Item.sellPrice(0, 2, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 5;
            item.buffType = mod.BuffType("rarebrimlingbuff");
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