using UnityEngine;

public class TeleporterA : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.collider != GetComponent<Collider2D>() ? collision.collider : collision.otherCollider;
        other.transform.position = new Vector3(-6.5f, -12.5f, 0);
    }
}
