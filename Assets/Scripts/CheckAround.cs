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
            if (scriptSphere.ballColor == selfcolor)
            {
                sameColorBalls.Add(other.gameObject);
                Amount++;
            }
        }
    }

    public void Explode()
    {
        Debug.Log("Explosion started");
        Destroy(killSphere.gameObject);

        for (int i = 0; i < sameColorBalls.Count; i++)
        {
            if (sameColorBalls[i] != null)
            {
                Destroy(sameColorBalls[i]);
                //KillableSphere script = sameColorBalls[i].GetComponent<KillableSphere>();
                // script.checkScript.Explode();
            }
        }
    }
}
