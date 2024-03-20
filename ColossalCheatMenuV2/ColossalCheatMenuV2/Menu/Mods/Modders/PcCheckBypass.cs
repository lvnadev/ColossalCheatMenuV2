using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class PcCheckBypass : MonoBehaviour {
        public void Update() {
            if (PluginConfig.pccheckbypass)
            {
                if (GameObject.Find("Mountain/Geometry/goodigloo").active)
                {
                    GameObject.Find("Mountain/Geometry/goodigloo").SetActive(false);
                    return;
                }
            }
            else
            {
                if (!GameObject.Find("Mountain/Geometry/goodigloo").active)
                {
                    GameObject.Find("Mountain/Geometry/goodigloo").SetActive(true);
                }
                UnityEngine.Object.Destroy(GorillaTagger.Instance.GetComponent<PcCheckBypass>());
            }
        }
    }
}
