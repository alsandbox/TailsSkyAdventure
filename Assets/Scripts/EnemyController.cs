using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //counting is done from the top
    public GameObject[] enemyFirstLine;
    public GameObject[] enemySecondLine;
    public GameObject[] enemyThirdLine;
    private float repeatRateCall = 2.6f;
    private float repeatRateSlow = 0.8f;

    private void Start()
    {
        StartCoroutine(CallEnemy());
    }

    private void RandomEnemyMovement()
    {
        int randomFirstEnemy = Random.Range(0, enemyFirstLine.Length);
        int randomSecondEnemy = Random.Range(0, enemySecondLine.Length);
        int randomThirdEnemy = Random.Range(0, enemyThirdLine.Length);

        if (enemyFirstLine[randomFirstEnemy].activeSelf)
        {
            StartCoroutine(SlowEnemyMovement(randomFirstEnemy));
        }
        else if (enemySecondLine[randomSecondEnemy].activeSelf)
        {
            StartCoroutine(SlowEnemyMovement(randomSecondEnemy));
        }
        else
        {
            StartCoroutine(SlowEnemyMovement(randomThirdEnemy));
        }
    }

    IEnumerator SlowEnemyMovement(int enemyNumber)
    {
        enemyFirstLine[enemyNumber].SetActive(true);
        yield return new WaitForSeconds(repeatRateSlow);
        enemyFirstLine[enemyNumber].SetActive(false);

        enemySecondLine[enemyNumber].SetActive(true);
        yield return new WaitForSeconds(repeatRateSlow);
        enemySecondLine[enemyNumber].SetActive(false);

        enemyThirdLine[enemyNumber].SetActive(true);
        yield return new WaitForSeconds(repeatRateSlow);
        enemyThirdLine[enemyNumber].SetActive(false);
    }

    IEnumerator CallEnemy()
    {
        while (true)
        {
            RandomEnemyMovement();
            yield return new WaitForSeconds(repeatRateCall);
        }
    }
}
