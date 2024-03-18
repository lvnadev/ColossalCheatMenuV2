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
    public class ExcelFly : MonoBehaviour
    {
        public void Update()
        {
            if (PluginConfig.excelfly)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += -GorillaLocomotion.Player.Instance.leftControllerTransform.right / 2f;
                }
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += GorillaLocomotion.Player.Instance.rightControllerTransform.right / 2f;
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<ExcelFly>());
            }
        }
    }
}
