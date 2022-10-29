using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Touch theTouch;
    Vector3 screenPosition;
    Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenPosition = Input.mousePosition;
            screenPosition.z = Camera.main.nearClipPlane + 20;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            // transform.position = worldPosition;
            // converted.y = 0f;
        }

        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Moved)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(theTouch.position);
                touchPos.z = 10f;
            }
        }
    }
}
