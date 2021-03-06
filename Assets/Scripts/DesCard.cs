﻿using UnityEngine;
using System.Collections;

/*
 * Description: DesCard
 * Author:      JiangShu
 * Create Time: 2015/8/10 15:36:34
 */
public class DesCard : MonoBehaviour
{
    public static DesCard instance;

    public UILabel harmLabel;
    public UILabel hpLabel;

    private UISprite sprite;

    private float showTime = 2f;
    private float timer;
    private bool isShow = false;
    
    void Awake()
    {
        instance = this;

        sprite = GetComponent<UISprite>();
        sprite.alpha = 0;
    }
    void Start()
    {

    }
    void Update()
    {
        if(isShow)
        {
            timer += Time.deltaTime;
            if(timer > showTime)
            {
                sprite.alpha = 0;
                timer = 0;
                isShow = false;
            }
            else
            {
                sprite.alpha = (showTime - timer) / showTime;
            }
        }
    }
    public void ShowCard(string cardName)
    {
        sprite.alpha = 1;
        sprite.spriteName = cardName;

        int harm = cardName[7] - '0';
        int hp = cardName[9] - '0';
        harmLabel.text = harm.ToString();
        hpLabel.text = hp.ToString();

        timer = 0;
        isShow = true;
    }
}
