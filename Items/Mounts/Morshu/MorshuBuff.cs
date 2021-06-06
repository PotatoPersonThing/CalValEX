using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class MorshuBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Morshu Buff");
            Description.SetDefault("Rope coil? Gel? Bombs? You want it? It's yours my friend, as long as you have a giant ruby...");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().morshu = true;
            player.mount.SetMount(ModContent.MountType<MorshuMount>(), player);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.5f, 0.5f);
        }
    }
}