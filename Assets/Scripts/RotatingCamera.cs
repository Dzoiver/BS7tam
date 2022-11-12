using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    Vector3 startVector = new Vector3();
    Camera cam;
    float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        startVector = transform.position;
        cam = GetComponent<Camera>();
        Camera.main.enabled = false;
        cam.enabled = true;
    }

    void ResetCameraPos()
    {
        transform.position = startVector;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0)
        {
            ResetCameraPos();
        }
        Vector3 move = transform.position;
        move.z -= speed * Time.deltaTime;
        transform.position = move;
    }
}
