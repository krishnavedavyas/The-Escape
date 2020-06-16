using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text PlayerGermCountText;
    public Text UIGermCountText;
    public Image selectionImage;
    public Image[] PlayerLifes;
    bool paused = false;
    [SerializeField]
   public  AudioSource MenuSoundEffect;
    [SerializeField]
    AudioClip SelectedEffect;
    public void openShop(int germCount)
    {
        PlayerGermCountText.text = "" + germCount + "G";

    }
    public void UpdateShopSelection(int ypos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, ypos);
    }
    private void Start()
    {
        Instance = this;
    }
    public void GermCount(int DiamondCount)
    {
        UIGermCountText.text = "" + DiamondCount + "G";
    }
    public void UpdateLifes(int Lifes)
    {
        for (int i = 0; i <= Lifes; i++)
        {
            if (i == Lifes)
            {
                PlayerLifes[i].enabled = false;
            }
        }
    }
    public void REstartButton()
    {
        MenuSoundEffect.clip = SelectedEffect;
        MenuSoundEffect.Play();
        SceneManager.LoadScene(0);
        
    }
   
    public void OnMouseDown()
    {
        paused = !paused;
        if (paused)
        {
            MenuSoundEffect.clip = SelectedEffect;
            MenuSoundEffect.Play();
            Time.timeScale = 0;
        }
        else
        {
            MenuSoundEffect.clip = SelectedEffect;
            MenuSoundEffect.Play();
            Time.timeScale = 1;
        }
    }

}

