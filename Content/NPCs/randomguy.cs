using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using Terraria.Audio;

using badgatchagame.Content.PlayerObjects;
using badgatchagame.Content.Randomisation;
using badgatchagame.Content.Items.Tickets;
using static badgatchagame.Content.Randomisation.RandomItemsLists;

namespace badgatchagame.Content.NPCs
{ 
    // this is already pretty messy, just because there is a lot of unique interactions with this npc
    // and lots of text
    
    [AutoloadHead]
	public class randomguy : ModNPC
	{
        private static bool hasntcomplainedyet = true;
        private static bool isGenerous = false;
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

            // Support for DialogueTweak mod
            DialogueTweakHelper.ReplaceButtonIcon(
                DialogueTweakHelper.ReplacementType.Shop,
                ModContent.NPCType<randomguy>(),
                "badgatchagame/Content/NPCs/blank");
            DialogueTweakHelper.ReplaceButtonIcon(
                DialogueTweakHelper.ReplacementType.Extra,
                ModContent.NPCType<randomguy>(),
                "badgatchagame/Content/NPCs/blank");
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

        private static bool PlayerHasCoupon() {
            if (!Main.expertMode) return false;
            Player plr = Main.player[Main.myPlayer];
            for (int i = 0; i < plr.inventory.Length; i++) {
                if (plr.inventory[i].type == ModContent.ItemType<b1g1f>()) return true;
            }
            return false;
        }

        private static void TakePlayerCoupon() {
            Player plr = Main.player[Main.myPlayer];
            if (plr.FindItem(ModContent.ItemType<b1g1f>()) > -1) plr.inventory[plr.FindItem(ModContent.ItemType<b1g1f>())] = new Item(ItemID.None);
        }

        private static bool PlayerInventoryIsFull() {
            Player plr = Main.player[Main.myPlayer];
            int available = 0;
            for (int i = 0; i <= 49; i++) {
                if (getAllRandomItems().FindIndex(a => a == plr.inventory[i].type) > -1) available++;
                else if (plr.inventory[i].type < ItemID.IronPickaxe) available++;
            }
            return !(available > 1); // 2 slots available
        }

        private static void FilterPlayerInventory() {
            Player plr = Main.player[Main.myPlayer];
            foreach (var item in getAllRandomItems()) {
                int itemSlot = plr.FindItem(item);
                while (itemSlot > -1) {
                    plr.inventory[itemSlot] = new Item(ItemID.None);
                    itemSlot = plr.FindItem(item);
                }
            }
        }

        private static List<int> GetFilteredCurrentProgressionList() {
            List<int> cpl = getCurrentProgressionList();
            Player plr = Main.player[Main.myPlayer];
            RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();
            if (mplr.ClassChosen > -1) {
                // filter!!
                return ChooseRandomItem.FilterWeaponType(cpl, mplr.ClassChosen);
            } else {
                return cpl;
            }
        }

