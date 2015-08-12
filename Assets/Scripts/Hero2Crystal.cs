using UnityEngine;
using System.Collections;

/*
 * Description: Hero2Crystal
 * Author:      JiangShu
 * Create Time: 2015/8/10 9:38:26
 */
public class Hero2Crystal : MonoBehaviour
{
    public int usableNumber = 1;
    public int totalNumber = 1;
    public int maxNumber = 10;

    private UILabel label;
    void Start()
    {
        label = GetComponent<UILabel>();

        GameController.instance.OnNewRound += this.OnNewRound;
    }
    void Update()
    {

    }
    public void UpdateShow()
    {
        label.text = usableNumber + "/" + totalNumber;
    }

    public void UpdateCrystalNumber()
    {
        if(totalNumber < maxNumber)
        {
            totalNumber++;
        }
        usableNumber = totalNumber;
        UpdateShow();
    }
    //消耗水晶,返回表示是否成功
    public bool GetCrystal(int number)
    {
        if(usableNumber >= number)
        {
            usableNumber -= number;
            UpdateShow();
            return true;
        }
        return false;
    }
    public void OnNewRound(string heroName)
    {
        if(heroName == "hero2")
        {
            UpdateCrystalNumber();
        }
    }
}
