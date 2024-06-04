using System.Collections.Generic;
using randomitems.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// i know
// i hate myself too

namespace randomitems.Content.Randomisation
{
    public class RandomItemsLists : ModSystem
    {
        public static readonly List<int> randomItemsPreboss = [
            ModContent.ItemType<TROLOLOLOL>(),

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
            ItemID.CrimsonYoyo,
            ItemID.CorruptYoyo,
            ItemID.AshWoodBow,
            ItemID.AshWoodSword,
            ItemID.BallOHurt,
            ItemID.BatBat,
            ItemID.BladeofGrass,
            ItemID.BladedGlove,
            ItemID.BloodButcherer,
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
            ItemID.CrimsonRod,
            ItemID.DemonBow,
            ItemID.DemonScythe,
            ItemID.DiamondStaff,
            ItemID.EbonwoodBow,
            ItemID.EbonwoodSword,
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
            ItemID.LightsBane,
            ItemID.Mace,
            ItemID.AntlionClaw,
            ItemID.Minishark,
            ItemID.Musket,
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
            ItemID.ShadewoodBow,
            ItemID.ShadewoodSword,
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
            ItemID.TendonBow,
            ItemID.TentacleSpike,
            ItemID.Terragrim,
            ItemID.TheRottedFork,
            ItemID.TheUndertaker,
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
            ItemID.Vilethorn,
            ItemID.WandofFrosting,
            ItemID.WandofSparking,
            ItemID.ZombieArm,
        ];

        public static readonly List<int> randomItemsPostEOC = [
            ItemID.ZapinatorGray,
            ItemID.Code1,
        ];

        public static readonly List<int> randomItemsPostEvil = [
            ItemID.AleThrowingGlove,
            ItemID.DD2BallistraTowerT1Popper,
            ItemID.DD2ExplosiveTrapT1Popper,
            ItemID.Flamarang,
            ItemID.DD2FlameburstTowerT1Popper,
            ItemID.ImpStaff,
            ItemID.DD2LightningAuraT1Popper,
            ItemID.RedPhaseblade,
            ItemID.BluePhaseblade,
            ItemID.GreenPhaseblade,
            ItemID.WhitePhaseblade,
            ItemID.PurplePhaseblade,
            ItemID.OrangePhaseblade,
            ItemID.YellowPhaseblade,
            ItemID.SpaceGun,
            ItemID.StarCannon,
            ItemID.TheMeatball,
            ItemID.FieryGreatsword,
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
            ItemID.MoltenFury,
            ItemID.Muramasa,
            ItemID.NightsEdge,
            ItemID.PhoenixBlaster,
            ItemID.QuadBarrelShotgun,
            ItemID.BoneWhip,
            ItemID.Sunfury,
            ItemID.Valor,
            ItemID.WaterBolt,
        ];

