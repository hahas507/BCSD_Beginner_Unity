using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text TextCom = null;

    private void Start()
    {
        TextCom = GetComponent<Text>();
        if (null == TextCom)
        {
            Debug.LogError("null == TextCom(Start)");
            return;
        }
    }

    private void Update()
    {
        if (null == TextCom)
        {
            Debug.LogError("null == TextCom (update)");
            return;
        }

        TextCom.text = LogicValue.Score.ToString();
    }
}