using UnityEngine;
using System.Collections;

/*
 * Description: Card
 * Author:      JiangShu
 * Create Time: 2015/8/10 15:34:45
 */
public class Card : MonoBehaviour
{
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
            DesCard.instance.ShowCard(sprite.spriteName);
        }
        else
        {

        }
    }
}
