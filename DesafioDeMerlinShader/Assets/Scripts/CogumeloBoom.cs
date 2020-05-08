using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogumeloBoom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        //colocar particulas de explosão
    }
}
