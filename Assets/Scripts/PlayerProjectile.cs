using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] GameObject killable;
    [SerializeField] Grid grid;
    [SerializeField] LineController lineC;
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
            newBallPosition = transform.position;
            transform.position = startPosition;
            speed = 0f;
            KillableSphere kill = other.GetComponent<KillableSphere>();
            if (kill.IsSameColor(color) && kill.checkScript.Amount >= 1)
            {
                Debug.Log("Same color");
                kill.checkScript.Explode();
            }
            else
            {
                Debug.Log("Color not the same, creating ball");
                Vector3 endPoint = newBallPosition - (rb.velocity.normalized * 1);
                Debug.Log(endPoint);
                Vector3Int cellPos = grid.WorldToCell(endPoint);
                newBallPosition = grid.CellToWorld(cellPos);
                GameObject ball = Instantiate(killable, newBallPosition, Quaternion.identity);
                ball.GetComponent<KillableSphere>().SetColor(color);
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
