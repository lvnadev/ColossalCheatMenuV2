using ColossalCheatMenuV2.Patches.MakeItFuckingWork;
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
    public class TFly : MonoBehaviour
    {
        public void Update()
        {
            if (PluginConfig.tfly)
            {
                bool leftControllerSecondaryButton = ControllerInputPoller.instance.leftControllerSecondaryButton;
                bool rightTrigger = StarrySteamControllerPatch.GetRightTrigger();
                if (leftControllerSecondaryButton)
                {
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = new Vector3(0f, 0.01f, 0f);
                }
                if (rightTrigger)
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.leftControllerTransform.forward * 0.45f;
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
                    return;
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<TFly>());
            }
        }
    }
}
