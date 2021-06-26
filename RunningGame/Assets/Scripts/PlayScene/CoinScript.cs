using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
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
        Destroy(gameObject);
        //Debug.Log("Player collision");
    }
}