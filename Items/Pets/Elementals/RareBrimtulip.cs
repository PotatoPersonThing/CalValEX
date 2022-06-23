using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    [LegacyName("brimtulip")]
    public class RareBrimtulip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rare Brimtulip");
            Tooltip.SetDefault("An elemental's favorite flower!\n" + "Summons a Rare Brimling");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Elementals.RareBrimling>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Item.rare = 5;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Elementals.rarebrimlingbuff>();
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