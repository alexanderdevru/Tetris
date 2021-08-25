using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{
    public GameObject[] figuresPrefabs;
    private GameObject figure;
    public GameObject figuresParent;
    private int nextPrefab;
    public GameManager gameManager;
    private bool firstFigure = true;

    // Start is called before the first frame update
    void Start()
    {
        //NewFigure();
    }

    public void NewFigure()
    {
        if (firstFigure)
        {
            figure = Instantiate(figuresPrefabs[Random.Range(0, figuresPrefabs.Length)], transform.position, Quaternion.identity, figuresParent.transform);
            firstFigure = false;
        }
        else
        {
            figure = Instantiate(figuresPrefabs[nextPrefab], transform.position, Quaternion.identity, figuresParent.transform);
        }
        nextPrefab = Random.Range(0, figuresPrefabs.Length);
        gameManager.UpdateNextFigure(nextPrefab);
    }
}
