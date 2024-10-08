using System.Collections.Generic;
using badgatchagame.Content.Items;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

// i know
// i hate myself too

namespace badgatchagame.Content.Randomisation
{
    public class RandomItemsLists : ModSystem
    {
        public static readonly List<int> randomItemsPreboss = [
            // ModContent.ItemType<TROLOLOLOL>(), i'm not that mean :)

            ItemID.CopperShortsword,
            ItemID.TinShortsword,
            ItemID.IronShortsword,
            ItemID.LeadShortsword,
            ItemID.SilverShortsword,
            ItemID.TungstenShortsword,
            ItemID.GoldShortsword,
            ItemID.PlatinumShortsword,
            ItemID.WoodenSword,
            ItemID.WoodenBow,
            ItemID.WoodenBoomerang,
            ItemID.WoodYoyo,
            ItemID.AbigailsFlower,
            ItemID.JungleYoyo,
            ItemID.AmberStaff,
            ItemID.AmethystStaff,
            ItemID.AshWoodBow,
            ItemID.AshWoodSword,
            ItemID.BatBat,
            ItemID.BladeofGrass,
            ItemID.BladedGlove,
            ItemID.BloodRainBow,
            ItemID.BloodyMachete,
            ItemID.Blowpipe,
            ItemID.BoneSword,
            ItemID.Boomstick,
            ItemID.BorealWoodBow,
            ItemID.BorealWoodSword,
            ItemID.BreathingReed,
            ItemID.CactusSword,
            ItemID.CandyCaneSword,
            ItemID.ChainKnife,
            ItemID.CopperBow,
            ItemID.CopperBroadsword,
            ItemID.DemonScythe,
            ItemID.DiamondStaff,
            ItemID.EmeraldStaff,
            ItemID.EnchantedBoomerang,
            ItemID.EnchantedSword,
            ItemID.DyeTradersScimitar,
            ItemID.FalconBlade,
            ItemID.BabyBirdStaff,
            ItemID.FlamingMace,
            ItemID.FlareGun,
            ItemID.FlintlockPistol,
            ItemID.FlinxStaff,
            ItemID.Flymeal,
            ItemID.FruitcakeChakram,
            ItemID.Gladius,
            ItemID.GoldBow,
            ItemID.GoldBroadsword,
            ItemID.Harpoon,
            ItemID.IceBlade,
            ItemID.IceBoomerang,
            ItemID.IronBow,
            ItemID.IronBroadsword,
            ItemID.Katana,
            ItemID.LeadBow,
            ItemID.LeadBroadsword,
            ItemID.BlandWhip,
            ItemID.Mace,
            ItemID.AntlionClaw,
            ItemID.Minishark,
            ItemID.PainterPaintballGun,
            ItemID.PalmWoodBow,
            ItemID.PalmWoodSword,
            ItemID.PlatinumBow,
            ItemID.PlatinumBroadsword,
            ItemID.PurpleClubberfish,
            ItemID.Rally,
            ItemID.RedRyder,
            ItemID.Revolver,
            ItemID.RichMahoganyBow,
            ItemID.RichMahoganySword,
            ItemID.Ruler,
            ItemID.Sandgun,
            ItemID.SapphireStaff,
            ItemID.Shroomerang,
            ItemID.SilverBow,
            ItemID.SilverBroadsword,
            ItemID.SlimeStaff,
            ItemID.ThornWhip,
            ItemID.SnowballCannon,
            ItemID.Spear,
            ItemID.Starfury,
            ItemID.ThunderSpear,
            ItemID.StylistKilLaKillScissorsIWish,
            ItemID.Swordfish,
            ItemID.TentacleSpike,
            ItemID.Terragrim,
            ItemID.ThornChakram,
            ItemID.ThunderStaff,
            ItemID.TinBow,
            ItemID.TinBroadsword,
            ItemID.TopazStaff,
            ItemID.Trident,
            ItemID.Trimarang,
            ItemID.TungstenBow,
            ItemID.TungstenBroadsword,
            ItemID.Umbrella,
            ItemID.VampireFrogStaff,
            ItemID.WandofFrosting,
            ItemID.WandofSparking,
            ItemID.ZombieArm,
            ItemID.Sickle,
        ];

