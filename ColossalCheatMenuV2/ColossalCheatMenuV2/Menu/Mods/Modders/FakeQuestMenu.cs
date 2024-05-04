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
