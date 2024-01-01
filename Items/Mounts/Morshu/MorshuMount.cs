using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class MorshuMount : ModMount
    {
        public int morshuscal = 0;
        private bool morshuguncheck;
        private bool morshuplaysound;
        private bool scaldying;
        private bool gunsound;
        Terraria.Audio.SoundStyle Draespeech = new("CalValEX/Sounds/Item/MorshuDraedon");
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<MorshuBuff>();
            MountData.heightBoost = 94;
            MountData.flightTimeMax = 0;
            MountData.fallDamage = 0.5f;
            MountData.runSpeed = 8f;
            MountData.dashSpeed = 8f;
            MountData.acceleration = 0.35f;
            MountData.jumpHeight = 18;
            MountData.jumpSpeed = 8.25f;
            MountData.constantJump = true;
            MountData.totalFrames = 4;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 94;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 30;
            MountData.bodyFrame = 3;
            MountData.yOffset = 0;
            MountData.playerHeadOffset = 94;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 12;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 4;
            MountData.runningFrameDelay = 60;
            MountData.runningFrameStart = 0;
            MountData.flyingFrameCount = 0;
            MountData.flyingFrameDelay = 0;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 12;
            MountData.inAirFrameStart = 3;
            MountData.idleFrameCount = 0;
            MountData.idleFrameDelay = 0;
            MountData.idleFrameStart = 0;

            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            MountData.textureWidth = MountData.backTexture.Width();
            MountData.textureHeight = MountData.backTexture.Height();
        }

        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                if (player.velocity.Y >= 0)
                    player.velocity.Y = -4.5f;
            }

            MorshuConsumeCoinAI(player, 5);
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (scaldying)
            {
                morshuscal++;
                if (!morshuplaysound && morshuscal >= 60)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Draespeech, player.Center);
                    morshuplaysound = true;
                }
                if (morshuscal >= 240)
                {
                    player.GetModPlayer<CalValEXPlayer>().morshugun = true;
                    if (!gunsound)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item117);
                        gunsound = true;
                    }
                }
                if (morshuscal >= 480)
                {
                    Vector2 perturbedSpeed = new Vector2(40, 0).RotatedByRandom(MathHelper.ToRadians(10));
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
                    Projectile.NewProjectile(new EntitySource_Parent(player), player.position.X + (104 * player.direction), player.position.Y + 78, 40 * player.direction, perturbedSpeed.Y, ProjectileID.GoldenBullet/*calamityMod.ProjectileType("AccelerationBulletProj")*/, 30000, 0.1f, player.whoAmI, 0f, 0f);
                    Projectile.NewProjectile(new EntitySource_Parent(player), player.position.X + (74 * player.direction), player.position.Y + 78, 40 * player.direction, perturbedSpeed.Y, ProjectileID.GoldenBullet/*calamityMod.ProjectileType("AccelerationBulletProj")*/, 30000, 0.1f, player.whoAmI, 0f, 0f);
                }
            }

            else
            {
                morshuscal = -1;
                player.GetModPlayer<CalValEXPlayer>().morshugun = false;
                morshuplaysound = false;
                gunsound = false;
            }
            /*if (NPC.AnyNPCs(calamityMod.NPCType("Draedon")))
            {
                for (int x = 0; x < Main.maxNPCs; x++)
                {
                    NPC npc = Main.npc[x];
                    if (npc.type == calamityMod.NPCType("Draedon"))
                    {
                        if (npc.dontTakeDamage == false)
                        {
                            scaldying = true;
                        }
                        if (scaldying)
                        {
                            npc.dontTakeDamage = false; //YOU AREN'T HOLOGRAMMIN THIS TIME BISH
                        }
                    }
                    //npc.dontTakeDamage = false && npc.life <= npc.lifeMax * 0.99 && 
                    //(npc.dontTakeDamage = false)
                }
            }*/
            
            /*if (!NPC.AnyNPCs(calamityMod.NPCType("Draedon")))
            {
                scaldying = false;
            }*/

            //This is here for testing
            /*if (NPC.AnyNPCs(calamityMod.NPCType("SuperDummyNPC")))
            {
                scaldying = true;
            }
              
            if (!NPC.AnyNPCs(calamityMod.NPCType("SuperDummyNPC")))
            {
                scaldying = false;
            }*/
        }

        /// <param name="time">Time in seconds</param>
        private void MorshuConsumeCoinAI(Player player, int time)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (++modPlayer.morshuTimer >= time * 60)
            {
                modPlayer.morshuTimer = 0;
                bool consumed = false;

                for (int i = 50; i < 53; i++)
                {
                    if (player.inventory[i].type == ItemID.CopperCoin) //there are copper coins in the inventory. great!
                    {
                        player.inventory[i].stack -= 1;
                        if (player.inventory[i].stack == 0)
                            player.inventory[i].SetDefaults(ItemID.None);
                        consumed = true;
                        break;
                    }
                }

                #region silver

                if (!consumed)
                {
                    bool placedDownCopper = false;
                    for (int i = 50; i < 53; i++)
                    {
                        if (player.inventory[i].type == ItemID.SilverCoin)
                        {
                            player.inventory[i].stack -= 1;
                            if (player.inventory[i].stack == 0)
                                player.inventory[i].SetDefaults(ItemID.None);
                            if (player.inventory[i].type == ItemID.None) //easy solution, its already empty.
                            {
                                player.inventory[i].SetDefaults(ItemID.CopperCoin);
                                player.inventory[i].stack = 99;
                                placedDownCopper = true;
                                break;
                            }
                            consumed = true;
                        }
                    }

                    if (consumed)
                    {
                        if (!placedDownCopper)
                        {
                            PlaceCoinsDown(player, 99, ItemID.CopperCoin, ref placedDownCopper);
                        }
                    }
                }

                #endregion silver

                #region gold

                if (!consumed)
                {
                    bool placedDownSilver = false;
                    bool placedDownCopper = false;
                    for (int i = 50; i < 53; i++)
                    {
                        if (player.inventory[i].type == ItemID.GoldCoin)
                        {
                            player.inventory[i].stack -= 1;
                            if (player.inventory[i].stack == 0)
                                player.inventory[i].SetDefaults(ItemID.None);
                            if (player.inventory[i].type == ItemID.None)
                            {
                                player.inventory[i].SetDefaults(ItemID.SilverCoin);
                                player.inventory[i].stack = 99;
                                placedDownSilver = true;
                            }
                            consumed = true;
                            break;
                        }
                    }

                    if (!placedDownSilver && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.SilverCoin, ref placedDownSilver);
                    }

                    if (!placedDownCopper && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.CopperCoin, ref placedDownCopper);
                    }
                }

                #endregion gold

                #region platinum

                if (!consumed)
                {
                    bool placedDownGold = false;
                    bool placedDownSilver = false;
                    bool placedDownCopper = false;
                    for (int i = 50; i < 53; i++)
                    {
                        if (player.inventory[i].type == ItemID.PlatinumCoin)
                        {
                            player.inventory[i].stack -= 1;
                            if (player.inventory[i].stack == 0)
                                player.inventory[i].SetDefaults(ItemID.None);
                            if (player.inventory[i].type == ItemID.None)
                            {
                                player.inventory[i].SetDefaults(ItemID.GoldCoin);
                                player.inventory[i].stack = 99;
                                placedDownGold = true;
                            }
                            consumed = true;
                            break;
                        }
                    }

                    if (!placedDownGold && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.GoldCoin, ref placedDownGold);
                    }

                    if (!placedDownSilver && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.SilverCoin, ref placedDownSilver);
                    }

                    if (!placedDownCopper && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.CopperCoin, ref placedDownCopper);
                    }
                }

                #endregion platinum

                //if no coin consumed, make the player slower.

                MountData.runSpeed = 8f;
                MountData.dashSpeed = 8f;
                MountData.acceleration = 0.35f;
                MountData.jumpHeight = 18;
                MountData.jumpSpeed = 8.25f;

                if (!consumed)
                {
                    MountData.runSpeed = 2f;
                    MountData.dashSpeed = 2f;
                    MountData.acceleration = 0.05f;
                    MountData.jumpHeight = 4;
                    MountData.jumpSpeed = 8.25f;
                }
            }
        }

        private void PlaceCoinsDown(Player player, int coinCount, int coinType, ref bool coinBool)
        {
            for (int i = 50; i < 53; i++) //Try to find a new coin slot.
            {
                if (player.inventory[i].type == ItemID.None)
                {
                    player.inventory[i].SetDefaults(coinType);
                    player.inventory[i].stack = coinCount;
                    coinBool = true;
                    break;
                }
            }

            if (!coinBool)
            {
                for (int i = 0; i < 49; i++) //no coin slots empty, try to put it in the inventory.
                {
                    if (player.inventory[i].type == ItemID.None)
                    {
                        player.inventory[i].SetDefaults(coinType);
                        player.inventory[i].stack = coinCount;
                        coinBool = true;
                        break;
                    }
                }
            }

            if (!coinBool) //if all else fails, spawn the coins outside.
                player.QuickSpawnItem(new EntitySource_Parent(player), coinType, coinCount);
        }
    }
}