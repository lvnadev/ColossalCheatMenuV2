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
    class Startup : MonoBehaviour
    {
        public static GameObject prefabInstance;
        private static float timer;
        private static LayerMask defaultlocomotionlayers;

        private static GameObject enviroment = GameObject.Find("Environment Objects");
        public static bool startani = false;
        public static void LoadAssets()
        {
            Debug.Log("Load assets");

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ColossalCheatMenuV2.Asset.startup");
            AssetBundle assetBundle = AssetBundle.LoadFromStream(stream);

            GameObject prefab = assetBundle.LoadAsset<GameObject>("startup");
            prefabInstance = GameObject.Instantiate(prefab);

            // dumbass alert
            defaultlocomotionlayers = GorillaLocomotion.Player.Instance.locomotionEnabledLayers;
            if (defaultlocomotionlayers == GorillaLocomotion.Player.Instance.locomotionEnabledLayers)
                GorillaLocomotion.Player.Instance.locomotionEnabledLayers = 0;

            prefabInstance.transform.position = new Vector3(GorillaLocomotion.Player.Instance.transform.position.x, GorillaLocomotion.Player.Instance.transform.position.y, GorillaLocomotion.Player.Instance.transform.position.z - 2.5f);
            prefabInstance.transform.rotation = GorillaLocomotion.Player.Instance.transform.rotation;

            if (enviroment != null)
                enviroment.SetActive(false);

            assetBundle.Unload(false);
        }
        public static async void Accept()
        {
            prefabInstance.GetComponent<Animator>().SetTrigger("Agreed");

            await Task.Delay(1500);

            GameObject.Find("Startup(Clone)").SetActive(false);

            if (enviroment != null)
                enviroment.SetActive(true);

            GorillaLocomotion.Player.Instance.locomotionEnabledLayers = defaultlocomotionlayers;

            Menu.Menu.agreement = true;
        }
        //public void Update()
        //{
        //    timer += Time.deltaTime;

        //    if (prefabInstance != null && !Menu.Menu.agreement && startani)
        //    {
        //        prefabInstance.GetComponent<Animator>().SetTrigger("Agreed");

        //        if (timer >= 1.5f)
        //        {
        //            prefabInstance.SetActive(false);

        //            if (enviroment != null)
        //                enviroment.SetActive(true);

        //            GorillaLocomotion.Player.Instance.locomotionEnabledLayers = defaultlocomotionlayers;

        //            Menu.Menu.agreement = true;
        //        }
        //    }
        //    else
        //        prefabInstance = GameObject.Find("Startup(Clone)");
        //}
    }
}
