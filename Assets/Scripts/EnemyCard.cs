using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Description: EnemyCard
 * Author:      JiangShu
 * Create Time: 2015/8/12 9:45:36
 */
public class EnemyCard : MonoBehaviour
{
    public Transform cardOrigin;//卡牌存放的位置
    public List<GameObject> cardList = new List<GameObject>();

    void Start()
    {

    }
    void Update()
    {

    }

    //给敌人发牌
    public void AddCard(GameObject go)
    {
        go.transform.parent = this.transform;
        cardList.Add(go);

        iTween.MoveTo(go, cardOrigin.position, 0.5f);
    }
    public void RemoveCard(GameObject go)
    {
        cardList.Remove(go);
    }
}
