using Colossal.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColossalCheatMenuV2.Mods
{
    class NearPulse : MonoBehaviour
    {
        public float Distance;
        public void Update()
        {
            switch (PluginConfig.NearPulseDistance)
            {
                case 0:
                    Distance = 5f;
                    break;
                case 1:
                    Distance = 10f;
                    break;
                case 2:
                    Distance = 15f;
                    break;
                case 3:
                    Distance = 20f;
                    break;
            }
            if (PluginConfig.NearPulse)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.isOfflineVRRig && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.ToLower().Contains("fected"))
                    {
                        if (vrrig.mainSkin.material.name.ToLower().Contains("fected"))
                        {
                            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddExplosionForce(50f, vrrig.head.headTransform.position, PluginConfig.NearPulseDistance + 5 * 10);
                        }
                    }
                }
            }
        }
    }
}