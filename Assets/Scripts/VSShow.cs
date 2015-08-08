using UnityEngine;
using System.Collections;

/*
 * Description: VSShow
 * Author:      JiangShu
 * Create Time: 2015/8/7 15:37:42
 */
public class VSShow : MonoBehaviour
{
    public static VSShow instance;

    public TweenPosition hero1Tween;
    public TweenPosition hero2Tween;
    public TweenScale vsTween;

    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }
    void Update()
    {

    }

    public void Show(string name1,string name2)
    {
        gameObject.SetActive(true);

        PlayerPrefs.SetString("hero1", name1);
        PlayerPrefs.SetString("hero2", name2);

        hero1Tween.GetComponent<UISprite>().spriteName = name1;
        hero2Tween.GetComponent<UISprite>().spriteName = name2;

        hero1Tween.PlayForward();
        hero2Tween.PlayForward();
        vsTween.PlayForward();

        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(1);
    }
}
