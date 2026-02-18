using TrxUITest.src.tests.utils;

namespace TrxUITest.src.inputData
{
    public static class TacticalTradeInputData
    {
        //12 trades. Sell by Amount, filter by account.
        public static readonly TacticalTrade[] trade1 = {
            new TacticalTrade(
                new Filter("GFI", "DIBRX", new string[] {"9999-0024", "9999-0025", "9999-0066", "9999-0117", "9999-0132", "9999-0126"}),
                new Sell(TradeType.TradeTypes.Amount, "1250"),
                new Buy[] {new Buy("GFI", "PFODX", "100")}
            )
        };

        //25 trades. Sell by Percent of Position, filter by value >= $150,000, buy 4 securities.
        public static readonly TacticalTrade[] trade2 = {
            new TacticalTrade(
                new Filter("CORE", "DFEOX", null, "150000"),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "50"),
                new Buy[] {new Buy("CORE", "JFEAX", "20"), new Buy("CORE", "TPICZ", "40"), new Buy("CORE", "VIIIX", "10"), new Buy("CORE", "PLFSX", "30")}
            )
        };

        //Adds to an existing position for specified accounts, sell by Percent of Client. 45 trades.
        public static readonly TacticalTrade[] trade3 = {
            new TacticalTrade(
                new Filter("GRE", "DFREX", new string[] {"9999-0002", "9999-0007", "9999-0008", "9999-0029" }),
                new Sell(TradeType.TradeTypes.ByPercentOfClient, "5"),
                new Buy[] { new Buy(null, "ACIIX", "100") }
            )
        };

        //Sell from negative CASH.
        public static readonly TacticalTrade[] trade4 = {
            new TacticalTrade(
                new Filter(null, "CASH", new string[] {"9999-0126"}),
                new Sell(TradeType.TradeTypes.Amount, "5000"),
                new Buy[] {new Buy(null, "VIMAX", "100")}
            )
        };

        //22 items in blotter, 11 trades. Filter by advisor and value >= $90,000. Sell by Amount $10,000. Buy CASH
        public static readonly TacticalTrade[] trade5 = {
            new TacticalTrade(
                new Filter("CFI", null, null, "90000", "AA"),
                new Sell(TradeType.TradeTypes.Amount, "10000"),
                new Buy[] {new Buy(null, "CASH", "100")}
            )
        };

