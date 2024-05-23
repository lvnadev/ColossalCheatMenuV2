using Colossal.Menu;
using Colossal.Patches;
using Photon.Pun;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Valve.VR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class TagGun : MonoBehaviour
    {
        private GameObject pointer;
        private LineRenderer radiusLine;
        private Material lineMaterial;

        private void Update()
        {
            if (PluginConfig.taggun && PhotonNetwork.InRoom)
            {
                if (GorillaLocomotion.Player.Instance == null)
                    return;

                HandlePointer();
                HandleTagging();
            }
            else
            {
                DestroyComponents();
            }
        }

        private void HandlePointer()
        {
            if (pointer == null)
            {
                pointer = CreatePointer();
            }

            RaycastHit hit;
            if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out hit, float.PositiveInfinity, GorillaLocomotion.Player.Instance.locomotionEnabledLayers | 16384))
            {
                pointer.transform.position = hit.point;
            }
        }

        private void HandleTagging()
        {
            if (SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand))
            {
                InitializeRadiusLine();
                UpdateRadiusLine();
                EnableDisableRig(false);
                UpdatePlayerPosition();
            }
            else
            {
                EnableDisableRig(true);
                DestroyRadiusLine();
            }
        }

        private GameObject CreatePointer()
        {
            GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Object.Destroy(pointer.GetComponent<Rigidbody>());
            Object.Destroy(pointer.GetComponent<SphereCollider>());
            pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            pointer.GetComponent<Renderer>().material = Boards.boardmat;
            return pointer;
        }

        private void InitializeRadiusLine()
        {
            if (radiusLine == null && pointer != null)
            {
                lineMaterial = new Material(Shader.Find("Sprites/Default"));
                radiusLine = new GameObject("RadiusLine").AddComponent<LineRenderer>();
                radiusLine.positionCount = 2;
                radiusLine.startWidth = 0.05f;
                radiusLine.endWidth = 0.05f;
                radiusLine.material = lineMaterial;
                radiusLine.transform.parent = pointer.transform;
            }
        }

        private void UpdateRadiusLine()
        {
            RaycastHit hit;
            if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out hit, float.PositiveInfinity, GorillaLocomotion.Player.Instance.locomotionEnabledLayers | 16384))
            {
                if (radiusLine != null)
                {
                    radiusLine.SetPosition(0, hit.point);
                    radiusLine.SetPosition(1, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                }
            }
        }

        private void EnableDisableRig(bool disable)
        {
            DisableRig.disablerig = disable;
        }

        private void UpdatePlayerPosition()
        {
            RaycastHit hit;
            if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out hit, float.PositiveInfinity, GorillaLocomotion.Player.Instance.locomotionEnabledLayers | 16384))
            {
                if (GorillaTagger.Instance != null && GorillaTagger.Instance.offlineVRRig != null)
                {
                    GorillaTagger.Instance.offlineVRRig.transform.position = hit.point;
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = hit.point;
                }
            }
        }

        private void DestroyRadiusLine()
        {
            if (radiusLine != null)
            {
                Destroy(radiusLine.gameObject);
                radiusLine = null;
            }

            if (lineMaterial != null)
            {
                Material.Destroy(lineMaterial);
                lineMaterial = null;
            }
        }

        private void DestroyComponents()
        {
            if (holder != null)
                Destroy(holder.GetComponent<TagGun>());

            if (pointer != null)
            {
                Destroy(pointer);
                pointer = null;
            }
        }
    }
}