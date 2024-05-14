using Colossal.Menu;
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
        private float speed;
        public void Update()
        {
            if (PluginConfig.excelfly)
            {
                switch (PluginConfig.ExcelFlySpeed)
                {
                    case 0:
                        if(speed != 8)
                            speed = 8;
                        break;
                    case 1:
                        if (speed != 6)
                            speed = 6;
                        break;
                    case 2:
                        if (speed != 4)
                            speed = 4;
                        break;
                    case 3:
                        if (speed != 2)
                            speed = 2;
                        break;
                    case 4:
                        if (speed != 1)
                            speed = 1;
                        break;
                }

                //speed *= GorillaLocomotion.Player.Instance.scale; it works but its reversed????? (slower when bigger)

                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += -GorillaLocomotion.Player.Instance.leftControllerTransform.right / speed;
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += GorillaLocomotion.Player.Instance.rightControllerTransform.right / speed;
            }
            else
            {
                Destroy(holder.GetComponent<ExcelFly>());
            }
        }
    }
}
