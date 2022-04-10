using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    public class cloudcandy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Candy");
            Tooltip.SetDefault("An elemental's favorite sweet!\n" + "Summons a Miniature Cloud Elemental");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("CloudMini");
            item.value = Item.sellPrice(0, 2, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 4;
            item.buffType = mod.BuffType("cloudbuff");
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