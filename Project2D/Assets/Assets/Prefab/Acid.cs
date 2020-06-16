using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField]
    float AcidSpeed;

    private void Start()
    {
        Destroy(this.gameObject, 2.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.left *AcidSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IDamageAble Hit = collision.GetComponent<IDamageAble>();
            if(Hit != null)
            {
                Hit.Damage();
                Destroy(this.gameObject);
            }
            
        }
    }
}
