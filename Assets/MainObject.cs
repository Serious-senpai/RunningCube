using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    public float acceleration;
    public float jumpForce;
    public new Camera camera;
    public GameObject bullet;
    private int groundContacts = 0;
    private Stopwatch timer = new Stopwatch();
    private double lastShot = 0;

    public Rigidbody2D rigidBody
    {
        get => GetComponent<Rigidbody2D>();
    }

    public Vector3 velocity
    {
        get => rigidBody.velocity;
    }

    void Start()
    {
        timer.Start();
    }

    void Update()
    {
        float dx = 0, dy = 0;

        dx += Input.GetKey(KeyCode.D) ? 1 : 0;
        dx -= Input.GetKey(KeyCode.A) ? 1 : 0;

        dy += Input.GetKey(KeyCode.W) ? 1 : 0;

        dx *= acceleration * 50 / (Math.Abs(velocity.x) + 50);
        dy *= jumpForce;
        if (Input.GetKey(KeyCode.S))
        {
            dx /= 2; dy /= 2;
        }

        if (groundContacts == 0)
        {
            dy /= 100;
        }

        if (dx != 0 || dy != 0)
        {
            rigidBody.AddForce(new Vector2(dx, dy));
        }

        camera.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            camera.transform.position.z
        );

        if (timer.Elapsed.TotalSeconds - lastShot > 0.5 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            var position = camera.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            lastShot = timer.Elapsed.TotalSeconds;
            Bullets.Shoot(gameObject, position, bullet);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            groundContacts++;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            groundContacts--;
        }
    }

    void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