        public static readonly List<int>randomItemsPreBossCorruption = [
            ItemID.CorruptYoyo,
            ItemID.Musket,
            ItemID.Vilethorn,
            ItemID.LightsBane,
            ItemID.BallOHurt,
            ItemID.DemonBow,
            ItemID.EbonwoodBow,
            ItemID.EbonwoodSword,
        ];

        public static readonly List<int>randomItemsPreBossCrimson = [
            ItemID.TheRottedFork,
            ItemID.TheUndertaker,
            ItemID.CrimsonYoyo,
            ItemID.BloodButcherer,
            ItemID.TendonBow,
            ItemID.CrimsonRod,
            ItemID.ShadewoodBow,
            ItemID.ShadewoodSword,
        ];

        public static readonly List<int> randomItemsPostEOC = [
            ItemID.ZapinatorGray,
            ItemID.Code1,
        ];

        public static readonly List<int> randomItemsPostEvil = [
            ItemID.Flamarang,
            ItemID.ImpStaff,
            ItemID.FieryGreatsword,
            ItemID.MoltenFury,
        ];

        public static readonly List<int> randomItemsPostUnconsiousMan = [
            ItemID.AleThrowingGlove,
        ];

        public static readonly List<int> randomItemsPostMeteorite = [
            ItemID.RedPhaseblade,
            ItemID.BluePhaseblade,
            ItemID.GreenPhaseblade,
            ItemID.WhitePhaseblade,
            ItemID.PurplePhaseblade,
            ItemID.OrangePhaseblade,
            ItemID.YellowPhaseblade,
            ItemID.SpaceGun,
            ItemID.StarCannon,
        ];

        public static readonly List<int> randomItemsPostBoC = [
            ItemID.TheMeatball,
        ];

        public static readonly List<int> randomItemsPostDeerclops = [
            ItemID.HoundiusShootius,
            ItemID.PewMaticHorn,
            ItemID.WeatherPain,
        ];

        public static readonly List<int> randomItemsPostQueenBee = [
            ItemID.BeeGun,
            ItemID.BeeKeeper,
            ItemID.Blowgun,
            ItemID.HiveFive,
            ItemID.HornetStaff,
            ItemID.BeesKnees,
        ];

        public static readonly List<int> randomItemsPostSkeletron = [
            ItemID.AquaScepter,
            ItemID.BlueMoon,
            ItemID.BookofSkulls,
            ItemID.Cascade,
            ItemID.CombatWrench,
            ItemID.DarkLance,
            ItemID.Flamelash,
            ItemID.FlowerofFire,
            ItemID.Handgun,
            ItemID.HellwingBow,
            ItemID.MagicMissile,
            ItemID.Muramasa,
            ItemID.NightsEdge,
            ItemID.PhoenixBlaster,
            ItemID.QuadBarrelShotgun,
            ItemID.BoneWhip,
            ItemID.Sunfury,
            ItemID.Valor,
            ItemID.WaterBolt,
        ];

