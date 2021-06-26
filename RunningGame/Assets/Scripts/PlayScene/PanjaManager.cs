using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//일정 시간마다 판자가 만들어진다.

public class PanjaManager : MonoBehaviour
{
    [SerializeField]
    private Sprite Panja = null;

    [SerializeField]
    private float CreateRange = 20f;

    #region Platform size

    [SerializeField]
    private int CreateRandomScaleXStart = 2;

    [SerializeField]
    private int CreateRandomScaleXEnd = 6;

    #endregion Platform size

    #region Platform Spawn

    [SerializeField]
    private float CreateRandomInterXStart = 4f;

    [SerializeField]
    private int CreateRandomInterXEnd = 2;

    [SerializeField]
    private float CreateRandomRangeYStart = -2f;

    [SerializeField]
    private float CreateRandomRangeYEnd = 2f;

    #endregion Platform Spawn

    //마지막으로 만들어진 판자의 x크기
    [SerializeField]
    private float LastCreateScaleX = 0f;

    //마지막으로 만들어진 판자의 x위치
    [SerializeField]
    private float LastCreatePosX = 0f;

    private float ResetLastCreateScaleX = 0f;

    private float ResetLastCreatePosX = 0f;

    public static PanjaManager MainPanjaManager;

    public static void PanjaReset()
    {
        MainPanjaManager.ResetData();
    }

    private void Awake()
    {
        ResetLastCreateScaleX = LastCreateScaleX;
        ResetLastCreatePosX = LastCreatePosX;

        MainPanjaManager = this;

        Debug.Log("panjamanager awake");
        ChechPanjaCreate();
    }

    public void ResetData()
    {
        LastCreateScaleX = ResetLastCreateScaleX;
        LastCreatePosX = ResetLastCreatePosX;
        ChechPanjaCreate();
    }

    private bool NewPanjaLogic()
    {
        if (LastCreatePosX >= PlayerScript.PlayerPos.x + CreateRange)
        {
            return false;
        }

        int NewFloorCount = Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd);

        GameObject NewPanja = new GameObject("Panja");
        //NewPanja.transform.localScale = new Vector3(Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1f, 0);

        Vector3 CreatePos = new Vector3();

        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewFloorCount * 0.5f);
        CreatePos.x += Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd);
        CreatePos.z = 0f;
        CreatePos.y = Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);

        NewPanja.transform.position = CreatePos;

        //이미지 세팅
        //SpriteRenderer NewSP = NewPanja.AddComponent<SpriteRenderer>();
        //NewSP.sprite = Panja;
        //NewSP.color = new Color(1f, 0f, 0f, 1f);

        PanjaScript PS = NewPanja.AddComponent<PanjaScript>();
        PS.FloorCount = NewFloorCount;

        //BoxCollider BC = NewPanja.AddComponent<BoxCollider>();
        //BC.size = new Vector3(PS.LocalScale + 4, 0.95f, 1);
        //BC.center = new Vector3(0.15f, 0, 0);

        //갱신
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (PS.FloorCount * 0.5f);

        return true;
    }

    private void ChechPanjaCreate()
    {
        while (NewPanjaLogic()) ;
    }

    private void Start()
    {
        ChechPanjaCreate();
    }

    private void Update()
    {
        ChechPanjaCreate();
    }
}