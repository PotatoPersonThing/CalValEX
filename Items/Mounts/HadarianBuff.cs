using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class HadarianBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hadarian Fledgling");
            Description.SetDefault("SCREEEE");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<Items.Mounts.HadarianMount>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}