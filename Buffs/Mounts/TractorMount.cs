using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.Ground;

namespace CalValEX.Buffs.Mounts
{
    public class TractorMount : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wulfrum Tank");
            Description.SetDefault("Move forward soldier!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<WulfrumTractor>(), player, false);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.75f, 0.75f);
        }
    }
}