using MU3.AM;
using MU3.DB;
using System.Collections.Generic;

namespace UnityParrot.Components
{
    public class CreditPatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(CreditPatches));
            Harmony.MakeRET(typeof(Credit), "clearAimeLog");
            Harmony.MakeRET(typeof(Credit), "initialize");
            Harmony.MakeRET(typeof(Credit), "isGameCostEnough", true);
            Harmony.MakeRET(typeof(Credit), "onCoinIn", true);
            Harmony.MakeRET(typeof(Credit), "payGameCost", true);
            Harmony.MakeRET(typeof(Credit), "sendAimeLog");
            Harmony.MakeRET(typeof(Credit), "terminate");
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_addableCoin")]
        static bool addableCoin(ref int __result)
        {
            __result = 0;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_coin")]
        static bool coin(ref int __result)
        {
            __result = 10;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_CoinAmount")]
        static bool CoinAmount(ref int __result)
        {
            __result = 1;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_credit")]
        static bool credit(ref int __result)
        {
            __result = 10;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "toCoins")]
        static bool toCoins(ref int __result, int __0)
        {
            __result = __0;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "getGpProductList")]
        static bool getGpProductList(ref List<Product> __result)
        {
            __result = new List<Product>();
            __result.Add(new Product(GpProductID.A_Credit1, GpProductID.A_Credit1));
            __result.Add(new Product(GpProductID.A_Credit2, GpProductID.A_Credit2));
            __result.Add(new Product(GpProductID.A_Credit3, GpProductID.A_Credit3));

            return false;
        }
    }
}
