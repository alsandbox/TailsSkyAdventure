using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    //counting is done from the top
    public GameObject[] enemyFirstLine;
    public GameObject[] enemySecondLine;
    public GameObject[] enemyThirdLine;
    public GameObject[] enemyFourthLine;

    private readonly float repeatRateSlow = 0.6f;
    private readonly float timeDelayInvisibleEnemy = 0.4f;
    public bool IsDestroyed { get; set; }

    public UnityEvent EnemyIsMissing;

    private void Start()
    {
        EnemyCall();
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

        if (!IsDestroyed)
        {
            enemySecondLine[randomSecondNum].SetActive(true);
            yield return new WaitForSeconds(repeatRateSlow);
            enemySecondLine[randomSecondNum].SetActive(false);
        }

        if (!IsDestroyed)
        {
            enemyThirdLine[randomThirdNum].SetActive(true);
            yield return new WaitForSeconds(repeatRateSlow);
            enemyThirdLine[randomThirdNum].SetActive(false);
        }

        if (!IsDestroyed)
        {
            enemyFourthLine[randomThirdNum].SetActive(true);
            yield return new WaitForSeconds(timeDelayInvisibleEnemy);
            EnemyIsMissing?.Invoke(); //from PlayerController
            enemyFourthLine[randomThirdNum].SetActive(false);
        }
        
        yield return new WaitForSeconds(repeatRateSlow);
        EnemyCall();
    }

    private void EnemyCall()
    {
        if (!PlayerController.IsGameOver)
        {
            IsDestroyed = false;
            RandomEnemyMovement();
        }
    }
}