        public static readonly List<int> randomItemsHardmode = [
            ItemID.AdamantiteGlaive,
            ItemID.AdamantiteRepeater,
            ItemID.AdamantiteSword,
            ItemID.Amarok,
            ItemID.Anchor,
            ItemID.Bananarang,
            ItemID.BeamSword,
            ItemID.SharpTears,
            ItemID.BreakerBlade,
            ItemID.Chik,
            ItemID.TaxCollectorsStickOfDoom,
            ItemID.ClockworkAssaultRifle,
            ItemID.CobaltNaginata,
            ItemID.CobaltRepeater,
            ItemID.CobaltSword,
            ItemID.CoinGun,
            ItemID.CoolWhip,
            ItemID.CrystalSerpent,
            ItemID.CrystalStorm,
            ItemID.CrystalVileShard,
            ItemID.Cutlass,
            ItemID.DaedalusStormbow,
            ItemID.DaoofPow,
            ItemID.DripplerFlail,
            ItemID.FireWhip,
            ItemID.FlowerofFrost,
            ItemID.FlyingKnife,
            ItemID.FormatC,
            ItemID.FrostStaff,
            ItemID.Frostbrand,
            ItemID.Gatligator,
            ItemID.Gradient,
            ItemID.HamBat,
            ItemID.HelFire,
            ItemID.IceBow,
            ItemID.IceRod,
            ItemID.IceSickle,
            ItemID.JoustingLance,
            ItemID.KOCannon,
            ItemID.LaserRifle,
            ItemID.MagicDagger,
            ItemID.Marrow,
            ItemID.MedusaHead,
            ItemID.MythrilHalberd,
            ItemID.MythrilRepeater,
            ItemID.MythrilSword,
            ItemID.NimbusRod,
            ItemID.ObsidianSwordfish,
            ItemID.OnyxBlaster,
            ItemID.ZapinatorOrange,
            ItemID.OrichalcumHalberd,
            ItemID.OrichalcumRepeater,
            ItemID.OrichalcumSword,
            ItemID.PalladiumPike,
            ItemID.PalladiumSword,
            ItemID.PearlwoodBow,
            ItemID.PearlwoodSword,
            ItemID.PirateStaff,
            ItemID.PoisonStaff,
            ItemID.QueenSpiderStaff,
            ItemID.SanguineStaff,
            ItemID.BouncingShield,
            ItemID.ShadowFlameBow,
            ItemID.ShadowFlameHexDoll,
            ItemID.ShadowFlameKnife,
            ItemID.Shotgun,
            ItemID.SkyFracture,
            ItemID.SlapHand,
            ItemID.SpiderStaff,
            ItemID.SpiritFlame,
            ItemID.TitaniumRepeater,
            ItemID.TitaniumSword,
            ItemID.TitaniumTrident,
            ItemID.Uzi
        ];

        public static readonly List<int> randomItemsHardmodeMeteorite = [
            ItemID.RedPhasesaber,
            ItemID.BluePhasesaber,
            ItemID.GreenPhasesaber,
            ItemID.WhitePhasesaber,
            ItemID.PurplePhasesaber,
            ItemID.OrangePhasesaber,
            ItemID.YellowPhasesaber,
            ItemID.MeteorStaff,
        ];

        public static readonly List<int> randomItemsHardmodeCorruption = [
            ItemID.ClingerStaff,
            ItemID.DartRifle,
            ItemID.ChainGuillotines,
            ItemID.CursedFlames,
            ItemID.Toxikarp,
        ];

        public static readonly List<int> randomItemsHardmodeCrimson = [
            ItemID.FetidBaghnakhs,
            ItemID.DartPistol,
            ItemID.SoulDrain,
            ItemID.GoldenShower,
            ItemID.Bladetongue,
        ];

        public static readonly List<int> randomItemsPostQueenSlime = [
            ItemID.Smolstar,
        ];

        public static readonly List<int> randomItemsPostAnyHardmodeBoss = [
            ItemID.Arkhalis,
            ItemID.RedsYoyo,
            ItemID.ValkyrieYoyo,
        ];

        public static readonly List<int> randomItemsPostMech = [
            ItemID.Code2,
            ItemID.Excalibur,
            ItemID.SwordWhip,
            ItemID.Gungnir,
            ItemID.HallowJoustingLance,
            ItemID.HallowedRepeater,
            ItemID.SuperStarCannon,
            ItemID.Yelets,
            ItemID.UnholyTrident,
            ItemID.MushroomSpear,
        ];

        public static readonly List<int> randomItemsPostMechEye = [
            ItemID.MagicalHarp,
            ItemID.OpticStaff,
            ItemID.RainbowRod,
        ];

        public static readonly List<int> randomItemsPostMechSkeletron = [
            ItemID.Flamethrower,
        ];

        public static readonly List<int> randomItemsPostMechWorm = [
            ItemID.Megashark,
            ItemID.LightDisc,
        ];

        public static readonly List<int> randomItemsPrePlantera = [
            ItemID.ChlorophyteClaymore,
            ItemID.ChlorophytePartisan,
            ItemID.ChlorophyteSaber,
            ItemID.ChlorophyteShotbow,
            ItemID.DeathSickle,
            ItemID.PulseBow,
            ItemID.TrueExcalibur,
            ItemID.TrueNightsEdge,
            ItemID.WaffleIron,
        ];

