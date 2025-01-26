using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    void Awake()
    {
        float targetHeight = 1334f;
        if (750f * Screen.height > 1334f * Screen.width)
        {
            targetHeight = 750f * Screen.height / Screen.width;
        }

        Camera.main.fieldOfView *= (targetHeight / 1334f);
    }
}
