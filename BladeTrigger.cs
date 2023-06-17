using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrigger : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stone")
        {
           
            Destroy(collision.gameObject);

            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            Destroy(explosion, 1f); // 1초 후에 폭발 효과 삭제
        }
    }
}
