using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameIsGoing = true;
    public int p1wins;
    public int p2wins;

    public Text score1;
    public Text score2;

    private void Update()
    {
        score1.text = (p1wins/2).ToString();
        score2.text = (p2wins/2).ToString();
        if(p1wins > p2wins) score1.color = Color.green;
        if(p1wins < p2wins) score1.color = Color.red;
        if(p2wins > p1wins) score2.color = Color.green;
        if(p2wins < p1wins) score2.color = Color.red;
        if(p2wins == p1wins) score1.color = Color.yellow;
        if(p1wins == p2wins) score2.color = Color.yellow;
    }
}