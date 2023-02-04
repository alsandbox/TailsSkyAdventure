using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //counting is done from the top
    public GameObject[] enemyFirstLine;
    public GameObject[] enemySecondLine;
    public GameObject[] enemyThirdLine;
    public GameObject[] enemyFourthLine;

    private readonly float repeatRateSlow = 0.6f;
    private readonly float timeDelayInvisibleEnemy = 0.15f;

    public GameStates gameStates;

    private void Start()
    {
        EnemyCall();
    }

    private void EnemyCall()
    {
        if (!gameStates.IsGameOver)
        {
            gameStates.EnemyIsDestroyed = false;
            RandomEnemyMovement();
        }
    }

    private void RandomEnemyMovement()
    {
        int randomFirstEnemy = Random.Range(0, enemyFirstLine.Length);
        int randomSecondEnemy = Random.Range(0, enemySecondLine.Length);
        int randomThirdEnemy = Random.Range(0, enemyThirdLine.Length);

        StartCoroutine(SlowEnemyMovement(randomFirstEnemy, randomSecondEnemy, randomThirdEnemy));
    }

    IEnumerator SlowEnemyMovement(int randomFirstNum, int randomSecondNum, int randomThirdNum)
    {
        enemyFirstLine[randomFirstNum].SetActive(true);
        yield return new WaitForSeconds(repeatRateSlow);
        enemyFirstLine[randomFirstNum].SetActive(false);

        if (!gameStates.EnemyIsDestroyed & !gameStates.IsPaused)
        {
            enemySecondLine[randomSecondNum].SetActive(true);
            yield return new WaitForSeconds(repeatRateSlow);
            enemySecondLine[randomSecondNum].SetActive(false);
        }
        else if (gameStates.IsPaused)
        {
            enemyFirstLine[randomFirstNum].SetActive(true);
            while (gameStates.IsPaused)
            {   
                yield return null;
            }
            enemyFirstLine[randomFirstNum].SetActive(false);
            enemySecondLine[randomSecondNum].SetActive(true);
            yield return new WaitForSeconds(repeatRateSlow);
            enemySecondLine[randomSecondNum].SetActive(false);
        }

        if (!gameStates.EnemyIsDestroyed & !gameStates.IsPaused)
        {
            enemyThirdLine[randomThirdNum].SetActive(true);
            yield return new WaitForSeconds(repeatRateSlow);
            enemyThirdLine[randomThirdNum].SetActive(false);
        }
        else if (gameStates.IsPaused)
        {
            enemySecondLine[randomSecondNum].SetActive(true);
            while (gameStates.IsPaused)
            {
                yield return null;
            }
            enemySecondLine[randomSecondNum].SetActive(false);
            enemyThirdLine[randomThirdNum].SetActive(true);
            yield return new WaitForSeconds(repeatRateSlow);
            enemyThirdLine[randomThirdNum].SetActive(false);
        }

        if (!gameStates.EnemyIsDestroyed & !gameStates.IsPaused)
        {
            enemyFourthLine[randomThirdNum].SetActive(true);
            yield return new WaitForSeconds(timeDelayInvisibleEnemy);
            enemyFourthLine[randomThirdNum].SetActive(false);
        }
        else if (gameStates.IsPaused)
        {
            enemyThirdLine[randomThirdNum].SetActive(true);
            while (gameStates.IsPaused)
            {
                yield return null;
            }
            enemyThirdLine[randomThirdNum].SetActive(false);
            enemyFourthLine[randomThirdNum].SetActive(true);
            yield return new WaitForSeconds(timeDelayInvisibleEnemy);
            enemyFourthLine[randomThirdNum].SetActive(false);
        }

        yield return new WaitForSeconds(repeatRateSlow);
        EnemyCall();
    }
}
