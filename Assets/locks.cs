using System;
using UnityEngine;
using UnityEngine.UI;
public class locks : MonoBehaviour
{
    [SerializeField] private Button mainbutton;
    [SerializeField] private Button button;
    [SerializeField] private GameObject image;
    [SerializeField] private shopBank bank;
    [SerializeField] state type;
    [SerializeField] private string u_key;
    [SerializeField] private AudioSource source;

    
    enum state
    {
        open = 0,
        locked = 1,
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey(u_key))
        {
            type = (state)PlayerPrefs.GetInt(u_key);
        }

        if (type == state.open) 
        {
            mainbutton.interactable = true;
            button.interactable = false;
            image.SetActive(false);
            
        }

    }

    public void Unlock(int cost)
    {
        if (bank.score >= cost)
        {
            bank.spend(cost);
            type = state.open;
            PlayerPrefs.SetInt(u_key, (int)type);
            mainbutton.interactable = true;
            button.interactable = false;
            image.SetActive(false);
            source.Play();
            

        }
    }



}
