using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject ChooseLvlPanel;
    public GameObject GamePanel;
    public GameObject GameField;
    public SpawnFigures spawnFigures;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePanel(StartPanel, true);
    }

    public void StartNewGame(int level)
    {
        ActivatePanel(ChooseLvlPanel, false);
        ActivatePanel(GamePanel, true);
        ActivatePanel(GameField, true);
        spawnFigures.NewGame();
    }

    public void ActivatePanel(GameObject panel, bool active)
    {
        if (active)
        {
            //���������� ������
            if (!panel.activeInHierarchy)
            {
                panel.SetActive(true);
            }
        }
        else
        {
            //������������
            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);
            }
        }
    }
}
