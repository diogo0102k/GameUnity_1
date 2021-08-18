using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;

    public TMPro.TextMeshPro ScoreText;
    private int score;
    private float timer;
    private static bool gameOver;

    void Start()
    {
        StartCoroutine(SpawnHazards());

    }
        private void Update() {
            if (gameOver)
            return;
                timer += Time.deltaTime;

                if (timer >= 1f)
                {
                    score++;
                    ScoreText.text = score.ToString();
                    timer = 0;
                }



    }
    private IEnumerator SpawnHazards(){

        var HazardParaSpawn = Random.Range(1, 4);

        for (int i=0;i<HazardParaSpawn;i++)
        
        {

        var x = Random.Range(-6, 7);
        var y = Random.Range(-12, -1);
        var drag = Random.Range(0f, 2f);
        
        var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, y), Quaternion.identity);
        hazard.GetComponent<Rigidbody>().drag = drag;

        }

        
            yield return new WaitForSeconds(1f);
           yield return SpawnHazards();
    

    } 
   public static void GameOver() {

        gameOver = true;

   }
}