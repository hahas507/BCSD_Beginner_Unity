using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
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
}