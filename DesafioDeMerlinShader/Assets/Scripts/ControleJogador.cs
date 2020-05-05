﻿using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    Rigidbody fisica;
    RaycastHit hit;
    Vector3 movimento;

    [SerializeField] string pisandoEmQueIlha;


    private Animator animator;


    //ector3 posicaoDoMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    void Start()
    {
        animator = GetComponent<Animator>();
        fisica = GetComponent<Rigidbody>();
        Cursor.visible = false;

    }

    private void Update()
    {
        if (animator == null)
            return;
        float axisX = Input.GetAxisRaw("Vertical");
        float axixZ = Input.GetAxisRaw("Horizontal");

        movimento = new Vector3((axisX), 0f, -(axixZ));
        movimento = movimento.normalized * speed;
        fisica.velocity = movimento;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            Vector3 playerToMouse = (hit.point - transform.position).normalized;
            playerToMouse.y = 0;
            Quaternion newRot = Quaternion.LookRotation(playerToMouse);
            fisica.MoveRotation(newRot);
        }

        PlayAnim(axisX, axixZ);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == pisandoEmQueIlha)
        {
            for (int i = 0; i < WaveSpawner.Instance.spawnPoints.Length; i++)
            {
                WaveSpawner.Instance.spawnPoints[i].position = transform.forward * 10;
            }
        }
    }



    void PlayAnim(float x, float y)
    {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }
    // Update is called once per frame
    //void FixedUpdate()
    //{

    //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    //    {
    //        Vector3 playerToMouse = hit.point - transform.position;
    //        playerToMouse.y = 0;
    //        Quaternion newRot = Quaternion.LookRotation(playerToMouse);
    //        fisica.MoveRotation(newRot);
    //    }
    //    //Apenas inverti os valores do movimento baseado no Angulo da Camera, se preferir que a camera fique do jeito Original, basta retirar as 2 barrinhas "//" da linha abaixo e apagar a linha invertida

    //    movimento = new Vector3((Input.GetAxisRaw("Horizontal")), 0f, (Input.GetAxisRaw("Vertical")));
    //    movimento = new Vector3((Input.GetAxisRaw("Vertical")), 0f, -(Input.GetAxisRaw("Horizontal")));
    //    movimento = movimento.normalized * speed * Time.fixedDeltaTime;
    //    fisica.MovePosition(transform.position + movimento);

    //}

}
