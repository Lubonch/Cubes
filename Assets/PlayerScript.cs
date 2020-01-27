using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed = 10.0f;
    public int cubesDestroyed;
    public Vector3 jump;
    void Start()
    {
        jump = new Vector3(0,10,0);
        cubesDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0,0,speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0,0,-speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-speed*Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(speed*Time.deltaTime,0,0);
        }
        if(Input.GetKeyDown(KeyCode.Space) && canJump())
        {
            player.GetComponent<Rigidbody>().AddForce(jump,ForceMode.Impulse);
        }
    }
    private bool canJump()
    {
        if(player.transform.position.y > 0.5000001f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        cubesDestroyed++;
        Debug.Log(cubesDestroyed);
    }
}
