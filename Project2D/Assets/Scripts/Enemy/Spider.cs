using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageAble
{
    public GameObject DiamondPrefab;
    public new int  Health { get; set; }
    public GameObject AcidPrefab;
    public override void Init()
    {
        base.Init();
        Health = base.Health;
       // Animator.SetTrigger("IsIdel");
        CallAfter();
        //germs = 6;
    }
    public override void Movement()
    {
       
    }
    public void Damage()    
    { 
        Health -= 10;
        if (Health < 1)
        {
            IsDead = true;
            Animator.SetTrigger("Dead");
            GameObject DiamondPreCoount = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            Debug.Log("Germs :" + germs);
            DiamondPreCoount.GetComponent<Diamond>().germs += base.germs;
            EmenySoundEffect.clip = DeadSound;
            EmenySoundEffect.Play();
            Invoke("DestoryInSeconds", 2.0f);
        }
    }
   public void Attack()
    {  
        Instantiate(AcidPrefab, transform.position, Quaternion.identity);
        EmenySoundEffect.clip = AttackSound;
        EmenySoundEffect.Play();
    }
    void DestoryInSeconds()
    {
        Destroy(this.gameObject);
    }
    void CallAfter()
    {
        Animator.SetTrigger("IsIdel");
        Invoke("CallAfter", 2f);
    }

}
