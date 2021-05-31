using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("camera awake");
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
    }
}