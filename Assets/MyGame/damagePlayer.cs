using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public int Health = 3;
    int damage = 1;

    private void Start()
    {
        print(Health);
    }
    void OnCollisionEnter(Collision _collision)
    {
     if (_collision.gameObject.tag == "enemy")
        {
            print("enemy Just touched Something!");
        }
    }
    
        
    }

