using CalValEX.Items.Mounts.LimitedFlight;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Mounts
{
    public class DebrisMount : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<PhantomDebris>(), player);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.4f, 0.35f);
        }
    }
}