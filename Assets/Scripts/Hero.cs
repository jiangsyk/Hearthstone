using UnityEngine;
using System.Collections;

/*
 * Description: Hero
 * Author:      JiangShu
 * Create Time: 2015/8/10 14:57:40
 */
public class Hero : MonoBehaviour
{
    public int maxHp = 30;
    public int minHp = 0;

    protected UISprite sprite;
    protected UILabel hpLabel;
    protected int hpCount = 30;

    void Awake()
    {
        sprite = GetComponent<UISprite>();
        hpLabel = transform.FindChild("Hp").GetComponent<UILabel>();
    }
    void Update()
    {

    }
    //吸收伤害值
    public void TakeDamage(int damage)
    {
        hpCount -= damage;
        hpLabel.text = hpCount.ToString();
        if(hpCount <= minHp)
        {
            //游戏结束

        }
    }
    public void PlusHp(int value)
    {
        hpCount += value;
        if (hpCount > maxHp) hpCount = maxHp;
        hpLabel.text = hpCount.ToString();
    }
}
