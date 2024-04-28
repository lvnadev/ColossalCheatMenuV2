using BepInEx;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Colossal
{
    class Startup : MonoBehaviour
    {
        public static GameObject prefabInstance;
        public static void LoadAssets()
        {
            // Load the embedded resource stream
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ColossalCheatMenuV2.Asset.startup");

            // Load the asset bundle from the stream
            AssetBundle assetBundle = AssetBundle.LoadFromStream(stream);

            // Instantiate an object from the asset bundle
            GameObject prefab = assetBundle.LoadAsset<GameObject>("startup");
            prefabInstance = GameObject.Instantiate(prefab);

            prefabInstance.transform.position = new Vector3(999f, 999f, 999f);

            // Optional: unload the asset bundle after instantiating the object
            assetBundle.Unload(false);
        }

        public static void Accept()
        {
            prefabInstance.GetComponent<Animator>().SetTrigger("Agreed");
            while (!prefabInstance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Enter"))
            {
                return;
            }
            LayerMask Default = GorillaLocomotion.Player.Instance.locomotionEnabledLayers;
            GorillaLocomotion.Player.Instance.locomotionEnabledLayers = 0;
            GorillaLocomotion.Player.Instance.transform.position = new Vector3(-41.4174f, -2.2224f, -76.5318f);
            Startup.prefabInstance.SetActive(false);
            GorillaLocomotion.Player.Instance.locomotionEnabledLayers = Default;
        }
    }
}
