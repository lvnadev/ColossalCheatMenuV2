using Colossal.Menu;
using Colossal.Patches;
using GorillaExtensions;
using Photon.Pun;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using static Colossal.Plugin;


namespace Colossal.Mods
{
    public class Desync : MonoBehaviour
    {
        private GameObject ghost;
        private float prevTime;
        private Vector3 prevPos;
        private Quaternion prevRot;
        private Transform leftHand;
        private Transform rightHand;
        private Vector3 prevRightPos;
        private Vector3 prevLeftPos;
        private Quaternion prevRightRot;
        private Quaternion prevLeftRot;

        private void Update()
        {
            if (PluginConfig.desync && Time.time - prevTime >= (1 / 28) && Time.time - prevTime >= (PhotonNetwork.GetPing() / 500))
            {
                if (ghost == null)
                    ghost = GhostManager.SpawnGhost();

                var vrRig = ghost.GetComponent<VRRig>();
                ghost.transform.SetPositionAndRotation(prevPos, prevRot);

                if (leftHand == null || rightHand == null)
                {
                    leftHand = vrRig.leftHandPlayer.transform;
                    rightHand = vrRig.rightHandPlayer.transform;
                }

                leftHand.SetPositionAndRotation(prevLeftPos, prevLeftRot);
                rightHand.SetPositionAndRotation(prevRightPos, prevRightRot);

                vrRig.leftHandPlayer.Pause();
                vrRig.rightHandPlayer.Pause();
                vrRig.mainSkin.material.color = GhostManager.ghostColor;
                vrRig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                vrRig.enabled = false;

                var offlineVRRig = GorillaTagger.Instance.offlineVRRig;
                prevPos = offlineVRRig.transform.position;
                prevRot = offlineVRRig.transform.rotation;
                prevLeftPos = offlineVRRig.leftHandTransform.position;
                prevLeftRot = offlineVRRig.leftHandTransform.rotation;
                prevRightPos = offlineVRRig.rightHandTransform.position;
                prevRightRot = offlineVRRig.rightHandTransform.rotation;

                prevTime = Time.time;
            }
            else
            {
                if (!DisableRig.disablerig)
                    DisableRig.disablerig = true;

                if (ghost != null)
                    GhostManager.DestroyGhost(ghost);

                Destroy(holder.GetComponent<Desync>());
            }
        }
    }
}