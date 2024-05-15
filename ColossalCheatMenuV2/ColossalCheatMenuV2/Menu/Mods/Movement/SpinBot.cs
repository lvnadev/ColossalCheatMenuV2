
﻿using Colossal.Menu;
using Colossal.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class SpinBot : MonoBehaviour
    {
        private GameObject ghost;
        public void Update()
        {
            if (PluginConfig.SpinBot)
            {
                //if (ghost == null)
                //    ghost = GhostManager.SpawnGhost();

                //if (ghost != null)
                //{
                //    if (DisableRig.disablerig)
                //        DisableRig.disablerig = false;

                //    VRRig vrrig = ghost.GetComponent<VRRig>();
                //    vrrig.mainSkin.material.color = GhostManager.ghostColor;
                //    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");

                //    ghost.transform.Rotate(Vector3.up * 150 * Time.deltaTime);
                //}
            }
            else
            {
                //GorillaTagger.Instance.offlineVRRig.transform.SetParent(null);

                //if (ghost != null)
                //    GhostManager.DestroyGhost(ghost);

                Destroy(GorillaTagger.Instance.GetComponent<SpinBot>());
            }

        }
    }
}
