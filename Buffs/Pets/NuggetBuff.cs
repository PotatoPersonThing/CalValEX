using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class  NuggetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("The Jungle Nugget!");
            Description.SetDefault("Rawr!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Nugget = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Nugget")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Nugget"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }

}