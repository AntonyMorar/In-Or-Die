﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraVignette : MonoBehaviour
{
    private PostProcessVolume ppv;
    private bool toActive;
    private bool toDeactive;

    private void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if (toActive && ppv.weight >= 1)
        {
            toActive = false;
        }

        if(toDeactive && ppv.weight <= 0)
        {
            toDeactive = false;
        }

        if (toActive)
        {
            ppv.weight += 0.08f;
        }
        if (toDeactive)
        {
            ppv.weight -= 0.05f;
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
