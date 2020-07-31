using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace CalValEX.Items.Mounts

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
		if (!(bool) NPC.downedBoss3)
        	{
			Main.LocalPlayer.AddBuff(BuffID.Cursed, 10);
		}
	}
	}
}
