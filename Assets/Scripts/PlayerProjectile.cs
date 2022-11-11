using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] GameObject killable;
    [SerializeField] LineController lineC;
    [SerializeField] Director dir;

    Grid grid;
    Vector3 newBallPosition;
    Vector3 startPosition;
    Vector3 endPoint;
    Rigidbody rb;
    Material mat;
    MeshRenderer mesh;
    public SphereColor color;
    float constantSpeed = 30f;
    float speed = 30f;

    List<SphereColor> colorsLeft = new List<SphereColor>();
    // Start is called before the first frame update
    void Start()
    {
        colorsLeft.Add(SphereColor.Red);
        colorsLeft.Add(SphereColor.Green);
        colorsLeft.Add(SphereColor.Blue);

        endPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        InitColor();
        startPosition = transform.position;
    }

    public void InitGrid(Grid newgrid)
    {
        grid = newgrid;
    }

    private void InitColor()
    {
        int rng = Random.Range(0, 3);
        switch (rng)
        {
            case 0:
                if (!dir.IsBlueLeft() && dir.gameStarted)
                {
                    goto case 1;
                }
                color = SphereColor.Blue;
                mat.color = new Color(0, 0, 1);
                break;
            case 1:
                if (!dir.IsGreenLeft() && dir.gameStarted)
                {
                    goto case 2;
                }
                color = SphereColor.Green;
                mat.color = new Color(0, 1, 0);
                break;
            case 2:
                if (!dir.IsRedLeft() && dir.gameStarted)
                {
                    goto case 0;
                }
                color = SphereColor.Red;
                mat.color = new Color(1, 0, 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kill" && lineC.BallLaunched)
        {
            newBallPosition = transform.position; // Remember hit position
            transform.position = startPosition; // Return Player's ball to its origin
            speed = 0f; // Stop the speed
            KillableSphere kill = other.GetComponent<KillableSphere>();
            if (kill.IsSameColor(color) && kill.checkScript.AdjacentBallsCount >= 1)
                kill.checkScript.ChainExplosion();
            else
            {
                Vector3 endPoint = newBallPosition - (rb.velocity.normalized * 1); // Reverted new ball world pos
                Vector3Int cellPos = grid.WorldToCell(endPoint); // New ball grid pos
                newBallPosition = grid.CellToWorld(cellPos); // World pos from grid pos
                newBallPosition.y = 0;
                GameObject ball = Instantiate(killable, newBallPosition, Quaternion.identity);
                dir.BallCreated(color);
                KillableSphere script = ball.GetComponent<KillableSphere>();
                script.SetColor(color);
                script.checkScript.IsCreatedByPlayer = true;
            }
            InitColor();
            lineC.BallLaunched = false;
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
