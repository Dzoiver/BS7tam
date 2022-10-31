using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAround : MonoBehaviour
{
    public SphereColor selfcolor;
    public int Amount = 0;
    [SerializeField] KillableSphere killSphere;
    [SerializeField] List<GameObject> sameColorBalls = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "SphereToDestroy" && other.gameObject != killSphere.gameObject)
        {
            KillableSphere scriptSphere = other.gameObject.GetComponent<KillableSphere>();
            if (scriptSphere.color == selfcolor)
            {
                sameColorBalls.Add(other.gameObject);
                Amount++;
            }
        }

        //if (other.gameObject.name == "Sphere" || false)
        //{
        //    PlayerProjectile projectile = other.gameObject.GetComponent<PlayerProjectile>();
        //    if (projectile.color == selfcolor)
        //    {
        //        Explode();
        //    }
        //}
    }

    public void Explode()
    {
        Debug.Log("Explosion started");
        Destroy(killSphere.gameObject);

        for (int i = 0; i < sameColorBalls.Count; i++)
        {
            KillableSphere script = sameColorBalls[i].GetComponent<KillableSphere>();
            Debug.Log(script);
            // script.checkScript.Explode();
        }
    }
}
