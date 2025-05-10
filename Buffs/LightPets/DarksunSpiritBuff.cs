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
            player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
            if (CalValEX.CalamityActive)
            {
                Mod clamMod = ModLoader.GetMod("CalamityMod");
                clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 4);
            }
            bool _ = false;
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref _, ModContent.ProjectileType<DarksunSpiritSkull_1>());
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref _, ModContent.ProjectileType<DarksunSpiritSkull_2>());
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref _, ModContent.ProjectileType<DarksunSpirit_Fish>());
        }
    }
}