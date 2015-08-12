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

    public bool isCanShowSelectRole = false;
    public TweenPosition selectRoleTween;

    public UISprite selectedHero;
    public GameObject clickLabel;

    void Start()
    {
     //   Screen.SetResolution(1100, 700, false);

        movTexture.loop = false;
        movTexture.Play();

        logoTween.AddOnFinished(OnLogoFinished);
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

        if(isCanShowSelectRole && Input.GetMouseButtonDown(0))
        {
            selectRoleTween.gameObject.SetActive(true);
            selectRoleTween.PlayForward();
            clickLabel.SetActive(false);


            isCanShowSelectRole = false;
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
    private void OnLogoFinished()
    {
        isCanShowSelectRole = true;
    }
    public void OnClickPlayBtn()
    {
        string name1 = selectedHero.spriteName;
        string name2 = "hero" + Random.Range(1,10);
        BlackMask.instance.Show();
        VSShow.instance.Show(name1, name2);
    }
}
