using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < player.position.y + 4 && transform.position.y > player.position.y - 4)
            transform.position = new Vector3(player.position.x + 9, transform.position.y, -10);
        else if (transform.position.y < player.position.y)
            transform.position = new Vector3(player.position.x + 9, transform.position.y + 10 * Time.deltaTime, -10);
        else
            transform.position = new Vector3(player.position.x + 9, transform.position.y - 10 * Time.deltaTime, -10);
    }
}
