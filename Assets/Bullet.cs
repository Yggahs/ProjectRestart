using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletPower;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyWalker>() != null)
        {
            collision.gameObject.GetComponent<EnemyController>().Damage(bulletPower);
            Debug.Log("ouch");
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,2f);
    }
}
