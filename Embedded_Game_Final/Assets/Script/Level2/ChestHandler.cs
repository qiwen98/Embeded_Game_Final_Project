using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestHandler : MonoBehaviour
{
    public string playableName;
    public string mainTitleStr;
    public string subTitleStr;
    public Text mainTitle;
    public Text subTitle;
    public GameObject progrssBar;
    public float progress;
    public Text UIText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController plc = other.GetComponent<PlayerController>();
        Debug.Log(plc.cam.NextButton.Pressed);
        if (plc!=null)
        {
            Debug.Log(plc.cam.NextButton.Pressed);
            if(plc.cam.NextButton.Pressed)
            {
                mainTitle.text = mainTitleStr;
                subTitle.text = subTitleStr;
                TimelineManager.instance.checkAndPlayPlayable(playableName);
                GetComponent<Animator>().SetBool("IsOpen", true);
                float curProgress = progrssBar.GetComponent<Image>().fillAmount;
                if (progress != -1)
                {
                    progrssBar.GetComponent<Image>().fillAmount = progress;
                }
                else
                {
                    Camera.main.GetComponent<AudioListener>().enabled = true;
                }

                if (curProgress >= 0.15f&& curProgress < 0.3f) plc.cam.lockCameraDirection = false;
                if(curProgress >= 0.3f && curProgress < 0.5f)
                {
                    Debug.Log(curProgress);
                    Application.targetFrameRate = 30;
                    if(UIText!=null)
                        UIText.text = "1982: Wayout";

                }
                if(curProgress >= 0.5f && curProgress < 0.7f)
                {
                    Camera.main.GetComponent<CameraFilterPack_Pixel_Pixelisation>()._Pixelisation = 1f;
                }
                if (curProgress==0.7f)
                {
                    StartCoroutine("loadNextLevel");
                }

                
                /*
                for(int i = 0;i < transform.childCount;++i)
                {
                    transform.GetChild(i).GetComponent<MeshRenderer>().material.DOFade(0f, 5f);
                }
                */
            }
        }
    }
    IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Level2-DonkeyKing");
    }
}
