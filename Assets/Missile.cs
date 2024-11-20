using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Rigidbody body;
    public GameObject missile;
    GameObject barrel;
    public float BulletSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        barrel = GameObject.Find("Tank Top");
        body = this.GetComponent<Rigidbody>();

        
        Debug.Log("added force");
        StartCoroutine(WaitFor());

    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(transform.up * BulletSpeed, ForceMode.Impulse);
    }

    public void EndLife()
    {
        Destroy(missile);
    }

    public IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(5);
        EndLife();
    }
}
