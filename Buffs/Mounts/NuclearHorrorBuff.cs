using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.Ground;

namespace CalValEX.Buffs.Mounts
{
    public class NuclearHorrorBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nuclear Horror");
            Description.SetDefault("Why its helping you is beyond you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<NuclearHorror>(), player);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.6f, 0.6f);
        }
    }
}