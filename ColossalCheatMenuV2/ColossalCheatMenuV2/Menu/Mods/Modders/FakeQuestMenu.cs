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
        public void Update()
        {
            if (PluginConfig.fakequestmenu)
            {
                if(!GorillaLocomotion.Player.Instance.inOverlay)
                    GorillaLocomotion.Player.Instance.inOverlay = true;
            }
            else
            {
                if(GorillaLocomotion.Player.Instance.inOverlay)
                    GorillaLocomotion.Player.Instance.inOverlay = false;

                Destroy(holder.GetComponent<FakeQuestMenu>());
            }
        }
    }
}
