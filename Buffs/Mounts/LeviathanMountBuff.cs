using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.InfiniteFlight;

namespace CalValEX.Buffs.Mounts
{
    public class LeviathanMountBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<LeviMount>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}