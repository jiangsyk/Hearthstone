using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Description: MyCard
 * Author:      JiangShu
 * Create Time: 2015/8/10 10:23:46
 */
public class MyCard : MonoBehaviour
{
    public GameObject cardPrefab;

    public Transform card01;
    public Transform card02;

    private int startDepth = 10;
    private float xOffset;
    private List<GameObject> cards = new List<GameObject>();

    public void AddCard(GameObject cardGo)
    {
        GameObject go = cardGo;

        Vector3 toPosition = card01.position + new Vector3(xOffset * cards.Count, 0, 0);
        go.GetComponent<UISprite>().width = 80;
        go.GetComponent<Card>().SetDepth(startDepth);
        go.GetComponent<Card>().ResetPos();
        go.GetComponent<BoxCollider>().enabled = true;
        go.transform.parent = transform;
        startDepth += 3;

        iTween.MoveTo(go, toPosition, 1f);
        cards.Add(go);
    }
    //出牌删除
    public void RemoveCard(GameObject go)
    {
        cards.Remove(go);
        UpdateShow();
    }
    public void LoseCard()
    {
        int index = Random.Range(0, cards.Count);
        Destroy(cards[index]);
        cards.RemoveAt(index);
        UpdateShow();
    }

    void Start()
    {
        xOffset = card02.position.x - card01.position.x;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            LoseCard();
        }
    }
    public void UpdateShow()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 toPosition = card01.position + new Vector3(xOffset * i, 0, 0);
            iTween.MoveTo(cards[i], toPosition, 0.5f);
        }
    }
}
