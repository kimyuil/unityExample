using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Image background;
    Image joystick;
    Vector2 touchPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        joystick = transform.Find("controller").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touchPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {        

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            touchPosition.x = (touchPosition.x / background.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / background.rectTransform.sizeDelta.y);            
            touchPosition = new Vector2(touchPosition.x * 2 - 1, touchPosition.y * 2 - 1);            
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            joystick.rectTransform.anchoredPosition = new Vector2(
                touchPosition.x * joystick.rectTransform.sizeDelta.x / 2,
                touchPosition.y * joystick.rectTransform.sizeDelta.y / 2);

        }

    }    

    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.rectTransform.anchoredPosition = Vector2.zero;
        touchPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return touchPosition.x;
    }

    public float Vertical()
    {
        return touchPosition.y;
    }


}
