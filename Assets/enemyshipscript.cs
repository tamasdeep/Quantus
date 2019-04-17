using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshipscript : MonoBehaviour
{
    public int health = 20;
    public Transform bulletspawn;
    public GameObject emenybullet;
    public float radius = 1F;
    public float projectileSpeed = 2f;
    public bool runbullets = false;
    private float nexttime;
    public GameObject explosion;
    public GameObject player;
    public enum patterns
    {
        fullcircle, down60, rside60, lside60
    }
    public patterns pattern = patterns.fullcircle;
    // Start is called before the first frame update
    void Start()
    {
        nexttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)Time.time == (int)nexttime)
        {
            //Instantiate(emenybullet, bulletspawn.position, Quaternion.identity);
            //Instantiate(emenybullet, new Vector3(bulletspawn.position.x - .2f, bulletspawn.position.y, bulletspawn.position.z), Quaternion.identity);
            //Instantiate(emenybullet, new Vector3(bulletspawn.position.x + .2f, bulletspawn.position.y, bulletspawn.position.z), Quaternion.identity);
            if (pattern == patterns.fullcircle)
            {
                SpawnProjectile360(10);
            }
            else if (pattern == patterns.down60)
            {
                SpawnProjectiledown60(5);
            }
            else if (pattern == patterns.rside60)
            {
                SpawnProjectileright(5);
            }else if(pattern == patterns.lside60)
            {
                SpawnProjectileleft(5);
            }

            nexttime = Time.time + 1;
        }

    }

    // Spawns x number of projectiles.
    private void SpawnProjectiledown60(int _numberOfProjectiles)
    {
        float angleStep = 60f / _numberOfProjectiles;
        float angle = -30f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = bulletspawn.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = bulletspawn.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - bulletspawn.position).normalized * projectileSpeed;

            // Create game objects.
            GameObject tmpObj = Instantiate(emenybullet, bulletspawn.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, -projectileMoveDirection.y, 0);


            // Destory the gameobject after 10 seconds.
            //Destroy(tmpObj, 10F);

            angle += angleStep;
        }
    }

    // Spawns x number of projectiles.
    private void SpawnProjectile360(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = bulletspawn.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = bulletspawn.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - bulletspawn.position).normalized * projectileSpeed;

            // Create game objects.
            GameObject tmpObj = Instantiate(emenybullet, bulletspawn.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0) / 2;


            // Destory the gameobject after 10 seconds.
            Destroy(tmpObj, 10F);

            angle += angleStep;
        }
    }

    private void SpawnProjectileright(int _numberOfProjectiles)
    {
        float angleStep = 60f / _numberOfProjectiles;
        float angle = 60f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = bulletspawn.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = bulletspawn.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - bulletspawn.position).normalized * projectileSpeed;

            // Create game objects.
            GameObject tmpObj = Instantiate(emenybullet, bulletspawn.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0) / 2;


            // Destory the gameobject after 10 seconds.
            Destroy(tmpObj, 10F);

            angle += angleStep;
        }
    }

    private void SpawnProjectileleft(int _numberOfProjectiles)
    {
        float angleStep = 60f / _numberOfProjectiles;
        float angle = -120f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = bulletspawn.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = bulletspawn.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - bulletspawn.position).normalized * projectileSpeed;

            // Create game objects.
            GameObject tmpObj = Instantiate(emenybullet, bulletspawn.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0) / 2;


            // Destory the gameobject after 10 seconds.
            Destroy(tmpObj, 10F);

            angle += angleStep;
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.gameObject.tag.Equals("Bullet1"))
        {
            
            Destroy(hit.gameObject);
            health = health - 5;
            if(health <= 0)
            {
                player.gameObject.GetComponent<PlayerController>().myscore = player.gameObject.GetComponent<PlayerController>().myscore + 20;
                Destroy(gameObject);
                explosion.transform.localScale = new Vector3(.1f, .1f, .1f);
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }
}
