using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneratro : MonoBehaviour
{
    [SerializeField] private Transform tunel1;
    void Start()
    {
        Instantiate(tunel1, new Vector3(0, 0,-32), Quaternion.identity);   
    }

    private void SpawnTube(Vector3 spawnPosition)
    {
        Instantiate(tunel1, spawnPosition, Quaternion.identity);
    }
    void Update()
    {
        
    }
}
