using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotation_force;
    [SerializeField] private AudioSource hit_source;
    [SerializeField] private AudioSource start_source;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -speed, ForceMode.Impulse);
        start_source.Play();
        Invoke("desrtoy", 8f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) { hit_source.Play(); }
    }
    void desrtoy() { Destroy(gameObject); }
}
