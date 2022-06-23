using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.LimitedFlight;

namespace CalValEX.Buffs.Mounts
{
    public class FloatyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Floaty Rug");
            //Description.SetDefault("Warning: flight not included.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<FloatyCarpet>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}