
using HarmonyLib;
using UnityEngine;
using BepInEx;
using System.Reflection;

namespace Colossal.Patches {
    [BepInPlugin("ColossusYTTV.ColossalCheatMenuV2", "ColossalCheatMenuV2", "1.0.0")]
    class BepInPatcher : BaseUnityPlugin {

        private static GameObject gameob = new GameObject();

        BepInPatcher()
        {
            new Harmony("ColossusYTTV.ColossalCheatMenuV2").PatchAll(Assembly.GetExecutingAssembly());
        }

        void Awake() {
            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 51);
            if (randomNumber == 1) {
                Plugin.sussy = true;
            }
        }
        public static void LoadModStuff() {
            if (!GameObject.Find("KmansBepInPatch")) {
                CreateBepInPatch();
            }
        }
        public static void CreateBepInPatch() {
            Debug.Log("Creating Patcher");
            if (gameob == null)
            {
                gameob = new GameObject();
            }
            gameob.name = "KmansBepInPatch";
            gameob.AddComponent<Plugin>();
            UnityEngine.Object.DontDestroyOnLoad(gameob);
            Debug.Log("Creating Patcher");
        }
    }
}
