using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject MessagePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool mIsMessagePanelOpened = false;

    public bool IsMessagePanelOpened
    {
        get
        {
            return mIsMessagePanelOpened;
        }
    }

    public void OpeNMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = text;

        mIsMessagePanelOpened = true;
    }
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);

        mIsMessagePanelOpened = false;
    }
}
