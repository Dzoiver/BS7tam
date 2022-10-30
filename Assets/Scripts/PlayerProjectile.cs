using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPoint;
    Rigidbody rb;
    Material mat;
    MeshRenderer mesh;
    SphereColor color;
    float constantSpeed = 30f;
    float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        InitColor();
        startPosition = transform.position;
    }

    private void InitColor()
    {
        int rng = Random.Range(0, 3);
        switch (rng)
        {
            case 0:
                color = SphereColor.Blue;
                mat.color = new Color(0, 0, 1);
                break;
            case 1:
                color = SphereColor.Green;
                mat.color = new Color(0, 1, 0);
                break;
            case 2:
                color = SphereColor.Red;
                mat.color = new Color(1, 0, 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        KillableSphere kill = other.GetComponent<KillableSphere>();
        if (kill.IsSameColor(color))
        {
            transform.position = startPosition;
            speed = 0f;
        }
    }

    public void Launch(Vector3 target)
    {
        speed = constantSpeed;
        endPoint = target - transform.position;
        rb.AddForce(endPoint * constantSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * rb.velocity.normalized;
    }
}
