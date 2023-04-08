using System.Collections.Generic;
using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class DarksunSpiritBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (CalValEX.CalamityActive)
            {
                Mod clamMod = ModLoader.GetMod("CalamityMod");
                clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 4);
            }
            List<int> pets = new List<int>
            {
                ModContent.ProjectileType<DarksunSpirit_Fish>(),
                ModContent.ProjectileType<DarksunSpiritSkull_1>(),
                ModContent.ProjectileType<DarksunSpiritSkull_2>()
            };

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
            bool petProjectileNotSpawned = true;
            for (int i = 0; i < pets.Count; i++)
                if (player.ownedProjectileCounts[pets[i]] > 0)
                {
                    petProjectileNotSpawned = false;
                }

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                for (int i = 0; i < pets.Count; i++)
                    Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2,
                        player.position.Y + player.height / 2, 0f, 0f, pets[i], 0, 0f, player.whoAmI);
            }
        }
    }
}