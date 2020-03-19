using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public static class Leaderboards 
{
    //Writes files into the leaderboard.
    //[MenuItem("Tools/Write file")]
    public static void fileWriter()
    {
        string path = "Assets/TextFiles/Leaderboard.txt";

        StreamWriter w = new StreamWriter(path, true);
       
        w.WriteLine(Globals.userName + " " + Globals.completedCounter);
        w.Close();

        Globals.userName = "";
        Globals.completedCounter = 0;

        //AssetDatabase.ImportAsset(path);
    }
    //Stream reader, don't think I use this anywhere. BUT if you need it!
    //[MenuItem("Tools/Read file")]
    public static string ReadString()
    {
        string path = "Assets/TextFiles/Leaderboard.txt";

        StreamReader r = new StreamReader(path);
        var temp = r.ReadToEnd();
        r.Close();
        return temp;
    }
    //counts number of lines in leaderboard
    public static long counter()
    {
        var lines = 0;
        using (var r = new StreamReader("Assets/TextFiles/Leaderboard.txt"))
        {
            while (r.ReadLine() != null)
            {
                lines++;
            }
            return lines;
        }
    }
}
