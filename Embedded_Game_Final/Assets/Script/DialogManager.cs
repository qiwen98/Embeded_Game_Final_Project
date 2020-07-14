using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text npcNameText;
    public Text dialogText;
    public Text NextButtonText;

    //for fade in and fade out
    
    float fadeTime = 3f;
    Color colorToFadeTo;
    CanvasGroup canvasgroup;

    private List<string> conversation;
    int convoIndex;
 

    // Start is called before the first frame update
    void Start()
    {
         dialogPanel.SetActive(false);

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_dialog(SO_Convo _convo)
    {

        npcNameText.text = _convo.npcName;
        if(_convo.ConversationChoice1!=null&&_convo.condition_to_tigger_ConversationChoice1==true)
        {
            conversation = new List<string>(_convo.ConversationChoice1);
        }
        else
        {
            conversation = new List<string>(_convo.defaultConversation);
        }
       
        convoIndex = 0;
        showText();

        dialogPanel.SetActive(true);
        //make the fialod fade in
        canvasgroup = dialogPanel.GetComponent<CanvasGroup>();
        canvasgroup.alpha = 0f;
        dialogPanel.transform.localScale = new Vector3(0, 0, 0);

        float duration = 0.3f;
        LeanTween.alphaCanvas(canvasgroup, 1.0f, duration).setDelay(0.2f).setEase(LeanTweenType.easeInOutExpo);
        LeanTween.scale(dialogPanel,new Vector3(1,1,1),duration).setDelay(0.3f).setEase(LeanTweenType.easeInOutExpo);

        NextButtonText.text = "Next";

    }

  

    public void StopDialog()
    {
        LeanTween.alphaCanvas(canvasgroup, 0.0f, 0.5f).setEase(LeanTweenType.easeInOutExpo);
          
        //dialogPanel.SetActive(false);
       
    }

    
    /// <summary>
    /// 在展示Text的时候展示有没有文字动画事件，如果有，则执行
    /// </summary>
    private void showText()
    {
        dialogText.text = conversation[convoIndex];
        Debug.Log(dialogText.text);

        //观测Text有没有要执行playable或者challenge
        if(TimelineManager.instance.checkAndPlayPlayable(dialogText.text)) Next();
        if(GameManager.instance.checkAndPlayChallenge(dialogText.text,true)) Next();

    }

    public void Next()
    {
        convoIndex += 1;
        


        if (convoIndex == conversation.Count)
        {
            NextButtonText.text = "";

            StopDialog();
            
        }

        if (convoIndex<conversation.Count-1)
        {
            
            showText();
        }

        if (convoIndex == conversation.Count-1)
        {
            NextButtonText.text = "bye!";
            
            showText();
           
        }


       
    }
}
