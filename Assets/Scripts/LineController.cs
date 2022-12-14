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
    [SerializeField] LayerMask layerMask;
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
            screenPosition = Input.mousePosition;
            screenPosition.z = cam.nearClipPlane + 20;
            worldPosition = cam.ScreenToWorldPoint(screenPosition);
            Debug.DrawRay(worldPosition + Vector3.up, Vector3.down * 5, Color.yellow, 10f);
            RaycastHit hit;
            if (Physics.Raycast(worldPosition + Vector3.up, Vector3.down * 5, out hit, Mathf.Infinity, layerMask))
            {
                line.enabled = true;
                LaunchVect = worldPosition;
                line.SetPosition(0, sphere.transform.position);
                line.SetPosition(1, worldPosition);
            }
        }
        else
        {
            line.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(worldPosition + Vector3.up, Vector3.down * 5, out hit, Mathf.Infinity, layerMask))
            {
                projectile.Launch(worldPosition);
                BallLaunched = true;
            }
        }
    }
}
