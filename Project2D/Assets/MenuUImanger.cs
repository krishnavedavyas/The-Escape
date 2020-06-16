using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUImanger : MonoBehaviour

{
    [SerializeField]
    GameObject Loading;
    [SerializeField] AudioSource maincam;
    [SerializeField]
    AudioSource MenuSoundEffect;
    [SerializeField]
    AudioClip SelectedEffect;
    [SerializeField] GameObject panel;
    public void OnPressMenu()
    {
        panel.SetActive(true);
    }
    public void onpressSoundOn()
    {
        maincam.mute = false;
    }
    public void onpressSoundOFF()
    {
        maincam.mute = true;
    }
    public void OnPressExit()
    {
        panel.SetActive(false);
    }
    public void StartMenu()
    {
        MenuSoundEffect.clip = SelectedEffect;
        MenuSoundEffect.Play();
        Loading.SetActive(true);
        SceneManager.LoadScene("Game");
        
    }

    public void quit()
    {
        MenuSoundEffect.clip = SelectedEffect;
        MenuSoundEffect.Play();
        Application.Quit();
    }
}
