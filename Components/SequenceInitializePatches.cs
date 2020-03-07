namespace UnityParrot.Components
{
    public class SequenceInitializePatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(MU3.Sequence.Initialize), "Enter_CollabAdvertise");
        }
    }
}
