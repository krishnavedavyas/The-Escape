using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeePer : MonoBehaviour
{   [SerializeField]
     GameObject shopKeeper;
    int selectedbutton;
    int selectedButtonCost;
    [SerializeField]
    Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
         
        if (collision.tag == "Player")
        {
            shopKeeper.SetActive(true);
            Player player = collision.GetComponent<Player>();
            Debug.Log("Triggred");
            
            if (player != null)
            {
                UIManager.Instance.openShop(player.diamond);
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            shopKeeper.SetActive(false);
    }
    
    public void selectedItem(int item)
    {
        switch (item)
        {
            case 0 :
                UIManager.Instance.UpdateShopSelection(170);
                selectedbutton = 0;
                selectedButtonCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(67);
                selectedbutton = 1;
                selectedButtonCost = 100;
                break;
            case 2:     
                UIManager.Instance.UpdateShopSelection(-43);
                selectedbutton = 2;
                selectedButtonCost = 50;
                break;
                

        }
       

    }
    public void BuyItem()
    {
        if(player.diamond == selectedButtonCost)
        {
            player.diamond -= selectedButtonCost;
        }
        else
        {
            Debug.Log("You Don't Have Enough Diamonds");
            shopKeeper.SetActive(false);

        }
    }

}
