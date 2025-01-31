using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class HivelingBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHive = true;
            CVUtils.PetBuff(player, buffIndex, ModContent.ProjectileType<Hiveling>());
            CVUtils.PetBuff(player, buffIndex, ModContent.ProjectileType<HivelingDivaHead>());
            CVUtils.PetBuff(player, buffIndex, ModContent.ProjectileType<HivelingDarek>());
            CVUtils.PetBuff(player, buffIndex, ModContent.ProjectileType<HivelingBob>());
        }
    }
}