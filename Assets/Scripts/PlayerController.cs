using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject tailsCenter;
    public GameObject tailsLeft;
    public GameObject tailsRight;

    //counting is done from the bottom
    public GameObject[] tailsFireFirstLine;
    public GameObject[] tailsFireSecondLine;
    public GameObject[] tailsFireThirdLine;

    private float fireRepeatRate = 0.4f;

    void Start()
    {
        tailsCenter.SetActive(true);
    }

    void Update()
    {
        PlayerMove();
        PlayerShoot();
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
            else if(tailsRight.activeSelf)
            {
                tailsRight.SetActive(false);
                tailsCenter.SetActive(true);
            }
        }
    }

    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

        tailsFireSecondLine[fireNumber].SetActive(true);
        yield return new WaitForSeconds(fireRepeatRate);
        tailsFireSecondLine[fireNumber].SetActive(false);

        tailsFireThirdLine[fireNumber].SetActive(true);
        yield return new WaitForSeconds(fireRepeatRate);
        tailsFireThirdLine[fireNumber].SetActive(false);
    }
}