        public static readonly List<int> randomItemsPreHardmodeBoss = [
            ItemID.AdamantiteGlaive,
            ItemID.AdamantiteRepeater,
            ItemID.AdamantiteSword,
            ItemID.Amarok,
            ItemID.Anchor,
            ItemID.Bananarang,
            ItemID.BeamSword,
            ItemID.Bladetongue,
            ItemID.SharpTears,
            ItemID.BreakerBlade,
            ItemID.ChainGuillotines,
            ItemID.Chik,
            ItemID.TaxCollectorsStickOfDoom,
            ItemID.ClingerStaff,
            ItemID.ClockworkAssaultRifle,
            ItemID.CobaltNaginata,
            ItemID.CobaltRepeater,
            ItemID.CobaltSword,
            ItemID.CoinGun,
            ItemID.CoolWhip,
            ItemID.CrystalSerpent,
            ItemID.CrystalStorm,
            ItemID.CrystalVileShard,
            ItemID.CursedFlames,
            ItemID.Cutlass,
            ItemID.DaedalusStormbow,
            ItemID.DaoofPow,
            ItemID.DartPistol,
            ItemID.DartRifle,
            ItemID.DripplerFlail,
            ItemID.FetidBaghnakhs,
            ItemID.FireWhip,
            ItemID.FlowerofFrost,
            ItemID.FlyingKnife,
            ItemID.FormatC,
            ItemID.FrostStaff,
            ItemID.Frostbrand,
            ItemID.Gatligator,
            ItemID.GoldenShower,
            ItemID.Gradient,
            ItemID.HamBat,
            ItemID.HelFire,
            ItemID.IceBow,
            ItemID.IceRod,
            ItemID.IceSickle,
            ItemID.JoustingLance,
            ItemID.KOCannon,
            ItemID.LaserRifle,
            ItemID.SoulDrain,
            ItemID.MagicDagger,
            ItemID.Marrow,
            ItemID.MedusaHead,
            ItemID.MeteorStaff,
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
            ItemID.RedPhasesaber,
            ItemID.BluePhasesaber,
            ItemID.GreenPhasesaber,
            ItemID.WhitePhasesaber,
            ItemID.PurplePhasesaber,
            ItemID.OrangePhasesaber,
            ItemID.YellowPhasesaber,
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
            ItemID.Toxikarp,
            ItemID.Uzi
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
            ItemID.DD2BallistraTowerT2Popper,
            ItemID.DD2SquireDemonSword,
            ItemID.Code2,
            ItemID.Excalibur,
            ItemID.SwordWhip,
            ItemID.DD2ExplosiveTrapT2Popper,
            ItemID.DD2FlameburstTowerT2Popper,
            ItemID.Gungnir,
            ItemID.HallowJoustingLance,
            ItemID.HallowedRepeater,
            ItemID.DD2LightningAuraT2Popper,
            ItemID.SuperStarCannon,
            ItemID.Yelets,
            ItemID.UnholyTrident,
            ItemID.BookStaff,
            ItemID.MonkStaffT1,
            ItemID.MonkStaffT2,
            ItemID.DD2PhoenixBow,
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
            ItemID.DD2BetsyBow,
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
            ItemID.ScourgeoftheCorruptor,
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
            ItemID.VampireKnives,
            ItemID.VenusMagnum,
            ItemID.WaspGun,
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
            ItemID.DD2BallistraTowerT3Popper,
            ItemID.ApprenticeStaffT3,
            ItemID.FireworksLauncher,
            ItemID.DD2ExplosiveTrapT3Popper,
            ItemID.DD2FlameburstTowerT3Popper,
            ItemID.DD2SquireBetsySword,
            ItemID.GolemFist,
            ItemID.HeatRay,
            ItemID.DD2LightningAuraT3Popper,
            ItemID.PossessedHatchet,
            ItemID.MonkStaffT3,
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

        public static readonly List<int> randomItemsDebug = [
            // ItemID.CrimtaneOre,
            // ItemID.DemoniteOre,
            // ItemID.TissueSample,
            // ItemID.ShadowScale,
            // ItemID.CorruptSeeds,
            // ItemID.CrimsonSeeds,
            // ItemID.Gel,
            // ItemID.HallowedBar,
        ];
        
        public static List<int> getCurrentProgressionList() { // fuck you i dont care about naming conventions imma do it ma own way
            List<int> returnList = [];
            if (Main.hardMode) {
                returnList.AddRange(randomItemsPreHardmodeBoss);
                if (NPC.downedQueenSlime) { returnList.AddRange(randomItemsPostQueenSlime); }
                if (NPC.downedMechBossAny) { returnList.AddRange(randomItemsPostMech); }
                if (NPC.downedMechBossAny || NPC.downedQueenSlime) { returnList.AddRange(randomItemsPostAnyHardmodeBoss);}
                if (NPC.downedMechBoss1) { returnList.AddRange(randomItemsPostMechWorm); }
                if (NPC.downedMechBoss2) { returnList.AddRange(randomItemsPostMechEye); }
                if (NPC.downedMechBoss3) { returnList.AddRange(randomItemsPostMechSkeletron); }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) { returnList.AddRange(randomItemsPrePlantera); }
                if (NPC.downedPlantBoss) { returnList.AddRange(randomItemsPostPlantera); }
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
            } else {
                returnList.AddRange(randomItemsPreboss);
                if (NPC.downedBoss1) { returnList.AddRange(randomItemsPostEOC); }
                if (NPC.downedBoss2) { returnList.AddRange(randomItemsPostEvil); }
                if (NPC.downedDeerclops) { returnList.AddRange(randomItemsPostDeerclops); }
                if (NPC.downedQueenBee) { returnList.AddRange(randomItemsPostQueenBee); }
                if (NPC.downedBoss3) { returnList.AddRange(randomItemsPostSkeletron); }
            }
            return returnList;
        }

        public static List<int> getAllRandomItems() {
            List<int> returnList =
            [
                .. randomItemsPreboss,
                .. randomItemsPostEOC,
                .. randomItemsPostEvil,
                .. randomItemsPostDeerclops,
                .. randomItemsPostQueenBee,
                .. randomItemsPostSkeletron,
                .. randomItemsPreHardmodeBoss,
                .. randomItemsPostAnyHardmodeBoss,
                .. randomItemsPostQueenSlime,
                .. randomItemsPostMech,
                .. randomItemsPostMechEye,
                .. randomItemsPostMechWorm,
                .. randomItemsPostMechSkeletron,
                .. randomItemsPrePlantera,
                .. randomItemsPostPlantera,
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