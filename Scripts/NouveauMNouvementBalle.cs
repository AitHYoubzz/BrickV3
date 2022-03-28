using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouveauMNouvementBalle : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;
    private Vector3 dernièreVitesse;
    [SerializeField]
    private float minVitesse = 10f;

    [SerializeField]
    private Transform brickExplosion;

    public bool enJeu;
    [SerializeField]
    private Transform plateforme;
    [SerializeField]
    private Transform powerUp;
    [SerializeField]
    private Transform powerUpDeux;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * 500);
    }

    // Update is called once per frame 
    void Update()
    {
        if(!enJeu)
        {
            //transform.position.y = plateforme.position.y + 1;
            transform.position = new Vector3(plateforme.position.x, plateforme.position.y + 1, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            enJeu = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   
        dernièreVitesse = rb.velocity;
        Rebondit(collision.contacts[0].normal);
        if (collision.gameObject.CompareTag("Brick"))
        {
            int pourcentage = Random.Range(1, 101);

            if (pourcentage < 11)
            {
                Instantiate(powerUp, collision.transform.position, Quaternion.identity);
            }

            if (pourcentage > 90)
            {
                Instantiate(powerUpDeux, collision.transform.position, Quaternion.identity);
            }


            //Transform explosion = Instantiate(BrickExplosion, collision.transform.position, Quaternion.identity);
            //Destroy(explosion.gameObject, 3);
            Destroy(collision.gameObject);
            gm.GérerPointage(1000);

        }


    }

    private void Rebondit(Vector3 collisionNormal)
    {
        var speed = dernièreVitesse.magnitude;
        var direction = Vector3.Reflect(dernièreVitesse.normalized, collisionNormal);
        rb.velocity = direction * Mathf.Max(speed, minVitesse);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sol"))
        {
            gm.GérerVies(-1);
            enJeu = false;            
        }
    }
}