        public static readonly List<int> randomItemsPostPlantera = [
            ItemID.DeadlySphereStaff,
            ItemID.StormTigerStaff,
            ItemID.FlowerPow,
            ItemID.GrenadeLauncher,
            ItemID.InfernoFork,
            ItemID.Keybrand,
            ItemID.Kraken,
            ItemID.LeafBlower,
            ItemID.MagnetSphere,
            ItemID.MaceWhip,
            ItemID.NailGun,
            ItemID.NettleBurst,
            ItemID.PaladinsHammer,
            ItemID.PiranhaGun,
            ItemID.ProximityMineLauncher,
            ItemID.PsychoKnife,
            ItemID.PygmyStaff,
            ItemID.RainbowGun,
            ItemID.PrincessWeapon,
            ItemID.RocketLauncher,
            ItemID.Seedler,
            ItemID.ShadowJoustingLance,
            ItemID.ShadowbeamStaff,
            ItemID.SniperRifle,
            ItemID.SpectreStaff,
            ItemID.StaffoftheFrostHydra,
            ItemID.StakeLauncher,
            ItemID.TacticalShotgun,
            ItemID.TerraBlade,
            ItemID.TheEyeOfCthulhu,
            ItemID.ToxicFlask,
            ItemID.VenusMagnum,
            ItemID.WaspGun,
        ];

        public static readonly List<int> randomItemsPostPlanteraCorruption = [
            ItemID.ScourgeoftheCorruptor,
        ];

        public static readonly List<int> randomItemsPostPlanteraCrimson = [
            ItemID.VampireKnives,
        ];


        public static readonly List<int> randomItemsPostFrost = [
            ItemID.BlizzardStaff,
            ItemID.ChainGun,
            ItemID.ChristmasTreeSword,
            ItemID.ElfMelter,
            ItemID.NorthPole,
            ItemID.Razorpine,
            ItemID.SnowmanCannon,
        ];

        public static readonly List<int> randomItemsPostPumpkin = [
            ItemID.BatScepter,
            ItemID.CandyCornRifle,
            ItemID.ScytheWhip,
            ItemID.JackOLanternLauncher,
            ItemID.RavenStaff,
            ItemID.TheHorsemansBlade,
        ];
        
        public static readonly List<int> randomItemsPostFish = [
            ItemID.BubbleGun,
            ItemID.Flairon,
            ItemID.RazorbladeTyphoon,
            ItemID.TempestStaff,
            ItemID.Tsunami,
        ];

        public static readonly List<int> randomItemsPostEmpress = [
            ItemID.FairyQueenRangedItem,
            ItemID.RainbowWhip,
            ItemID.FairyQueenMagicItem,
            ItemID.PiercingStarlight,
            ItemID.SparkleGuitar,
            ItemID.EmpressBlade,
        ];
        
        public static readonly List<int> randomItemsPreLunarCultist = [
            ItemID.FireworksLauncher,
            ItemID.GolemFist,
            ItemID.HeatRay,
            ItemID.PossessedHatchet,
            ItemID.StaffofEarth,
            ItemID.Stynger,
        ];

        public static readonly List<int> randomItemsPostMartians = [
            ItemID.ChargedBlasterCannon,
            ItemID.ElectrosphereLauncher,
            ItemID.InfluxWaver,
            ItemID.LaserMachinegun,
            ItemID.XenoStaff,
            ItemID.Xenopopper,
        ];

        public static readonly List<int> randomItemsPostSolar = [
            ItemID.DayBreak,
            ItemID.SolarEruption,
        ];

        public static readonly List<int> randomItemsPostNebula = [
            ItemID.NebulaArcanum,
            ItemID.NebulaBlaze,
        ];

        public static readonly List<int> randomItemsPostStardust = [
            ItemID.StardustCellStaff,
            ItemID.StardustDragonStaff,
        ];

        public static readonly List<int> randomItemsPostVortex = [
            ItemID.VortexBeater,
            ItemID.Phantasm,
        ];

