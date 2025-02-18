﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public RectTransform RightHome;
    public RectTransform LeftHome;

    private void Start()
    {
        RightHome = GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
    }

    public void OnButtonClick()
    {
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -1.31f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 0.91f;

        GameManager.Instance.TurnOnComponentPlayer();
        GameManager.Instance.isStart = true;
        GameManager.Instance.InGame.gameObject.SetActive(true);

        StartCoroutine(MoveUI(RightHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right1").GetComponent<RectTransform>().anchoredPosition, 1.2f));
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 1.2f));
    }

    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Di chuyển từ từ từ điểm này đến điểm khác
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Chờ 1 frame trước khi tiếp tục
        }

        // Đảm bảo vị trí cuối cùng chính xác
        uiElement.anchoredPosition = targetPosition;
    }
}
