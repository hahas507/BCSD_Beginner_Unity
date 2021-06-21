using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    private void Awake()
    {
        //판자가 만들어졌다
        //이제 코인을 만든다.
        if (null == LogicValue.CoinPrefab)
        {
            Debug.LogError("null == LogicValue.CoinPrefab");
            Destroy(gameObject);
            return;
        }

        int CoinCount = (int)transform.localScale.x;
        float CoinScale = ((int)transform.localScale.x) * 0.5f;

        for (int i = 0; i < CoinCount; i++)
        {
            GameObject NewCoin = GameObject.Instantiate(LogicValue.CoinPrefab);
            NewCoin.transform.position = transform.position + Vector3.up;
            NewCoin.transform.position += Vector3.right * (i + 0.5f);
            NewCoin.transform.position += (Vector3.left * CoinScale);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (PlayerScript.PlayerPos.x - transform.position.x >= 10f)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (PlayerScript.IsDead)
        {
            Destroy(gameObject);
        }
    }
}