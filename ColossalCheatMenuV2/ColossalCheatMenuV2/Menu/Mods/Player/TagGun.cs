using Colossal.Menu;
using Colossal.Patches;
using Photon.Pun;
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
    public class TagGun : MonoBehaviour
    {
        private GameObject pointer;
        private LineRenderer radiusLine;
        private Material lineMaterial;
        public void Update()
        {
            if (PluginConfig.taggun && PhotonNetwork.InRoom)
            {
                //switch (PluginConfig.BeamColour)
                //{
                //    case 0:
                //        lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);
                //        break;
                //    case 1:
                //        lineMaterial.color = new Color(1f, 0f, 0f, 0.5f);
                //        break;
                //    case 2:
                //        lineMaterial.color = new Color(1f, 1f, 0f, 0.5f);
                //        break;
                //    case 3:
                //        lineMaterial.color = new Color(0f, 1f, 0f, 0.5f);
                //        break;
                //    case 4:
                //        lineMaterial.color = new Color(0f, 0f, 1f, 0.5f);
                //        break;
                //}

                if (pointer == null)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material = Boards.boardmat;
                }
                

                RaycastHit raycastHit2;
                LayerMask combinedLayerMask = GorillaLocomotion.Player.Instance.locomotionEnabledLayers | 16384;
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit2, float.PositiveInfinity, combinedLayerMask);
                pointer.transform.position = raycastHit2.point;

                if (SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand))
                {
                    if (radiusLine == null)
                    {
                        lineMaterial = new Material(Shader.Find("Sprites/Default"));
                        radiusLine = new GameObject("RadiusLine")
                        {
                            transform =
                            {
                                parent = pointer.transform
                            }
                        }.AddComponent<LineRenderer>();
                        radiusLine.positionCount = 2;
                        radiusLine.startWidth = 0.05f;
                        radiusLine.endWidth = 0.05f;
                        radiusLine.material = lineMaterial;
                    }
                    radiusLine.SetPosition(0, raycastHit2.point);
                    radiusLine.SetPosition(1, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    radiusLine.GetPosition(0);
                    if (DisableRig.disablerig)
                    {
                        DisableRig.disablerig = false;
                    }
                    GorillaTagger.Instance.offlineVRRig.transform.position = raycastHit2.point;
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = raycastHit2.point;
                    return;
                }
                if (!DisableRig.disablerig)
                {
                    DisableRig.disablerig = true;
                }
                if (radiusLine != null)
                {
                    UnityEngine.Object.Destroy(radiusLine);
                    radiusLine = null;
                    return;
                }
            }
            else
            {
                UnityEngine.Object.Destroy(holder.GetComponent<TagGun>());
                if (pointer != null)
                {
                    UnityEngine.Object.Destroy(pointer);
                }
            }
        }
    }
}
