using Photon.Pun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR.Extras;

namespace Colossal
{
    internal class GhostManager : MonoBehaviour
    {
        private static List<GameObject> ghosts = new List<GameObject>();
        private static byte opacity;
        public static Color32 ghostColor;

        public static GameObject SpawnGhost()
        {
            GameObject ghost = GameObject.Instantiate(GorillaTagger.Instance.offlineVRRig.gameObject);
            var vrrig = ghost.GetComponent<VRRig>();


            switch (Menu.Menu.Colours[4].stringsliderind)
            {
                case 0:
                    opacity = 0;
                    break;
                case 1:
                    opacity = 20;
                    break;
                case 2:
                    opacity = 30;
                    break;
                case 3:
                    opacity = 60;
                    break;
                case 4:
                    opacity = 80;
                    break;
                case 5:
                    opacity = 100;
                    break;
            }
            switch (Menu.Menu.Colours[1].stringsliderind)
            {
                case 0:
                    ghostColor = new Color32(204, 51, 255, opacity);
                    break;
                case 1:
                    ghostColor = new Color32(255, 0, 0, opacity);
                    break;
                case 2:
                    ghostColor = new Color32(255, 255, 0, opacity);
                    break;
                case 3:
                    ghostColor = new Color32(0, 255, 0, opacity);
                    break;
                case 4:
                    ghostColor = new Color32(64, 255, 0, opacity);
                    break;
                case 5:
                    ghostColor = new Color32(0, 0, 255, opacity);
                    break;
                default:
                    ghostColor = new Color32(255, 255, 255, 255);
                    break;
            }


            GameObject.Destroy(vrrig.GetComponent<Rigidbody>());


            if (!PluginConfig.csghostclient)
            {
                vrrig.mainSkin.enabled = false;
                vrrig.headMesh.active = false;
                vrrig.showName = false;
            }
            else
            {
                vrrig.mainSkin.material.color = ghostColor;
                vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                if (!vrrig.headMesh.active)
                    vrrig.headMesh.active = true;
                if(!vrrig.mainSkin.enabled)
                    vrrig.mainSkin.enabled = true;
                if(!vrrig.showName)
                    vrrig.showName = true;
            }


            ghosts.Add(ghost);
            return ghost;
        }
        public static void DestroyGhost(GameObject ghost)
        {
            if (ghosts.Contains(ghost))
            {
                ghosts.Remove(ghost);
                GameObject.Destroy(ghost);
            }
        }
    }
}
