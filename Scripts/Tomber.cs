using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomber : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sol"))
        {
            Destroy(this.gameObject);
        }
    }
}
