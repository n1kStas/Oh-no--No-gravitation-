using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishResult : MonoBehaviour
{
    public GameObject theDamageWasDoneStar;
    public GameObject numberOfMovesStar;
    public GameObject levelPassingSecondStar;
    public Timer timer;
    public DrawAPath drawAPath;

    public Text resultDamage;    
    public Text resultNumberOfMoves;
    public Text resultTime;
    public Text levelName;

    public bool[] ShowResult(LevelData levelData, Player player)
    {
        levelName.text = drawAPath.GetComponent<GameController>().gameManager.level.GetComponent<LevelData>().nameLevel;
        bool[] achievementsLevel = new bool[3];
        if (player.health == 2)
        {
            theDamageWasDoneStar.SetActive(true);
            achievementsLevel[0] = true;
            resultDamage.text = "Без столкновений";
            resultDamage.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            resultDamage.text = "Без столкновений";
            theDamageWasDoneStar.SetActive(false);
            achievementsLevel[0] = false;
            resultDamage.color = new Color32(0, 0, 0, 255);
        }
        if(drawAPath.numberOfMoves <= levelData.numberOfMoves)
        {
            numberOfMovesStar.SetActive(true);
            achievementsLevel[1] = true;
            resultNumberOfMoves.text = "Количество ходов: " + levelData.numberOfMoves.ToString();
            resultNumberOfMoves.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            numberOfMovesStar.SetActive(false);
            achievementsLevel[1] = false;
            resultNumberOfMoves.text = "Количество ходов: " + levelData.numberOfMoves.ToString();
            resultNumberOfMoves.color = new Color32(0, 0, 0, 255);
        }
        if(timer.second <= levelData.levelPassingSecond)
        {
            levelPassingSecondStar.SetActive(true);
            achievementsLevel[2] = true;
            resultTime.text = "Время на уровень: " + levelData.levelPassingSecond / 60 + " : " + levelData.levelPassingSecond % 60;
            resultTime.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            levelPassingSecondStar.SetActive(false);
            achievementsLevel[2] = false;
            resultTime.text = "Время на уровень: " + levelData.levelPassingSecond / 60 + " : " + levelData.levelPassingSecond % 60;
            resultTime.color = new Color32(0, 0, 0, 255);
        }
        return achievementsLevel;
    }
}
