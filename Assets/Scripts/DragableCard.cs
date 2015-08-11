using UnityEngine;
using System.Collections;

/*
 * Description: DragableCard
 * Author:      JiangShu
 * Create Time: 2015/8/11 9:47:46
 */
public class DragableCard : UIDragDropItem
{
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface != null && surface.tag == "FightCard")
        {
            print("拖拽到可发牌区域!");

            //判断水晶
            int needCrystal = GetComponent<Card>().needCrystal;
            Hero1Crystal hero1Crystal = GameObject.Find("hero1_crystal").GetComponent<Hero1Crystal>();
            bool isSuccess = hero1Crystal.GetCrystal(needCrystal);
            if(isSuccess)
            {
                transform.parent.GetComponent<MyCard>().RemoveCard(gameObject);
                FightCard fightCard = surface.GetComponent<FightCard>();
                fightCard.AddCard(gameObject);
            }
            else
                transform.parent.GetComponent<MyCard>().UpdateShow();
        }
        else
        {
            transform.parent.GetComponent<MyCard>().UpdateShow();
        }
    }
}
