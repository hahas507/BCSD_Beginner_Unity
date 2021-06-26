using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float Inter;

    private float CheckInter;
    private float DivInter;

    private bool m_isNext = false;

    private void Start()
    {
    }

    private void Update()
    {
        //생성
        if (m_isNext == false && PlayerScript.PlayerPos.x >= transform.position.x)
        {
            GameObject NextBackGround = Instantiate<GameObject>(gameObject);

            Vector3 Pos = transform.position;

            Pos.x += Inter;
            NextBackGround.transform.position = Pos;

            m_isNext = true;
        }

        //지우기
        if (Inter <= PlayerScript.PlayerPos.x - transform.position.x)
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