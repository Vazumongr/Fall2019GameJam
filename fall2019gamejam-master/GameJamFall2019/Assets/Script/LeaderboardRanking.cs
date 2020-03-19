using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using System.IO;
public class LeaderboardRanking : MonoBehaviour
{
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    public Text t5;

    private string[] values;
    private string[] split;
    private int[] ranking;
    void Start()
    {
        split = new string[2];
        SortLeaderboard();
        BubbleSort();
        PrintToTextBox();
        
    }

    void SortLeaderboard()
    {
        //reads from the leaderboard file
        string path = "Assets/TextFiles/Leaderboard.txt";

        StreamReader r = new StreamReader(path);
        var temp = "";
        
       //gets the number of things in the leaderboard
        var numberOfPlayers = Leaderboards.counter();
        values = new string[numberOfPlayers];
        ranking = new int[numberOfPlayers];
        var score = 0;
        //parses the items and puts them in the correct integers
        for (int i = 0; i < numberOfPlayers; i++) {
            temp = r.ReadLine();
            //if statement needed, otherwise the writer doesn't put the info in correctly
            if (temp != "")
            {
                split = temp.Split(char.Parse(" "));
                score = int.Parse(split[1]);
                ranking[i] = score;
                values[i] = split[0];
            }
        }

        r.Close();

    }
    //Bubble Sort
    void BubbleSort()
    {
        int n = ranking.Length -1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
                if (ranking[j] < ranking[j + 1])
                {
                    //sorts the integers
                    int temp = ranking[j];
                    ranking[j] = ranking[j + 1];
                    ranking[j + 1] = temp;

                    //sorts the strings
                    string str = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = str;
                }
        }
    }
    void PrintToTextBox()
    {
        // Puts them into the textboxes. Its 3:30 am I don't want to do more loops.
        t1.text = "1. " + values[0] + " Score: " + ranking[0];
        t2.text = "2. " + values[1] + " Score: " + ranking[1];
        t3.text = "3. " + values[2] + " Score: " + ranking[2];
        t4.text = "4. " + values[3] + " Score: " + ranking[3];
        t5.text = "5. " + values[4] + " Score: " + ranking[4];
        /*for(int i = 0; i < 5; i++)
        {
            t.text 
        }*/
    }
}
