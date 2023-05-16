using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    JoystickController joystickController;

    [SerializeField]
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystickController.Horizontal();
        float y = joystickController.Vertical();

        transform.position += new Vector3(x,y,0) * speed * Time.deltaTime;
    }
}
