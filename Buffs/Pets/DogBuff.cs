using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Buffs.Pets
{
    public class DogBuff : ModBuff
    {
        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("The Devourer of Gods");
            Description.SetDefault("This probably isn't canon.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if ((bool)calamityMod.Call("GetBossDowned", "devourerofgods"))
            {
                player.GetModPlayer<CalValEXPlayer>().voreworm = true;
                bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.DogHead>()] <= 0;
                if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.DogHead>(), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            else
            {
                return;
            }
        }
    }
}