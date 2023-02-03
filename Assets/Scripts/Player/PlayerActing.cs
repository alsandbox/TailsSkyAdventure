using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActing : MonoBehaviour
{
    public GameObject tailsCenter;
    public GameObject tailsLeft;
    public GameObject tailsRight;

    //counting is done from the bottom
    public GameObject[] tailsFireFirstLine;
    public GameObject[] tailsFireSecondLine;
    public GameObject[] tailsFireThirdLine;

    private readonly float fireRepeatRate = 0.2f;
    public EnemyController enemyController;

    public AudioSource fireSound;

    void Start()
    {
        tailsCenter.SetActive(true);
        enemyController = enemyController.GetComponent<EnemyController>();
    }

    void Update()
    {
        if (!PlayerController.IsGameOver & !UIHandler.isPaused)
        {
            PlayerMove();
            PlayerShoot();
        }
    }

    private void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (tailsCenter.activeSelf)
            {
                tailsCenter.SetActive(false);
                tailsRight.SetActive(true);
            }
            else if (tailsLeft.activeSelf)
            {
                tailsLeft.SetActive(false);
                tailsCenter.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (tailsCenter.activeSelf)
            {
                tailsLeft.SetActive(true);
                tailsCenter.SetActive(false);
            }
            else if (tailsRight.activeSelf)
            {
                tailsRight.SetActive(false);
                tailsCenter.SetActive(true);
            }
        }
    }

    private void PlayerShoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fireSound.Play();

            if (tailsCenter.activeSelf)
            {
                StartCoroutine(SlowFire(1));
            }
            else if (tailsRight.activeSelf)
            {
                StartCoroutine(SlowFire(2));
            }
            else
            {
                StartCoroutine(SlowFire(0));
            }
        }
    }

    IEnumerator SlowFire(int fireNumber)
    {
        tailsFireFirstLine[fireNumber].SetActive(true);
        yield return new WaitForSeconds(fireRepeatRate);
        tailsFireFirstLine[fireNumber].SetActive(false);

        if (!enemyController.IsDestroyed)
        {
            tailsFireSecondLine[fireNumber].SetActive(true);
            yield return new WaitForSeconds(fireRepeatRate);
            tailsFireSecondLine[fireNumber].SetActive(false);
        }
        else
        {
            yield break;
        }

        if (!enemyController.IsDestroyed)
        {
            tailsFireThirdLine[fireNumber].SetActive(true);
            yield return new WaitForSeconds(fireRepeatRate);
            tailsFireThirdLine[fireNumber].SetActive(false);
        }
    }
}
