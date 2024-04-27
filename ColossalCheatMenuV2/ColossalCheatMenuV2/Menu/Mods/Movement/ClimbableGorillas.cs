using BepInEx;
using Colossal.Menu;
using GorillaLocomotion.Climbing;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class ClimbableGorillas : MonoBehaviour
    {
        bool doonce = false;
        public void Update()
        {
            if (PluginConfig.ClimbableGorillas)
            {
                if (!doonce)
                {
                    foreach (GameObject Gos in Resources.FindObjectsOfTypeAll<GameObject>())
                        if (Gos.name == "BodyTrigger")
                            if (Gos.GetComponent<GorillaClimbable>() == null)
                                Gos.AddComponent<GorillaClimbable>();

                    doonce = true;
                }
                    
                
                //looks goofy as hell LMAO
            }
            else
            {
                foreach (GameObject Gos in Resources.FindObjectsOfTypeAll<GameObject>())
                    if (Gos.name == "BodyTrigger")
                        if (Gos.GetComponent<GorillaClimbable>() != null)
                            Destroy(Gos.GetComponent<GorillaClimbable>());

                doonce = false;

                Destroy(holder.GetComponent<ClimbableGorillas>());
            }
        }
    }
}
