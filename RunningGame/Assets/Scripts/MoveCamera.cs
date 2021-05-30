using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Test
{
    private int A = 100;

    public void Func()
    {
        Debug.Log("hahahaha");
    }
}

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Test NewTest = null;
        //NewTest.Func();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }
}