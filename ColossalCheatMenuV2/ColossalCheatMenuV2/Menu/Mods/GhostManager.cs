using Photon.Pun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR.Extras;

<<<<<<< Updated upstream
namespace ColossalCheatMenuV2.Menu.Mods
=======
namespace Colossal.Menu
>>>>>>> Stashed changes
{
    internal class GhostManager
    {
        private static List<GameObject> ghosts = new List<GameObject>();

        public static GameObject SpawnGhost(int colorOption)
        {
            GameObject ghost = GameObject.Instantiate(GorillaTagger.Instance.offlineVRRig.gameObject);
            var vrrig = ghost.GetComponent<VRRig>();

<<<<<<< Updated upstream
            Color32 ghostColor;
            switch (colorOption)
            {
                case 1:
                    ghostColor = new Color32(204, 51, 255, 60);
                    break;
                case 2:
                    ghostColor = new Color32(68, 51, 255, 60);
=======

            switch (Menu.ColourSettings[4].stringsliderind)
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
            switch (Menu.ColourSettings[1].stringsliderind)
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
>>>>>>> Stashed changes
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
