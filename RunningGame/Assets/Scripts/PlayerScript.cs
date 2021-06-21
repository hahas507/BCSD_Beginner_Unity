using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private static bool m_isDead;

    public static bool IsDead
    {
        get
        {
            return m_isDead;
        }
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
    private Animator m_Ani = null;

    private void Awake()
    {
        {
            m_Rigi = GetComponent<Rigidbody>();
            m_Ani = GetComponent<Animator>();
            m_JumpCount = LogicValue.JumpCount;
            if (null == m_Rigi)
            {
                //���� ����ش�
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
            //�÷��̾� �� ó������ ������
            transform.position = Vector3.zero;
            //ī�޶� ��ó������ ������
            MoveCamera.CameraReset();

            m_isDead = true;
        }

        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        if (true == Input.GetKeyDown(KeyCode.Space) && 0 < m_JumpCount)
        {
            m_Ani.SetTrigger("Jump");
            //Vector3 CurrentSpeed = new Vector3(0, 0, 0);
            m_Rigi.velocity = new Vector3(0, 0, 0);

            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower);
            //m_isJump = true;

            --m_JumpCount;
        }
    }

    private void FixedUpdate()
    {
        if (true == m_isDead)
        {
            //���� �����
            PanjaManager.PanjaReset();
            m_isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("coin collision");
    }

    private void OnCollisionStay(Collision collision)
    {
        //���������� �ߵ��ϴ� ����
    }

    private void OnCollisionExit(Collision collision)
    {
        //�浹���̴� ������ ����
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�ٸ� �ݶ��̴��� ���� ������Ʈ�� ���� �浹�ϴ� ����

        //������ �ٵ� ���� ������Ʈ�� ȣ��ȴ�.
        //������ �ٵ�� �ݶ��̴��� ���� � ������Ʈ��

        //m_isJump = false;
        m_Ani.SetTrigger("Run");
        m_JumpCount = LogicValue.JumpCount;
    }
}