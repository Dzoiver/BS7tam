using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAround : MonoBehaviour
{
    public SphereColor selfcolor;
    [SerializeField] KillableSphere killSphere;
    [SerializeField] List<GameObject> sameColorBalls = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "SphereToDestroy")
        {
            KillableSphere scriptSphere = other.gameObject.GetComponent<KillableSphere>();
            if (scriptSphere.color == selfcolor)
            {
                sameColorBalls.Add(other.gameObject);
            }
        }

        if (other.gameObject.name == "Sphere")
        {
            PlayerProjectile projectile = other.gameObject.GetComponent<PlayerProjectile>();
            if (projectile.color == selfcolor)
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        for (int i = 0; i < sameColorBalls.Count; i++)
        {
            Destroy(sameColorBalls[i]);
            KillableSphere script = sameColorBalls[i].GetComponent<KillableSphere>();

            script.checkScript.Explode();
        }
    }
}
