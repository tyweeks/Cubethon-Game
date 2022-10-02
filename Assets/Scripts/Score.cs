using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;

    public Text scoreText;

    [HideInInspector]
    public bool GameHasEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (!GameHasEnded)
        {
            scoreText.text = player.position.z.ToString("0");
        }
    }
}
