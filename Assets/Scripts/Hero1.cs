using UnityEngine;
using System.Collections;

/*
 * Description: Hero1
 * Author:      JiangShu
 * Create Time: 2015/8/8 15:18:57
 */
public class Hero1 : Hero
{
    void Start()
    {
        string spriteName = PlayerPrefs.GetString("hero1");
        sprite.spriteName = spriteName;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(Random.Range(1, 5));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlusHp(Random.Range(1, 5));
        }

    }
}
