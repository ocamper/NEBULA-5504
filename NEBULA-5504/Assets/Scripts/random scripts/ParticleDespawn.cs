using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour
{
    [SerializeField] private float timeToDespawn;
    
    private void Awake()
    {
        Invoke("StopParticle", timeToDespawn);
    }

    void StopParticle()
    {
        Destroy(gameObject);
    }
}
