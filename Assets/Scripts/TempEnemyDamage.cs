using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyDamage : MonoBehaviour
{


    // Start is called before the first frame update
    public EnemyHealth playerHealth;


    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(20);
        }
    }


}
