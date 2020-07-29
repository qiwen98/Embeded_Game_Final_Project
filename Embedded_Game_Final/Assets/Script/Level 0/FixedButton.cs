using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    public bool PressDown;
    public bool PressUp;
    public int curFrameDown = 0;
    public int curFrameUp = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed && PressDown)
        {
            Debug.Log("??");
            PressDown = false;
        }
        if (!Pressed && PressUp)
        {
            PressUp = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("In");
        PressDown = true;
        Pressed = true;
        curFrameDown = Time.frameCount;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        PressUp = true;
        curFrameUp = Time.frameCount;
    }

}