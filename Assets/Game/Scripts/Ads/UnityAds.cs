using UnityEngine;
using System.Collections;
using System;
//using UnityEngine.Advertisements;
  /*
namespace Ads {
    public class UnityAds : Partner
    {
                
		const string TAG = "video";
		const string TAG_REVARD = "rewardedVideo";

		public static string tag(PLACEMENT type) {
            if (type == PLACEMENT.FAILED_GAME) {
				return TAG_REVARD;
			} else {
				return TAG;
			}
		}

		public int priority {
			get {return 10; }
		}

		public bool Ready (PLACEMENT type) {
            return Advertisement.IsReady(tag(type));
        }
		
		public IEnumerator Play(PLACEMENT type)
        {
            bool cbCalled = false;
			if (Ready(type)) {
                ShowOptions callback = new ShowOptions() {
                    resultCallback = r =>
                    {
                        switch (r) {
                            case ShowResult.Finished:  
                                break;
                            case ShowResult.Skipped:   
                                break;
                            default: 
                                break;
                        }
                        cbCalled = true;
                    }
                };

				Advertisement.Show(tag(type), callback);
                yield return new WaitUntil(() => cbCalled);
            }              
        }
    }
}
   */