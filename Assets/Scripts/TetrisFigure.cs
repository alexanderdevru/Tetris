using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisFigure : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    private GameManager gameManager;

    public enum FigureTypes
    {
        LLeftForm,
        LRightForm,
        LineForm,
        SquareForm,
        TForm,
        ZLeftForm,
        ZRightForm
    }

    private const string lLeftForm = "L Left Form(Clone)";
    private const string lRightForm = "L Right Form(Clone)";
    private const string lineForm = "Line Form(Clone)";
    private const string squareForm = "Square Form(Clone)";
    private const string tForm = "T Form(Clone)";
    private const string zLeftForm = "Z Left Form(Clone)";
    private const string zRightForm = "Z Right Form(Clone)";

    private FigureTypes figureType;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("figure instantiated " + gameObject.name);
        SetFigureType();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateFiguresStatistic(figureType);
        gameManager.UpdateScores(true);
        fallTime = gameManager.fallingTime;
        Debug.Log("Fall time " + fallTime);
    }

    public FigureTypes GetFigureType()
    {
        return figureType;
    }

    private void SetFigureType()
    {
        switch (gameObject.name)
        {
            case lLeftForm:
                figureType = FigureTypes.LLeftForm;
                break;
            case lRightForm:
                figureType = FigureTypes.LRightForm;
                break;
            case lineForm:
                figureType = FigureTypes.LineForm;
                break;
            case squareForm:
                figureType = FigureTypes.SquareForm;
                break;
            case tForm:
                figureType = FigureTypes.TForm;
                break;
            case zLeftForm:
                figureType = FigureTypes.ZLeftForm;
                break;
            case zRightForm:
                figureType = FigureTypes.ZRightForm;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                if (!IsGameOver())
                {
                    AddToGrid();
                    CheckForLines();
                    this.enabled = false;
                    FindObjectOfType<SpawnFigures>().NewFigure();
                }
            }
            previousTime = Time.time;
        }
    }

    private bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsGameOver()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            Debug.Log("roundedX = " + roundedX);
            Debug.Log("roundedY = " + roundedY);

            if (roundedY >= height)
            {
                Debug.Log("Game Over");
                this.enabled = false;
                gameManager.GameOver();
                return true;
            }
        }

        return false;
    }

    private void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    private void CheckForLines()
    {
        for(int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                Debug.Log("line complete");
                gameManager.UpdateLinesNumber();
                gameManager.UpdateScores(false);
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    private bool HasLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    private void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    private void RowDown(int i)
    {
        for(int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
