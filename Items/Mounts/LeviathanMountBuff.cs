using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class LeviathanMountBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Leviathan Hatchling");
            Description.SetDefault("Better catch a fish");
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