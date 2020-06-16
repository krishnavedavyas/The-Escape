using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public int germs = 1;
   public AudioSource DiamondCollectionSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.UPdateGermCount(germs);
                DiamondCollectionSound.Play();
                //DiamondCollectionSound.Stop();
                gameObject.GetComponent<SpriteRenderer>().enabled=false;

                Invoke("DestoryGameObject", 1f);
            }

        }

    }
    void DestoryGameObject()
    {
        Destroy(this.gameObject);
    }
    
}