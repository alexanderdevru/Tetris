using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	public TMP_Text tFormNumber;
	public TMP_Text lRightFormNumber;
	public TMP_Text zLeftFormNumber;
	public TMP_Text squareFormNumber;
	public TMP_Text zRightFormNumber;
	public TMP_Text lLeftFormNumber;
	public TMP_Text lineFormNumber;
	
	public TMP_Text linesNumber;
	private int linesCount = 0;

	public TMP_Text topScoreNumber;
	private int topScoreCount = 0;

	public TMP_Text scoresNumber;
	private int scoresCount = 0;

	private const int figureCost = 5;
	private const int lineCost = 500;

	private int[] figureNums = { 0, 0, 0, 0, 0, 0, 0 };

	public GameObject[] figuresViews;
	public GameObject figuresParent;

	private int difficultyLevel = 0;
	public TMP_Text diffLevelText;
	private const int maxLevel = 9;

	public float fallingTime = 0.8f;

	public SpawnFigures spawnFigures;

	void Awake()
	{
		if (!_instance)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void DeleteFigureView()
    {
        if (figuresParent.transform.childCount > 1)
        {
			Destroy(figuresParent.transform.GetChild(1).gameObject);	
		}
    }

	public void UpdateNextFigure(int prefabIndex)
    {
		Debug.Log("prefab index is " + prefabIndex);
		DeleteFigureView();
        switch (prefabIndex)
        {
			case 0:
				//tform
				Instantiate(figuresViews[0], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			case 1:
				//lright
				Instantiate(figuresViews[1], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			case 2:
				//zleft
				Instantiate(figuresViews[2], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			case 3:
				//square
				Instantiate(figuresViews[3], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			case 4:
				//tright
				Instantiate(figuresViews[4], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			case 5:
				//lleft
				Instantiate(figuresViews[5], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			case 6:
				//line
				Instantiate(figuresViews[6], figuresParent.transform.position, Quaternion.identity, figuresParent.transform);
				break;

			default:
                break;
        }
    }

	public void UpdateScores(bool figureOrLine)
    {
        if (figureOrLine)
        {
			//figure
			scoresCount += figureCost;
        }
        else
        {
			//line
			scoresCount += lineCost;
        }
		scoresNumber.text = scoresCount.ToString();
    }

	public void UpdateLinesNumber()
    {
		linesCount++;
		linesNumber.text = linesCount.ToString();
		Debug.Log(linesCount % 10);
        if (linesCount % 10 == 0 && difficultyLevel < maxLevel)
        {
			IncreaseDifficultyLevel();
        }
	}

	private void IncreaseDifficultyLevel()
    {
		difficultyLevel++;
		diffLevelText.text = difficultyLevel.ToString();
		fallingTime -= 0.08f;
    }

	public void UpdateFiguresStatistic(TetrisFigure.FigureTypes figureType)
    {
		Debug.Log("UpdateFiguresStatistic " + figureType);
        switch (figureType)
        {
            case TetrisFigure.FigureTypes.LLeftForm:
				//5
				figureNums[5]++;
				lLeftFormNumber.text = figureNums[5].ToString();
				break;
            case TetrisFigure.FigureTypes.LRightForm:
				//1
				figureNums[1]++;
				lRightFormNumber.text = figureNums[1].ToString();
				break;
            case TetrisFigure.FigureTypes.LineForm:
				//6
				figureNums[6]++;
				lineFormNumber.text = figureNums[6].ToString();
				break;
            case TetrisFigure.FigureTypes.SquareForm:
				//3
				figureNums[3]++;
				squareFormNumber.text = figureNums[3].ToString();
				break;
            case TetrisFigure.FigureTypes.TForm:
				//0
				figureNums[0]++;
				tFormNumber.text = figureNums[0].ToString();
				break;
            case TetrisFigure.FigureTypes.ZLeftForm:
				//2
				figureNums[2]++;
				zLeftFormNumber.text = figureNums[2].ToString();
				break;
            case TetrisFigure.FigureTypes.ZRightForm:
				//4
				figureNums[4]++;
				zRightFormNumber.text = figureNums[4].ToString();
				break;
            default:
                break;
        }
    }

	public void NewGame(int level)
    {
		SetDifficultyLevel(level);
		spawnFigures.NewFigure();
    }

	private void SetDifficultyLevel(int level)
    {
		difficultyLevel = level;
		diffLevelText.text = difficultyLevel.ToString();
		fallingTime -= 0.08f * level;
	}

	public void GameOver()
    {
		Debug.Log("Игра окончена");
    }
}
