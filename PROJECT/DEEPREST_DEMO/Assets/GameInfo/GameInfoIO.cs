using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public static class GameInfoIO
{
    public static void WriteGameInfo(string[] lines)
    {
        File.WriteAllLines("Assets/GameInfo/GameInfo.txt", lines);
    }

    public static string ReadName(){
        string[] name = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return name[0];
    }

    public static string ReadCouple(){
        string[] name = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return name[1];
    }
}
