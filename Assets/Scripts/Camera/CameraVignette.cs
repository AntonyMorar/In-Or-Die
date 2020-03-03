using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraVignette : MonoBehaviour
{
    [SerializeField]private PostProcessVolume vignetteProfile;

    private bool toActive;
    private bool toDeactive;

    private void Update()
    {
        if (toActive && vignetteProfile.weight >= 1)
        {
            toActive = false;
        }

        if(toDeactive && vignetteProfile.weight <= 0)
        {
            toDeactive = false;
        }

        if (toActive)
        {
            vignetteProfile.weight += 0.08f;
        }
        if (toDeactive)
        {
            vignetteProfile.weight -= 0.05f;
        }
    }

    public void ActiveVignette()
    {
        toActive = true;
        toDeactive = false;
    }

    public void DeactiveVignette()
    {
        toDeactive = true;
        toActive = false;
    }

}
