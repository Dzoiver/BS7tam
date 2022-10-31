using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineController : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] GameObject sphere;
    [SerializeField] PlayerProjectile projectile;
    Vector3 worldPosition;
    Vector3 screenPosition;
    bool gameStarted = false;
    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    public void StartGame()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(0.1f);
        seq.onComplete = Seq;
    }

    public void Seq()
    {
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
            return;

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
