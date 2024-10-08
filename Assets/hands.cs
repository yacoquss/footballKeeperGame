using UnityEngine;
using TMPro;
using System;
public class hands : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float LowerborderpositionX;
    [SerializeField] private float UpperborderpositionX;
    [SerializeField] private float LowerborderpositionY;
    [SerializeField] private float UpperborderpositionY;
    [SerializeField] private TextMeshProUGUI scoreup;

    public static Action<int> reward;

    void Update()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.x = Mathf.Clamp(objPosition.x, LowerborderpositionX, UpperborderpositionX);
        objPosition.y = Mathf.Clamp(objPosition.y, LowerborderpositionY, UpperborderpositionY);
        transform.position = objPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball")) 
        {
            var upindex = UnityEngine.Random.Range(5,30);
            scoreup.text = upindex.ToString();

            scoreup.gameObject.SetActive(true);
            reward?.Invoke(upindex);

        }
    }


}
