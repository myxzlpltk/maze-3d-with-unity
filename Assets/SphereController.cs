using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private Rigidbody rg;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            Vector3 maju = new Vector3(0, 0, 1);
            rg.AddForce(maju * speed);
        }

        if (Input.GetKey("a"))
        {
            Vector3 kiri = new Vector3(-1, 0, 0);
            rg.AddForce(kiri * speed);
        }

        if (Input.GetKey("s"))
        {
            Vector3 mundur = new Vector3(0, 0, -1);
            rg.AddForce(mundur * speed);
        }

        if (Input.GetKey("d"))
        {
            Vector3 kanan = new Vector3(1, 0, 0);
            rg.AddForce(kanan * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "YouAreWin")
        {
            Debug.Log("MENANG");
        }
    }
}
