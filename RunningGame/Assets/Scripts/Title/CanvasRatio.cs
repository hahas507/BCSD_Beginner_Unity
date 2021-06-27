using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRatio : MonoBehaviour
{
    [SerializeField]
    private Vector2 DefaultSize;

    [SerializeField]
    private Camera Cam;

    private void Awake()
    {
        if (null == Cam)
        {
            Debug.LogError("null == Cam");
            return;
        }

        CanvasScaler CS = GetComponent<CanvasScaler>();

        if ((DefaultSize.x / DefaultSize.y) > (Cam.pixelWidth / Cam.pixelHeight))
        {
            CS.matchWidthOrHeight = 0f;
        }
        else
        {
            CS.matchWidthOrHeight = 1f;
        }
        //Debug.Log(Cam.pixelWidth.ToString() + " " + Cam.pixelHeight.ToString());
    }

    private void Update()
    {
    }
}