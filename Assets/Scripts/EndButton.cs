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
    void Awake()
    {
        label = GetComponentInChildren<UILabel>();
    }
    void Start()
    {
        GameController.instance.OnNewRound += OnNewRound;
    }
    void Update()
    {

    }
    public void OnEndButtonClick()
    {
        if(label.text == "结束回合")
        {
            label.text = "对方回合";
            GameController.instance.TransformPlayer();
        }
    }
    private void OnNewRound(string heroName)
    {
        if(heroName == "hero1")
        {
            label.text = "结束回合";
        }
    }
}
