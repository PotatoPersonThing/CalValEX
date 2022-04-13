using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.Ground;

namespace CalValEX.Buffs.Mounts
{
    public class GodRiderBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("God Rider");
            //Description.SetDefault("Ridin' the dimensional tides");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<GoDrider>(), player);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.7f, 0.75f);
        }
    }
}