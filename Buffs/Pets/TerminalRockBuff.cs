using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class  TerminalRockBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Xeroc's Pet Rock");
            Description.SetDefault("\"This does put a smile on my face...\"");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().TerminalRock = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("TerminalRock")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("TerminalRock"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }

}