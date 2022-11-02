using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineController : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] GameObject sphere;
    [SerializeField] PlayerProjectile projectile;
    [SerializeField] Camera cam;
    Vector3 worldPosition;
    public Vector3 LaunchVect;
    Vector3 screenPosition;
    public bool BallLaunched = false;
    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            line.enabled = true;
            screenPosition = Input.mousePosition;
            screenPosition.z = cam.nearClipPlane + 20;
            worldPosition = cam.ScreenToWorldPoint(screenPosition);
            LaunchVect = worldPosition;

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
            BallLaunched = true;
        }
    }
}
