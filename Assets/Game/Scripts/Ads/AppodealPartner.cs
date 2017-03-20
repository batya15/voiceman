using System;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System.Collections;

namespace Ads {
	public class AppodealPartner: Partner, ISkippableVideoAdListener, IRewardedVideoAdListener {

		#if UNITY_IOS 
		string APP_KEY = "";
		#else
		string APP_KEY = "a01b9829151af0b897fb60f24183f870b4e5f5abc36e53f9";
		#endif

		public int priority {
			get {return 0; }
		}

		public AppodealPartner () {
				#if TEST_BUILD
				Appodeal.setLogging(true);
				//Appodeal.setTesting(true);
				#endif
				Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
				Appodeal.initialize (APP_KEY, Appodeal.SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO | Appodeal.BANNER_BOTTOM);


				Appodeal.setSkippableVideoCallbacks (this);
				Appodeal.setRewardedVideoCallbacks(this);
		}

		public void onSkippableVideoLoaded() { Debug.Log("Skippable Video loaded"); }
		public void onSkippableVideoFailedToLoad() { Debug.Log("Skippable Video failed"); }
		public void onSkippableVideoShown() { Debug.Log("Skippable Video opened"); }
		public void onSkippableVideoClosed() { result = true; }
		public void onSkippableVideoFinished() { result = true; }

		public void onRewardedVideoLoaded() { Debug.Log("Rewarded Video loaded"); }
		public void onRewardedVideoFailedToLoad() { Debug.Log("Rewarded Video failed"); }
		public void onRewardedVideoShown() { Debug.Log("Rewarded Video opened"); }
		public void onRewardedVideoClosed() { result = true; }
		public void onRewardedVideoFinished(int amount, string name) { result = true; }


        public static int tag(PLACEMENT type) {
            if (type == PLACEMENT.FAILED_GAME) {
                return Appodeal.SKIPPABLE_VIDEO;
            } else if (type == PLACEMENT.BANER) {
                return Appodeal.BANNER_BOTTOM;
            } else { 
                return Appodeal.REWARDED_VIDEO;
            }
        }

        public bool Ready (PLACEMENT type) {
            return Appodeal.isLoaded(tag(type));
		}

		bool result = false;

		public IEnumerator Play(PLACEMENT type) {
			result = false;
			if (Ready (type)) {              
				Appodeal.show(tag(type));
				yield return new WaitWhile (() => !result);
			}  
		} 
	}
}

