using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.InfiniteFlight;

namespace CalValEX.Buffs.Mounts
{
    public class YharonMountBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Yharite");
            //Description.SetDefault("He's finally here!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<YharonMount>(), player);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.4f, 0.4f);
        }
    }
}