using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneratro : MonoBehaviour
{
    [SerializeField] Transform[] tunnelPrefab;
    [SerializeField] Transform[] biome1;
    [SerializeField] Transform[] biome2;
    [SerializeField] Transform[] biome3;
    [SerializeField] Transform[] biome4;
    [SerializeField] int partIndex = 0; // currently change in runtime has no effect
    [SerializeField] int partsCount = 10;
    [SerializeField] int biomeSize = 20;
    int biomeChangeCounter = 0;
    public float offset = 18F; // distance between parts
    [SerializeField] float speed = 1F;
    [SerializeField] float startZ = 0;
    [SerializeField] float cutoffZ = -24F; // when part is gone from screen
    List<Transform> activeParts = new List<Transform>();
    int latestPartIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy template
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        // Spawn initial tunnel parts
        for (int i = 0; i < partsCount; i++)
        {
            Transform newObject = Instantiate(GetCurrentBiomePart(), new Vector3(0, 0, startZ + i * offset), Quaternion.identity);
            newObject.parent = transform;
            activeParts.Add(newObject);
        }

        latestPartIndex = partsCount - 1;

        StartCoroutine(Every1Meter());
    }

    Transform GetCurrentBiomePart()
    {
        Transform partTrans = biome1[0]; //default value
        int variation = Random.Range(0, biome1.Length - 1);

        switch (partIndex)
        {
            case 0:
                partTrans = biome1[variation];
                break;
            case 1:
                partTrans = biome2[variation];
                break;
            case 2:
                partTrans = biome3[variation];
                break;
            case 3:
                partTrans = biome4[variation];
                break;
        }
        return partTrans;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, offset * speed * Time.deltaTime);
    }

    IEnumerator Every1Meter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / offset * speed);
        }
    }


}