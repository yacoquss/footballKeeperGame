using UnityEngine;
using System;
using System.Collections;
public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private GameObject[] balls;
    [SerializeField] private bool IsGameStart = false;
    [SerializeField] private Transform parent;
    [SerializeField] private float timetoshoot;
    [SerializeField] private GameObject startbutton;

    private void Start() { border.lose += ChangeGame; }
    private void OnDestroy() { border.lose -= ChangeGame; }

    public void ChangeGame()
    {
        IsGameStart = !IsGameStart;
        if (IsGameStart) StartCoroutine(shoot());
        else { startbutton.SetActive(true); }
    }

    IEnumerator shoot()
    {
        while (IsGameStart)
        {
            var P_index = UnityEngine.Random.Range(0, points.Length);
            var B_index = UnityEngine.Random.Range(0, balls.Length);
            yield return new WaitForSeconds(timetoshoot);
            if(IsGameStart)Instantiate(balls[B_index], points[P_index].transform.position, Quaternion.identity, parent);
        }

        yield return null;
    }
}
