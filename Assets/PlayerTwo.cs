using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankTwo : MonoBehaviour
{
    public int health = 6;
    public float playerSpeed = 60f;
    public float rotationSpeed = 0.1f;
    public GameObject TankTop;
    public GameObject TankBase;
    public GameObject Missile;
    public Transform MissileSpawner;

    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement(playerSpeed);
        Cannon();
        StartCoroutine(Fire());


    }

    private void Movement(float speed)
    {
        float horizontalInput = Input.GetAxis("Horizontal2");
        float verticalInput = Input.GetAxis("Vertical2");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * playerSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            TankBase.transform.rotation = Quaternion.RotateTowards(TankBase.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void Cannon()
    {
        if (Input.GetKey(KeyCode.P))
        {
            TankTop.transform.Rotate(0, 0.08f, 0);
        }

        if (Input.GetKey(KeyCode.I))
        {
            TankTop.transform.Rotate(0, -0.08f, 0);
        }
    }

    public IEnumerator Fire()
    {
        if (Input.GetKeyUp(KeyCode.J) && canShoot == true)
        {
            Instantiate(Missile, MissileSpawner.position, MissileSpawner.rotation);
            canShoot = false;
            yield return new WaitForSeconds(2);
            canShoot = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            --health;
        }
        if (health == 0)
        {
            Destroy(this);
        }
    }
}
