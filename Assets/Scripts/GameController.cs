﻿using UnityEngine;
using System.Collections;

/*
 * Description: GameController
 * Author:      JiangShu
 * Create Time: 2015/8/10 9:52:25
 */
public class GameController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform fromCard;
    public Transform toCard;
    public string[] cardNames;

    public float transformTime = 2f;
    public int tranformSpeed = 20;

    private bool isTransforming = false;
    private float timer = 0;
    private UISprite nowGenerateCard;
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RandomGenerateCard();
        }
        if(isTransforming)
        {
            timer += Time.deltaTime;
            int index = (int)(timer / (1f / tranformSpeed));
            index %= cardNames.Length;
            nowGenerateCard.spriteName = cardNames[index];
            if(timer > transformTime)
            {
                timer = 0;
                isTransforming = false;
            }
        }

    }
    public void RandomGenerateCard()
    {
        //为何用协成创建？等待一帧 ，用GameObject创建的话
        //用NGUI就不用
        GameObject go = NGUITools.AddChild(gameObject, cardPrefab);
        go.transform.position = fromCard.position;
        nowGenerateCard = go.GetComponent<UISprite>();
        iTween.MoveTo(go, toCard.position, 1f);
        isTransforming = true;
    }
}