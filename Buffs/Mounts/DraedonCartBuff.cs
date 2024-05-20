using CalValEX.Items.Mounts.Minecart;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Mounts
{
    public class DraedonCartBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<DraedonCartMount>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}
