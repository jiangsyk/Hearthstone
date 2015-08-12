using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Description: FightCard
 * Author:      JiangShu
 * Create Time: 2015/8/11 10:21:46
 */
public class FightCard : MonoBehaviour
{
    public Transform card01;
    public Transform card02;
    private float xOffset = 0;//偏移

    private List<GameObject> cardList = new List<GameObject>();
    
    void Start()
    {
        xOffset = card02.transform.position.x - card01.transform.position.x;
    }
    //添加卡牌，把卡牌放到战斗区域
    public void AddCard(GameObject go)
    {
        go.transform.parent = this.transform;
        go.GetComponent<BoxCollider>().enabled = false;
        cardList.Add(go);

        Vector3 pos = CalcPosition();
        iTween.MoveTo(go, pos, 0.5f);
    }

    //用来计算新来卡牌的位置
    Vector3 CalcPosition()
    {
        int index = cardList.Count;//add 之后 从1 开始

        //偶数向左
        if (index % 2 == 0) 
        {
            float myxOffset = index / 2 * xOffset;
            Vector3 pos = card01.position - new Vector3(myxOffset, 0, 0);
            return pos;
        }
        else
        {
            float myxOffset = index / 2 * xOffset;
            Vector3 pos = card01.position + new Vector3(myxOffset, 0, 0);
            return pos;
        }
    }
}
