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

    private UILabel label;
    void Start()
    {
        label = GetComponent<UILabel>();
    }
    void Update()
    {

    }
    public void UpdateShow()
    {
        label.text = usableNumber + "/" + totalNumber;
    }
}
