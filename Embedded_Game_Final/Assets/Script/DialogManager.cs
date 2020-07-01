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
        dialogPanel.SetActive(true);
        convoIndex = 0;
        showText();
    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
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
            Debug.Log("prss");
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