        //Multiple batches
        public static readonly TacticalTrade[] trade6 = {
            new TacticalTrade( //4 trades
                new Filter("CFI", "VBTIX"),
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {new Buy("CFI", "BCHYX", "100")}
            ),

            new TacticalTrade( //12 trades
                new Filter("CORE", "VIIIX"),
                new Sell(TradeType.TradeTypes.Amount, "200"),
                new Buy[] {new Buy("EME", "DFEMX", "50"), new Buy("EME", "DFCEX", "50")}
            ),

            new TacticalTrade( //3 trades
                new Filter("LCV", "FEQIX"),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "4"),
                new Buy[] {new Buy("TIPS", "FINPX", "80"), new Buy("EME", "DFCEX", "20")}
            ),
        };

        //Attempt to sell security with CurrentPrice == 0
        public static readonly TacticalTrade[] trade7 = {
            new TacticalTrade(
                new Filter(null, "381426NL5", new string[] {"9999-0083"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "10"),
                new Buy[] {new Buy("EME", "DFEMX", "100")}
            )
        };

        //Attempt to sell position with value $0
        public static readonly TacticalTrade[] trade8 = {
            new TacticalTrade(
                new Filter(null, "MUTBOND.BAA", new string[] {"9999-0093"}),
                //Sell is not used because the position results in an error on the positions page
                new Sell(TradeType.TradeTypes.PercentOfPosition, null),
                new Buy[] {new Buy(null, null, null)}
            )
        };

        //Attempt to sell security with SellFlag == "Do Not Sell"
        public static readonly TacticalTrade[] trade9 = {
            new TacticalTrade(
                new Filter(null, "ACBPX"),
                //Sell is not used because the position results in an error on the positions page
                new Sell(TradeType.TradeTypes.PercentOfPosition, null),
                new Buy[] {new Buy(null, null, null)}
            )
        };

        //Hidden and Locked Clients
        public static readonly TacticalTrade[] trade10 = {
            new TacticalTrade(
                new Filter("COMM", null, new string[] {"9999-0002", "9999-0007"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "14"),
                new Buy[] {
                    new Buy("CORE", "DFEOX", "40"),
                    new Buy("TIPS", "FINPX", "60")
                }
            )
        };

        //Sell exceeds held position
        public static readonly TacticalTrade[] trade11 = {
            new TacticalTrade(
                new Filter(null, "DCMSX", new string[] {"9999-0053"}),
                new Sell(TradeType.TradeTypes.Amount, "30777"),
                new Buy[] {
                    new Buy("CORE", "DFEOX", "100")
                }
            )
        };

        //Buy security does not have current price
        public static readonly TacticalTrade[] trade12 = {
            new TacticalTrade(
                new Filter(null, "VHGEX", new string[] {"9999-0048"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "30"),
                new Buy[] {
                    new Buy(null, "381426NL5", "50"),
                    new Buy(null, "AA", "50")
                }
            )
        };

        //Sell and buy the same security in the same amount
        public static readonly TacticalTrade[] trade13 = {
            new TacticalTrade(
                new Filter(null, "VHGEX", new string[] {"9999-0048"}),
                new Sell(TradeType.TradeTypes.Amount, "3000"),
                new Buy[] {
                    new Buy(null, "VHGEX", "100"),
                }
            )
        };

        //Sell and buy the same security in the different amounts
        public static readonly TacticalTrade[] trade14 = {
            new TacticalTrade(
                new Filter(null, "VHGEX", new string[] {"9999-0048"}),
                new Sell(TradeType.TradeTypes.Amount, "3000"),
                new Buy[] {
                    new Buy(null, "VHGEX", "70"),
                    new Buy("TIPS", "FINPX", "30")
                }
            )
        };

        //Many buys. Causing paging of tactical trade detail buys list.
        public static readonly TacticalTrade[] trade15 = {
            new TacticalTrade(
                new Filter("CFI", "ACBPX", new string[] {"9999-0023"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "90"),
                new Buy[] {
                    new Buy("CORE", "DFEOX", "2"),
                    new Buy("TIPS", "FINPX", "2"),
                    new Buy("EME", "DFEMX", "2"),
                    new Buy("GE", "AGGIX", "2"),
                    new Buy("GFI", "PEBIX", "2"),
                    new Buy("GRE", "DFREX", "2"),
                    new Buy("INTLC", "DFIEX", "2"),
                    new Buy("LCV", "ACIIX", "2"),
                    new Buy("MC", "VIMAX", "2"),
                    new Buy("SHTIPS", "APISX", "2"),

                    new Buy("COMM", "DCMSX", "4"),
                    new Buy("AAF1", "PIRMX", "4"),
                    new Buy("AAF1", "PPRMX", "4"),
                    new Buy("EME", "DFCEX", "4"),
                    new Buy("EME", "DFESX", "4"),
                    new Buy("GE", "ACWI", "4"),
                    new Buy("GE", "TWGGX", "4"),
                    new Buy("GE", "VHGEX", "4"),
                    new Buy("GFI", "DIBRX", "4"),
                    new Buy("SCV", "DFSVX", "4"),

                    new Buy("GFI", "PFOAX", "2"),
                    new Buy("GFI", "PFODX", "2"),
                    new Buy("SCV", "ANH", "2"),
                    new Buy("GRE", "PRETX", "2"),
                    new Buy("GRE", "TIAA RE", "2"),
                    new Buy("SCV", "ACVIX", "2"),
                    new Buy("INTLC", "DFALX", "2"),
                    new Buy("INTLC", "VANGINT", "2"),
                    new Buy("INTLC", "PYRINTL", "2"),
                    new Buy("INTLSC", "DFISX", "2"),
                    new Buy("TIPS", "AIANX", "10"),
                    new Buy("TIPS", "SEMPRA", "10"),
                }
            )
        };

        //Sell a security which is held in multiple accounts for the same client
        public static readonly TacticalTrade[] trade16 = {
            new TacticalTrade(
                new Filter("CFI", "ACBPX", new string[] {"9999-0014", "9999-0017"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "14"),
                new Buy[] {
                    new Buy("CORE", "DFEOX", "40"),
                    new Buy("TIPS", "FINPX", "60")
                }
            )
        };

        //Sell 100% of position
        public static readonly TacticalTrade[] trade17 = {
            new TacticalTrade(
                new Filter("CFI", "BCTIX"),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "100"),
                new Buy[] {
                    new Buy("SCV", "BPSIX", "100")
                }
            )
        };

        //Volume test
        //Sell CFI, COMM, CORE, EME, GE, GFI, GRE, INTLC, INTLSC, LCV,
        //     MC, REALC, SHTIPS, TIPS
        public static readonly TacticalTrade[] tradeVolume = {
            new TacticalTrade(
                new Filter("CFI", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"), 
                new Buy[] {
                    new Buy("CORE", "DFEOX", "10"),
                    new Buy("TIPS", "FINPX", "10"), 
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "AGGIX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            ),
    
            new TacticalTrade(
                new Filter("GFI", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"), 
                new Buy[] {
                    new Buy("CORE", "DFEOX", "10"),
                    new Buy("TIPS", "FINPX", "10"), 
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "AGGIX", "10"),
                    new Buy("CFI", "FSITX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            ),
        
            new TacticalTrade(
                new Filter("CORE", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {
                    new Buy("CFI", "FSITX", "10"),
                    new Buy("TIPS", "FINPX", "10"),
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "AGGIX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            ),
    
            new TacticalTrade(
                new Filter("TIPS", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {
                    new Buy("CFI", "FSITX", "10"),
                    new Buy("CORE", "PREIX", "10"),
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "CWGIX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            ),

            new TacticalTrade(
                new Filter("SHTIPS", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {
                    new Buy("CFI", "FSITX", "10"),
                    new Buy("CORE", "PREIX", "10"),
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "CWGIX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("TIPS", "PRRIX", "10")
                }
            ),

            new TacticalTrade(
                new Filter("GRE", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {
                    new Buy("CORE", "DFEOX", "10"),
                    new Buy("TIPS", "FINPX", "10"),
                    new Buy("CFI", "VBTIX", "10"),
                    new Buy("GE", "AGGIX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("TIPS", "PRRIX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            ),

            new TacticalTrade(
                new Filter("INTLC", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {
                    new Buy("CFI", "FSITX", "10"),
                    new Buy("TIPS", "FINPX", "10"),
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "AGGIX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("CORE", "DFEOX", "10"),
                    new Buy("LCV", "ACIIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            ),

            new TacticalTrade(
                new Filter("LCV", null), 
                new Sell(TradeType.TradeTypes.Amount, "100"),
                new Buy[] {
                    new Buy("CORE", "DFEOX", "10"),
                    new Buy("TIPS", "FINPX", "10"),
                    new Buy("EME", "DFEMX", "10"),
                    new Buy("GE", "AGGIX", "10"),
                    new Buy("CFI", "FSITX", "10"),
                    new Buy("GRE", "DFREX", "10"),
                    new Buy("INTLC", "DFIEX", "10"),
                    new Buy("GFI", "PEBIX", "10"),
                    new Buy("MC", "VIMAX", "10"),
                    new Buy("SHTIPS", "APISX", "10")
                }
            )        
        };

       
        //Target percent exceeds held position
        public static readonly TacticalTrade[] trade18 = {
            new TacticalTrade(
                new Filter("SCV", "DFSVX", new string[] {"9999-0139"}),
                new Sell(TradeType.TradeTypes.ToTargetPercent, "2.5"),
                new Buy[] {
                    new Buy("SCV", "BPSIX", "100")
                }
            )
        };

        //Target percent is less than held position
        public static readonly TacticalTrade[] trade19 = {
            new TacticalTrade(
                new Filter("SCV", "DFSVX", new string[] {"9999-0139"}),
                new Sell(TradeType.TradeTypes.ToTargetPercent, "2"),
                new Buy[] {
                    new Buy("SCV", "BPSIX", "100")
                }
            )
        };

        //Percent of client is less than held position
        public static readonly TacticalTrade[] trade20 = {
            new TacticalTrade(
                new Filter("GRE", "DFREX", new string[] {"9999-0064"}),
                new Sell(TradeType.TradeTypes.ByPercentOfClient, "7.49"),
                new Buy[] {
                    new Buy("SHTIPS", "APOIX", "100")
                }
            )
        };

        //Sell 1% of position
        public static readonly TacticalTrade[] trade21 = {
            new TacticalTrade(
                new Filter("CFI", "38375QGN3", new string[] {"9999-0081"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "1"),
                new Buy[] {
                    new Buy("SCV", "BPSIX", "100")
                }
            )
        };
        
        //Clients with no model. This is a negative test and the Sell is irrelvant.
        public static readonly TacticalTrade[] trade22 = {
            new TacticalTrade(
                new Filter(null, "AGGIX", new string[] {"9999-0004"}),
                new Sell(TradeType.TradeTypes.PercentOfPosition, "1"),
                new Buy[] {
                    new Buy(null, null, null)
                }
            )
        };
    }
}
