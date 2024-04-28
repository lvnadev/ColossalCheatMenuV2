using BepInEx;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Threading;
using System.Threading.Tasks;

namespace Colossal
{
    class Startup
    {
        public static GameObject prefabInstance;
        private static float timer;
        private static LayerMask defaultlocomotionlayers;

        public static GameObject enviroment = GameObject.Find("Environment Objects");
        public static Vector3 trans = GorillaLocomotion.Player.Instance.transform.position;
        public static bool ballzandcock = false;
        public static void LoadAssets()
        {
            Debug.Log("Load assets");

            GorillaTagger.Instance.thirdPersonCamera.active = false;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ColossalCheatMenuV2.Asset.startup");
            AssetBundle assetBundle = AssetBundle.LoadFromStream(stream);

            GameObject prefab = assetBundle.LoadAsset<GameObject>("startup");
            prefabInstance = GameObject.Instantiate(prefab);

            // dumbass alert
            defaultlocomotionlayers = GorillaLocomotion.Player.Instance.locomotionEnabledLayers;
            if (defaultlocomotionlayers == GorillaLocomotion.Player.Instance.locomotionEnabledLayers)
                GorillaLocomotion.Player.Instance.locomotionEnabledLayers = 0;

            prefabInstance.transform.position = new Vector3(trans.x + 2.5f, trans.y, trans.z);
            prefabInstance.transform.rotation = GorillaLocomotion.Player.Instance.transform.rotation;

            if (enviroment != null)
                enviroment.SetActive(false);

            assetBundle.Unload(false);
        }
        public static async void Accept()
        {
            GameObject.Find("Startup(Clone)").GetComponent<Animator>().SetTrigger("Agreed");

            await Task.Delay(2500);
            if (enviroment != null)
            {
                enviroment.SetActive(true);
                ballzandcock = true;
            }

            //GameObject.Find("Startup(Clone)").SetActive(false);

            GorillaLocomotion.Player.Instance.locomotionEnabledLayers = defaultlocomotionlayers;

            Menu.Menu.agreement = true;
        }
    }
}
