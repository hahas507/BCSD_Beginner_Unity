using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//데이터 직렬화를 자동으로 해주면서
//컴퓨터가 읽고 쓰기 쉽게 변경해주는 기능이라고 생각하면 된다.
[Serializable]
public class CameraAndPlayerData
{
    [SerializeField]
    public float m_MoveSpeed = 10f;

    [SerializeField]
    public float m_JumpPower = 10f;

    [SerializeField]
    public int m_JumpCount = 3;
}

public class LogicValue : MonoBehaviour
{
    private static LogicValue Inst = null;

    [SerializeField]
    private CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();

    public static float MoveSpeed
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_MoveSpeed;
        }
    }

    public static float JumpPower
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_JumpPower;
        }
    }

    public static int JumpCount
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_JumpCount;
        }
    }

    [SerializeField]
    private GameObject m_CoinPrefab;

    [SerializeField]
    private Sprite m_MainFloor;

    public static Sprite MainFloorSprite { get { return Inst.m_MainFloor; } }

    [SerializeField]
    private Sprite m_LeftFloor;

    public static Sprite LeftFloorSprite { get { return Inst.m_LeftFloor; } }

    [SerializeField]
    private Sprite m_RightFloor;

    public static Sprite RightFloorSprite { get { return Inst.m_RightFloor; } }

    public static GameObject CoinPrefab
    { get { return Inst.m_CoinPrefab; } }

    //기존 입력해준 값에 의해서 결정되는 상수와 같은 값도 여기서 계산해줄 수 있다.
    private void Awake()
    {
        Debug.Log("logicvalue awake");
        Inst = this;
    }

    private void Update()
    {
    }
}