using MU3.AM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class CreditPatches : MonoBehaviour
    {
        void Start()
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
        static bool AddableCoin(ref int __result)
        {
            __result = 0;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_coin")]
        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_CoinAmount")]
        [MethodPatch(PatchType.Prefix, typeof(Credit), "get_credit")]
        [MethodPatch(PatchType.Prefix, typeof(Credit), "toCoins")]
        static bool Coin(ref int __result)
        {
            __result = 100;
            return false;
        }
    }
}
