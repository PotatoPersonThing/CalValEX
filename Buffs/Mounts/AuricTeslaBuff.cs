using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Mounts.Ground;

namespace CalValEX.Buffs.Mounts
{
    public class AuricTeslaBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Tesla");
            Description.SetDefault("Yharim Car\nYharim Car");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<YharimCar>(), player);
            player.buffTime[buffIndex] = 10;
            CalValEX.MountNerf(player, 0.95f, 0.95f);
            player.GetModPlayer<CalValEXPlayer>().yharcar = true;
        }
    }
}