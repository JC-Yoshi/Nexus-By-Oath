using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //  public Animator animator;

    public Transform attackPoint; // The point from which the wepons range is calculated
    public float attackRange = 0.5f;// the range the wepon can attack up to
    public LayerMask enemyLayers;// defines what an enemy is

    public int attackDamage = 1;// the players damage

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))//triggers when left mouse click is clicked
        {
            Attack();
        }
    }

    void Attack()// the attack function 
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger(); // name of the trigger will go in the brakets


        //detect enemies in range
       Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);


        //damage them
        foreach(Collider enemy in hitEnemies)
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);//calls the enemy script and allows damage to be done 
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);   
    }
}
