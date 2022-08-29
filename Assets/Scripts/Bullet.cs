using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (time < 1) time += 1 * Time.deltaTime;
            if(time > 1) time = 1;
            if (time == 1)
            {
                collision.gameObject.GetComponent<Player>().Health -= 20;
                time = 0;
            }
        }
        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jumppad") { gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 40));; }
    }
}
