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

    [SerializeField]
    private float CreateRandomRangeYStart = -2f;

    [SerializeField]
    private float CreateRandomRangeYEnd = 2f;

    [SerializeField]
    private float CreateRandomScaleXStart = 5f;

    [SerializeField]
    private float CreateRandomInterXEnd = 2f;

    [SerializeField]
    private float CreateRandomInterXStart = 4f;

    [SerializeField]
    private float CreateRandomScaleXEnd = 10f;

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
        GameObject NewPanja = new GameObject("Panja");
        NewPanja.transform.localScale = new Vector3(Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1f, 0);

        Vector3 CreatePos = new Vector3();

        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewPanja.transform.localScale.x * 0.5f);
        CreatePos.x += Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd);
        CreatePos.z = 0f;
        CreatePos.y = Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);

        NewPanja.transform.position = CreatePos;

        //이미지 세팅
        SpriteRenderer NewSP = NewPanja.AddComponent<SpriteRenderer>();
        NewSP.sprite = Panja;
        NewSP.color = new Color(1f, 0f, 0f, 1f);

        //갱신
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (NewPanja.transform.localScale.x * 0.5f);

        NewPanja.AddComponent<BoxCollider>();
        NewPanja.AddComponent<PanjaScript>();

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