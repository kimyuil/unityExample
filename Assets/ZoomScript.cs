using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomScript : MonoBehaviour
{
    Touch firstTouch;
    Touch secondTouch;
    

    [SerializeField]
    float zoomSpeed = 1;

    [SerializeField]
    Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount == 2)
        {
            firstTouch = Input.GetTouch(0);
            secondTouch = Input.GetTouch(1);

            // 현재위치 - 위치변화량 = 직전 위치..
            Vector2 firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

            // 직전 프레임 터치위치 거리값
            float previousTouchDistance = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
            // 현재 프레임 터치위치 거리값
            float curruentTouchDistance = (firstTouch.position - secondTouch.position).magnitude;

            // 위치변화량 계산.. 줌을 어느정도 할지 수치를 계산할 수 있게 하나 보다.
            float zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomSpeed;

            if(previousTouchDistance > curruentTouchDistance)
            {
                cameraTransform.position += Vector3.back * zoomModifier * Time.deltaTime;
            }
            else if (previousTouchDistance < curruentTouchDistance)
            {
                cameraTransform.position += Vector3.forward * zoomModifier * Time.deltaTime;
            }

        }
    }
    

    public void vibrate()
    {
        Handheld.Vibrate();
    }
}
