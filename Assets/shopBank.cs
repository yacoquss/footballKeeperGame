using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class shopBank : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI s_text;
    [SerializeField] private Material mat;
    [SerializeField] private Color[] colors;
    [SerializeField] private GameObject obj;
    [SerializeField] private Button[] locks;
    public int score;
    private int index;
    private const string key = "score";
    private const string _index = "index";
   
    
    public void spend(int value)
    {
        score -= value;
        PlayerPrefs.SetInt(key, score);
        s_text.text = score.ToString();

    }
    private void Start()
    {
        hands.reward += Reward;


        if (PlayerPrefs.HasKey(key)) { score = PlayerPrefs.GetInt(key); }
        else { score = 0; }
        s_text.text = score.ToString();
        if (PlayerPrefs.HasKey(_index)) {
            index = PlayerPrefs.GetInt(_index);
            mat.color = colors[index];
        }
        else { mat.color = Color.white; }



    }

    private void OnDestroy() { hands.reward -= Reward; }
    
    
    public void takeindex(int index) 
    { 
        this.index = index;
        mat.color = colors[index];
        PlayerPrefs.SetInt(_index, index);
    }
    public void Reward(int value) 
    {
        
        score+=value;
        PlayerPrefs.SetInt(key, score);
        s_text.text = score.ToString();
    }
}
