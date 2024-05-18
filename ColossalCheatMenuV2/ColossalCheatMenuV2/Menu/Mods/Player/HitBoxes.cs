
using Colossal.Menu;
using Colossal.Patches;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class HitBoxes : MonoBehaviour
    {
        public static float ammount;

        private GameObject visualizerL;
        private GameObject visualizerR;
        private static byte opacity;
        private static Color color;
        public void Update()
        {
            if(PluginConfig.hitboxes)
            {
                switch(PluginConfig.hitboxesradius)
                {
                    case 0:
                        ammount = 0.05f;
                        break;
                    case 1:
                        ammount = 0.07f;
                        break;
                    case 2:
                        ammount = 0.09f;
                        break;
                    case 3:
                        ammount = 0.11f;
                        break;
                    case 4:
                        ammount = 0.13f;
                        break;
                    case 5:
                        ammount = 0.15f;
                        break;
                    case 6:
                        ammount = 0.3f;
                        break;
                }


                switch (PluginConfig.HitBoxesOpacity)
                {
                    case 0:
                        opacity = 100;
                        break;
                    case 1:
                        opacity = 80;
                        break;
                    case 2:
                        opacity = 60;
                        break;
                    case 3:
                        opacity = 30;
                        break;
                    case 4:
                        opacity = 20;
                        break;
                    case 5:
                        opacity = 0;
                        break;
                }
                switch (PluginConfig.HitBoxesColour)
                {
                    case 0:
                        color = new Color32(204, 51, 255, opacity);
                        break;
                    case 1:
                        color = new Color32(255, 0, 0, opacity);
                        break;
                    case 2:
                        color = new Color32(255, 255, 0, opacity);
                        break;
                    case 3:
                        color = new Color32(0, 255, 0, opacity);
                        break;
                    case 4:
                        color = new Color32(64, 255, 0, opacity);
                        break;
                    case 5:
                        color = new Color32(0, 0, 255, opacity);
                        break;
                    default:
                        color = new Color32(255, 255, 255, 255);
                        break;
                }

                if (visualizerL == null)
                {
                    visualizerL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(visualizerL.GetComponent<Collider>());

                    visualizerL.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                    visualizerL.transform.SetParent(GorillaLocomotion.Player.Instance.leftControllerTransform);
                    visualizerL.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position;
                }
                if (visualizerR == null)
                {
                    visualizerR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(visualizerR.GetComponent<Collider>());

                    visualizerR.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                    visualizerR.transform.SetParent(GorillaLocomotion.Player.Instance.rightControllerTransform);
                    visualizerR.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                }

                if (visualizerL != null)
                {
                    visualizerL.GetComponent<Renderer>().material.color = color;
                    visualizerL.transform.localScale = new Vector3(ammount, ammount, ammount);
                }
                if (visualizerR != null)
                {
                    visualizerR.GetComponent<Renderer>().material.color = color;
                    visualizerR.transform.localScale = new Vector3(ammount, ammount, ammount);
                }
            }
            else
            {
                if (visualizerR != null)
                    Destroy(visualizerR);
                if (visualizerL != null)
                    Destroy(visualizerL);

                Destroy(holder.GetComponent<HitBoxes>());
            }
        }
    }

    [HarmonyPatch(typeof(GorillaTagger), "sphereCastRadius", MethodType.Getter)]
    public class HitBoxesPatch
    {
        static void Postfix(ref float __result)
        {
            if (PluginConfig.hitboxes)
                __result = HitBoxes.ammount;
        }
    }
}
