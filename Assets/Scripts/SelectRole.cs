using UnityEngine;
using System.Collections;

/*
 * Description: 选角界面
 * Author:      JiangShu
 * Create Time: 2015/8/7 15:11:56
 */
public class SelectRole : MonoBehaviour
{
    private string[] HERO_NAME = {
                                            "吉安娜·普罗德摩尔",
                                            "雷克萨",
                                            "乌瑟尔•光明使者",
                                            "加尔鲁什•地狱咆哮",
                                            "玛法里奥•怒风",
                                            "古尔丹",
                                            "萨尔",
                                            "安杜因•乌瑞恩",
                                            "瓦莉拉•萨古纳尔"
                                       };

    public UISprite[] heros;
    public UISprite selectHero;
    public UILabel selectName;

    void Start()
    {
        foreach(UISprite hero in heros)
        {
            UIEventListener.Get(hero.gameObject).onClick += OnClickHero;
        }
    }
    void Update()
    {

    }
    private void OnClickHero(GameObject go)
    {
        string heroName = go.name;
        char heroIndexChar = heroName[4];
        int heroIndex = heroIndexChar - '0';

        selectHero.spriteName = heroName;
        selectName.text = HERO_NAME[heroIndex - 1];
    }
}
