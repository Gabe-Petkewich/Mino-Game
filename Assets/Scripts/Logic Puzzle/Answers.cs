using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    // Manager object holds the universal values for the puzzle,
    // i.e. totalCorrect and totalAnswered for entire puzzle.
    [SerializeField]
    Answers Manager;
    [SerializeField]
    Answers Neighbor1;
    [SerializeField]
    Answers Neighbor2;
    [SerializeField]
    bool isCorrect;
    [SerializeField]
    bool isManager;
    bool isAnswered = false;
    bool isCompleted = false;
    int totalAnswered = 0;
    int totalCorrect = 0;


    void Update()
    {
        if(isCompleted == false)
            IsComplete();
    }

    /*
    If the trigger of the answer is entered, iterate totalAnswered by 1 and
    mark all the adajacent answered so they cannot be answered again. If the 
    choice was correct, iterate totalCorrect by one as well.
     */
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if(isCorrect == true && isAnswered == false)
        {
            Debug.Log("Correct Answer");
            Manager.totalAnswered++;
            Manager.totalCorrect++;
            AnswerChosen();
        }
        else if(isCorrect == false && isAnswered == false)
        {
            Debug.Log("Incorrect Answer");
            Manager.totalAnswered++;
            AnswerChosen();
        }
    }

    // When an answer is chosen, mark it and adajacent answers unable to be 
    // triggered again.
    void AnswerChosen()
    {
        isAnswered = true;
        Neighbor1.isAnswered = true;
        Neighbor2.isAnswered = true;
    }

    /*
    Runs in the update function to see if the puzzle is completed by checking the 
    totalAnswers. If complete and matches totalCorrect, puzzle was compeleted 
    successfully. Otherwise, it was a failure.
    */

    void IsComplete()
    {
        if(Manager.totalAnswered == 3 && Manager.totalCorrect == 3)
        {
            Debug.Log("Puzzle Correctly Solved");
            isCompleted = true;
        }
        else if (Manager.totalAnswered == 3 && Manager.totalCorrect != 3)
        {
            Debug.Log("Puzzle Incorrectly Solved");
            isCompleted = true;
        }
    }

}
