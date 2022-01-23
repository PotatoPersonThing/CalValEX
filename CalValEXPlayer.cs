//using CalValEX.Buffs.Transformations;
//using CalValEX.Items.Equips.Transformations;
//using CalamityMod.CalPlayer;
using System.Collections.Generic;
using System.IO;
using CalamityMod.Events;
using CalValEX.Items.Equips.Hats.Draedon;
using CalValEX.Items.Equips.Shirts.Draedon;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Buffs.Transformations;
using CalValEX.Items.Mounts.Morshu;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Items.Equips.Backs;
using CalValEX.Projectiles.Pets.Elementals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX
{
    public class CalValEXPlayer : ModPlayer
    {
        private const int saveVersion = 0;

        public static readonly PlayerHeadLayer HeadDraedonHelmet = new PlayerHeadLayer("CalValEX", "HeadDraedonHelmet",
            delegate (PlayerHeadDrawInfo drawInfo)
            {
                Player drawPlayer = drawInfo.drawPlayer;
                Mod mod = ModLoader.GetMod("CalValEX");

                if (drawPlayer.head != mod.GetEquipSlot("DraedonHelmet", EquipType.Head))
                    return;

                Texture2D texture = drawPlayer.HeldItem.magic ? DraedonHelmetTextureCache.DraedonMagicHelm
                    : drawPlayer.HeldItem.summon ? DraedonHelmetTextureCache.DraedonSummonerHelm
                    : drawPlayer.HeldItem.ranged ? DraedonHelmetTextureCache.DraedonRangerHelm
                    : drawPlayer.HeldItem.thrown ? DraedonHelmetTextureCache.DraedonRogueHelm
                    : drawPlayer.HeldItem.melee ? DraedonHelmetTextureCache.DraedonMeleeHelm
                    : DraedonHelmetTextureCache.DraedonDefaultHelm;

                if (texture == DraedonHelmetTextureCache.DraedonDefaultHelm)
                    return;

                float drawX = (int)(drawPlayer.position.X - Main.screenPosition.X - drawPlayer.bodyFrame.Width / 2f + drawPlayer.width / 2f);
                float drawY = (int)(drawPlayer.position.Y - Main.screenPosition.Y + drawPlayer.height -
                    drawPlayer.bodyFrame.Height + 4);
                Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition + drawInfo.drawOrigin;
                float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
                float scale = drawInfo.scale;
                DrawData drawData = new DrawData(texture, position, drawPlayer.bodyFrame, Color.White * alpha,
                    drawPlayer.headRotation, drawInfo.drawOrigin, scale, drawInfo.spriteEffects, 0);

                GameShaders.Armor.Apply(drawInfo.armorShader, drawPlayer, drawData);
                drawData.Draw(Main.spriteBatch);
                Main.pixelShader.CurrentTechnique.Passes[0].Apply();
            });

        public static readonly PlayerLayer DraedonHelmet = new PlayerLayer("CalValEX", "DraedonHelmet",
            PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
                              {
                                  if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
                                      return;

                                  Player drawPlayer = drawInfo.drawPlayer;
                                  Mod mod = ModLoader.GetMod("CalValEX");

                                  if (drawPlayer.head != mod.GetEquipSlot("DraedonHelmet", EquipType.Head))
                                      return;

                                  Texture2D texture = drawPlayer.HeldItem.magic ? DraedonHelmetTextureCache.DraedonMagicHelm
                                      : drawPlayer.HeldItem.summon ? DraedonHelmetTextureCache.DraedonSummonerHelm
                                      : drawPlayer.HeldItem.ranged ? DraedonHelmetTextureCache.DraedonRangerHelm
                                      : drawPlayer.HeldItem.thrown ? DraedonHelmetTextureCache.DraedonRogueHelm
                                      : drawPlayer.HeldItem.melee ? DraedonHelmetTextureCache.DraedonMeleeHelm
                                      : DraedonHelmetTextureCache.DraedonDefaultHelm;

                                  if (texture == DraedonHelmetTextureCache.DraedonDefaultHelm)
                                      return;

                                  float drawX = (int)(drawInfo.position.X - Main.screenPosition.X -
                                      drawPlayer.bodyFrame.Width / 2f + drawPlayer.width / 2f);
                                  float drawY = (int)(drawInfo.position.Y - Main.screenPosition.Y + drawPlayer.height -
                                      drawPlayer.bodyFrame.Height + 4);

                                  Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition + drawInfo.headOrigin;
                                  Color color = Lighting.GetColor(
                                      (int)(drawInfo.position.X + drawPlayer.width * 0.5) / 16,
                                      (int)(drawInfo.position.Y + drawPlayer.height * 0.25) / 16,
                                      Color.White);
                                  float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
                                  Vector2 origin = drawInfo.headOrigin;
                                  DrawData drawData = new DrawData(texture, position, drawPlayer.bodyFrame,
                                      color * alpha, drawPlayer.headRotation, origin, 1f, drawInfo.spriteEffects, 0)
                                  {
                                      shader = drawInfo.headArmorShader
                                  };
                                  Main.playerDrawData.Add(drawData);
                              });

        public static readonly PlayerLayer DraedonChestplate = new PlayerLayer("CalValEX", "DraedonChestplate",
            PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
                              {
                                  if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
                                      return;

                                  Player drawPlayer = drawInfo.drawPlayer;
                                  Mod mod = ModLoader.GetMod("CalValEX");

                                  if (drawPlayer.body != mod.GetEquipSlot("DraedonChestplate", EquipType.Body))
                                      return;

                                  Texture2D texture = drawPlayer.HeldItem.magic ? DraedonChestplateCache.DraedonMagicChest
                                      : drawPlayer.HeldItem.summon ? DraedonChestplateCache.DraedonSummonerChest
                                      : drawPlayer.HeldItem.ranged ? DraedonChestplateCache.DraedonRangerChest
                                      : drawPlayer.HeldItem.thrown ? DraedonChestplateCache.DraedonRogueChest
                                      : drawPlayer.HeldItem.melee ? DraedonChestplateCache.DraedonMeleeChest
                                      : DraedonChestplateCache.DraedonDefaultChest;

                                  if (texture == DraedonHelmetTextureCache.DraedonDefaultHelm)
                                      return;

                                  float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
                                  float drawY = (int)drawInfo.position.Y + drawPlayer.height -
                                      drawPlayer.bodyFrame.Height / 2 + 4f;
                                  Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition -
                                                     Main.screenPosition;
                                  float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
                                  Color color = Lighting.GetColor(
                                      (int)(drawInfo.position.X + drawPlayer.width * 0.5) / 16,
                                      (int)(drawInfo.position.Y + drawPlayer.height * 0.5) / 16,
                                      Color.White);
                                  DrawData drawData = new DrawData(texture, position, drawPlayer.bodyFrame,
                                      color * alpha, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f,
                                      drawInfo.spriteEffects, 0)
                                  {
                                      shader = drawInfo.bodyArmorShader
                                  };


                                  Main.playerDrawData.Add(drawData);
                              });

        public bool aero;
        public bool andro;
        public bool Angrypup;
        public bool asPet;
        public bool AstPhage;
        public bool BabyCnidrion;
        public bool babywaterclone;
        public bool bDoge;
        public bool BoldLizard;
        public bool CalamityBABYBool;
        public bool CalamityBabyGotHit;

        //Monoliths
        public bool calMonolith = false;
        public bool catfish;
        public bool Chihuahua;
        public bool cloudmini;
        public bool cr;
        public bool cryokid;
        public bool darksunSpirits;
        public bool dBall;
        public bool deusmain;
        public bool deussmall;
        public bool dogMonolith = false;
        public bool drone;
        public bool dsPet;
        public bool Dstone;
        public bool eb;
        public bool eidolist;
        public bool Enredpet;
        public bool euros;
        public bool EWyrm;
        public bool excal;
        public bool feel;
        public bool fog;
        public bool George;
        public bool GeorgeII;
        public bool goozmaPet;
        public bool hDoge;
        public bool HellLab;
        public bool hover;
        public bool jared;
        public bool junsi;
        public bool leviMonolith = false;
        public bool Lightshield;
        public bool mAero;
        public bool mAmb;
        public bool mAme;
        public bool mArmored;
        public bool mBirb;
        public bool mBirb2;
        public bool mChan;
        public bool mClam;
        public bool mCry;
        public bool mDebris;
        public bool mDia;
        public bool mDoge;
        public bool mDuke;
        public bool MechaGeorge;
        public bool mEme;
        public bool mFolly;
        public bool mHeat;
        public bool mHeat2;
        public bool mHive;
        public bool mImp;
        public bool MiniCryo;
        public bool mNaked;
        public bool moistPet;
        public bool conejo;

        public int morshuscal = 0;
        //public CalamityPlayer calPlayer;
        /*
        public bool sandTPrevious;
        public bool sandT;
        public bool sandHide;
        public bool sandForce;
        */

        public int morshuTimer;
        public bool mPerf;
        public bool mPhan;
        public bool mRav;
        public bool mRub;
        public bool mSap;
        public bool mScourge;
        public bool mShark;
        public bool mSkater;
        public bool mSlime;
        public bool mTop;
        public bool Nugget;
        public bool oSquid;
        public bool PBGmini;
        public bool pbgMonolith = false;
        public bool ProGuard1;
        public bool ProGuard2;
        public bool ProGuard3;
        public bool ProviPet;
        public bool provMonolith = false;
        public bool pylon;
        public bool rarebrimling;
        public bool raresandmini;
        public bool RepairBot;
        public bool rover;
        public bool rPanda;
        public bool rusty;
        public bool sandmini;
        public bool sBun;
        public int SCalHits;
        public bool scalMonolith = false;
        public bool sDuke;
        public bool seerL;
        public bool seerM;
        public bool seerS;
        public bool sepet;
        public bool SignusMini;
        public bool sirember;
        public bool Skeetyeet;
        public bool SmolCrab;
        public bool squid;
        public bool sSignus;
        public bool StarJelly;
        public bool strongWeeb;
        public bool sVoid;
        public bool sWeeb;
        public bool SWPet;
        public bool TerminalRock;
        public bool tub;
        public bool uSerpent;
        public bool voidling;
        public bool VoidOrb;
        public bool voreworm;
        public bool worb;
        public bool yharonMonolith = false;
        public bool brMonolith = false;
        public bool exoMonolith = false;
        public bool ySquid;
        public bool amogus;
        public bool buppy;
        public bool BMonster;
        public bool hage;
        public bool Blok;
        public bool ZoneAstral;
        public bool ZoneLab;
        public bool aesthetic;
        public bool exorb;
        public bool rockhat;
        public bool prismshell;
        public bool rainbow;
        public bool avalon;
        public bool SupJ;
        public bool poltermask;
        public bool polterchest;
        public bool polterthigh;
        public bool bSignut;
        public bool bSlime;
        public bool buffboi;
        public bool smaul;
        public bool shart;
        public bool roverd;
        public bool morshu;
        public bool morshugun;
        public bool scaldown;
        public bool yharcar;
        public bool sepneo;
        //Signus Transformation bools
        public bool signutHide;
        public bool signutForce;
        public bool signutPrevious;
        public bool signutPower;
        public bool signutTrans;
        //Andromeda transformation bools
        public bool androHide;
        public bool androForce;
        public bool androPrevious;
        public bool androPower;
        public bool androTrans;
        //Classic Brimmy transformation bools
        public bool classicHide;
        public bool classicForce;
        public bool classicPrevious;
        public bool classicPower;
        public bool classicTrans;
        //Cloud transformation bools
        public bool cloudHide;
        public bool cloudForce;
        public bool cloudPrevious;
        public bool cloudPower;
        public bool cloudTrans;
        //Sand transformation bools
        public bool sandHide;
        public bool sandForce;
        public bool sandPrevious;
        public bool sandPower;
        public bool sandTrans;
        //More stuff ig
        public bool vanityhote;
        public bool vanitysand;
        public bool vanityrare;
        public bool vanitysiren;
        public bool vanitybrim;
        public bool vanitycloud;
        public bool vanityfunclump;
        public bool vanityyound;
        public int choppercounter = 0;
        public double rotcounter = 0;
        public double rotdeg = 0;
        public double rotsin = 0;
        public int chopperframe = 0;
        public int conecounter = 0;
        public int coneframe = 0;
        public int twincounter = 0;
        public int twinframe = 0;
        public int stwincounter = 0;
        public int stwinframe = 0;
        public bool wulfrumjam;
        public bool cassette;
        public bool specan;
        public bool carriage;
        public float bcarriagewheel = 0.0f;
        public bool twinballoon;
        public bool artballoon;
        public bool apballoon;
        public bool sapballoon;
        public bool sartballoon;
        //344
        //Pong stuff
        public bool pongactive;
        public int pongstage = 0;
        public int pongoutcome = 0;
        /*public float pongballposx;
        public float pongballposy;
        public float sliderposx;
        public float sliderposy;*/
        //Enchants
        public bool soupench = false;
        public int bossded;
        public bool aresarms;
        public bool lumpe;

        public override void Initialize()
        {
            ResetMyStuff();
            //calPlayer = player.GetModPlayer<CalamityPlayer>();
            CalamityBabyGotHit = false;
            morshuTimer = 0;
        }

        public override void ResetEffects()
        {
            signutPrevious = signutTrans;
            signutTrans = signutHide = signutForce = signutPower = false;
            androPrevious = androTrans;
            androTrans = androHide = androForce = androPower = false;
            classicPrevious = classicTrans;
            classicTrans = classicHide = classicForce = classicPower = false;
            cloudPrevious = cloudTrans;
            cloudTrans = cloudHide = cloudForce = cloudPower = false;
            sandPrevious = sandTrans;
            sandTrans = sandHide = sandForce = sandPower = false;
            ResetMyStuff();
        }

        
        public override void UpdateVanityAccessories()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Mod antisocial = ModLoader.GetMod("Antisocial");
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.type == ModContent.ItemType<Signus>())
                {
                    signutHide = false;
                    signutForce = true;
                }
                else if (item.type == ModContent.ItemType<ProtoRing>())
                {
                    androHide = false;
                    androForce = true;
                }
                else if (item.type == ModContent.ItemType<BurningEye>())
                {
                    classicHide = false;
                    classicForce = true;
                }
                else if (item.type == ModContent.ItemType<CloudWaistbelt>())
                {
                    cloudHide = false;
                    cloudForce = true;
                }
                else if (item.type == ModContent.ItemType<SandyBangles>())
                {
                    sandHide = false;
                    sandForce = true;
                }
                //Update vanity won't work for these two so they are detected here
                else if (item.type == ModContent.ItemType<PrismShell>())
                {
                    prismshell = true;
                }
                else if (item.type == ModContent.ItemType<Items.Equips.ExodiumMoon>())
                {
                    exorb = true;
                }
                else if (item.type == calamityMod.ItemType("HeartoftheElements") && !CalValEXConfig.Instance.HeartVanity && antisocial == null)
                {
                    bool brimmyspawned = player.ownedProjectileCounts[ProjectileType<VanityBrimstone>()] <= 0;
                    bool cloudspawned = player.ownedProjectileCounts[ProjectileType<VanityCloud>()] <= 0;
                    bool sandspawned = player.ownedProjectileCounts[ProjectileType<VanitySand>()] <= 0;
                    bool raresandspawned = player.ownedProjectileCounts[ProjectileType<VanityRareSand>()] <= 0;
                    bool anahitaspawned = player.ownedProjectileCounts[ProjectileType<VanityAnahita>()] <= 0;
                    if (brimmyspawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityBrimstone>(), 0, 0f, player.whoAmI);
                    }
                    if (cloudspawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityCloud>(), 0, 0f, player.whoAmI);
                    }
                    if (sandspawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanitySand>(), 0, 0f, player.whoAmI);
                    }
                    if (raresandspawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityRareSand>(), 0, 0f, player.whoAmI);
                    }
                    if (anahitaspawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityAnahita>(), 0, 0f, player.whoAmI);
                    }
                    vanityhote = true;
                }
                else if (item.type == calamityMod.ItemType("RoseStone") && !CalValEXConfig.Instance.HeartVanity && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanityBrimstone>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityBrimstone>(), 0, 0f, player.whoAmI);
                    }
                    vanitybrim = true;
                }
                else if (item.type == calamityMod.ItemType("EyeoftheStorm") && !CalValEXConfig.Instance.HeartVanity && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanityCloud>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityCloud>(), 0, 0f, player.whoAmI);
                    }
                    vanitycloud = true;
                }
                else if (item.type == calamityMod.ItemType("WifeinaBottle") && !CalValEXConfig.Instance.HeartVanity && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanitySand>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanitySand>(), 0, 0f, player.whoAmI);
                    }
                    vanitysand = true;
                }
                else if (item.type == calamityMod.ItemType("WifeinaBottlewithBoobs") && !CalValEXConfig.Instance.HeartVanity && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanityRareSand>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityRareSand>(), 0, 0f, player.whoAmI);
                    }
                    vanityrare = true;
                }
                else if (item.type == calamityMod.ItemType("LureofEnthrallment") && !CalValEXConfig.Instance.HeartVanity && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanityAnahita>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityAnahita>(), 0, 0f, player.whoAmI);
                    }
                    vanitysiren = true;
                }
                else if (item.type == calamityMod.ItemType("CryoStone") && !CalValEXConfig.Instance.ColdShield && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<Lightshield>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<Lightshield>(), 0, 0f, player.whoAmI);
                    }
                    Lightshield = true;
                }
                else if (item.type == calamityMod.ItemType("MutatedTruffle") && !CalValEXConfig.Instance.YoungDukePSS && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanityYoungDuke>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityYoungDuke>(), 0, 0f, player.whoAmI);
                    }
                    vanityyound = true;
                }
                else if (item.type == calamityMod.ItemType("FungalClump") && !CalValEXConfig.Instance.FungusClump && antisocial == null)
                {
                    bool cryospawned = player.ownedProjectileCounts[ProjectileType<VanityFunClump>()] <= 0;
                    if (cryospawned && player.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                            0f, 0f, ProjectileType<VanityFunClump>(), 0, 0f, player.whoAmI);
                    }
                    vanityfunclump = true;
                }
            }
            //Despawn vanity elementals and cryo shield if in functional slots
            for (int n = 3; n < 10 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.type == calamityMod.ItemType("HeartoftheElements"))
                {
                    vanityhote = false;
                }
                if (item.type == calamityMod.ItemType("WifeinaBottle"))
                {
                    vanitysand = false;
                }
                if (item.type == calamityMod.ItemType("WifeinaBottlewithBoobs"))
                {
                    vanityrare = false;
                }
                if (item.type == calamityMod.ItemType("EyeoftheStorm"))
                {
                    vanitycloud = false;
                }
                if (item.type == calamityMod.ItemType("RoseStone"))
                {
                    vanitybrim = false;
                }
                if (item.type == calamityMod.ItemType("LureofEnthrallment"))
                {
                    vanitysiren = false;
                }
                if (item.type == calamityMod.ItemType("CryoStone"))
                {
                    Lightshield = false;
                }
                if (item.type == calamityMod.ItemType("FungalClump"))
                {
                    vanityfunclump = false;
                }
                if (item.type == calamityMod.ItemType("MutatedTruffle"))
                {
                    vanityyound = false;
                }
            }
        }
        public override void FrameEffects()
        {
            if ((signutTrans || signutForce) && !signutHide)
            {
                player.legs = mod.GetEquipSlot("SignusLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("SignusBody", EquipType.Body);
                player.head = mod.GetEquipSlot("SignusHead", EquipType.Head);
            }
            else if ((androTrans || androForce) && !androHide)
            {
                player.legs = mod.GetEquipSlot("TinyIbanRobotOfDoomLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("TinyIbanRobotOfDoomBody", EquipType.Body);
                player.head = mod.GetEquipSlot("TinyIbanRobotOfDoomHead", EquipType.Head);
            }
            else if ((classicTrans || classicForce) && !classicHide)
            {
                player.legs = mod.GetEquipSlot("ClassicBrimmyLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("ClassicBrimmyBody", EquipType.Body);
                player.head = mod.GetEquipSlot("ClassicBrimmyHead", EquipType.Head);
            }
            else if ((cloudTrans || cloudForce) && !cloudHide)
            {
                player.legs = mod.GetEquipSlot("CloudLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("CloudBody", EquipType.Body);
                player.head = mod.GetEquipSlot("CloudHead", EquipType.Head);
            }
            else if ((sandTrans || sandForce) && !sandHide)
            {
                player.legs = mod.GetEquipSlot("SandLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("SandBody", EquipType.Body);
                player.head = mod.GetEquipSlot("SandHead", EquipType.Head);
            }
            if (wulfrumjam)
            {
                player.wings = mod.GetEquipSlot("BlankWings", EquipType.Wings);
            }
            if (cassette)
            {
                player.armorEffectDrawShadow = true;
                player.armorEffectDrawOutlines = true;
            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        { 
            if (signutTrans)
                player.AddBuff(ModContent.BuffType<SignutTransformationBuff>(), 60, true);
            else if (androTrans)
                player.AddBuff(ModContent.BuffType<ProtoRingBuff>(), 60, true);
            else if (classicTrans)
                player.AddBuff(ModContent.BuffType<ClassicBrimmyBuff>(), 60, true);
            else if (cloudTrans)
                player.AddBuff(ModContent.BuffType<CloudTransformationBuff>(), 60, true);
            else if (sandTrans)
                player.AddBuff(ModContent.BuffType<SandTransformationBuff>(), 60, true);
        }

        public override void PreUpdateMovement()
        {
            if (pongactive)
            {
                player.releaseHook = true;
                player.releaseMount = true;
                player.velocity.X = 0;
                if (player.velocity.Y < 0)
                {
                    player.velocity.Y = 0;
                }
            }
            if (!pongactive)
            {
                pongstage = 0;
                pongoutcome = 0;
            }
        }

        public override void PostUpdateBuffs()
        {
            if (!player.HasBuff(ModContent.BuffType<MorshuBuff>()))
            {
                morshuTimer = 0;
            }
        }

        public override void UpdateDead()
        {
            ResetMyStuff();
            CalamityBabyGotHit = false;
            SCalHits = 0;
            morshuTimer = 0;
        }

        public override void PreUpdate()
        {
            /* //Removing these for now because they broke shit
            //Kill Cadance potion heart particles
            Main.instance.LoadGore(331);
            Player player = Main.LocalPlayer;
            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();
            if (calPlayer.cadence && CalValEXConfig.Instance.Cadance)
            {
                Main.goreTexture[331] = GetTexture("CalValEX/Items/Equips/Shields/Invishield_Shield");
            }
            else
            {
                Main.goreLoaded[331] = false;
            }*/

            //Custom player draw frame counters
            int wulfrumflame = 9;
            if (choppercounter >= 7)
            {
                choppercounter = -1;
                chopperframe = chopperframe == wulfrumflame - 1 ? 0 : chopperframe + 1;
            }
            choppercounter++;

            int coneflame = 6;
            if (conecounter >= 5)
            {
                conecounter = -1;
                coneframe = coneframe == coneflame - 1 ? 0 : coneframe + 1;
            }
            conecounter++;

            int twinflame = 5;
            if (twincounter >= 12)
            {
                twincounter = -1;
                twinframe = twinframe == twinflame - 1 ? 0 : twinframe + 1;
            }
            twincounter++;

            int stwinflame = 12;
            if (stwincounter >= 12)
            {
                stwincounter = -1;
                stwinframe = stwinframe == stwinflame - 1 ? 0 : stwinframe + 1;
            }
            stwincounter++;

            if (Main.LocalPlayer.velocity.X > 0)
            {
                bcarriagewheel += 1.0f;
            }
            else if (Main.LocalPlayer.velocity.X < 0)
            {
                bcarriagewheel -= 1.0f;
            }
            if (bossded > 0)
            {
                bossded--;
            }
            rotcounter += Math.PI / 80;
            rotdeg = Math.Cos(rotcounter);
            rotsin = -Math.Sin(rotcounter);
        }

        private void ResetMyStuff()
        {
            mBirb = false;
            mBirb2 = false;
            mDoge = false;
            mAero = false;
            mSkater = false;
            mShark = false;
            mFolly = false;
            mPerf = false;
            mHive = false;
            mPhan = false;
            mChan = false;
            mNaked = false;
            mArmored = false;
            eidolist = false;
            excal = false;
            aero = false;
            mRav = false;
            tub = false;
            andro = false;
            seerS = false;
            seerM = false;
            seerL = false;
            mImp = false;
            George = false;
            rPanda = false;
            catfish = false;
            cr = false;
            eb = false;
            mSlime = false;
            fog = false;
            mDebris = false;
            mHeat = false;
            mHeat2 = false;
            dBall = false;
            mClam = false;
            mAme = false;
            mSap = false;
            mEme = false;
            mTop = false;
            mRub = false;
            mDia = false;
            mCry = false;
            mAmb = false;
            sBun = false;
            uSerpent = false;
            GeorgeII = false;
            junsi = false;
            SignusMini = false;
            MiniCryo = false;
            SmolCrab = false;
            VoidOrb = false;
            AstPhage = false;
            StarJelly = false;
            ProGuard1 = false;
            ProGuard2 = false;
            ProGuard3 = false;
            ProviPet = false;
            Dstone = false;
            EWyrm = false;
            PBGmini = false;
            BoldLizard = false;
            Nugget = false;
            Enredpet = false;
            sandmini = false;
            raresandmini = false;
            rarebrimling = false;
            babywaterclone = false;
            cloudmini = false;
            Skeetyeet = false;
            Angrypup = false;
            cryokid = false;
            TerminalRock = false;
            BabyCnidrion = false;
            sVoid = false;
            sSignus = false;
            sWeeb = false;
            euros = false;
            hDoge = false;
            bDoge = false;
            SWPet = false;
            jared = false;
            asPet = false;
            dsPet = false;
            mDuke = false;
            sirember = false;
            deusmain = false;
            deussmall = false;
            roverd = false;
            rusty = false;
            sepet = false;
            pylon = false;
            worb = false;
            rover = false;
            drone = false;
            hover = false;
            RepairBot = false;
            MechaGeorge = false;
            CalamityBABYBool = false;
            Lightshield = false;
            sDuke = false;
            squid = false;
            voidling = false;
            mScourge = false;
            darksunSpirits = false;
            goozmaPet = false;
            voreworm = false;
            moistPet = false;
            Chihuahua = false;
            strongWeeb = false;
            ySquid = false;
            oSquid = false;
            feel = false;
            amogus = false;
            buppy = false;
            BMonster = false;
            hage = false;
            Blok = false;
            aesthetic = false;
            exorb = false;
            poltermask = false;
            polterchest = false;
            polterthigh = false;
            rockhat = false;
            prismshell = false;
            rainbow = false;
            SupJ = false;
            bSignut = false;
            bSlime = false;
            buffboi = false;
            smaul = false;
            shart = false;
            morshu = false;
            morshugun = false;
            scaldown = false;
            vanityhote = false;
            vanitybrim = false;
            vanityrare = false;
            vanitysand = false;
            vanitysiren = false;
            vanitycloud = false;
            vanityyound = false;
            vanityfunclump = false;
            avalon = false;
            wulfrumjam = false;
            conejo = false;
            cassette = false;
            specan = false;
            carriage = false;
            yharcar = false;
            sepneo = false;
            twinballoon = false;
            artballoon = false;
            apballoon = false;
            sapballoon = false;
            sartballoon = false;
            /*pongactive = false;
            pongoutcome = 0;
            pongstage = 0;*/
            soupench = false;
            aresarms = false;
            lumpe = false;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            DoCalamityBabyThings((int)damage);
            if (signutTrans)
            {
                Main.PlaySound(SoundID.NPCHit49, (int)player.position.X, (int)player.position.Y);
                for (int x = 0; x < 15; x++)
                {
                    Dust dust;
                    Vector2 position = Main.LocalPlayer.Center;
                    dust = Main.dust[Terraria.Dust.NewDust(player.Center, 26, 15, 191, 0f, 0f, 147, new Color(255, 255, 255), 0.9868422f)];
                }
            }

            if (classicTrans) Main.PlaySound(SoundID.FemaleHit, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
            if (cloudTrans) Main.PlaySound(SoundID.FemaleHit, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
            if (sandTrans) Main.PlaySound(SoundID.FemaleHit, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (signutTrans) playSound = false;
            if (cloudTrans) playSound = false;
            if (classicTrans) playSound = false;
            if (sandTrans) playSound = false;
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            DoCalamityBabyThings(damage);

            if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas") && player.immuneTime <= 0)
            {
                SCalHits++;
            }
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            DoCalamityBabyThings(damage);

            for (int i = 0; i < Main.maxNPCs; i++)
                if (Main.npc[i].active &&
                    Main.npc[i].type == ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas"))
                {
                    if (player.immuneTime <= 0)
                    {
                        SCalHits++;
                    }
                }
        }

        private void DoCalamityBabyThings(int damage)
        {
            if (CalamityBABYBool)
            {
                if (damage > 0)
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.name == "Kawaggy")
                        {
                            string humiliationText = "";
                            switch (Main.rand.Next(0, 5))
                            {
                                case 0:
                                    humiliationText = "Why didn't you code me earlier?";
                                    break;

                                case 1:
                                    humiliationText = "Not worthy.";
                                    break;

                                case 2:
                                    humiliationText = "It's been months.";
                                    break;

                                case 3:
                                    humiliationText = "You will not be forgiven.";
                                    break;

                                case 4:
                                    humiliationText = "I hope you learn.";
                                    break;
                            }

                            CombatText.NewText(player.getRect(), Color.White, humiliationText);
                            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " is not worthy."), 99999999,
                                -1);
                        }

                        if (Main.rand.NextFloat() < 0.08f)
                        {
                            if (CalamityBABY.nameList.Contains(player.name))
                            {
                                player.AddBuff(BuffID.Lovestruck, Main.rand.Next(600, 3601));
                            }
                            else if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("AstrageldonBuff")) ||
                                     !Main.LocalPlayer.HasItem(ItemID.LandMine))
                            {
                                CalamityBabyGotHit = true;
                            }
                        }
                    }
                }
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize,
            int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (player.ZoneBeach && power > 80 && Main.rand.NextFloat() < 0.021f)
            {
                caughtType = mod.ItemType("WetBubble");
            }
            if (ZoneAstral && power > 80 && Main.rand.NextFloat() < 0.0105f)
            {
                    caughtType = mod.ItemType("AstralOldPurple");
            }
            if (ZoneAstral && power > 80 && Main.rand.NextFloat() < 0.0105f)
            {
                caughtType = mod.ItemType("AstralOldYellow");
            }
            if ((bool)calamityMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea") && (bool)calamityMod.Call("GetBossDowned", "hmclam") && power > 80 && Main.rand.NextFloat() < 0.021f)
            {
                caughtType = mod.ItemType("SailfishTrophy");
            }
        }

        public override void UpdateBiomes()
        {
            ZoneAstral = CalValEXWorld.astralTiles > 400;
            HellLab = CalValEXWorld.hellTiles > 50;
            ZoneLab = CalValEXWorld.labTiles > 100;
        }

        public override bool CustomBiomesMatch(Player other)
        {
            CalValEXPlayer modOther = other.GetModPlayer<CalValEXPlayer>();
            return ZoneAstral == modOther.ZoneAstral;
            return HellLab == modOther.HellLab;
            return ZoneLab = modOther.ZoneLab;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            CalValEXPlayer modOther = other.GetModPlayer<CalValEXPlayer>();
            modOther.ZoneAstral = ZoneAstral;
            modOther.HellLab = HellLab;
            modOther.ZoneLab = ZoneLab;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneAstral;
            flags[1] = HellLab;
            flags[2] = ZoneLab;
            writer.Write(flags);
        }

        public override void UpdateBiomeVisuals()
        {
            bool useAstralBiome = ZoneAstral;
            player.ManageSpecialBiomeVisuals("CalValEX:AstralBiome", useAstralBiome);

            bool bossIsAlive2 = false;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    bossIsAlive2 = true;
                }
            }
            if (!bossIsAlive2)
            {
                bool useCalMonolith = calMonolith;
                bool useLeviMonolith = leviMonolith;
                bool usePBGMonolith = pbgMonolith;
                bool useProvMonolith = provMonolith;
                bool useDogMonolith = dogMonolith;
                bool useYharonMonolith = yharonMonolith;
                bool useExoMonolith = exoMonolith;
                bool useBRMonolith = brMonolith;
                bool useScalMonolith = scalMonolith;
                bool TerminalMonolith = CalValEXWorld.RockshrinEX;
                if (calMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:CalamitasRun3", useCalMonolith, player.Center);
                }
                else if (leviMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:Leviathan", useLeviMonolith, player.Center);
                }
                else if (pbgMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:PlaguebringerGoliath", usePBGMonolith, player.Center);
                }
                else if (provMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:Providence", useProvMonolith, player.Center);
                }
                else if (dogMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:DevourerofGodsHead", useDogMonolith, player.Center);
                }
                else if (yharonMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:Yharon", useYharonMonolith, player.Center);
                }
                else if (exoMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:ExoMechs", useExoMonolith, player.Center);
                }
                //player.ManageSpecialBiomeVisuals("CalamityMod:BossRush", useExoMonolith, player.Center); //"Boss Rush" effect seems closer to the Draedon effect for some reason, so they have been swapped
                else if (scalMonolith)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:SupremeCalamitas", useScalMonolith, player.Center);
                }
                else if (CalValEXWorld.RockshrinEX)
                {
                    player.ManageSpecialBiomeVisuals("CalamityMod:SupremeCalamitas", TerminalMonolith, player.Center);
                }
                /*if (useBRMonolith)
                {
                    CalamityMod.Events.BossRushEvent.EndTimer = -1;
                }*/
            }
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneAstral = flags[0];
            HellLab = flags[1];
        }

        public override void clientClone(ModPlayer clientClone)
        {
            CalValEXPlayer clone = clientClone as CalValEXPlayer;
            clone.SCalHits = SCalHits;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)CalValEX.MessageType.SyncCalValEXPlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(SCalHits);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            CalValEXPlayer clone = clientPlayer as CalValEXPlayer;
            if (clone.SCalHits != SCalHits)
            {
                var packet = mod.GetPacket();
                packet.Write((byte)CalValEX.MessageType.SyncSCalHits);
                packet.Write((byte)player.whoAmI);
                packet.Write(SCalHits);
                packet.Send();
            }
        }

        public static readonly PlayerLayer HeadFront = new PlayerLayer("CalValEX", "HeadFront", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.specan)
            {
                Texture2D texture = mod.GetTexture("Items/Equips/Hats/SpectralstormHat");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y - secondyoffset);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0)
                {
                    shader = drawInfo.headArmorShader
                };
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer Head = new PlayerLayer("CalValEX", "Head", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.aesthetic)
            {
                Texture2D texture = mod.GetTexture("Items/Equips/Hats/AestheticrownEquipped");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y - secondyoffset);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0)
                {
                    shader = drawInfo.headArmorShader
                }; 
                Main.playerDrawData.Add(data);
            }
            if (modPlayer.rockhat)
            {
                Texture2D texture = mod.GetTexture("Items/Equips/Hats/StonePileEquipped");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y - secondyoffset);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0)
                {
                    shader = drawInfo.headArmorShader
                }; 
                Main.playerDrawData.Add(data);
            }
            if (modPlayer.conejo)
            {
                int winflip = 1 * -drawPlayer.direction;
                    Texture2D texture = mod.GetTexture("Items/Equips/Hats/TrueCosmicConeEquipped");
                    Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction, drawPlayer.gfxOffY - 85 - secondyoffset);
                    Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                    Rectangle conesquare = texture.Frame(1, 6, 0, modPlayer.coneframe);
                    DrawData data = new DrawData(texture, wtf, conesquare, Color.White * alb, 0f, origin, 1, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0
                    )
                    {
                        shader = drawInfo.headArmorShader
                    };
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer BCarriage = new PlayerLayer("CalValEX", "BCarriage", PlayerLayer.Arms, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.carriage)
            {
                int flipoffset;
                int gnuflip = 56 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Mounts/Ground/BloodstoneCarriageWheel");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X + gnuflip);
                int drawX2 = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y + 16);
                DrawData data = new DrawData(texture, new Vector2(drawX + (drawPlayer.direction == 1 ? 6 : -8), drawY), null, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y - texture.Height / 2f) / 16f)), modPlayer.bcarriagewheel / 15.0f, new Vector2(texture.Width / 2f, texture.Height /2f), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                DrawData data2 = new DrawData(texture, new Vector2(drawX2 + (drawPlayer.direction == -1 ? -8 : 6), drawY), null, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y - texture.Height / 2f) / 16f)), modPlayer.bcarriagewheel / 15.0f, new Vector2(texture.Width / 2f, texture.Height /2f), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                Main.playerDrawData.Add(data);
                Main.playerDrawData.Add(data2);
            }
        });

        public static readonly PlayerLayer Mimigun = new PlayerLayer("CalValEX", "Mimigun", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.morshugun)
            {
                int gnuflip = 66 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Mounts/Morshu/Minigun");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y + 56);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y - 4f - texture.Height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer Mimigun2 = new PlayerLayer("CalValEX", "Mimigun2", PlayerLayer.Arms, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.morshugun)
            {
                int gnuflip = 36 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Mounts/Morshu/Minigun");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y + 56);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y - 4f - texture.Height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer Prismshell = new PlayerLayer("CalValEX", "Prismshell", PlayerLayer.BackAcc, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.prismshell)
            {
                int gnuflip = /*66 */ -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Equips/Backs/PrismShell");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip + (15 * gnuflip));
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y - 4 - secondyoffset/*+ 56*/);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0)
                {
                    shader = drawInfo.backShader
                };
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer Rotator = new PlayerLayer("CalValEX", "Rotator", PlayerLayer.MiscEffectsBack, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.exorb)
            {
                Texture2D texture = mod.GetTexture("Items/Equips/ExodiumMoon");
                Vector2 Circle = drawPlayer.Center + new Vector2(0, 300).RotatedBy(modPlayer.rotcounter);
                Vector2 draw = Circle - Main.screenPosition;
                Vector2 draw2 = Circle - Main.screenPosition;
                DrawData data = new DrawData(texture, draw, null, Color.White * alb, (float)modPlayer.rotsin, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0)
                {
                    shader = drawInfo.backShader
                };
                DrawData data2 = new DrawData(texture, draw2, null, Color.White * alb, (float)modPlayer.rotsin, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0)
                {
                    shader = drawInfo.frontShader
                };
                Main.playerDrawData.Add(data);
                Main.playerDrawData.Add(data2);
            }
        });

        public static readonly PlayerLayer Sexoballoon = new PlayerLayer("CalValEX", "Sexoballoon", PlayerLayer.BalloonAcc, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            int xflip = 0;
            xflip = (player.direction == -1 ? -40 : 0);
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            if (modPlayer.sartballoon)
            {
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Equips/Balloons/ArtemisBalloonSmallEquipped");
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction + 20 + xflip, drawPlayer.gfxOffY + 8- secondyoffset);
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 12, 0, modPlayer.stwinframe);
                DrawData data = new DrawData(texture, wtf, conesquare, Color.White * alb, 0f, origin, 1, player.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                )
                {
                    shader = drawInfo.balloonShader
                };
                Main.playerDrawData.Add(data);
            }
            if (modPlayer.sapballoon)
            {
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Equips/Balloons/ApolloBalloonSmallEquipped");
                texture = modPlayer.sapballoon ? mod.GetTexture("Items/Equips/Balloons/ApolloBalloonSmallEquipped") : mod.GetTexture("Items/Equips/Balloons/ArtemisBalloonSmallEquipped");
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction + 20 + xflip, drawPlayer.gfxOffY + 8- secondyoffset);
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 12, 0, modPlayer.stwinframe);
                DrawData data = new DrawData(texture, wtf, conesquare, Color.White * alb, 0f, origin, 1, player.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                )
                {
                    shader = drawInfo.balloonShader
                };
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer Exoballoon = new PlayerLayer("CalValEX", "Exoballoon", PlayerLayer.BalloonAcc, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            if (modPlayer.apballoon)
            {
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Equips/Balloons/ApolloBalloonEquipped");
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction + (40 * player.direction), drawPlayer.gfxOffY - 170 - secondyoffset);
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 5, 0, modPlayer.twinframe);
                DrawData data = new DrawData(texture, wtf, conesquare, Color.White * alb, 0f, origin, 1, player.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                )
                {
                    shader = drawInfo.balloonShader
                };
                Main.playerDrawData.Add(data);
            }
            else if (modPlayer.artballoon)
            {
                Texture2D texture = mod.GetTexture("Items/Equips/Balloons/ArtemisBalloonEquipped");
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction - (140 * player.direction), drawPlayer.gfxOffY - 170 - secondyoffset);
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 5, 0, modPlayer.twinframe);
                DrawData data = new DrawData(texture, wtf, conesquare, Color.White * alb, 0f, origin, 1, player.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                )
                {
                    shader = drawInfo.balloonShader
                };
                Main.playerDrawData.Add(data);
            }
            else if (modPlayer.twinballoon)
            {
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = mod.GetTexture("Items/Equips/Balloons/ArtemisBalloonEquipped");
                Texture2D texture2 = mod.GetTexture("Items/Equips/Balloons/ApolloBalloonEquipped");
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction - (140 * player.direction), drawPlayer.gfxOffY - 170 - secondyoffset);
                Vector2 wtf2 = drawPlayer.Center - Main.screenPosition + new Vector2(0f * player.direction + (40 * player.direction), drawPlayer.gfxOffY - 170 - secondyoffset);
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 5, 0, modPlayer.twinframe);
                DrawData data = new DrawData(texture, wtf, conesquare, Color.White * alb, 0f, origin, 1, player.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                )
                {
                    shader = drawInfo.balloonShader
                };
                DrawData data2 = new DrawData(texture2, wtf2, conesquare, Color.White * alb, 0f, origin, 1, player.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                )
                {
                    shader = drawInfo.balloonShader
                };
                Main.playerDrawData.Add(data);
                Main.playerDrawData.Add(data2);
            }
        });

        //Welcome to pong hell
        /*public static readonly PlayerLayer PongUI = new PlayerLayer("CalValEX", "PongUI", PlayerLayer.SolarShield, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            if (drawPlayer.controlMount)
            {
                modPlayer.pongactive = false;
            }
            if (modPlayer.pongactive)
            {
                //Stage logic
                if (modPlayer.pongstage == 0)
                {
                    if (drawPlayer.controlUseItem)
                    {
                        modPlayer.pongstage = 3;
                    }
                }

                Texture2D texture = mod.GetTexture("ExtraTextures/Pong/PongBG");
                int drawX = (int)(drawInfo.position.X + drawPlayer.width - Main.screenPosition.X);
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y);
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY + 200), null, Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0);
                Main.playerDrawData.Add(data);
            }
        });*/

        /*public static readonly PlayerLayer PongOverlay = new PlayerLayer("CalValEX", "PongOverlay", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();

            if (modPlayer.pongactive)
            {
                if (modPlayer.pongstage == 0)
                {
                    Texture2D texture = mod.GetTexture("ExtraTextures/Pong/PongInitialPrompt");
                    int drawX2 = (int)(drawInfo.position.X + drawPlayer.width - Main.screenPosition.X);
                    int drawY2 = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y);
                    DrawData data2 = new DrawData(texture, new Vector2(drawX2, drawY2 + 200), null, Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(data2);
                }
                else if (modPlayer.pongstage == 1)
                {
                    Texture2D texture = mod.GetTexture("ExtraTextures/Pong/PongLossPrompt");
                    int drawX2 = (int)(drawInfo.position.X + drawPlayer.width - Main.screenPosition.X);
                    int drawY2 = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y);
                    DrawData data2 = new DrawData(texture, new Vector2(drawX2, drawY2 + 200), null, Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(data2);
                }
                else if (modPlayer.pongstage == 2)
                {
                    Texture2D texture = mod.GetTexture("ExtraTextures/Pong/PongWinPrompt");
                    int drawX2 = (int)(drawInfo.position.X + drawPlayer.width - Main.screenPosition.X);
                    int drawY2 = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y);
                    DrawData data2 = new DrawData(texture, new Vector2(drawX2, drawY2 + 200), null, Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(data2);
                }
                else
                {

                    Texture2D texture = mod.GetTexture("ExtraTextures/Pong/InnerBarriers");
                    int drawX2 = (int)(drawInfo.position.X + drawPlayer.width - Main.screenPosition.X);
                    int drawY2 = (int)(drawInfo.position.Y + drawPlayer.height - Main.screenPosition.Y);
                    DrawData data2 = new DrawData(texture, new Vector2(drawX2, drawY2 + 200), null, Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(data2);
                    bool anahitaspawned = drawPlayer.ownedProjectileCounts[ProjectileType<Projectiles.Pong.PlayerSlider>()] <= 0;
                    if (anahitaspawned && drawPlayer.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(drawPlayer.position.X + drawPlayer.width / 2 - 80, drawPlayer.position.Y + drawPlayer.height / 2 - 40,
                            0f, 0f, ProjectileType<Projectiles.Pong.PlayerSlider>(), 0, 0f, drawPlayer.whoAmI);
                    }
                    bool ballspawned = drawPlayer.ownedProjectileCounts[ProjectileType<Projectiles.Pong.PongBall>()] <= 0;
                    if (anahitaspawned && drawPlayer.whoAmI == Main.myPlayer)
                    {
                        Projectile.NewProjectile(drawPlayer.position.X + drawPlayer.width / 2 + 180, drawPlayer.position.Y + drawPlayer.height / 2 - 40,
                            -4f, 4f, ProjectileType<Projectiles.Pong.PongBall>(), 0, 0f, drawPlayer.whoAmI);
                    }
                    for (int x = 0; x < Main.maxProjectiles; x++)
                    {
                        Projectile projectile = Main.projectile[x];
                        if (projectile.type == ProjectileType<Projectiles.Pong.PongBall>())
                        {
                            modPlayer.pongballposx = projectile.position.X;
                            modPlayer.pongballposy = projectile.position.Y;
                        }
                    }
                    for (int x = 0; x < Main.maxProjectiles; x++)
                    {
                        Projectile projectile = Main.projectile[x];
                        if (projectile.type == ProjectileType<Projectiles.Pong.PlayerSlider>())
                        {
                            modPlayer.sliderposx = projectile.position.X;
                            modPlayer.sliderposy = projectile.position.Y;
                        }
                    }

                    Vector2 pball;
                    pball.X = modPlayer.pongballposx;
                    pball.Y = modPlayer.pongballposy;

                    Vector2 slider;
                    slider.X = modPlayer.sliderposx;
                    slider.Y = modPlayer.sliderposy;

                    Texture2D textureball = mod.GetTexture("ExtraTextures/Pong/PongBall");
                    int drawXde2 = (int)(modPlayer.pongballposx + 36 - Main.screenPosition.X);
                    int drawYde2 = (int)(modPlayer.pongballposy + 36 - Main.screenPosition.Y);
                    DrawData datae2 = new DrawData(textureball, new Vector2(drawXde2, drawYde2), null, Color.White, 0f, new Vector2(textureball.Width / 2f, textureball.Height), 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(datae2);



                    Texture2D textureslider = mod.GetTexture("ExtraTextures/Pong/PongSlider");
                    int drawXd2 = (int)(modPlayer.sliderposx + 25 - Main.screenPosition.X);
                    int drawYd2 = (int)(modPlayer.sliderposy + 78 - Main.screenPosition.Y);
                    DrawData datad2 = new DrawData(textureslider, new Vector2(drawXd2, drawYd2 + 200), null, Color.White, 0f, new Vector2(textureslider.Width / 2f, textureslider.Height), 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(datad2);


                }
            }
        });*/

        public static readonly PlayerLayer Chopper = new PlayerLayer("CalValEX", "Chopper", PlayerLayer.Wings, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            Player player = Main.LocalPlayer;
            if (modPlayer.wulfrumjam)
            {
                    int winflip = 1 * -drawPlayer.direction;
                    Texture2D texture = mod.GetTexture("Items/Equips/Wings/WulfrumHelipackMalfunction");
                    Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f - 10 * player.direction, drawPlayer.gfxOffY - 2);
                //DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y - 4f - texture.Height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 9f);
                    //float wulfrumframe = 8f / 8;
                    //int wulfheight = (int)((float)(framecounter / texture.Height) * wulfrumframe) * (texture.Height / 8);
                    Rectangle wulfsquare = texture.Frame(1, 9, 0, modPlayer.chopperframe);
                    DrawData data = new DrawData(texture, wtf, wulfsquare, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y - 4f - texture.Height / 2f) / 16f)), 0f, origin, 1, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0
                    )
                    {
                        shader = drawInfo.wingShader
                    }; 

                /*spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), wulfsquare, hive2alpha, npc.rotation, Utils.Size(wulfsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                return false;*/


                Main.playerDrawData.Add(data);
                }
        });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int headLayer = layers.FindIndex(l => l == PlayerLayer.Head);
            int bodyLayer = layers.FindIndex(l => l == PlayerLayer.Body);
            int armLayer = layers.FindIndex(l => l == PlayerLayer.Arms);
            int wingLayer = layers.FindIndex(l => l == PlayerLayer.Wings);
            int backLayer = layers.FindIndex(l => l == PlayerLayer.BackAcc);
            int carriageLayer = layers.FindIndex(l => l == PlayerLayer.MountFront);
            int shieldLaer = layers.FindIndex(l => l == PlayerLayer.SolarShield);
            int highLaer = layers.FindIndex(l => l == PlayerLayer.MiscEffectsFront);
            int hairLayer = layers.FindIndex(l => l == PlayerLayer.Hair);
            int ballLayer = layers.FindIndex(l => l == PlayerLayer.BalloonAcc);
            int waybackLayer = layers.FindIndex(l => l == PlayerLayer.MiscEffectsBack);

            if (headLayer > -1)
            {
                layers.Insert(headLayer + 1, DraedonHelmet);
            }

            if (bodyLayer > -1)
            {
                layers.Insert(bodyLayer + 1, DraedonChestplate);
            }

            if (wingLayer > -1)
            {
                layers.Insert(wingLayer + 1, Chopper);
            }
            Head.visible = true;
            layers.Insert(headLayer + 1, Head);
            HeadFront.visible = true;
            layers.Insert(headLayer + 4, HeadFront);
            Mimigun.visible = true;
            layers.Insert(headLayer + 2, Mimigun);
            Mimigun2.visible = true;
            layers.Insert(armLayer + 1, Mimigun2);
            Prismshell.visible = true;
            layers.Insert(backLayer + 1, Prismshell);
            Prismshell.visible = true;
            layers.Insert(backLayer + 2, Rotator);
            BCarriage.visible = true;
            layers.Insert(armLayer + 1, BCarriage);
            Exoballoon.visible = true;
            layers.Insert(ballLayer + 2, Exoballoon);
            Sexoballoon.visible = true;
            layers.Insert(waybackLayer + 3, Sexoballoon);
            if (yharcar)
            {
                foreach (PlayerLayer layer in layers)
                {
                    if (layer != PlayerLayer.MountBack && layer != PlayerLayer.MountFront && layer != PlayerLayer.MiscEffectsFront && layer != PlayerLayer.MiscEffectsBack)
                    {
                        ((DrawLayer<PlayerDrawInfo>)(object)layer).visible = false;
                    }
                }
            }
            if (pongactive)
            {
                foreach (PlayerLayer layer in layers)
                {
                    ((DrawLayer<PlayerDrawInfo>)(object)layer).visible = false;
                }
            }
            else
            {
                foreach (PlayerLayer layer in layers)
                {
                    ((DrawLayer<PlayerDrawInfo>)(object)layer).visible = true;
                }
            }
            /*PongUI.visible = true;
            layers.Insert(shieldLaer + 14, PongUI);
            PongOverlay.visible = true;
            layers.Insert(highLaer + 15, PongOverlay);*/
        }

        public override void ModifyDrawHeadLayers(List<PlayerHeadLayer> layers)
        {
            int headLayer = layers.FindIndex(l => l == PlayerHeadLayer.Armor);

            if (headLayer > -1)
            {
                layers.Insert(headLayer + 1, HeadDraedonHelmet);
            }
        }

        public override void
            ModifyDrawInfo(ref PlayerDrawInfo drawInfo) //i just really dont want to fix the sprite issues.
        {
            if (drawInfo.drawPlayer.legs == mod.GetEquipSlot("DraedonLeggings", EquipType.Legs))
            {
                drawInfo.legColor = Color.Transparent;
                drawInfo.legGlowMaskColor = Color.Transparent;
                drawInfo.pantsColor = Color.Transparent;
            }

            if (drawInfo.drawPlayer.body == mod.GetEquipSlot("DraedonChestplate", EquipType.Body))
            {
                drawInfo.armGlowMaskColor = Color.Transparent;
                drawInfo.bodyColor = Color.Transparent;
                drawInfo.bodyGlowMaskColor = Color.Transparent;
                drawInfo.shirtColor = Color.Transparent;
                drawInfo.underShirtColor = Color.Transparent;
            }

            if (drawInfo.drawPlayer.head == mod.GetEquipSlot("DraedonHelmet", EquipType.Head))
            {
                drawInfo.eyeColor = Color.Transparent;
                drawInfo.eyeWhiteColor = Color.Transparent;
                drawInfo.faceColor = Color.Transparent;
                drawInfo.hairColor = Color.Transparent;
                drawInfo.headGlowMaskColor = Color.Transparent;
            }
        }
        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneAstral)
            {
                return ModContent.GetTexture("CalValEX/Backgrounds/AstralMap");
            }
            return null;
        }
    }
}
