using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class SequenceInitializePatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.MakeRET(typeof(MU3.Sequence.Initialize), "Enter_CollabAdvertise");
        }
    }
}
