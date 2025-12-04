using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    int[] secuence = new int[4];
    int playerIndex = 0;
    int lvl = 4;
    int lastButtonPressed = 0;
    void Start()
    {
    
        StartCoroutine(PlaySimonSays());
        
    }

    IEnumerator PlaySimonSays()
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
                yield return new WaitForSeconds(2f);
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
                            yield break;
                        }



                    }
                    time += Time.deltaTime;
                    yield return null;


                }
                if (!recieved)
                {
                    Debug.Log("Broski hay que ser mas rapido eh!");
                    yield break;
                }

            }
            Debug.Log("Pos mu bien");
        }
        Debug.Log("Joder eres weno e");
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
