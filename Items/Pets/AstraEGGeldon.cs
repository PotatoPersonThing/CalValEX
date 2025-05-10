using CalValEX.Buffs.Pets;
using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("YharexsLetter")]
    public class AstraEGGeldon : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.shoot = ModContent.ProjectileType<CalamityBABY>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ModContent.RarityType<Rarities.Aqua>();
            Item.buffType = ModContent.BuffType<CalamityBABYBuff>();
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.NPCDeath4;
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player myPlayer = Main.player[i];
                if (myPlayer.active)
                {
                    myPlayer.GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit = false;
                }
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}