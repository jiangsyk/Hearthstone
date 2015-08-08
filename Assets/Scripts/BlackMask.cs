using UnityEngine;
using System.Collections;

/*
 * Description: BlackMask
 * Author:      JiangShu
 * Create Time: 2015/8/7 15:28:50
 */
public class BlackMask : MonoBehaviour
{
    public static BlackMask instance;
    void Start()
    {
        instance = this;
        Hide();
    }
    void Update()
    {

    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
