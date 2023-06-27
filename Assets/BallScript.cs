using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D ball;
    private Vector3 LastVelocity;
    private float speed = 20000f;
    private static int score;
    private Vector2 position;
    public TextMeshProUGUI text;
    public GameObject canevasGame;
    public GameObject canevasSide;
    public GameObject canevasBottom;
    public GameObject canevasGameOver;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.AddForce(new Vector2(-20 * Time.deltaTime * speed, -20 * Time.deltaTime * speed));
        /*InvokeRepeating("Spawn", 5f, 10f);*/
    }

    // Update is called once per frame
    void Update()
    {
        LastVelocity = ball.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            /*GameObject ballInstance = Instantiate(this.gameObject, new Vector2(0, 0), Quaternion.identity) as GameObject;
            ballInstance.transform.SetParent(GameObject.FindGameObjectWithTag("GamePanel").transform, false);*/
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            /*score = int.Parse(text.text);*/
            score += 1;
            text.SetText(score.ToString());
            text2.SetText("Score : " + score.ToString());
        }

        if (collision.gameObject.tag == "Player")
        {
            /*canevasGame.SetActive(false);
            canevasSide.SetActive(false);
            canevasBottom.SetActive(false);
            canevasGameOver.SetActive(true);*/
            Instantiate(ball, new Vector2(Random.Range(200, 500), Random.Range(300, 400)), Quaternion.identity, GameObject.FindGameObjectWithTag("GamePanel").transform);
            text1.SetText("Score : "+score.ToString());
            if (score > 1)
            {
                score = score - 1;
            }
            text.SetText(score.ToString());
        }

        var speedCollision = LastVelocity.magnitude;
        /*Debug.Log(speedCollision);*/
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        ball.velocity = direction * Mathf.Max(speedCollision, 0f);
    }

    public void Spawn()
    {
        Rigidbody2D ballInstance = Instantiate(ball, new Vector2(Random.Range(200, 500), Random.Range(300, 400)), Quaternion.identity, GameObject.FindGameObjectWithTag("GamePanel").transform);
        /*ballInstance.AddForce(new Vector2(-20 * Time.deltaTime * speed, -20 * Time.deltaTime * speed));*/
        /*ball = ballInstance;*/
    }

    public void Reset()
    {
        score = 0;
        text.SetText(score.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
