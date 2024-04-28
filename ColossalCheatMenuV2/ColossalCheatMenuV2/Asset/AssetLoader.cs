using System;
using System.Reflection;
using UnityEngine;

namespace HorrorHardMode
{
    // Token: 0x02000002 RID: 2
    internal class AssetLoader : MonoBehaviour
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private void Awake()
        {
            AssetLoader.AssetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("HorrorHardMode.mynewbundle"));
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000206C File Offset: 0x0000026C
        public static GameObject LoadPrefab(string Name)
        {
            return AssetLoader.AssetBundle.LoadAsset<GameObject>(Name);
        }

        // Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
        public static GameObject LoadAsset(string Name)
        {
            return UnityEngine.Object.Instantiate<GameObject>(AssetLoader.LoadPrefab(Name));
        }

        // Token: 0x04000001 RID: 1
        private static AssetBundle AssetBundle;
    }
}
