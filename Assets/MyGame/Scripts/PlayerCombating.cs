using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombating : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public AudioSource s;
    public AudioClip[] audioClipArray;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTime)

            if (Input.GetKeyDown(KeyCode.Space))
             {
                 Attack();
                nextAttackTime = Time.time + 1f / attackRate;
    }      }
    void Attack()
    {
        //Play an attack animation
        
        animator.SetTrigger("Attack");
        s = GetComponent<AudioSource>();
        s.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        s.PlayOneShot(s.clip);
        {
            
            {
                //Detect enemies in range of attack
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);           
            Debug.Log("We hit" + enemy.name);
        }
    }
    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        return;
  
      Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
    }
}
            
        









                




        
        
   
              




            
