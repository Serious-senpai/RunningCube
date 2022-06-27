using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    private Stopwatch timer = new Stopwatch();
    private double lastShot = 0;

    public static int enemiesLeft = 0;

    void Start()
    {
        timer.Start();
        enemiesLeft++;
    }

    void Update()
    {
        if (timer.Elapsed.TotalSeconds - lastShot > 3 && target != null)
        {
            Bullets.Shoot(gameObject, CreateDispersion(target.transform.position), bullet);
            lastShot = timer.Elapsed.TotalSeconds;
        }
    }

    Vector3 CreateDispersion(Vector3 original)
    {
        var rand = new System.Random();
        original.x += rand.Next(-5, 5);
        original.y += rand.Next(-5, 5);
        return original;
    }

    void OnDestroy()
    {
        enemiesLeft--;
    }
}
