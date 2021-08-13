using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{
    public GameObject[] figuresPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        NewFigure();
    }

    public void NewFigure()
    {
        Instantiate(figuresPrefabs[Random.Range(0, figuresPrefabs.Length)], transform.position, Quaternion.identity);
    }
}
