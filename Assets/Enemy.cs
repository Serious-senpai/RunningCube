using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    private Stopwatch timer = new Stopwatch();
    private double lastShot = 0;

    void Start()
    {
        timer.Start();
    }

    void Update()
    {
        if (timer.Elapsed.TotalSeconds - lastShot > 2 && target != null)
        {
            Bullets.Shoot(gameObject, target.transform.position, bullet);
            lastShot = timer.Elapsed.TotalSeconds;
        }
    }
}
