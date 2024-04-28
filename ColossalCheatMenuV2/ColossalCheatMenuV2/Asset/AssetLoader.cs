using System;
using System.Reflection;
using UnityEngine;

namespace HorrorHardMode
{
    internal class AssetLoader : MonoBehaviour
    {
        private void Awake()
        {
            AssetLoader.AssetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ColossalCheatMenuV2.Asset.startup"));
        }
        public static GameObject LoadPrefab(string Name)
        {
            return AssetLoader.AssetBundle.LoadAsset<GameObject>(Name);
        }
        public static GameObject LoadAsset(string Name)
        {
            return UnityEngine.Object.Instantiate<GameObject>(AssetLoader.LoadPrefab(Name));
        }
        private static AssetBundle AssetBundle;
    }
}
