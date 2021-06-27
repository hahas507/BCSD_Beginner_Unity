using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ipointer 이벤트 등록
using UnityEngine.EventSystems;

// 씬 관련
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("씬 로드.");
        SceneManager.LoadScene("PlayScene");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("ui 범위 밖");
    }

    public void SceneChange()
    {
        //Debug.Log("Test");
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}