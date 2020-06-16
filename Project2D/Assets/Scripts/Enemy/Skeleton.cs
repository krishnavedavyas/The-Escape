using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageAble
{
    public GameObject DiamondPrefab;
    public new int Health { get; set; }
    
    public override void Init()
    {
        base.Init();
        Health = base.Health;
    }
    public override void Movement()
    {
        base.Movement();
    }
    public void Damage()
    {
        Debug.Log("hit");
        Health -= 10;
        IsHit = true;
        
        Animator.SetTrigger("IsHit");
        Animator.SetBool("IsCombat", true);
        if (Health < 1)
        {
            IsDead = true;
            Animator.SetTrigger("Dead");

          
            GameObject DiamondPreCoount = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            Debug.Log("INstantiate");
            DiamondPreCoount.GetComponent<Diamond>().germs += base.germs;
            Invoke("DestoryInSeconds", 2f);
        }
       
    }
    void DestoryInSeconds()
    {
        Destroy(this.gameObject);
    }

}
