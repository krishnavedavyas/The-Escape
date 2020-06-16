using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit:"+collision.name);
        IDamageAble hit = collision.GetComponent<IDamageAble>();
        if (hit != null)
        hit.Damage();
    }
}
