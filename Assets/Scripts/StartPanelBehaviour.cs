using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelBehaviour : MonoBehaviour
{
    public MainView mainView;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            mainView.ActivatePanel(this.gameObject, false);
            mainView.ActivatePanel(mainView.ChooseLvlPanel, true);
        }
    }
}
