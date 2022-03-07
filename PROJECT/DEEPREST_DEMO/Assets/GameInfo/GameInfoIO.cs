using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public static class GameInfoIO
{
    public static int GetSize(){
        string[] gameInfo = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return gameInfo.Length;
    }
    public static void WriteGameInfo(string[] lines)
    {
        File.WriteAllLines("Assets/GameInfo/GameInfo.txt", lines);
    }

    public static string[] ReadGameInfo(){
        string[] gameInfo = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return gameInfo;
    }

    public static string ReadName(){
        string[] name = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return name[0];
    }

    public static string ReadCouple(){
        string[] name = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return name[1];
    }

    public static void EnablePhone(){
        if(GetSize() < 3) IncreaseSizeBy(1);
        string[] gameInfo = ReadGameInfo();
        gameInfo[2] = "1"; 
        WriteGameInfo(gameInfo);
    }

    public static void DisablePhone(){
        if(GetSize() < 3) IncreaseSizeBy(1);
        string[] gameInfo = ReadGameInfo();
        gameInfo[2] = "0"; 
        WriteGameInfo(gameInfo);
    }

    public static string ReadPhone(){
        string[] phone = File.ReadAllLines("Assets/GameInfo/GameInfo.txt");
        return phone[2];
    }

    public static void UpdatePhone(int value){
        string[] gameInfo = ReadGameInfo();
        gameInfo[2] = value.ToString();
        WriteGameInfo(gameInfo);
    }

    public static void IncreaseSizeBy(int value){
        string[] gameInfo = ReadGameInfo();
        string[] newGameInfo = new string[(gameInfo.Length + value)];
        for (int i = 0; i < gameInfo.Length; i++)
        {
            newGameInfo[i] = gameInfo[i];
        }
        WriteGameInfo(newGameInfo);
        Debug.Log("OLD ARRAY LENGTH: " + gameInfo.Length + "\nDATABASE SIZE INCREASED BY " + value + "\nNEW ARRAY LENGHT: " + ReadGameInfo().Length);
    }
}
