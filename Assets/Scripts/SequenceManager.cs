using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SequenceManager : MonoBehaviour
{
    public MapManager mapManager;
    public List<GameObject> commands;
    private int playerErrors;
    public int maxErrors;
    //public int maxSequenceNextTimeInSeconds;
    public List<Sequence> sequences;
    private int currentSequence;
    private bool allertOn;

  
    public UnityEvent<int> onWrongSolution;
    public UnityEvent onCorrectSolution;
    public UnityEvent onWin;
    public UnityEvent onGameOver;

    private void Start()
    {
        currentSequence = -1;
        SetNextSequence();
    }

    public void CheckSolution()
    {
        if (!allertOn) return;

         var mapPart = mapManager.GetActiveMap();

        if(mapPart != sequences[currentSequence].mapSlice)
        {
            SolutionIsWrong();
            return;
        }

        foreach (GameObject command in commands) 
        {
            IState state = command.GetComponentInChildren<IState>();

            switch (state.Id) 
            {            
                case 1:
                    if (sequences[currentSequence].numPadNumber == 9999) break;
                    if (sequences[currentSequence].numPadNumber != (int)state.GetValue())
                    {
                        SolutionIsWrong();
                        return;
                    }
                    break;
                case 2:
                    if (sequences[currentSequence].levaOn == -1) break;
                    if (sequences[currentSequence].levaOn != (int)state.GetValue())
                    {
                        SolutionIsWrong();
                        return;
                    }
                    break;
                case 3:
                    if (sequences[currentSequence].counterNumber == -1) break;
                    if (sequences[currentSequence].counterNumber != (int)state.GetValue())
                    {
                        SolutionIsWrong();
                        return;
                    }
                    break;
            }
        }

        SolutionIsCorrect();
    }

    public void SolutionIsWrong()
    {
        playerErrors++;
        if(playerErrors > maxErrors)
        {
            GameOver();
            return;
        }
        onWrongSolution?.Invoke(playerErrors);
        //Debug.Log("Solutione sbagliata");
    }

    public void SolutionIsCorrect()
    {
        allertOn = false;
        SetNextSequence();
        onCorrectSolution?.Invoke();       
        //Debug.Log("Solutione corretta");
    }

    public void SetNextSequence()
    {
        //var timeToWait = Random.Range(1, maxSequenceNextTimeInSeconds);

        //await UniTask.Delay(timeToWait*1000);

        if(currentSequence == sequences.Count -1)
        {
            GameWin();
            return;
        }       

        currentSequence++;

        mapManager.ActivateEmergencyPart(sequences[currentSequence]);

        allertOn = true;
    }

    public void GameOver()
    {
        onGameOver?.Invoke();
        ReloadScene().Forget();
    }

    public void GameWin()
    {
        onWin?.Invoke();
    }

    public async UniTaskVoid ReloadScene()
    {
        await UniTask.Delay(5000);
        SceneManager.LoadScene("Game");
    }

    public void ReloadSceneInstantly()
    {     
        SceneManager.LoadScene("Game");
    }
}
