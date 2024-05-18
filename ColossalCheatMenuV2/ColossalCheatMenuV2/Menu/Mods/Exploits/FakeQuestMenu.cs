using Colossal.Menu;
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
    public class FakeQuestMenu : MonoBehaviour
    {
        public static bool fakeQuestMenuFinger = false;
        public void Update()
        {
            if (PluginConfig.fakequestmenu)
            {
                if(!GorillaLocomotion.Player.Instance.inOverlay)
                    GorillaLocomotion.Player.Instance.inOverlay = true;

                if (!fakeQuestMenuFinger)
                    fakeQuestMenuFinger = true;

                if (GorillaTagger.Instance.rightHandTransform.transform.rotation != new Quaternion(0, 0, 0, 0))
                    GorillaTagger.Instance.rightHandTransform.transform.rotation = new Quaternion(0, 0, 0, 0);
                if (GorillaTagger.Instance.leftHandTransform.transform.rotation != new Quaternion(0, 0, 0, 0))
                    GorillaTagger.Instance.leftHandTransform.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                if(GorillaLocomotion.Player.Instance.inOverlay)
                    GorillaLocomotion.Player.Instance.inOverlay = false;

                if (fakeQuestMenuFinger)
                    fakeQuestMenuFinger = false;

                Destroy(holder.GetComponent<FakeQuestMenu>());
            }
        }
    }
}
