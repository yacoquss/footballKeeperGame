using UnityEngine;
using System;
using TMPro;
public class border : MonoBehaviour
{
    public static Action lose;
    public ParticleSystem effect;
    public AudioSource source;
    public int index;
    public TextMeshProUGUI goalsText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball")) {
            hit();
            Destroy(other);
        }
    }
    void hit() 
    {
        index++;
        effect.Play();
        source.Play();
        if (index == 3) {
            lose?.Invoke();
            index = 0;
        }
        goalsText.text = index.ToString();
    }
}
