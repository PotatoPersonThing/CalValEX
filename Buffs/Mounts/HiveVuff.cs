using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.LimitedFlight;

namespace CalValEX.Buffs.Mounts
{
    public class HiveVuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<HiveMount>(), player);
            player.buffTime[buffIndex] = 10;
            //Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("CorruptionEffigyBuff"), 10);
        }
    }
}