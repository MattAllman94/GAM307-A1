using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour //Copied Coin Script and adapted for potions
{
    public float rotateSpeed = 1.0f, floatSpeed = 0.5f, movementDistance = 0.5f;
    
    public GameObject collectPotionEffect;
    

    private float startingY;
    private bool isMovingUp = true;

    void Start()
    {
        startingY = transform.position.y;
        transform.Rotate(transform.up, Random.Range(0f, 360f));
        StartCoroutine(Spin());
        StartCoroutine(Float());
    }

    IEnumerator Spin()
    {
        while (true)
        {
            transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
            yield return 0;
        }
    }

    IEnumerator Float()
    {
        while (true)
        {
            float newY = transform.position.y + (isMovingUp ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;

            if (newY > startingY + movementDistance)
            {
                newY = startingY + movementDistance;
                isMovingUp = false;
            }
            else if (newY < startingY)
            {
                newY = startingY;
                isMovingUp = true;
            }

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthPickup();

        }
    }

    private void HealthPickup() //attempting to heal player only when less than 100% health
    {
        if(GameManager.instance.PlayerHealth < 100)
        {
            GameManager.instance.PlayerHealth = Mathf.Clamp(GameManager.instance.PlayerHealth + 1, 0, 10);
            Instantiate(collectPotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        
       
    }

   
}
