using System;
using System.Collections.Generic;
using randomitems.Content.PlayerObjects;
using randomitems.Content.Randomisation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using static randomitems.Content.Randomisation.RandomItemsLists;
using Stubble.Core;

namespace randomitems.Content.NPCs
{ 
    [AutoloadHead]
	public class randomguy : ModNPC
	{
        private static bool hasntcomplainedyet = true;
        private static readonly string invalidString = "Something's gone wrong. I've forgotten what I was going to say. Sorry about that!";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 0;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 10000;
            NPCID.Sets.AttackAverageChance[NPC.type] = 0;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.aiStyle = 7;
            NPC.width = 28;
            NPC.height = 20;
            NPC.defense = 35;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            return true;
        }

        private static bool PlayerInventoryIsFull() {
            Player plr = Main.player[Main.myPlayer];
            bool returnVal = true;
            for (int i = 0; i <= 49; i++) {
                if (plr.inventory[i].type < ItemID.IronPickaxe) returnVal = false;
            }
            return returnVal;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton) {
                int chosenID = ChooseRandomItem.GetRandomItemID();
                Item chosen = new(chosenID);
                Player plr = Main.player[Main.myPlayer];
                double RerollPrice = GetAdjustedPlayerRerollPrice();
                
                if (plr.CanAcceptItemIntoInventory(chosen) && !PlayerInventoryIsFull()) {
                    if (PlayerIsEligableForHardmodeDiscount() || plr.BuyItem(Item.buyPrice(gold: (int)RerollPrice))) {   
                        foreach (var item in getAllRandomItems()) {
                            int itemSlot = plr.FindItem(item);
                            while (itemSlot > -1) {
                                plr.inventory[itemSlot] = new Item(0);
                                itemSlot = plr.FindItem(item);
                            }
                        }
                        plr.GetItem(Main.myPlayer, chosen, GetItemSettings.ItemCreatedFromItemUsage);
                        Main.npcChatText = GetWeaponObtainedText(chosen.Name, chosenID);
                        if (RemovePlayersHardmodeDiscount() == false) IncreaseRerollPrice();
                    } else {
                        if (Main.rand.NextBool(50)) {
                            int Error = EligableForDecrease();
                            if (Error == 0) {
                                double NewPrice = LowerRerollPriceSlightly();
                                List<int> CurrencyList = ConvertGoldToCurrencyList(NewPrice);
                                string Readable = ConvertCurrencyListToString(CurrencyList);
                                Main.npcChatText = GetLoweredPriceByForceText(Readable);
                            } else if (Error == 2) {
                                Main.npcChatText = GetFailedToLowerPriceText();
                            }
                            hasntcomplainedyet = true;
                        } else {
                            Main.npcChatText = GetWeaponDeniedText(0);
                        }
                        hasntcomplainedyet = false;
                    }
                } else {
                    Main.npcChatText = GetWeaponDeniedText(1);
                    return;
                }
            } else {
                Main.npcChatText = GetStockText();
            }
        }

        private static double GetPlayerRerollPrice() {
            Player plr = Main.player[Main.myPlayer];
            double RerollPrice = plr.GetModPlayer<RandomPlayer>().RerollPrice;
            return RerollPrice; 
        }

        private static double GetAdjustedPlayerRerollPrice() {
            Player plr = Main.player[Main.myPlayer];
            double RerollPrice = plr.GetModPlayer<RandomPlayer>().RerollPrice;
            if (LanternNight.LanternsUp) RerollPrice -= RerollPrice / 5;
            return RerollPrice; 
        }

        private static void IncreaseRerollPrice() {
            Player plr = Main.player[Main.myPlayer];
            double newPrice = plr.GetModPlayer<RandomPlayer>().RerollPrice;

            if (newPrice <= 1) {
                // got this weapon for free
                // what a stinky loser.

                newPrice = (double)Main.rand.Next(2);
                newPrice += 1D;
            } else {
                double addPrice = 1D;
                addPrice += Main.rand.Next(4);
                addPrice *= ((double)Main.rand.Next(50)+75)/100D;
                newPrice += addPrice;
            }

            plr.GetModPlayer<RandomPlayer>().RerollPrice = newPrice;
        }

        private static int EligableForDecrease() {
            Player plr = Main.player[Main.myPlayer];
            int LoweredPrices = plr.GetModPlayer<RandomPlayer>().LoweredPrices;


            double RerollPrice = GetPlayerRerollPrice();

            if (RerollPrice <= 1 || hasntcomplainedyet == true) {
                return 1;
            } else if (LoweredPrices >= 5) {
                return 2;
            } else {
                plr.GetModPlayer<RandomPlayer>().LoweredPrices += 1;
                return 0;
            }
        }

        private static double LowerRerollPriceSlightly() {
            Player plr = Main.player[Main.myPlayer];
            double newPrice = plr.GetModPlayer<RandomPlayer>().RerollPrice;

            newPrice *= 0.95;

            plr.GetModPlayer<RandomPlayer>().RerollPrice = newPrice;

            return GetAdjustedPlayerRerollPrice();
        }

        public static List<int> ConvertGoldToCurrencyList(double Gold) {
            const int CopperPerSilver = 100;
            const int SilverPerGold = 100;
            const int GoldPerPlatinum = 100;

            double totalCopper = Gold * SilverPerGold * CopperPerSilver;

            double platinum = totalCopper / (GoldPerPlatinum * SilverPerGold * CopperPerSilver);
            double remainingCopper = totalCopper % (GoldPerPlatinum * SilverPerGold * CopperPerSilver);

            double gold = remainingCopper / (SilverPerGold * CopperPerSilver);
            remainingCopper %= SilverPerGold * CopperPerSilver;

            double silver = remainingCopper / CopperPerSilver;
            double copper = remainingCopper % CopperPerSilver;

            List<int> returnList = [
                (int) copper,
                (int) silver,
                (int) gold,
                (int) platinum
            ];

            return returnList;
        }

        public static string ConvertCurrencyListToString(List<int> CurrencyList) {
            int Copper = CurrencyList[0];
            int Silver = CurrencyList[1];
            int Gold = CurrencyList[2];
            int Platinum = CurrencyList[3];

            String copperPart = "";
            String silverPart = "";
            String goldPart = "";
            String platinumPart = "";

            if (Platinum <= 0 && Gold <= 0 && Silver <= 0 && Copper <= 0) return "FREE";

            if (Platinum > 0) {
                platinumPart = Platinum+" platinum";
            }
            if (Gold > 0) {
                if (Platinum > 0 && Silver > 0 || Platinum > 0 && Copper > 0) goldPart = ", "+Gold+" gold";
                else if (Platinum > 0) goldPart = " and "+Gold+" gold";
                else goldPart = Gold+" gold";
            }
            if (Silver > 0) {
                if (Gold > 0 && Copper > 0 || Platinum > 0 && Copper > 0) silverPart = ", "+Silver+" silver";
                else if (Gold > 0 || Platinum > 0) silverPart = " and "+Silver+" silver";
                else silverPart = Silver+" silver";
            }
            if (Copper > 0) {
                if (Gold > 0 || Platinum > 0 || Silver > 0) copperPart = " and "+Copper+" copper";
                else copperPart = Copper+" copper";
            }

            return platinumPart+goldPart+silverPart+copperPart;
        }

        private static bool PlayerIsEligableForHardmodeDiscount() {
            Player plr = Main.player[Main.myPlayer];
            bool congrats = plr.GetModPlayer<RandomPlayer>().Congrats;

            return congrats;
        }

        private static bool RemovePlayersHardmodeDiscount() {
            Player plr = Main.player[Main.myPlayer];
            bool OldCongrats = plr.GetModPlayer<RandomPlayer>().Congrats;
            plr.GetModPlayer<RandomPlayer>().Congrats = false;

            return OldCongrats != plr.GetModPlayer<RandomPlayer>().Congrats;
        }


        // all text things below


        public override List<string> SetNPCNameList()
        {
            return [
                "Jake",
                "Sir Slushington IV",
                "John",
                "William",
                "Joseph",
                "Harry",
                "Sebastian",
                "Jack",
                "Phoebe",
                "Walter",
                "Jesse",
                "Edward",
                "Daniel",
                "Smith",
                "Reagan",
                "Johnathon",
                "Chad",
                "Wael", //waeland confirmed!??!?!!?
                "Brock"
            ];
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Spin new item";
            button2 = "Price";
        }

        private static string GetWeaponObtainedText(string WeaponName, int WeaponType)
        {
            double RerollPrice = GetAdjustedPlayerRerollPrice();
            if (RerollPrice <= 1) {
                //first time
                return Main.rand.Next(6) switch
                {
                    0 => "As your first weapon, I'm sure this [item:"+WeaponType+"] "+WeaponName+" is amazing!",
                    1 => "This [item:"+WeaponType+"] "+WeaponName+" will surely help you throughout your journey!",
                    2 => "I hope you take good care of your first [item:"+WeaponType+"] "+WeaponName+".",
                    3 => "I was scrounging around and found the perfect first weapon for you, this [item:"+WeaponType+"] "+WeaponName+"!",
                    4 => "I found the perfect beginners weapon, this [item:"+WeaponType+"] "+WeaponName+"!",
                    5 => "I got you this [item:"+WeaponType+"] "+WeaponName+"! Good luck on your adventure!",
                    _ => invalidString,
                };
            } else if (PlayerIsEligableForHardmodeDiscount()) {
                return Main.rand.Next(6) switch
                {
                    0 => "Here's your [item:"+WeaponType+"] "+WeaponName+". Pleasure doing business with you as always.",
                    1 => "I entrust you with this [item:"+WeaponType+"] "+WeaponName+", congratulations again!",
                    2 => "Say hello to your brand new [item:"+WeaponType+"] "+WeaponName+"! Congratulations!",
                    3 => "I wish you well with this new [item:"+WeaponType+"] "+WeaponName+"!",
                    4 => "I'm sure you'll enjoy this [item:"+WeaponType+"] "+WeaponName+"!",
                    5 => "I am certain this is the best weapon for you, this [item:"+WeaponType+"] "+WeaponName+"!",
                    _ => invalidString,
                };
            } else {
                return Main.rand.Next(6) switch
                {
                    0 => "I've heard this [item:"+WeaponType+"] "+WeaponName+" thing is a great weapon! Pleasure doing business with you!",
                    1 => "Y'know, I used to love using this [item:"+WeaponType+"] "+WeaponName+", I'm sure you will too.",
                    2 => "I found this [item:"+WeaponType+"] "+WeaponName+" for you, when i saw it, it reminded me of you.",
                    3 => "Here's this [item:"+WeaponType+"] "+WeaponName+" I found in the back. Enjoy!",
                    4 => "I got you an amazing [item:"+WeaponType+"] "+WeaponName+"! Pleasure doing business with you!!",
                    5 => "I had to get you this [item:"+WeaponType+"] "+WeaponName+", when I looked at it, it reminded me of you.",
                    _ => invalidString,
                };
            }
        }

        private static string GetStockText()
        {
            List<int> pool = getCurrentProgressionList();
            int stock = pool.Count;

            double RerollPrice = GetAdjustedPlayerRerollPrice();

            if (RerollPrice <= 1) {
                return Main.rand.Next(6) switch
                {
                    0 => "I can give you only one of my "+stock+" weapons for free! The rest you need to pay for.",
                    1 => "I'm willing to give one of my "+stock+" weapons for free, but the others are paid.",
                    2 => "C'mon, one of my "+stock+" weapons are waiting for you! It's free!",
                    3 => "For the low, low price of about.. 0 gold, You can get one of my "+stock+" weapons!",
                    4 => "I have about "+stock+" weapons in stock, and because you need a weapon, I'll give it for free!",
                    5 => "For one of my "+stock+" weapons, that'll set you back a loathesome 0 gold. Do you have enough for that?",
                    _ => invalidString,
                };
            } else if (PlayerIsEligableForHardmodeDiscount()) {
                return Main.rand.Next(4) switch
                {
                    0 => "I can give you only one of my "+stock+" weapons for free because you entered hardmode!",
                    1 => "I'm willing to give one of my "+stock+" weapons for free, due to your heroic achievement.",
                    2 => "C'mon, one of my "+stock+" heroic weapons are waiting for you! It's free!",
                    3 => "Because you are so strong, you can get one of my "+stock+" weapons for free!",
                    _ => invalidString,
                };
            } else {
                List<int> CurrencyList = ConvertGoldToCurrencyList(RerollPrice);
                String Readable = ConvertCurrencyListToString(CurrencyList);
                if (LanternNight.LanternsUp) {
                    return Main.rand.Next(6) switch
                    {
                        0 => "I have about "+stock+" weapons for only "+Readable+"! 20% off!",
                        1 => "Because of your 20% off, you only have to spend "+Readable+" to get one of my "+stock+" weapons!",
                        2 => "If you give me "+Readable+", you get get one of my "+stock+" weapons! That's 20% less than usual!",
                        3 => "Thats right, you have 20% off! For only "+Readable+", you can get one of these "+stock+" weapons!",
                        4 => "20% off tonight! My "+stock+" weapons only cost "+Readable+"!",
                        5 => "You have a 20% discount! That means my "+stock+" weapons only cost "+Readable+" tonight!",
                        _ => invalidString,
                    };
                } else {
                    return Main.rand.Next(6) switch
                    {
                        0 => "I have about "+stock+" weapons for only "+Readable+"!",
                        1 => "For the low, low price of "+Readable+", you can get one of my "+stock+" weapons!",
                        2 => "If you give me "+Readable+", you get get one of my "+stock+" weapons!",
                        3 => "For only "+Readable+", you can get one of these "+stock+" weapons!",
                        4 => stock+" weapons are waiting for you at the low, low price of only "+Readable+"!",
                        5 => "For one of my "+stock+" weapons, that'll set you back a loathesome "+Readable+".",
                        _ => invalidString,
                    };
                }
            }
        }

        private static string GetWeaponDeniedText(int reasonCode) {
            switch (reasonCode) {
                case 0: // not enough money, should never happen if first time.
                    double RerollPrice = GetAdjustedPlayerRerollPrice();
                    List<int> CurrencyList = ConvertGoldToCurrencyList(RerollPrice);
                    String Readable = ConvertCurrencyListToString(CurrencyList);
                    return Main.rand.Next(6) switch
                    {
                        0 => "You're telling me you don't have "+Readable+"?",
                        1 => "No money? No weapons. Want weapons? I need "+Readable+".",
                        2 => "My weapons are no longer free. I need "+Readable+".",
                        3 => "I need "+Readable+" to afford giving you a weapon.",
                        4 => "I'm selling this weapon for "+Readable+", nothing more, nothing less",
                        5 => "You need to give me atleast "+Readable+" for my weapons.",
                        _ => invalidString,
                    };
                
                case 1: // not enough inv room
                    return Main.rand.Next(6) switch
                    {
                        0 => "You're holding onto too many things!",
                        1 => "Put something away so I can give this item to you!",
                        2 => "I don't see a place to put this item.",
                        3 => "Make some room, please! I can't give this to you right now!",
                        4 => "You can't fit this new weapon into your inventory!",
                        5 => "Please, make some room for your new weapon!",
                        _ => invalidString,
                    };

                default:
                    return "Error - unhandled exception, denial - code "+reasonCode+". This is a bug.";
            }
        }

        public override string GetChat()
        {
            hasntcomplainedyet = true;
            double RerollPrice = GetAdjustedPlayerRerollPrice();
            if (RerollPrice <= 1) {
                //first time
                return Main.rand.Next(8) switch
                {
                    0 => "I have all of these weapons, want one for free?",
                    1 => "Want some weapons? I can give you one for free!",
                    2 => "I heard you may be in need of a weapon. I can give you a good beginners one!",
                    3 => "C'mon, want a weapon? First ones on me!",
                    4 => "Hello! Nice meeting you. Want a free weapon?",
                    5 => "Greetings! I am the weapon man. Want a weapon for free?",
                    6 => "My life is interesting. I sell weapons for a living! Want one for free?",
                    7 => "You look like you're in need of a free weapon.",
                    _ => "i am actually a painter. they've kidnapped me and stripped me of my past life. don't believe the lies.",
                };
            } else {
                if (LanternNight.LanternsUp) {
                    return Main.rand.Next(6) switch
                    {
                        0 => "Tonight is a special night. 20% off!",
                        1 => "Congratulations on beating a boss! 20% off for the rest of the night.",
                        2 => "20% off tonight! Congratulations on winning the battle!",
                        3 => "Tonight is 20% off, because you beat a boss! How brave.",
                        4 => "Congrats! Let's celebrate by getting you a 20% discount!",
                        5 => "Well done, I shall reward you with a 20% discount!",
                        _ => invalidString,
                    };
                } else if (PlayerIsEligableForHardmodeDiscount()) {
                    return Main.rand.Next(6) switch
                    {
                        0 => "You are a brave warrior. Care for a free weapon?",
                        1 => "Congratulations! Would you like a free weapon?",
                        2 => "Welcome to hard mode! Want a new weapon for free?",
                        3 => "What a wonderful achievement! I think that deserves a free weapon!",
                        4 => "Well done! You deserve a free weapon! I have new ones..!",
                        5 => "How was the battle? You must've fought well. I'll reward you with a free weapon!",
                        _ => invalidString,
                    };
                } else {
                    return Main.rand.Next(6) switch
                    {
                        0 => "I have all of these powerful weapons. Want one?",
                        1 => "Want some weapons? Give me two of your kidneys and we'll talk.",
                        2 => "I heard you may need an upgrade. I can maybe give you one!",
                        3 => "C'mon, want a weapon? I have plenty to choose from!",
                        4 => "Would you like to buy a brand new weapon?",
                        5 => "Wold you like to walk away with a stronger weapon? Buy one now!",
                        _ => invalidString,
                    };
                }
            }
        }

        private static string GetLoweredPriceByForceText(string Readable) {
            return Main.rand.Next(6) switch
            {
                0 => "Fine, I've had enough of you asking. I'll lower my prices to "+Readable+".",
                1 => "Enough! I'll lower the price! Is "+Readable+" good enough for you???",
                2 => "Gosh, you're so picky. Fine. I'll do "+Readable+".",
                3 => "I hate customers like you. I'll drop the price to "+Readable+". Is that enough?",
                4 => "You're such a choosing beggar. Is "+Readable+" good enough price?",
                5 => "Do you really need lower prices? Fine, I'll lower them to "+Readable+"",
                _ => invalidString,
            };
        }

        private static string GetFailedToLowerPriceText() {
            return Main.rand.Next(6) switch
            {
                0 => "Are you expecting me to lower my prices? Not happening.",
                1 => "I am not going to lower my prices again. You've asked one too many times.",
                2 => "Can you stop asking to lower my prices? They're my prices for a reason.",
                3 => "I swear to god if you ask me to lower my prices one more time I will kill you.",
                4 => "I will go bankrupt if I lower my prices again. Not happening.",
                5 => "My prices are my prices. You cannot tell me to lower them.",
                _ => invalidString,
            };
        }
	}
}