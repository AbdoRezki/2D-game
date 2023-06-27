using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 500f;
    private float jumpAmount = 2000f;
    private float x, z, xI, xP;
    private Rigidbody2D player;
    public GameObject fireBall;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");


        if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            z = 90;
        } 
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            z = -90;
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.velocity.y == 0)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            FireBall();
        }
    }

    void FixedUpdate()
    {
        player.velocity = new Vector2(x * speed, player.velocity.y);

    }
    public void Right()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        player.AddForce(new Vector2(50000f, 0));
        /*Debug.Log(player.velocity);*/
    }
    public void Left()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        player.AddForce(new Vector2(-50000f, 0));
        Debug.Log(transform.rotation);
    }

    public void Jump()
    {
        player.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    public void FireBall()
    {
        GameObject fireBallInstance = Instantiate(fireBall, new Vector2(player.transform.position.x - 500, player.transform.position.y - 250), Quaternion.Euler(0, 0, z)) as GameObject;
        fireBallInstance.transform.SetParent(GameObject.FindGameObjectWithTag("GamePanel").transform, false);
        fireBallInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20 * Time.deltaTime * 200000f));
    }
}
