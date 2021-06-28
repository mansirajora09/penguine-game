using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_UI : MonoBehaviour {

    public Text stars;
    public GameObject tapToBegin;
    public GameObject heart1, heart2, heart3;
	
	void Update ()
    {
        stars.text = GameManager.Stars.ToString();
        if (Input.anyKeyDown)
            tapToBegin.SetActive(false);
        CheckHearts();
    }

    public void CheckHearts()
    {
        if (GameManager.Hearts <= 0)
            GameManager.instance.GameOver();

        if (GameManager.Hearts >= 3)
            GameManager.Hearts = 3;

        switch (GameManager.Hearts)
        {
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;

            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;

            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            default:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
        }
    }

}
