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

	private int[] figureNums = { 0, 0, 0, 0, 0, 0, 0 };

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

}
