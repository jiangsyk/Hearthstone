using UnityEngine;
using System.Collections;

/*
 * Description: EndButton
 * Author:      JiangShu
 * Create Time: 2015/8/8 16:46:00
 */
public class EndButton : MonoBehaviour
{
    UILabel label;
    void Start()
    {
        label = GetComponentInChildren<UILabel>();
    }
    void Update()
    {

    }
    public void OnEndButtonClick()
    {
        label.text = "对方回合";
    }
}