        public static readonly List<int> randomItemsPostMoonMan = [
            ItemID.Celeb2,
            ItemID.LastPrism,
            ItemID.LunarFlareBook,
            ItemID.MoonlordTurretStaff,
            ItemID.Meowmere,
            ItemID.RainbowCrystalStaff,
            ItemID.SDMG,
            ItemID.StarWrath,
            ItemID.Terrarian,
            ItemID.Zenith
        ];

        public static readonly List<int> randomitemsPostDD2T2 = [
            ItemID.BookStaff,
            ItemID.MonkStaffT1,
            ItemID.MonkStaffT2,
            ItemID.DD2PhoenixBow,
            ItemID.DD2SquireDemonSword,
        ];

        public static readonly List<int> randomitemsPostDD2T3 = [
            ItemID.DD2BetsyBow,
            ItemID.DD2SquireBetsySword,
            ItemID.MonkStaffT3,
            ItemID.ApprenticeStaffT3,
        ];

        public static readonly List<int> randomItemsDebug = [
            // ItemID.Bass,
        ];
        
        public static List<int> getCurrentProgressionList() { // fuck you i dont care about naming conventions imma do it ma own way
            List<int> returnList = [];
            if (Main.hardMode) {
                returnList.AddRange(randomItemsHardmode);
                if (SpawnCondition.Meteor.Active) { returnList.AddRange(randomItemsHardmodeMeteorite); }
                if (WorldGen.crimson) { returnList.AddRange(randomItemsHardmodeCrimson); } else {returnList.AddRange(randomItemsHardmodeCorruption);}
                if (NPC.downedQueenSlime) { returnList.AddRange(randomItemsPostQueenSlime); }
                if (NPC.downedMechBossAny) { returnList.AddRange(randomItemsPostMech); }
                if (NPC.downedMechBossAny || NPC.downedQueenSlime) { returnList.AddRange(randomItemsPostAnyHardmodeBoss);}
                if (NPC.downedMechBoss1) { returnList.AddRange(randomItemsPostMechWorm); }
                if (NPC.downedMechBoss2) { returnList.AddRange(randomItemsPostMechEye); }
                if (NPC.downedMechBoss3) { returnList.AddRange(randomItemsPostMechSkeletron); }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) { returnList.AddRange(randomItemsPrePlantera); }
                if (NPC.downedPlantBoss) { returnList.AddRange(randomItemsPostPlantera); }
                if (NPC.downedPlantBoss && WorldGen.crimson) { returnList.AddRange(randomItemsPostPlanteraCrimson); }
                else if (NPC.downedPlantBoss && !WorldGen.crimson) { returnList.AddRange(randomItemsPostPlanteraCorruption); }
                if (NPC.downedChristmasIceQueen) { returnList.AddRange(randomItemsPostFrost); }
                if (NPC.downedHalloweenKing) { returnList.AddRange(randomItemsPostPumpkin); }
                if (NPC.downedFishron) { returnList.AddRange(randomItemsPostFish); }
                if (NPC.downedEmpressOfLight) { returnList.AddRange(randomItemsPostEmpress); }
                if (NPC.downedGolemBoss) { returnList.AddRange(randomItemsPreLunarCultist); }
                if (NPC.downedMartians) { returnList.AddRange(randomItemsPostMartians); }

                if (NPC.downedTowerSolar) { returnList.AddRange(randomItemsPostSolar); }
                if (NPC.downedTowerVortex) { returnList.AddRange(randomItemsPostVortex); }
                if (NPC.downedTowerStardust) { returnList.AddRange(randomItemsPostStardust); }
                if (NPC.downedTowerNebula) { returnList.AddRange(randomItemsPostNebula); }
                if (NPC.downedMoonlord) { returnList.AddRange(randomItemsPostMoonMan); }
                if (DD2Event.DownedInvasionT2) { returnList.AddRange(randomitemsPostDD2T2); }
                if (DD2Event.DownedInvasionT3) { returnList.AddRange(randomitemsPostDD2T3); }
            } else {
                returnList.AddRange(randomItemsPreboss);
                if (NPC.downedBoss1) { returnList.AddRange(randomItemsPostEOC); }
                if (WorldGen.crimson) { returnList.AddRange(randomItemsPreBossCrimson); } else {returnList.AddRange(randomItemsPreBossCorruption);}
                if (NPC.downedBoss2) { returnList.AddRange(randomItemsPostEvil); }
                if (NPC.downedBoss2 && WorldGen.crimson) { returnList.AddRange(randomItemsPostBoC); }
                if (SpawnCondition.Meteor.Active) { returnList.AddRange(randomItemsPostMeteorite); } // this is seperate because i might only make it available once a meteorite has landed.
                if (NPC.savedBartender) { returnList.AddRange(randomItemsPostUnconsiousMan); }
                if (NPC.downedDeerclops) { returnList.AddRange(randomItemsPostDeerclops); }
                if (NPC.downedQueenBee) { returnList.AddRange(randomItemsPostQueenBee); }
                if (NPC.downedBoss3) { returnList.AddRange(randomItemsPostSkeletron); }
            }
            return returnList;
        }

