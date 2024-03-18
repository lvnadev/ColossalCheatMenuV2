using Colossal.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class FreezeMonkey : MonoBehaviour
    {
        public void Update()
        {
            /*if (PluginConfig.freezemonkey)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    if(DisableRig.disablerig)
                        DisableRig.disablerig = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.transform.position;
                    GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaLocomotion.Player.Instance.transform.rotation;
                }
                else
                {
                    if (!DisableRig.disablerig)
                        DisableRig.disablerig = true;
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<FreezeMonkey>());
            }*/
        }
    }
}
