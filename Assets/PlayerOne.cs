using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankOne : MonoBehaviour
{
    public int Health = 3;
    public int Damage = 1;
    public float playerSpeed = 5f;
    public GameObject TankTop;
    public GameObject TankBase;
    public GameObject Missile;
    public Transform MissileSpawner;

    float rotation;
    
    bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
         rotation = TankBase.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(playerSpeed);
        Cannon(1);
        StartCoroutine(Fire());
       
    }

    private void Movement(float speed)
    {

        

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (rotation < 90)
            {
                TankBase.transform.Rotate(Vector3.up * 90 * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (rotation > -90)
            {
                TankBase.transform.Rotate(Vector3.up * -90 * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    private void Cannon(int Damage)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            TankTop.transform.Rotate(0, 0.5f, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            TankTop.transform.Rotate(0, -0.5f, 0);
        }
    }

    public void Shoot()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            Instantiate(Missile, MissileSpawner.position, MissileSpawner.rotation);
        }
    }

    
    public IEnumerator Fire()
    {
        if (Input.GetKeyUp(KeyCode.F) && canShoot == true)
        {
            Shoot();
            canShoot = false;
            yield return new WaitForSeconds(2);
            canShoot = true;
        }
    }
}