        public static Item getAccompanyingItemIfExists(int mainItem) {
            Item MainItem = new(mainItem);
            if (MainItem.useAmmo != AmmoID.None || MainItem.useAmmo > 0) { // i am sorry switch statement lovers
                Item newitem = null;
                int quantity = 250;
                if (MainItem.useAmmo == AmmoID.Bullet && !NPC.savedWizard) newitem = new Item(ItemID.MusketBall);
                else if (MainItem.useAmmo == AmmoID.Arrow && !NPC.savedWizard) newitem = new Item(ItemID.WoodenArrow);
                else if (MainItem.useAmmo == AmmoID.Gel) newitem = new Item(ItemID.Gel);
                else if (MainItem.useAmmo == AmmoID.FallenStar) {quantity = 100; newitem = new Item(ItemID.FallenStar);}
                else if (MainItem.useAmmo == AmmoID.Sand) newitem = new Item(ItemID.SandBlock);
                else if (MainItem.useAmmo == AmmoID.CandyCorn) newitem = new Item(ItemID.CandyCorn);
                else if (MainItem.useAmmo == AmmoID.Snowball) newitem = new Item(ItemID.Snowball);
                else if (MainItem.useAmmo == AmmoID.Flare) newitem = new Item(ItemID.Flare);
                else if (MainItem.useAmmo == AmmoID.JackOLantern) newitem = new Item(ItemID.ExplosiveJackOLantern);
                else if (MainItem.useAmmo == AmmoID.Rocket) newitem = new Item(ItemID.RocketI);
                else if (MainItem.useAmmo == AmmoID.NailFriendly) newitem = new Item(ItemID.Nail);
                else if (MainItem.useAmmo == AmmoID.Dart) newitem = new Item(ItemID.Seed);
                else if (MainItem.useAmmo == AmmoID.StyngerBolt) newitem = new Item(ItemID.Stynger);
                else if (MainItem.useAmmo == AmmoID.Stake) newitem = new Item(ItemID.Stake);
                if (newitem != null) {
                    newitem.stack = quantity;
                    return newitem;
                }
            }
            int rand;
            switch (mainItem) {
                case ItemID.AbigailsFlower:
                case ItemID.BabyBirdStaff:
                case ItemID.SlimeStaff:
                case ItemID.FlinxStaff:
                    return new Item(ItemID.BlandWhip);

                case ItemID.VampireFrogStaff:
                case ItemID.HornetStaff:
                case ItemID.HoundiusShootius:
                    return new Item(ItemID.ThornWhip);

                case ItemID.ImpStaff:
                    return new Item(ItemID.BoneWhip);

                case ItemID.SpiderStaff:
                case ItemID.PirateStaff:
                case ItemID.QueenSpiderStaff:
                    return new Item(ItemID.FireWhip);

                case ItemID.Smolstar:
                case ItemID.SanguineStaff:
                    return new Item(ItemID.CoolWhip);

                case ItemID.OpticStaff:
                case ItemID.PygmyStaff:
                    return new Item(ItemID.SwordWhip);

                case ItemID.DeadlySphereStaff:
                case ItemID.RavenStaff:
                case ItemID.StaffoftheFrostHydra:
                    return new Item(ItemID.ScytheWhip);

                case ItemID.StormTigerStaff:
                case ItemID.XenoStaff:
                case ItemID.TempestStaff:
                    return new Item(ItemID.MaceWhip);

                case ItemID.StardustDragonStaff:
                case ItemID.StardustCellStaff:
                case ItemID.EmpressBlade:
                case ItemID.MoonlordTurretStaff:
                case ItemID.RainbowCrystalStaff:
                    return new Item(ItemID.RainbowWhip);

                case ItemID.BlandWhip:
                    rand = Main.rand.Next(3);
                    return rand == 0 ? new Item(ItemID.FlinxStaff) : rand == 1 ? new Item(ItemID.SlimeStaff) : rand == 2 ? new Item(ItemID.AbigailsFlower) : new Item(ItemID.BabyBirdStaff);
                case ItemID.ThornWhip:
                    rand = Main.rand.Next(1);
                    return rand == 0 ? new Item(ItemID.VampireFrogStaff) : new Item(ItemID.HornetStaff);
                case ItemID.BoneWhip:
                    return new Item(ItemID.ImpStaff);
                case ItemID.FireWhip:
                    rand = Main.rand.Next(1);
                    return rand == 0 ? new Item(ItemID.SpiderStaff) : new Item(ItemID.PirateStaff);
                case ItemID.CoolWhip:
                    rand = Main.rand.Next(1);
                    return rand == 0 ? new Item(ItemID.SanguineStaff) : new Item(ItemID.Smolstar);
                case ItemID.SwordWhip:
                    rand = Main.rand.Next(1);
                    return rand == 0 ? new Item(ItemID.OpticStaff) : new Item(ItemID.PygmyStaff);
                case ItemID.ScytheWhip:
                    rand = Main.rand.Next(1);
                    return rand == 0 ? new Item(ItemID.DeadlySphereBanner) : new Item(ItemID.RavenStaff);
                case ItemID.MaceWhip:
                    rand = Main.rand.Next(2);
                    return rand == 0 ? new Item(ItemID.StormTigerStaff) : rand == 1 ? new Item(ItemID.XenoStaff) : new Item(ItemID.TempestStaff);
                case ItemID.RainbowWhip:
                    return new Item(ItemID.EmpressBlade);
            }
            return new Item(0);
        }

