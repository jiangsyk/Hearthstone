using UnityEngine;
using System.Collections;

public enum GameState
{
    CardGenerating,//系统随机发放卡牌阶段
    PlayCard,//出牌阶段
    End//游戏结束
}
/*
 * Description: GameController
 * Author:      JiangShu
 * Create Time: 2015/8/10 15:10:58
 */
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState state = GameState.PlayCard;
    public float cycleTime = 60f;
    public MyCard myCard;
    public EnemyCard enemyCard;

    public int roundIndex = 0;
    public delegate void OnNewRoundEvent(string heroName);//控制转换
    public event OnNewRoundEvent OnNewRound;

    public float timer = 0;
    private UISprite wickpopeSprite;
    private float wickpopeWidth;

    private string currentHeroName = "hero1";//当前回合对象
    private CardGenerator cardGenerator;

    void Awake()
    {
        wickpopeSprite = this.transform.FindChild("Wickpope").GetComponent<UISprite>();
        wickpopeWidth = wickpopeSprite.width;
        wickpopeSprite.width = 0;

        cardGenerator = GetComponent<CardGenerator>();

        instance = this;
    }
    void Start()
    {
        //给当前回合英雄发牌
        StartCoroutine( GenerateCarForHero1() );
    }
    void Update()
    {
        if(state == GameState.PlayCard)
        {
            timer += Time.deltaTime;
            if(timer > cycleTime)
            {
                //强制结束当前回合
                TransformPlayer();
                timer = 0;
            }
            else if(cycleTime - timer <= 15)//剩余时间小于15秒
            {
                float scale = (cycleTime - timer) / 15;
                wickpopeSprite.width = (int)(wickpopeWidth * scale);
            }
        }
    }
    private IEnumerator GenerateCarForHero1()
    {
        //第一次发4张牌
        for(int i = 0;i<4;i++)
        {
            GameObject cardGo = cardGenerator.RandomGenerateCard();
            yield return new WaitForSeconds(2.25f);
            myCard.AddCard(cardGo);
        }
        //敌人发4张牌
        for(int i = 0;i<4;i++)
        {
            GameObject cardGo = cardGenerator.RandomGenerateCard();
            yield return new WaitForSeconds(2.25f);
            enemyCard.AddCard(cardGo);
        }

        state = GameState.PlayCard;
        timer = 0;
    }
    public void TransformPlayer()//转变发牌方
    {
        currentHeroName = currentHeroName == "hero1" ? "hero2" : "hero1";
        roundIndex++;
        timer = 0;
        OnNewRound(currentHeroName);
        
        //给当前回合发2张
        if(roundIndex >= 2)
        {
            StartCoroutine(DealCard());
        }
    }
    IEnumerator DealCard()
    {
        state = GameState.CardGenerating;
        if(currentHeroName == "hero1")
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject cardGo = cardGenerator.RandomGenerateCard();
                yield return new WaitForSeconds(2.25f);
                myCard.AddCard(cardGo);
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject cardGo = cardGenerator.RandomGenerateCard();
                yield return new WaitForSeconds(2.25f);
                enemyCard.AddCard(cardGo);
            }
        }
        state = GameState.PlayCard;
        timer = 0;
    }
}
