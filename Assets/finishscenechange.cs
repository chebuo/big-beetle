using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishscenechange : MonoBehaviour
{
    public GameObject fly;
    playercontroller PlayerController;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        fly = GameObject.Find("fly");
        PlayerController = fly.GetComponent<playercontroller>();
        image = this.GetComponent<Image>();
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.isBattle)
        {
            Debug.Log("kon");
            image.fillAmount += 0.01f;
        }
        if (image.fillAmount == 1 && PlayerController.Win)
        {
            SceneManager.LoadScene("WinScene");
        }
        if (image.fillAmount == 1 && !PlayerController.Win)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
