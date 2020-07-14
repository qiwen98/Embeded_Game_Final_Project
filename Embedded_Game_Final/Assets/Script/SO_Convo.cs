using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Convo : ScriptableObject
{
    public string npcName;
    public List<string> defaultConversation = new List<string>();
    public enum Face_Animation {Smile,Angry,Surprise,Talking};
    public Face_Animation face_Animation;
    public enum Body_Animation {Waving, Stop_Walking_With_Rifle, Kneeling_Up};
    public Body_Animation body_Animation;
    public enum Idle_Animation { Waving, Stop_Walking_With_Rifle, Kneeling_Up };
    public Idle_Animation idle_Animation;
    public List<string> ConversationChoice1 = new List<string>();
    public List<string> ConversationChoice2 = new List<string>();
    public bool condition_to_tigger_ConversationChoice1=false;
    public bool condition_to_tigger_ConversationChoice2=false;



    // Start is called before the first frame update
    void Start()
    {
        condition_to_tigger_ConversationChoice1 = false;
     condition_to_tigger_ConversationChoice2 = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_condition_to_tigger_ConversationChoice1()
    {
        condition_to_tigger_ConversationChoice1=true;
        Debug.Log("event received");
    }
}
