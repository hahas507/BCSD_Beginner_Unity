using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }
}