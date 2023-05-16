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

            // ������ġ - ��ġ��ȭ�� = ���� ��ġ..
            Vector2 firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

            // ���� ������ ��ġ��ġ �Ÿ���
            float previousTouchDistance = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
            // ���� ������ ��ġ��ġ �Ÿ���
            float curruentTouchDistance = (firstTouch.position - secondTouch.position).magnitude;

            // ��ġ��ȭ�� ���.. ���� ������� ���� ��ġ�� ����� �� �ְ� �ϳ� ����.
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
