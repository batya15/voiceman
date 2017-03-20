using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ads {
    public static class Manager {   

        public static List<Partner> parters = null;

        public static void Init() {
            if (parters == null) {
                parters = new List<Partner>() {        
                    new AppodealPartner()
                };
            }
        }

        static public bool Ready(PLACEMENT e) {
            return GetAwalableParnersForEventAds(e).Count > 0;
        }

        static public IEnumerator Play(PLACEMENT e, System.Action<bool> cb = null) {
            List<Partner> awalableParners = GetAwalableParnersForEventAds(e);
            if (awalableParners.Count > 0) {
                Partner p = awalableParners.OrderBy(i => i.priority).First();
                yield return p.Play(e);
                if (e != PLACEMENT.BANER) {   
                    Broadcaster.SendEvent("PlayAds");
                }    
            } else {
                Debug.Log(e + " - not found ads");
            }
        }

        static List<Partner> GetAwalableParnersForEventAds(PLACEMENT e) {
            List<Partner> result = new List<Partner>();
            if (parters != null) {
                result = parters.Where(p => p.Ready(e)).ToList();
            }

            return result;
        }
    }

}


