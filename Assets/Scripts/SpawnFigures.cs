using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{
    public GameObject[] figuresPrefabs;
    private GameObject figure;
    public GameObject figuresParent;

    // Start is called before the first frame update
    void Start()
    {
        //NewFigure();
    }

    public void NewFigure()
    {
        figure = Instantiate(figuresPrefabs[Random.Range(0, figuresPrefabs.Length)], transform.position, Quaternion.identity, figuresParent.transform);
    }

    public void NewGame()
    {
        NewFigure();
    }
}
