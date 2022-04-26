using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class GodrgeBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
           // //DisplayName.SetDefault("Nuclear George");
          //  //Description.SetDefault("Pathetic.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            //clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().GeorgeII = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Godrge>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Godrge>(), 0, 0f, player.whoAmI);
            }
        }
    }
}