using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    Camera cam;
    float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Camera.main.enabled = false;
        cam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.position;
        move.z -= speed * Time.deltaTime;
        transform.position = move;
    }
}
