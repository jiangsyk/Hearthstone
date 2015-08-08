using UnityEngine;
using System.Collections;

/*
 * Description: Hero1
 * Author:      JiangShu
 * Create Time: 2015/8/8 15:18:57
 */
public class Hero1 : MonoBehaviour
{
    UISprite sprite;
    void Start()
    {
        sprite = GetComponent<UISprite>();
        string spriteName = PlayerPrefs.GetString("hero1");
        sprite.spriteName = spriteName;
    }
    void Update()
    {

    }
}
