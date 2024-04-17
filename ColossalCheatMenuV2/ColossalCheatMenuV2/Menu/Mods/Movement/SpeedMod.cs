using Mono.Cecil.Cil;
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
    public class SpeedMod : MonoBehaviour
    {
        public void Update()
        {
            if(Menu.Menu.Speed[0].stringsliderind != null)
            {
                switch (Menu.Menu.Speed[0].stringsliderind)
                {
                    case 1:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                        break;
                    case 2:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                        break;
                    case 3:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                        break;
                    case 4:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                        break;
                    case 5:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                        break;
                    case 6:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                        break;
                    case 7:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                        break;
                    case 8:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                        break;
                    //case 9:
                    //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.8f;
                    //    break;
                    //case 10:
                    //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                    //    break;
                    //case 11:
                    //    GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
                    //    break;
                }
                if (ControllerInputPoller.instance.leftGrab)
                {
                    switch (Menu.Menu.Speed[1].stringsliderind)
                    {
                        case 1:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                            break;
                        case 2:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                            break;
                        case 3:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                            break;
                        case 4:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                            break;
                        case 5:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                            break;
                        case 6:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                            break;
                        case 7:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                            break;
                        case 8:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                            break;
                            //case 9:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.8f;
                            //    break;
                            //case 10:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                            //    break;
                            //case 11:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
                            //    break;
                    }
                }
                else if (!ControllerInputPoller.instance.rightGrab && Menu.Menu.Speed[1].stringsliderind != 0)
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                    else
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;

                if (ControllerInputPoller.instance.rightGrab)
                {
                    switch (Menu.Menu.Speed[2].stringsliderind)
                    {
                        case 1:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                            break;
                        case 2:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                            break;
                        case 3:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                            break;
                        case 4:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                            break;
                        case 5:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                            break;
                        case 6:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                            break;
                        case 7:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                            break;
                        case 8:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                            break;
                        //i am very good at making stuff undetected -Lars
                        //case 9:
                        //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.8f;
                        //    break;
                        //case 10:
                        //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                        //    break;
                        //case 11:
                        //    GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
                        //    break;
                    }
                }
                else if (!ControllerInputPoller.instance.leftGrab && Menu.Menu.Speed[1].stringsliderind != 0)
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                    else
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            }
        }
    }
}
