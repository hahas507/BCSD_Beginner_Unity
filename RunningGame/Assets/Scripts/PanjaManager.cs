using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//일정 시간마다 판자가 만들어진다.

public class PanjaManager : MonoBehaviour
{
    [SerializeField]
    private float CreateTime = 0.5f;

    private void Update()
    {
        CreateTime -= Time.deltaTime;

        if (CreateTime <= 0.0f)
        {
            GameObject NewPanja = new GameObject("Panja");

            Vector3 CreatePos = this.transform.position;
            CreatePos.z = 0f;
            NewPanja.transform.position = CreatePos;
            NewPanja.AddComponent<SpriteRenderer>();

            CreateTime = 0.5f;
        }
    }
}