        private static int GetFilteredRandomItemID() {
            Player plr = Main.player[Main.myPlayer];
            RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();
            if (mplr.ClassChosen > -1) {
                // filter!!
                List<int> itemPool = GetFilteredCurrentProgressionList();
                int index = Main.rand.Next(itemPool.Count);
                int chosenID = itemPool[index];
                return chosenID;
            } else {
                return ChooseRandomItem.GetRandomItemID();
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Player plr = Main.player[Main.myPlayer];
            RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();
            if (firstButton) {
                // first button
                
                if (mplr.CouponWeapon1 > ItemID.None && mplr.CouponWeapon2 > ItemID.None) {
                    Item couponWeaponChosen = new(mplr.CouponWeapon1);
                    if (plr.CanAcceptItemIntoInventory(couponWeaponChosen) && !PlayerInventoryIsFull()) {
                        FilterPlayerInventory();
                        SoundEngine.PlaySound(SoundID.Item37);
                        plr.GetItem(Main.myPlayer, couponWeaponChosen, GetItemSettings.ItemCreatedFromItemUsage);
                        Item accompanyingItem = getAccompanyingItemIfExists(mplr.CouponWeapon1);
                        int accompanyingItemStack = accompanyingItem.stack; // this fixes a bug where the stack is incorrectly set idfk why 
                        if (accompanyingItem.type > ItemID.None) {
                            plr.GetItem(Main.myPlayer, accompanyingItem, GetItemSettings.ItemCreatedFromItemUsage);
                            Main.npcChatText = GetDualWeaponObtainedText(couponWeaponChosen.Name, mplr.CouponWeapon1, accompanyingItem.Name, accompanyingItem.type, accompanyingItemStack);
                        } else {
                            Main.npcChatText = GetWeaponObtainedText(couponWeaponChosen.Name, mplr.CouponWeapon1);
                        }
                    } else {
                        Main.npcChatText = GetWeaponDeniedText(1);
                    }

                    mplr.CouponWeapon1 = ItemID.None;
                    mplr.CouponWeapon2 = ItemID.None;
                    if (RemovePlayersHardmodeDiscount() == false) IncreaseRerollPrice();

                    return;
                }
                int chosenID = GetFilteredRandomItemID();
                Item chosen = new(chosenID);
                
                double RerollPrice = GetAdjustedPlayerRerollPrice();

                if (plr.discountEquipped) {Main.npcChatText = GetWeaponDeniedText(2); return;}
                
                if (plr.CanAcceptItemIntoInventory(chosen) && !PlayerInventoryIsFull()) {
                    if (PlayerIsEligableForHardmodeDiscount() || plr.BuyItem(Item.buyPrice(silver: (int)(RerollPrice*100)))) {   
                        if (PlayerHasCoupon()) {
                            SoundEngine.PlaySound(SoundID.Coins);
                            TakePlayerCoupon();
                            int chosenID2 = GetFilteredRandomItemID();
                            while (chosenID == chosenID2) {
                                chosenID2 = GetFilteredRandomItemID();
                            }
                            mplr.CouponWeapon1 = chosenID;
                            mplr.CouponWeapon2 = chosenID2;
                            Item chosen2 = new(chosenID2);
                            Main.npcChatText = GetCouponUsedText(chosen.Name, chosenID, chosen2.Name, chosenID2);
                            return;
                        }
                        FilterPlayerInventory();
                        SoundEngine.PlaySound(SoundID.Item37);
                        plr.GetItem(Main.myPlayer, chosen, GetItemSettings.ItemCreatedFromItemUsage);
                        Item accompanyingItem = getAccompanyingItemIfExists(chosenID);
                        int accompanyingItemStack = accompanyingItem.stack; // this fixes a bug where the stack is incorrectly set idfk why 
                        if (accompanyingItem.type > ItemID.None) {
                            plr.GetItem(Main.myPlayer, accompanyingItem, GetItemSettings.ItemCreatedFromItemUsage);
                            Main.npcChatText = GetDualWeaponObtainedText(chosen.Name, chosenID, accompanyingItem.Name, accompanyingItem.type, accompanyingItemStack);
                        } else {
                            Main.npcChatText = GetWeaponObtainedText(chosen.Name, chosenID);
                        }
                        
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
                // second button
                if (mplr.CouponWeapon1 > ItemID.None && mplr.CouponWeapon2 > ItemID.None) {
                    Item couponWeaponChosen = new(mplr.CouponWeapon2);
                    if (plr.CanAcceptItemIntoInventory(couponWeaponChosen) && !PlayerInventoryIsFull()) {
                        FilterPlayerInventory();
                        SoundEngine.PlaySound(SoundID.Item37);
                        plr.GetItem(Main.myPlayer, couponWeaponChosen, GetItemSettings.ItemCreatedFromItemUsage);
                        Item accompanyingItem = getAccompanyingItemIfExists(mplr.CouponWeapon2);
                        int accompanyingItemStack = accompanyingItem.stack; // this fixes a bug where the stack is incorrectly set idfk why 
                        if (accompanyingItem.type > ItemID.None) {
                            plr.GetItem(Main.myPlayer, accompanyingItem, GetItemSettings.ItemCreatedFromItemUsage);
                            Main.npcChatText = GetDualWeaponObtainedText(couponWeaponChosen.Name, mplr.CouponWeapon2, accompanyingItem.Name, accompanyingItem.type, accompanyingItemStack);
                        } else {
                            Main.npcChatText = GetWeaponObtainedText(couponWeaponChosen.Name, mplr.CouponWeapon2);
                        }
                    } else {
                        Main.npcChatText = GetWeaponDeniedText(1);
                    }

                    mplr.CouponWeapon1 = ItemID.None;
                    mplr.CouponWeapon2 = ItemID.None;
                    if (RemovePlayersHardmodeDiscount() == false) IncreaseRerollPrice();

                    return;
                }

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
            int discount = 0;
            if (LanternNight.LanternsUp) discount += 10; // add 10% off
            if (isGenerous) discount += 50;
            if (discount > 0) RerollPrice -= RerollPrice / discount;
            return RerollPrice; 
        }

        private static void IncreaseRerollPrice() {
            Player plr = Main.player[Main.myPlayer];
            double newPrice = plr.GetModPlayer<RandomPlayer>().RerollPrice;

            if (newPrice <= 0) {
                // got this weapon for free
                // what a stinky loser.

                newPrice = Main.rand.Next(5);
                newPrice /= 10;
                newPrice += 0.5D;
            } else {
                double addPrice = 1D;
                // addPrice += Main.rand.Next(4);
                addPrice *= ((double)Main.rand.Next(10)+105)/100D;
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


        //  _            _
        // | |_ _____  _| |_
        // | __/ _ \ \/ / __|
        // | ||  __/>  <| |_
        // \__\___/_/\_\\__|
        // below


        public override List<string> SetNPCNameList()
        {
            return [
                "Edith",
                "Mathias",
                "Wael", // waeland confirmed!1!!1
                "Sir Slushington IV",
                "Lysander",
                "Daniel",
                "Edward",
                "Walter",
                "Sebastian",
                "Joseph",
                "Chad",
                "Smith",
            ];
        }


        public override void SetChatButtons(ref string button, ref string button2)
        {
            Player plr = Main.player[Main.myPlayer];
            RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();
            if (mplr.CouponWeapon1 > ItemID.None && mplr.CouponWeapon2 > ItemID.None) {
                button = "[i:"+mplr.CouponWeapon1+"] "+new Item(mplr.CouponWeapon1).Name;
                button2 = "[i:"+mplr.CouponWeapon2+"] "+new Item(mplr.CouponWeapon2).Name;
            } else {
                button = "Spin new item";
                button2 = "Price";
            }
        }

        private static string GetCouponUsedText(string WeaponName, int WeaponType, string Weapon2Name, int Weapon2Type)
        {
            return Main.rand.Next(6) switch
                {
                    0 => "I've accepted your coupon. You can choose to take either this [item:"+WeaponType+"] "+WeaponName+" or this [item:"+Weapon2Type+"] "+Weapon2Name+".",
                    1 => "Great! Now choose between this [item:"+WeaponType+"] "+WeaponName+" or this [item:"+Weapon2Type+"] "+Weapon2Name+".",
                    2 => "It's valid! Would you like to take this [item:"+WeaponType+"] "+WeaponName+" or this [item:"+Weapon2Type+"] "+Weapon2Name+"?",
                    3 => "I've found these two weapons for you, a [item:"+WeaponType+"] "+WeaponName+" and a [item:"+Weapon2Type+"] "+Weapon2Name+". Which one will you take?",
                    4 => "Coupon accepted. Take my [item:"+WeaponType+"] "+WeaponName+" or my [item:"+Weapon2Type+"] "+Weapon2Name+".",
                    5 => "Phew, it wasn't counterfit. Take this [item:"+WeaponType+"] "+WeaponName+" or this [item:"+Weapon2Type+"] "+Weapon2Name+".",
                    _ => invalidString,
                };
        }

        private static string GetDualWeaponObtainedText(string WeaponName, int WeaponType, string Weapon2Name, int Weapon2Type, int Weapon2Stack)
        {
            double RerollPrice = GetAdjustedPlayerRerollPrice();
            if (RerollPrice <= 0) {
                //first time
                return Main.rand.Next(3) switch // only 3 cuz it's less common
                {
                    0 => "Here's your free [item:"+WeaponType+"] "+WeaponName+", and a complimentary [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"!",
                    1 => "Take good care of your first [item:"+WeaponType+"] "+WeaponName+" with [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"!",
                    2 => "I found the perfect combination of a [item:"+WeaponType+"] "+WeaponName+" & [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"!",
                    _ => invalidString,
                };
            } else if (PlayerIsEligableForHardmodeDiscount()) {
                return Main.rand.Next(3) switch // only 3 cuz it's less common
                {
                    0 => "Here's your welcoming [item:"+WeaponType+"] "+WeaponName+" with [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"! Thank you again!",
                    1 => "I entrust you with this [item:"+WeaponType+"] "+WeaponName+" with a [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"! Congratulations!",
                    2 => "Congratulations! Here's a [item:"+WeaponType+"] "+WeaponName+" with a [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"!",
                    _ => invalidString,
                };
            } else {
                return Main.rand.Next(3) switch // only 3 cuz it's less common
                {
                    0 => "I've just found the perfect combination, a [item:"+WeaponType+"] "+WeaponName+" with [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"!",
                    1 => "Have fun with this [item:"+WeaponType+"] "+WeaponName+" with a free [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+"!",
                    2 => "I found this [item:"+WeaponType+"] "+WeaponName+" and [i/s"+Weapon2Stack+":"+Weapon2Type+"] "+Weapon2Name+" just for you!",
                    _ => invalidString,
                };
            }
        }

        private static string GetWeaponObtainedText(string WeaponName, int WeaponType)
        {
            double RerollPrice = GetAdjustedPlayerRerollPrice();
            if (RerollPrice <= 0) {
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
            Player plr = Main.player[Main.myPlayer];
            List<int> pool = GetFilteredCurrentProgressionList();
            int stock = pool.Count;

            double RerollPrice = GetAdjustedPlayerRerollPrice();

            if (plr.discountEquipped) {
                return Main.rand.Next(6) switch
                {
                    0 => "I am not quoting any price tag if you're going to try to scam me with a fake discount card.",
                    1 => "Are you still expecting me to give you a price with that counterfit discount card? No way!",
                    2 => "I am not quoting anything until you get that fake discount card out of my sight!",
                    3 => "No way I am going to give any prices with a fraudster with a fake discount card!",
                    4 => "Don't even try to ask me anything while holding that fake discount card!",
                    5 => "There is no way I am going to give you any price quotes while you hold that fake discount card!",
                    _ => invalidString,
                };
            } else if (RerollPrice <= 0) {
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
                if (LanternNight.LanternsUp && isGenerous) {
                    return Main.rand.Next(6) switch
                    {
                        0 => "I have about "+stock+" weapons for only "+Readable+"! 60% off!",
                        1 => "Because of your 60% off, you only have to spend "+Readable+" to get one of my "+stock+" weapons!",
                        2 => "If you give me "+Readable+", you get get one of my "+stock+" weapons! That's 60% less than usual!",
                        3 => "Thats right, you have 60% off! For only "+Readable+", you can get one of these "+stock+" weapons!",
                        4 => "60% off tonight! My "+stock+" weapons only cost "+Readable+"!",
                        5 => "You have a 60% discount! That means my "+stock+" weapons only cost "+Readable+" tonight!",
                        _ => invalidString,
                    };
                } else if (LanternNight.LanternsUp) {
                    return Main.rand.Next(6) switch
                    {
                        0 => "I have about "+stock+" weapons for only "+Readable+"! 10% off!",
                        1 => "Because of your 10% off, you only have to spend "+Readable+" to get one of my "+stock+" weapons!",
                        2 => "If you give me "+Readable+", you get get one of my "+stock+" weapons! That's 10% less than usual!",
                        3 => "Thats right, you have 10% off! For only "+Readable+", you can get one of these "+stock+" weapons!",
                        4 => "10% off tonight! My "+stock+" weapons only cost "+Readable+"!",
                        5 => "You have a 10% discount! That means my "+stock+" weapons only cost "+Readable+" tonight!",
                        _ => invalidString,
                    };
                } else if (isGenerous) {
                    return Main.rand.Next(6) switch
                    {
                        0 => "I have about "+stock+" weapons for only "+Readable+"! 50% off!",
                        1 => "Because of your 50% off, you only have to spend "+Readable+" to get one of my "+stock+" weapons!",
                        2 => "If you give me "+Readable+", you get get one of my "+stock+" weapons! That's 50% less than usual!",
                        3 => "Thats right, you have 50% off! For only "+Readable+", you can get one of these "+stock+" weapons!",
                        4 => "50% off tonight! My "+stock+" weapons only cost "+Readable+"!",
                        5 => "You have a 50% discount! That means my "+stock+" weapons only cost "+Readable+" tonight!",
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
                        0 => "You're holding onto too many things! You need 2 inventory slots!",
                        1 => "Please, make some room! I need 2 inventory slots!",
                        2 => "I can't see 2 free slots in your inventory!",
                        3 => "You really can't fit 2 things in your inventory?",
                        4 => "Why don't you have room for 2 more things in your inventory?",
                        5 => "Please, not even 2 items can fit in your inventory!",
                        _ => invalidString,
                    };

                case 2: // discount card
                    return Main.rand.Next(6) switch
                    {
                        0 => "I'm not going to sell you anything while you're using that fake discount card!",
                        1 => "And you think I'm doing business with a fraudster? Not with that discount card, I'm not!",
                        2 => "Get that fake discount card out of my sight before I call the police.",
                        3 => "I am not doing business with someone with a fake discount card.",
                        4 => "Get rid of that fake discount card immediately or else no weapons for you!",
                        5 => "That fake discount card is not accepted here! Get rid of it!",
                        _ => invalidString,
                    };

                default:
                    return "Error - unhandled exception, denial - code "+reasonCode+". This is likely a bug.";
            }
        }

        public override string GetChat()
        {
            isGenerous = Main.rand.Next(0, 8191) == 4096; // 1/8192 chance to get 50% off (no this is not a shiny reference)
            hasntcomplainedyet = true;
            double RerollPrice = GetAdjustedPlayerRerollPrice();
            Player plr = Main.player[Main.myPlayer];
            RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();

            // prority system:
            // 1 - coupon choosing
            // 2 - discount card && generous
            // 3 - discount card
            // 4 - first roll
            // 5 - hm discount && coupon
            // 6 - hm discount
            // 7 - lantern night && coupon && generous
            // 8 - lantern night && coupon
            // 9 - lantern night && generous
            // 10 - lantern night
            // 11 - coupon && generous
            // 12 - coupon
            // 13 - generous
            // 14 - normal chat

            if (mplr.CouponWeapon1 > ItemID.None && mplr.CouponWeapon2 > ItemID.None) {
                // coupon choosing (1)
                isGenerous = false;
                return Main.rand.Next(6) switch
                {
                    0 => "Hey! Don't leave me like that! You still have to decide!",
                    1 => "Don't leave me when i'm offering you something! Choose something!",
                    2 => "That's rude! Don't leave me while i'm offering you quality weapons. Choose one!",
                    3 => "I should reconsider if I should even give you a weapon. Choose one before I change my mind.",
                    4 => "Choose something! Don't leave me like that!",
                    5 => "That is so disrespectful. Choose something before i change my mind.",
                    _ => invalidString,
                };
            } else if (plr.discountEquipped && isGenerous) {
                // discount && generous (2)
                isGenerous = false;
                return Main.rand.Next(4) switch
                {
                    0 => "You know what? I was going to be generous to you today, but that fake discount card have just put me off.",
                    1 => "I was planning to be generous to you today, and then you show up with that counterfit discount card.",
                    2 => "Wow. Really? A fake discount card? I was going to be generous today, but never mind!",
                    3 => "I was going to be generous today, but you've just put me off with that fake discount card.",
                    _ => invalidString,
                };
            } else if (plr.discountEquipped) {
                // discount (3)
                isGenerous = false;
                return Main.rand.Next(4) switch
                {
                    0 => "You think you can fool me with your counterfeit discount card? Nope.",
                    1 => "Don't try using that discount card, it won't work here!",
                    2 => "Wow. Not even trying to hide that counterfeit discount card there.",
                    3 => "Are you trying to scam me? That discount card is obviously fake.",
                    _ => invalidString,
                };
            } else if (RerollPrice <= 0) {
                // first roll (4)
                isGenerous = false;
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
            } else if (PlayerIsEligableForHardmodeDiscount() && PlayerHasCoupon()) {
                // hm discount && coupon (5)
                isGenerous = false;
                return Main.rand.Next(6) switch
                {
                    0 => "You are a brave warrior. Care for a free weapon? 2 free weapons, even! You have a coupon.",
                    1 => "Congratulations! Would you like two whole free weapons? Your coupon makes these weapons free!",
                    2 => "Welcome to hard mode! Want 2 new weapons for free to start your hardmode journey, thanks to that coupon?",
                    3 => "What a wonderful achievement! I think that deserves a free weapon! No, 2 free weapons!",
                    4 => "Well done! You deserve 2 whole free weapons! Thanks to your coupon!",
                    5 => "Welcome to hard mode! I see you also have a coupon, I shall give you 2 free weapons!",
                    _ => invalidString,
                };
            } else if (PlayerIsEligableForHardmodeDiscount()) {
                // hm discount (6)
                isGenerous = false;
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
            } else if (LanternNight.LanternsUp && PlayerHasCoupon() && isGenerous) {
                // lantern night && coupon && generous (7)
                return Main.rand.Next(6) switch
                {
                    0 => "The stars have aligned. I am celebrating, generous and you have a coupon. Would you like 60% off for 2 weapons?",
                    1 => "How would you like 60% off for 2 whole weapons? Congratulations, and thank you for this coupon.",
                    2 => "I'm feeling generous today. Thanks to you winning that battle, and that coupon, I am going to give you 60% off for 2 weapons.",
                    3 => "Beautiful! You even have a coupon! You know what, i'm generous today... 60% off for 2 weapons, as my thank you.",
                    4 => "Congratulations! I've decided to agree on 60% for 2 weapons, due to your coupon, the lantern night and that i'm generous today!",
                    5 => "I'm feeling very generous today. Your coupon and your incredible achievement rewards you with 60% off for 2 weapons.",
                    _ => invalidString,
                };
            } else if (LanternNight.LanternsUp && PlayerHasCoupon()) {
                // lantern night && coupon (8)
                isGenerous = false;
                return Main.rand.Next(6) switch
                {
                    0 => "Tonight is a special night. 10% off! And a buy 1 get 1 free coupon!",
                    1 => "10% off, and a buy 1 get 1 free coupon! You must be lucky.",
                    2 => "10% off tonight! With your coupon, thats 2 weapons with a lower price! Bargain!",
                    3 => "You are so brave, I will happily give you 10% off and accept your coupon!",
                    4 => "Congrats! Let's celebrate by accepting your coupon and giving you a 10% discount!",
                    5 => "Well done, I shall reward you with a 10% discount and accepting your coupon!",
                    _ => invalidString,
                };
            } else if (LanternNight.LanternsUp && isGenerous) {
                // lantern night && generous (9)
                return Main.rand.Next(6) switch
                {
                    0 => "Wow, congrats on winning the fight! I'm feeling generous today, 60% off, just for the night!",
                    1 => "Congratulations on beating a boss! 10% off, no, 60% off for the rest of the night.",
                    2 => "You're so incredibly brave, I'm feeling generous today, I'll give you 60% off!",
                    3 => "Tonight is 10% off, because you beat a boss! No, wait, 60% because i'm feeling generous today!",
                    4 => "Congrats! Let's celebrate by giving you a 10%, no, 60% discount!",
                    5 => "Well done, because I'm feeling generous, and that you beat a boss, I'll reward you with 60% off!",
                    _ => invalidString,
                };
            } else if (LanternNight.LanternsUp) {
                // lantern night (10)
                isGenerous = false;
                return Main.rand.Next(6) switch
                {
                    0 => "Tonight is a special night. 10% off!",
                    1 => "Congratulations on beating a boss! 10% off for the rest of the night.",
                    2 => "10% off tonight! Congratulations on winning the battle!",
                    3 => "Tonight is 10% off, because you beat a boss! How brave.",
                    4 => "Congrats! Let's celebrate by giving you a 10% discount!",
                    5 => "Well done, I shall reward you with a 10% discount!",
                    _ => invalidString,
                };
            } else if (PlayerHasCoupon() && isGenerous) {
                // coupon (11)
                return Main.rand.Next(6) switch
                {
                    0 => "Is that.. a buy 1 get 1 free coupon? Indeed it is. Buy something, quickly! I'll even give you a 50% discount on top!",
                    1 => "Wow, a buy 1 get 1 free coupon! I'm feeling generous today, how about that coupon and a 50% discount?",
                    2 => "You can use your buy 1 get 1 free coupon here! I'm feeling generous today, so I'll add a 50% discount on top!",
                    3 => "You have.. a buy 1 get 1 free coupon? How amazing! You know what? 50% off, just because I'm feeling generous today.",
                    4 => "Amazing! You have a buy 1 get 1 free coupon! I'll give you a 50% discount too, just because I'm feeling generous today.",
                    5 => "Nice buy 1 get 1 free coupon! I'll accept it if you buy something from me! 50% off too, I'm feeling quite generous today.",
                    _ => invalidString,
                };
            } else if (PlayerHasCoupon()) {
                // coupon (12)
                isGenerous = false;
                return Main.rand.Next(6) switch
                {
                    0 => "Is that.. a buy 1 get 1 free coupon? Indeed it is. Buy something, quickly!",
                    1 => "Wow, a buy 1 get 1 free coupon! I will indeed accept this.",
                    2 => "You can use your buy 1 get 1 free coupon here! Buy a weapon now!",
                    3 => "You have.. a buy 1 get 1 free coupon? How amazing! I'll accept it!",
                    4 => "Amazing! You have a buy 1 get 1 free coupon! I can happily accept it here!",
                    5 => "Nice buy 1 get 1 free coupon! I'll accept it if you buy something from me!",
                    _ => invalidString,
                };
            } else if (isGenerous) {
                // generous (13)
                return Main.rand.Next(6) switch
                {
                    0 => "I have all of these powerful weapons. I'll even give you a 50% discount, just because I'm feeling generous today.",
                    1 => "Want some weapons? Give me only one of your kidneys and we'll talk. 50% off, just because i'm generous today.",
                    2 => "I heard you may need an upgrade. I can maybe give you one! Maybe even 50%, I'm feeling generous today!",
                    3 => "C'mon, want a weapon? I have plenty to choose from! I'm feeling generous today, so I'll give you 50% off!",
                    4 => "Would you like to buy a brand new weapon? I'm feeling generous today, so maybe 50% off?",
                    5 => "Would you like to walk away with a stronger weapon? I'm feeling quite generous today, I'll give you 50% off!",
                    _ => invalidString,
                };
            } else {
                // normal (14)
                return Main.rand.Next(6) switch
                {
                    0 => "I have all of these powerful weapons. Want one?",
                    1 => "Want some weapons? Give me two of your kidneys and we'll talk.",
                    2 => "I heard you may need an upgrade. I can maybe give you one!",
                    3 => "C'mon, want a weapon? I have plenty to choose from!",
                    4 => "Would you like to buy a brand new weapon?",
                    5 => "Would you like to walk away with a stronger weapon? Buy one now!",
                    _ => invalidString,
                };
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