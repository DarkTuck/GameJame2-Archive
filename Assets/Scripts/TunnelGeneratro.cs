using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneratro : MonoBehaviour
{
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
        for(int i=0; i<12; i++)
        {
            activeParts.Add(ObjectPooler.Instance.GetRandoObject().transform);
            activeParts[i].gameObject.SetActive(true);
            activeParts[i].position = new Vector3(0, 0, offset * i);
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        foreach (Transform activeSegment in activeParts)
        {
           activeSegment.position -= new Vector3(0, 0, offset * speed * Time.deltaTime);
        }
    }
    void PlaceSegment()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tube")
        {
        Debug.Log(other.gameObject.name);
        GameObject newSegment = ObjectPooler.Instance.GetRandoObject();
        other.gameObject.SetActive(false);
        newSegment.SetActive(true);
        activeParts.Remove(other.gameObject.transform);
        newSegment.transform.position = new Vector3(0, 0, offset ) + activeParts[activeParts.Count-1].position;
        activeParts.Add(newSegment.transform);
        }
    }

}