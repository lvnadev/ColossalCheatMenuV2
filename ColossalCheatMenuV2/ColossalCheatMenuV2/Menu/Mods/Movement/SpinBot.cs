<<<<<<< Updated upstream
﻿using Colossal.Patches;
using ColossalCheatMenuV2.Menu.Mods;
=======
﻿using Colossal.Menu;
using Colossal.Patches;
>>>>>>> Stashed changes
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
            //if (PluginConfig.SpinBot)
            //{
            //    if (ghost == null)
            //        ghost = GhostManager.SpawnGhost();

            //    if (ghost != null)
            //    {
            //        if (DisableRig.disablerig)
            //            DisableRig.disablerig = false;

            //        //Spinning SS rig
            //        GorillaTagger.Instance.offlineVRRig.transform.position = ghost.transform.position;
            //        GorillaTagger.Instance.offlineVRRig.transform.Rotate(0, 0, 50 * Time.deltaTime);

            //        //Spinning CS rig
            //        VRRig vrrig = ghost.GetComponent<VRRig>();
            //        vrrig.mainSkin.material.color = GhostManager.ghostColor;
            //        vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");

            //        //ghost.transform.Rotate(0, 0, 50 * Time.deltaTime);
            //    }
            //}
            //else
            //{
            //   if (ghost != null)
            //        GhostManager.DestroyGhost(ghost);

            //    Destroy(GorillaTagger.Instance.GetComponent<SpinBot>());
            //}
        }
    }
}
