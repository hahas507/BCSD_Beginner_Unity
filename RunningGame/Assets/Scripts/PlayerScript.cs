using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private void Start()
    {
    }

    private static Vector3 m_PlayerPos;

    public static Vector3 PlayerPos
    {
        get
        {
            return m_PlayerPos;
        }
    }

    private int m_JumpCount = 3;
    private Rigidbody m_Rigi = null;

    private void Awake()
    {
        {
            m_Rigi = GetComponent<Rigidbody>();
            m_JumpCount = LogicValue.JumpCount;
            if (null == m_Rigi)
            {
                //경고로 띄워준다
                //Debug.LogWarning("null == m_Rigi");
                Debug.LogError("null == m_Rigi");
            }
            //Debug.LogWarning("warning test");
            //Debug.LogError("error test");
        }
    }

    private void Update()
    {
        if (transform.position.y <= -MoveCamera.CamCom.orthographicSize)
        {
            //플레이어 맨 처음으로 돌리기
            transform.position = Vector3.zero;
            //카메라 맨처음으로 돌리기
            MoveCamera.CameraReset();
            //판자 지우기
            PanjaManager.PanjaReset();
        }

        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        if (true == Input.GetKeyDown(KeyCode.Space) && 0 < m_JumpCount)
        {
            //Vector3 CurrentSpeed = new Vector3(0, 0, 0);
            m_Rigi.velocity = new Vector3(0, 0, 0);

            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower);
            //m_isJump = true;

            --m_JumpCount;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //지속적으로 추돌하는 순간
    }

    private void OnCollisionExit(Collision collision)
    {
        //충돌중이다 떨어진 순간
    }

    private void OnCollisionEnter(Collision collision)
    {
        //다른 콜라이더를 가진 오브젝트와 최초 충돌하는 순간

        //리지드 바디를 가진 오브젝트만 호출된다.
        //리지드 바디와 콜라이더를 가진 어떤 오브젝트가

        //m_isJump = false;

        m_JumpCount = LogicValue.JumpCount;
    }
}