using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPlatforme : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody platforme;
    [SerializeField] int vitesse;
    public float limites;
    public GameManager gm;
    [SerializeField]
    private Transform plateforme;
    public Transform balle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    platforme.AddForce(-vitesse, 0, 0);
        //}
        //if(Input.GetKeyUp(KeyCode.A))
        //{
        //    platforme.angularVelocity = Vector3.zero;
        //    platforme.velocity = Vector3.zero;
        //}
        //if(Input.GetKeyDown(KeyCode.D))
        //{
        //    platforme.AddForce(vitesse, 0, 0);
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    platforme.angularVelocity = Vector3.zero;
        //    platforme.velocity = Vector3.zero;
        //}
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontal * Time.deltaTime * vitesse);
        if (transform.position.x >= limites )
        {
            transform.position = new Vector3(limites, transform.position.y, 0);
        }
        if(transform.position.x <= -limites)
        {
            transform.position = new Vector3(-limites, transform.position.y, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VieSupp"))
        { 
        gm.GérerVies(1);
        }
        if (other.CompareTag("DoubleCoup"))
        {
            Instantiate(balle, other.transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
    }
}
