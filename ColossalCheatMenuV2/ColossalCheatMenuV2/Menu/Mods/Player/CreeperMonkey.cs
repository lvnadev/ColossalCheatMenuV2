
using Colossal.Menu;
using Colossal.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class CreeperMonkey : MonoBehaviour
    {
        public void Update()
        {
            if (PluginConfig.creepermonkey)
            {
                if (Controls.LeftTrigger())
                {
                    float num = float.PositiveInfinity;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.isOfflineVRRig)
                        {
                            float sqrMagnitude = (vrrig.transform.position - GorillaLocomotion.Player.Instance.transform.position).sqrMagnitude;
                            if (sqrMagnitude < num)
                            {
                                num = sqrMagnitude;
                                GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(vrrig.headMesh.transform);
                                GorillaTagger.Instance.rightHandTransform.position = vrrig.headMesh.transform.position;
                            }
                        }
                    }
                }
            }
            else
                Destroy(holder.GetComponent<CreeperMonkey>());
        }
    }
}
