using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace GameServices
{
    public class AdService : MonoBehaviour, IService
    {
#if UNITY_IOS
        private string gameId = "3485817";
#elif UNITY_ANDROID
        private string gameId = "3485816";
#endif

        private string placementID = "video";
        private bool testMode = true;

        public void Initialize()
        {

#if UNITY_ANDROID || UNITY_IOS
            Advertisement.Initialize(gameId, testMode);
#else
            Debug.LogWarning("The current platform not support monetization");
#endif
        }

        public void DisplayAd()
        {
            if (!Advertisement.IsReady(placementID))
            {
                Debug.LogWarning("Placement <" + placementID + "> not ready to display.");
                return;
            }

            Advertisement.Show(placementID);
        }

    }

}