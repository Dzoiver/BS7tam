using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] GameObject sphere;
    [SerializeField] PlayerProjectile projectile;
    Vector3 worldPosition;
    Vector3 screenPosition;
    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    void Shoot()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            line.enabled = true;
            screenPosition = Input.mousePosition;
            screenPosition.z = Camera.main.nearClipPlane + 20;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            line.SetPosition(0, sphere.transform.position);
            line.SetPosition(1, worldPosition);
        }
        else
        {
            line.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            projectile.Launch(worldPosition);
        }
    }
}
