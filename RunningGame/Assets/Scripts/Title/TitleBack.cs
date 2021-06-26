using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBack : MonoBehaviour
{
    [SerializeField]
    private float LoopLength = -5;

    [SerializeField]
    private float NewBGSpawn = 57;

    [SerializeField]
    private float OldBGDestroy;

    private bool GenNextBG = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;

        if (GenNextBG == true && transform.position.x <= LoopLength)
        {
            Debug.Log("정상작동");
            GameObject NextBG = Instantiate<GameObject>(gameObject);
            Vector3 Position = transform.position;

            Position.x += NewBGSpawn;
            NextBG.transform.position = Position;
            GenNextBG = false;
        }
        else if (transform.position.x <= OldBGDestroy)
        {
            Destroy(gameObject);
        }
    }
}