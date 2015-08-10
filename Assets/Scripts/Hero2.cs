using UnityEngine;
using System.Collections;

/*
 * Description: Hero2
 * Author:      JiangShu
 * Create Time: 2015/8/8 15:19:03
 */
public class Hero2 : Hero
{
    void Start()
    {
        string spriteName = PlayerPrefs.GetString("hero2");
        sprite.spriteName = spriteName;
    }
    void Update()
    {
    }
}
