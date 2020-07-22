using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class  SsandBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tiny Sand Elemental");
            Description.SetDefault("She can't protect you, but she's doing her best");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("sandmini")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("sandmini"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }

}