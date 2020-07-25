using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager instance;

    public PlayableDirector[] playerable;

    private Dictionary<string,PlayableDirector> playerableDic;
    private void Awake()
    {
        instance = this;
        playerableDic = new Dictionary<string, PlayableDirector>();
    }

    // Start is called before the first frame update
    void Start()
    {
        registerPlayerAble();
    }

    void registerPlayerAble()
    {
        for(int i = 0;i < playerable.Length;++i)
        {
            playerableDic[playerable[i].gameObject.name] = playerable[i];
        }
    }
    public bool checkAndPlayPlayable(string name)
    {
        if(playerableDic.ContainsKey(name))
        {
            playerableDic[name].enabled = true;
            return true;
        }
        return false;
    }
}
