using UnityEngine;
using System.Collections;

/*
 * Description: Hero1Crystal
 * Author:      JiangShu
 * Create Time: 2015/8/8 15:37:41
 */
public class Hero1Crystal : MonoBehaviour
{
    public int usableNumber = 1;
    public int totalNumber = 1;
    public int maxNumber = 10;

    public UISprite[] crystals;
    UILabel numLabel;
    void Start()
    {
        numLabel = GetComponent<UILabel>();
        maxNumber = crystals.Length;
    }
    void Update()
    {
        UpdateShow();
    }

    public void UpdateShow()
    {
        numLabel.text = usableNumber + "/" + totalNumber;

        int i = 0;
        for (; i < usableNumber; i++)
        {
            crystals[i].gameObject.SetActive(true);
            if(i < 9)
                crystals[i].spriteName = "TextInlineImages_0" + (i + 1);
            else
                crystals[i].spriteName = "TextInlineImages_" + (i + 1);
        }
        for(;i<totalNumber;i++)
        {
            crystals[i].gameObject.SetActive(true);
            crystals[i].spriteName = "TextInlineImages_normal";

        }
        for (; i < maxNumber; i++) 
        {
            crystals[i].gameObject.SetActive(false);
        }

    }
}
