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
        conversation = new List<string>(_convo.myConversation);
        convoIndex = 0;
        showText();

         dialogPanel.SetActive(true);
        //make the fialod fade in
        canvasgroup = dialogPanel.GetComponent<CanvasGroup>();
        canvasgroup.alpha = 0f;

        float duration = 0.3f;
        LeanTween.alphaCanvas(canvasgroup, 1.0f, duration).setDelay(0.2f).setEase(LeanTweenType.easeInOutExpo);


        
    }

  

    public void StopDialog()
    {
        LeanTween.alphaCanvas(canvasgroup, 0.0f, 0.5f).setEase(LeanTweenType.easeInOutExpo);
          
        //dialogPanel.SetActive(false);
       
    }

    

    private void showText()
    {
        dialogText.text = conversation[convoIndex];
    }

    public void Next()
    {
        convoIndex += 1;

        if (convoIndex == conversation.Count)
        {
            NextButtonText.text = "Next";
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
