using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameLevel
{
    LEVEL0,
    LEVEL1,
    LEVEL2,
    LEVEL3,
    LEVEL4,
    CHALLENGE
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameLevel gameLevel;

    public string[] challenge;

    public GameObject[] challengeObj;

    public Dictionary<string, GameObject> challengeDic; 



    private void Awake()
    {
        instance = this;
        gameLevel = GameLevel.LEVEL0;
        challengeDic = new Dictionary<string, GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        registerDic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeStage(GameLevel level)
    {
        gameLevel = level;
    }
    public bool checkAndPlayChallenge(string str,bool active)
    {
        if(challengeDic.ContainsKey(str))
        {
            challengeDic[str].gameObject.SetActive(active);
            return true;
        }
        return false;
    }
    private void registerDic()
    {
        for(int i = 0;i < challenge.Length;++i)
        {
            challengeDic[challenge[i]] = challengeObj[i];
        }
    }
}
