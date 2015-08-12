using UnityEngine;
using System.Collections;

/*
 * Description: Card
 * Author:      JiangShu
 * Create Time: 2015/8/10 15:34:45
 */
public class Card : MonoBehaviour
{
    public int needCrystal;
    public int harm;
    public int hp;
    public string cardName
    {
        get { return sprite.spriteName; }
    }

    public UILabel harmLabel;
    public UILabel hpLabel;
    private UISprite sprite;
    void Awake()
    {
        sprite = GetComponent<UISprite>();
    }
    void Start()
    {
    }
    void Update()
    {

    }
    public void SetDepth(int depth)
    {
        sprite.depth = depth;
        harmLabel.depth = depth + 1;
        hpLabel.depth = depth + 2;
    }
    void OnPress(bool isPressed)
    {
        if(isPressed)
        {
            DesCard.instance.ShowCard(cardName);
        }
        else
        {

        }
    }
    public void ResetPos()
    {
        harmLabel.GetComponent<UIAnchor>().enabled = true;
        hpLabel.GetComponent<UIAnchor>().enabled = true;
    }
    private void ResetShow()
    {
        harmLabel.text = harm.ToString();
        hpLabel.text = hp.ToString();
    }
    public void InitProp()
    {
        /*
        string[] nameArr = cardName.Split('_');
        needCrystal = int.Parse(nameArr[1]);
        harm = int.Parse(nameArr[2]);
        hp = int.Parse(nameArr[3]);
        */
        needCrystal = cardName[5] - '0';
        harm = cardName[7] - '0';
        hp = cardName[9] - '0';

        ResetShow();
    }
}
