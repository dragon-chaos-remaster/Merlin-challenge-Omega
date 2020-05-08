using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMadeira : MonoBehaviour
{

    Transform target;
    public float disShot;
    public GameObject snare;
    public Transform shootPoint;
    bool isShooting;

    public float minAtirar;
    public float maxAtirar;

    [SerializeField] Pooling pooling;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        OlhandoProPlayer();
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= disShot)
        {
            if (!isShooting)
            {
                InvokeRepeating("Shoot", Random.Range(minAtirar, maxAtirar), Random.Range(minAtirar, maxAtirar));
                isShooting = true;
            }
        }
        else
        {
            CancelInvoke("Shoot");
            isShooting = false;

        }


    }
    void Shoot()
    {
        //Instantiate(flecha, shootPoint.position, shootPoint.rotation);
        GameObject aux = pooling.GetPooledObject();
        if (aux != null)
        {
            aux.SetActive(true);
            aux.transform.position = shootPoint.position;
            aux.transform.rotation = shootPoint.rotation;
        }
    }

    void OlhandoProPlayer()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);
    }
}