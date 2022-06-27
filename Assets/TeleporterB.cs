using UnityEngine;

public class TeleporterB : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.collider != GetComponent<Collider2D>() ? collision.collider : collision.otherCollider;
        other.transform.position = new Vector3(8.5f, 32.5f, 0);
    }
}
