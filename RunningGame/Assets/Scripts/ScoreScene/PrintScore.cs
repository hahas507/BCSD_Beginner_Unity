using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    private Text[] ArrText = null;

    private void Awake()
    {
        LogicValue.ScoreCheck();
        LogicValue.ScoreLoad();

        ArrText = GetComponentsInChildren<Text>();
    }

    private void Update()
    {
    }
}