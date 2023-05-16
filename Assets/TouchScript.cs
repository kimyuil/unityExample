using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TouchScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI touchCount;

    [SerializeField]
    TextMeshProUGUI log;

    [SerializeField]
    TextMeshProUGUI bye;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchCount.text = Input.touchCount.ToString();

        checkTouch();        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bye.text = "BYE!!";
        }


    }

    void checkTouch()
    {
        Touch touch;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        else
        {
            return;
        }        

        if (touch.phase == TouchPhase.Began)
        {
            log.text = "touch began";
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            log.text = "touch moved";
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            log.text = "touch Ended";
        }
        else if (touch.phase == TouchPhase.Stationary)
        {
            log.text = "touch Stationary";
        }
        else if (touch.phase == TouchPhase.Canceled)
        {
            log.text = "touch Canceled";
        }
    }

}
