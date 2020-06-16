using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource waterFall_1;
    //[SerializeField]
    //GameObject AudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {   
            waterFall_1.Play();
           //AudioSource.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("stopAudio", 2f);
            //AudioSource.SetActive(false);
        }
    }
    void stopAudio()
    { 
        waterFall_1.Stop();
        
    }
    
}
