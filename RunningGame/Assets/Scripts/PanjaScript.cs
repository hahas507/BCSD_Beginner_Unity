using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    [SerializeField]
    private int Count;

    private float PlatformScale;

    public float LocalScale
    {
        set
        {
            PlatformScale = value;
        }

        get
        {
            return PlatformScale;
        }
    }

    public int FloorCount
    {
        set
        {
            Count = value;

            float MoveSize = Count * -0.5f;

            //이것도 함수니깐 그대로 사용가능

            for (int i = 0; i < Count; i++)
            {
                PlatformScale = i * 1.45f;
                GameObject NewObj = new GameObject("Floor");
                NewObj.transform.SetParent(transform);
                NewObj.transform.localPosition = new Vector3(PlatformScale + MoveSize, 0, 0);
                SpriteRenderer SR = NewObj.AddComponent<SpriteRenderer>();
                SR.sprite = LogicValue.MainFloorSprite;
                NewObj.AddComponent<BoxCollider>();

                GameObject NewCoin = GameObject.Instantiate(LogicValue.CoinPrefab);
                NewCoin.transform.position = NewObj.transform.position + Vector3.up;
            }
            GameObject Left = new GameObject("Floor");
            Left.transform.SetParent(transform);
            Left.transform.localPosition = new Vector3(-1.325f + MoveSize, 0, 0);
            SpriteRenderer LeftSR = Left.AddComponent<SpriteRenderer>();
            LeftSR.sprite = LogicValue.LeftFloorSprite;
            Left.AddComponent<BoxCollider>();

            GameObject Right = new GameObject("Floor");
            Right.transform.SetParent(transform);
            Right.transform.localPosition = new Vector3(PlatformScale + 1.32f + MoveSize, 0, 0);
            SpriteRenderer RightSR = Right.AddComponent<SpriteRenderer>();
            RightSR.sprite = LogicValue.RightFloorSprite;
            Right.AddComponent<BoxCollider>();
        }
        get
        {
            return Count;
        }
    }

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
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (PlayerScript.PlayerPos.x - transform.position.x >= 20f)
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