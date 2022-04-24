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
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Elementals.CloudMini>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Item.rare = 4;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Elementals.cloudbuff>();
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