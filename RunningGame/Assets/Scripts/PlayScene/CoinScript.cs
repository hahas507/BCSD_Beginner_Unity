using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider other)
    {
        LogicValue.AddScore(5);
        Destroy(gameObject);
    }
}