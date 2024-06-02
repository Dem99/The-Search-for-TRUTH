using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject pieceA; // Kus obrázka A
    public GameObject pieceB; // Kus obrázka B
    public GameObject pieceC; 
    public GameObject pieceD; 
	public GameObject pieceE;
	public GameObject pieceF;
	public GameObject pieceG;
	public GameObject pieceH;
	public GameObject pieceI;
	public GameObject pieceJ;
	public GameObject pieceK;
	public GameObject pieceL;
	public GameObject pieceM;
	
	public string sceneName; 
			
    public Transform positionA1; // Pozice pro obrázek A
    public Transform positionB1; // Pozice pro obrázek B
    public Transform positionC1; // Pozice pro obrázek C
    public Transform positionD1; // Pozice pro obrázek D
	public Transform positionE1;
	public Transform positionF1;
	public Transform positionG1;
	public Transform positionH1;
	public Transform positionI1;
	public Transform positionJ1;
	public Transform positionK1;
	public Transform positionL1;
	public Transform positionM1;

 	public void OnWin()
    {
        GameManager.Instance.HasWonPuzzleGame = true;
        SceneManager.LoadScene(sceneName);
    }


    private void Update()
    {
        bool allCorrect = true;

        // Kontrola pozice kusu obrázka A
        if (!IsPieceInCorrectPosition(pieceA, positionA1))
            allCorrect = false;

        // Kontrola pozice kusu obrázka B
        if (!IsPieceInCorrectPosition(pieceB, positionB1))
            allCorrect = false;

        // Kontrola pozice kusu obrázka C
        if (!IsPieceInCorrectPosition(pieceC, positionC1))
            allCorrect = false;

        // Kontrola pozice kusu obrázka D
        if (!IsPieceInCorrectPosition(pieceD, positionD1) ||
			!IsPieceInCorrectPosition(pieceE, positionE1) ||
			!IsPieceInCorrectPosition(pieceF, positionF1) ||
			!IsPieceInCorrectPosition(pieceG, positionG1) ||
			!IsPieceInCorrectPosition(pieceH, positionH1) ||
			!IsPieceInCorrectPosition(pieceI, positionI1) ||
			!IsPieceInCorrectPosition(pieceJ, positionJ1) ||
			!IsPieceInCorrectPosition(pieceK, positionK1) ||
			!IsPieceInCorrectPosition(pieceL, positionL1) ||
			!IsPieceInCorrectPosition(pieceM, positionM1)) 
			{allCorrect = false;}

        // Pokud jsou všechny kusy obrázka na správných místech, hráč vyhrál
        if (allCorrect)
        {
            Debug.Log("Gratulujeme! Vyhráli jste!");
			OnWin();
		
        }
    }

    // Metoda pro kontrolu, zda je kus obrázka na správné pozici
    private bool IsPieceInCorrectPosition(GameObject piece, Transform correctPosition)
    {
        float distance = Vector3.Distance(piece.transform.position, correctPosition.position);
        return distance < 0.5f; // Zde můžete upravit toleranci
    }
}
