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
                switch (Menu.Menu.MiscSettings[2].stringsliderind)
                {
                    case 1:
                        lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);
                        break;
                    case 2:
                        lineMaterial.color = new Color(1f, 0f, 0f, 0.5f);
                        break;
                    case 3:
                        lineMaterial.color = new Color(1f, 1f, 0f, 0.5f);
                        break;
                    case 4:
                        lineMaterial.color = new Color(0f, 1f, 0f, 0.5f);
                        break;
                    case 5:
                        lineMaterial.color = new Color(0f, 0f, 1f, 0.5f);
                        break;
                }

                if (this.pointer == null)
                {
                    this.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(this.pointer.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(this.pointer.GetComponent<SphereCollider>());
                    this.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    this.pointer.GetComponent<Renderer>().material = Boards.boardmat;
                }
                RaycastHit raycastHit;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position - GorillaTagger.Instance.rightHandTransform.up, -GorillaTagger.Instance.rightHandTransform.up, out raycastHit);
                this.pointer.transform.position = raycastHit.point;
                RaycastHit raycastHit2;
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit2);
                if (SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand))
                {
                    if (this.radiusLine == null)
                    {
                        this.lineMaterial = new Material(Shader.Find("Sprites/Default"));
                        this.radiusLine = new GameObject("RadiusLine")
                        {
                            transform =
                            {
                                parent = this.pointer.transform
                            }
                        }.AddComponent<LineRenderer>();
                        this.radiusLine.positionCount = 2;
                        this.radiusLine.startWidth = 0.05f;
                        this.radiusLine.endWidth = 0.05f;
                        this.radiusLine.material = this.lineMaterial;
                    }
                    this.radiusLine.SetPosition(0, raycastHit2.point);
                    this.radiusLine.SetPosition(1, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    this.radiusLine.GetPosition(0);
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
                if (this.radiusLine != null)
                {
                    UnityEngine.Object.Destroy(this.radiusLine);
                    this.radiusLine = null;
                    return;
                }
            }
            else
            {
                UnityEngine.Object.Destroy(GorillaTagger.Instance.GetComponent<TagGun>());
                if (this.pointer != null)
                {
                    UnityEngine.Object.Destroy(this.pointer);
                }
            }
        }
    }
}
