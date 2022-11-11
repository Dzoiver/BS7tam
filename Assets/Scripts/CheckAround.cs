using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAround : MonoBehaviour
{
    public SphereColor selfcolor;
    public int AdjacentBallsCount = 0; // Self excluded
    public bool Exploded = false;
    public static int ChainCount = 0;
    public bool IsCreatedByPlayer = false;
    [SerializeField] KillableSphere killSphere;
    [SerializeField] List<GameObject> sameColorBalls = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "BallToDestroy" || other.gameObject.name == "BallToDestroy(Clone)") && other.gameObject != killSphere.gameObject)
        {
            KillableSphere scriptSphere = other.gameObject.GetComponent<KillableSphere>();
            if (scriptSphere.ballColor == selfcolor)
            {
                sameColorBalls.Add(other.gameObject);
                AdjacentBallsCount++;
                if (sameColorBalls.Count > 1 && IsCreatedByPlayer) // Means there are 3 in the chain at least
                {
                    for (int i = 0; i < sameColorBalls.Count; i++)
                    {
                        KillableSphere adjacentKillBall = sameColorBalls[i].GetComponent<KillableSphere>();
                        adjacentKillBall.checkScript.ChainExplosion();
                    }
                }
                else
                {
                    if (IsCreatedByPlayer)
                    {
                        KillableSphere script = other.gameObject.GetComponent<KillableSphere>();
                        script.checkScript.TryExplodeChain();
                    }
                }
            }
        }
    }

    public void TryExplodeChain()
    {
        if (sameColorBalls.Count > 1)
        {
            ChainExplosion();
        }
    }

    public void ChainExplosion()
    {
        Destroy(killSphere.gameObject);
        Exploded = true;
        for (int i = 0; i < sameColorBalls.Count; i++)
        {
            if (sameColorBalls[i] != null)
            {
                KillableSphere adjacentKillBall = sameColorBalls[i].GetComponent<KillableSphere>();
                if (!adjacentKillBall.checkScript.Exploded)
                {
                    adjacentKillBall.checkScript.ChainExplosion();
                }
            }
        }
    }
}
