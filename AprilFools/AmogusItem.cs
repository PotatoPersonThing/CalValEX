using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;

namespace CalValEX.AprilFools
{
    public class AmogusItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            /*if (CalValEX.month == 4)
            {
                //DisplayName.SetDefault("Stratus Astronaut");
                //Tooltip.SetDefault("'amogus'\nHe seems to really hate alien dinosaurs");
                Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
            }
            else
            {*/
                //DisplayName.SetDefault("Polus Communicator");
                //Tooltip.SetDefault("'summons a Stratus Astronaut'\nUNOBTAINABLE\nCheating this item in may have disastrous consequences");
            //}
            
        }

        /*public override string Texture => (CalValEX.month == 4 ? "CalValEX/AprilFools/AmogusItem" : "CalValEX/AprilFools/AmogusItemReal");*/

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 36;
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/AmogusScream");
            Item.shoot = ModContent.ProjectileType<Amogus>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<AmogusBuff>();
            Item.noUseGraphic = true;
            Item.expert = true;
        }

        /*public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (CalValEX.month == 4 || Main.LocalPlayer.wet)
            {
                for (int i = 0; i < tooltips.Count; i++)
                {
                    TooltipLine line = tooltips[i];
                    if (line.mod == "Terraria" && line.Name == "ItemName")
                    {
                        tooltips.RemoveAt(i);
                        i--;
                    }
                    else if (line.mod == "Terraria" && line.Name.StartsWith("Tooltip"))
                    {
                        tooltips.RemoveAt(i);
                        i--;
                    }
                    if (line.mod == "Terraria" && line.Name == "ItemName")
                    {
                        tooltips.Add(new TooltipLine(Mod, Mod.Name, Language.GetTextValue("Mods.CalValEX.ItemNameExtra0.AmogusItem")));
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        tooltips.Add(new TooltipLine(Mod, Mod.Name, Language.GetTextValue("Mods.CalValEX.ItemTooltipExtra0.AmogusItem")));
                    }
                }
                return;
            }
            else
            {
                for (int i = 0; i < tooltips.Count; i++)
                {
                    TooltipLine line = tooltips[i];
                    if (line.mod == "Terraria" && line.Name == "ItemName")
                    {
                        tooltips.RemoveAt(i);
                        i--;
                    }
                    else if (line.mod == "Terraria" && line.Name.StartsWith("Tooltip"))
                    {
                        tooltips.RemoveAt(i);
                        i--;
                    }
                    if (line.mod == "Terraria" && line.Name == "ItemName")
                    {
                        tooltips.Add(new TooltipLine(Mod, Mod.Name, Language.GetTextValue("Mods.CalValEX.ItemName.AmogusItem")));
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        tooltips.Add(new TooltipLine(Mod, Mod.Name, Language.GetTextValue("Mods.CalValEX.ItemTooltip.AmogusItem")));
                    }
                }
            }
        }*/

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}