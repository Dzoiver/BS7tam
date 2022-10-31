using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] GameObject killable;
    [SerializeField] Grid grid;
    float minimumDistance = 5f;
    Vector3 newBallPosition;
    Vector3 startPosition;
    Vector3 endPoint;
    Rigidbody rb;
    Material mat;
    MeshRenderer mesh;
    public SphereColor color;
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
        if (other.tag == "kill")
        {
            transform.position = startPosition;
            speed = 0f;
            KillableSphere kill = other.GetComponent<KillableSphere>();
            // Instantiate(killable, transform.position, Quaternion.identity);
            if (kill.IsSameColor(color))
            {
                Debug.Log("Same color");
                if (kill.checkScript.Amount >= 1)
                kill.checkScript.Explode();
                // More than 2? then explode
            }
            else
            {
                Debug.Log("Color not the same, creating ball");
                // Place new ball at hit position
                // Instantiate(killable, newBallPosition, Quaternion.identity);
            }
            InitColor();
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
