using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Description: HistoryCard
 * Author:      JiangShu
 * Create Time: 2015/8/8 16:18:49
 */
public class HistoryCard : MonoBehaviour
{
    public Transform inCard;
    public Transform outCard;
    public Transform card1;
    public Transform card2;

    public GameObject cardPrefab;
    private List<GameObject> cardList = new List<GameObject>();

    private float yOffset;
    void Start()
    {
        yOffset = card2.position.y - card1.position.y;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
         //   StartCoroutine(AddCard());
        }
    }
    public IEnumerator AddCard()
    { 
        GameObject card = GameObject.Instantiate(cardPrefab,inCard.position,Quaternion.identity) as GameObject;
        yield return 0;//等待一帧（等待初始化）
        card.transform.parent = transform;
        card.transform.position = inCard.position;
        iTween.MoveTo(card, card1.position, 1f);

        cardList.Add(card);
        //移动历史卡牌
        if(cardList.Count > 7)
        {
            iTween.MoveTo(cardList[0], outCard.position, 1f);
            Destroy(cardList[0], 1f);
            cardList.RemoveAt(0);
        }
        for(int i = 0;i<cardList.Count - 1;i++)
        {
            iTween.MoveTo(cardList[i],new Vector3(card1.position.x, cardList[i].transform.position.y + yOffset, 0), 0.5f);
        }
    }
}
