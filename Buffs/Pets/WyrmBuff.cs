using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class  WyrmBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eidolon Inchwyrm");
            Description.SetDefault("Ew, its all slimey...");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().EWyrm = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("EWyrm")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("EWyrm"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }

}