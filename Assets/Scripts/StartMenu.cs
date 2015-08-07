using UnityEngine;
using System.Collections;

/*
 * Description: StartMenu
 * Author:      JiangShu
 * Create Time: 2015/8/6 15:37:42
 */
public class StartMenu : MonoBehaviour
{
    public MovieTexture movTexture;
    public TweenScale logoTween;

    public bool isDrawMov = true;
    public bool isShowMessage = false;

    void Start()
    {
        movTexture.loop = false;
        movTexture.Play();
    }
    void Update()
    {
        if(isDrawMov)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (!isShowMessage)
                    isShowMessage = true;
                else
                    StopMov();
            }

        }
        if(isDrawMov != movTexture.isPlaying)
        {
            StopMov();
        }

    }
    void OnGUI()
    {
        if(isDrawMov)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
            if(isShowMessage)
            {
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 40), "再点击一次屏幕跳过动画");
            }
        }
    }
    private void StopMov()
    {
        movTexture.Stop();
        isDrawMov = false;
        //logo
        logoTween.PlayForward();
    }
}
