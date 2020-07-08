using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Convo : ScriptableObject
{
    public string npcName;
    public List<string> myConversation = new List<string>();
    public enum Face_Animation {Smile,Angry,Surprise,Talking};
    public Face_Animation face_Animation;
    public enum Body_Animation {Waving, Stop_Walking_With_Rifle, Kneeling_Up};
    public Body_Animation body_Animation;
    public enum Idle_Animation { Waving, Stop_Walking_With_Rifle, Kneeling_Up };
    public Idle_Animation idle_Animation;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
