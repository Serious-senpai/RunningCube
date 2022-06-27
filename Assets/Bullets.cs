using System.Diagnostics;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Stopwatch timer = new Stopwatch();

    void Start()
    {
        timer.Start();
    }

    void Update()
    {
        if (timer.Elapsed.TotalSeconds > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var other = collision.collider != GetComponent<Collider2D>() ? collision.collider : collision.otherCollider;
        if (!other.CompareTag("Terrain"))
        {
            Destroy(other.gameObject);
        }
    }

    public static GameObject Shoot(GameObject from, Vector3 target, GameObject bullet)
    {
        var obj = Object.Instantiate(bullet, from.transform);
        Physics2D.IgnoreCollision(from.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        obj.GetComponent<Rigidbody2D>().AddForce(60 * (target - from.transform.position));
        return obj;
    }
}