        public static List<int> getAllRandomItems() {
            List<int> returnList =
            [
                .. randomItemsPreboss,
                .. randomItemsPreBossCorruption,
                .. randomItemsPreBossCrimson,
                .. randomItemsPostEOC,
                .. randomItemsPostEvil,
                .. randomItemsPostMeteorite,
                .. randomItemsPostUnconsiousMan,
                .. randomItemsPostBoC,
                .. randomItemsPostDeerclops,
                .. randomItemsPostQueenBee,
                .. randomItemsPostSkeletron,
                .. randomItemsHardmode,
                .. randomItemsHardmodeMeteorite,
                .. randomItemsHardmodeCrimson,
                .. randomItemsHardmodeCorruption,
                .. randomItemsPostAnyHardmodeBoss,
                .. randomItemsPostQueenSlime,
                .. randomItemsPostMech,
                .. randomItemsPostMechEye,
                .. randomItemsPostMechWorm,
                .. randomItemsPostMechSkeletron,
                .. randomItemsPrePlantera,
                .. randomItemsPostPlantera,
                .. randomItemsPostPlanteraCorruption,
                .. randomItemsPostPlanteraCrimson,
                .. randomItemsPostFrost,
                .. randomItemsPostPumpkin,
                .. randomItemsPostFish,
                .. randomItemsPostEmpress,
                .. randomItemsPreLunarCultist,
                .. randomItemsPostMartians,
                .. randomItemsPostSolar,
                .. randomItemsPostVortex,
                .. randomItemsPostStardust,
                .. randomItemsPostNebula,
                .. randomItemsPostMoonMan,


                .. randomItemsDebug,
            ];
            return returnList;
        }
    }
}