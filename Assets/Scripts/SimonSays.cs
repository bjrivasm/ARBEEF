using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    [SerializeField] private int[] secuence = new int[4];
    int playerIndex = 0;
    [SerializeField] private int lvl = 4;
    int lastButtonPressed = 0;
    [SerializeField] private float timeBetweenNumbers = 2f;

    [SerializeField] private AnimationsManager animManager;

    [SerializeField] GameManager gameManager;

    void Start()
    {
        // animManager = GameObject.Find("AnimationsManager").GetComponent<AnimationsManager>();
    }

    public IEnumerator PlaySimonSays()
    {
        for (int i = 0; i < secuence.Length; i++)
        {
            secuence[i] = Random.Range(1 , 4 + 1);
        }

        for (int round = 1; round <= lvl; round++)
        {
            for (int i = 0; i < round; i++)
            {
                Debug.Log(secuence[i]);
                int direction = secuence[i];
                StartCoroutine(animationTransition(direction));
                yield return StartCoroutine(animationTransition(direction));
            }

            playerIndex = 0;

            while (playerIndex < round)
            {
                bool recieved = false;
                float time = 0f;

                while (!recieved && time < 5f)
                {
                    int direction = ReadKey();
                    if (direction != 0)
                    {
                        recieved = true;
                        if (direction == secuence[playerIndex])
                        {
                            Debug.Log("BIEN!");
                            playerIndex++;
                        }
                        else
                        {
                            Debug.Log("Tonto, asi no era, que eres tonto");
                            animManager.PlayRunning();
                            animManager.PlayExpressions();
                            gameManager.DisableButtons();
                            yield break;
                        }
                    }
                    time += Time.deltaTime;
                    yield return null;
                }
                if (!recieved)
                {
                    Debug.Log("Broski hay que ser mas rapido eh!");
                    animManager.PlayRunning();
                    animManager.PlayExpressions();
                    gameManager.DisableButtons();
                    yield break;
                }

            }
            Debug.Log("Pos mu bien");
        }
        Debug.Log("Joder eres weno e");
        animManager.PlayDying();
        animManager.PlayExpressions();
        gameManager.DisableButtons();
        yield break;
    }

    private IEnumerator animationTransition(int direction)
    {
        switch (direction)
        {
            case 1:
                animManager.PlaySimonUp();
                yield return new WaitForSeconds(timeBetweenNumbers / 2); 
                animManager.PlayIdle();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                break;
            case 2:
                animManager.PlaySimonLeft();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                animManager.PlayIdle();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                break;
            case 3:
                animManager.PlaySimonRight();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                animManager.PlayIdle();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                break;
            case 4:
                animManager.PlaySimonDown();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                animManager.PlayIdle();
                yield return new WaitForSeconds(timeBetweenNumbers / 2);
                break;
        }
    }

    int ReadKey()
    {
        int value = lastButtonPressed;
        lastButtonPressed = 0;
        return value;
    }
    public void PressUp()
    {
        lastButtonPressed = 1;
    }

    public void PressLeft()
    {
        lastButtonPressed = 2;
    }

    public void PressRight()
    {
        lastButtonPressed = 3;
    }

    public void PressDown()
    {
        lastButtonPressed = 4;
    }

}
