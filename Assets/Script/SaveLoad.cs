using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoad
{
    //? 存檔和讀檔
    public static void SaveGameData()
    {
        FileStream newData = new FileStream(Application.dataPath + "Data/PlayerData.txt", FileMode.Create);//? 在該檔案位址創建一個新的檔案(GameData.txt)
        StreamWriter write = new StreamWriter(newData);//? 對指定檔案進行寫入模式
        //? 由於讀取時以一行一行的方式來讀取，所以寫入時也以一筆資料寫入一行為準
        for (int x = 0; x < PlayerDataSO.Reimu_A_Clear.Length; x++)
            write.WriteLine(PlayerDataSO.Reimu_A_Clear[x]);
        for (int x = 0; x < PlayerDataSO.Reimu_B_Clear.Length; x++)
            write.WriteLine(PlayerDataSO.Reimu_B_Clear[x]);
        for (int x = 0; x < PlayerDataSO.Marisa_A_Clear.Length; x++)
            write.WriteLine(PlayerDataSO.Marisa_A_Clear[x]);
        for (int x = 0; x < PlayerDataSO.Marisa_B_Clear.Length; x++)
            write.WriteLine(PlayerDataSO.Marisa_B_Clear[x]);
        for (int x = 0; x < PlayerDataSO.Sanae_A_Clear.Length; x++)
            write.WriteLine(PlayerDataSO.Sanae_A_Clear[x]);
        for (int x = 0; x < PlayerDataSO.Sanae_B_Clear.Length; x++)
            write.WriteLine(PlayerDataSO.Sanae_B_Clear[x]);
        for (int x = 0; x < PlayerDataSO.AllMusic.Length; x++)
            write.WriteLine(PlayerDataSO.AllMusic[x]);
        //? 執行完後記得要關閉
        write.Close();
        newData.Close();
    }

    public static void LoadGameData()
    {
        FileStream newData = new FileStream(Application.dataPath + "Data/PlayerData.txt", FileMode.Open);//? 在該檔案位址開啟指定檔案(GameData.txt)
        StreamReader read = new StreamReader(newData);//? 對指定檔案進行讀取模式  
        for (int x = 0; x < PlayerDataSO.Reimu_A_Clear.Length; x++)
            PlayerDataSO.Reimu_A_Clear[x] = bool.Parse(read.ReadLine());
        for (int x = 0; x < PlayerDataSO.Reimu_B_Clear.Length; x++)
            PlayerDataSO.Reimu_B_Clear[x] = bool.Parse(read.ReadLine());
        for (int x = 0; x < PlayerDataSO.Marisa_A_Clear.Length; x++)
            PlayerDataSO.Marisa_A_Clear[x] = bool.Parse(read.ReadLine());
        for (int x = 0; x < PlayerDataSO.Marisa_B_Clear.Length; x++)
            PlayerDataSO.Marisa_B_Clear[x] = bool.Parse(read.ReadLine());
        for (int x = 0; x < PlayerDataSO.Sanae_A_Clear.Length; x++)
            PlayerDataSO.Sanae_A_Clear[x] = bool.Parse(read.ReadLine());
        for (int x = 0; x < PlayerDataSO.Sanae_B_Clear.Length; x++)
            PlayerDataSO.Sanae_B_Clear[x] = bool.Parse(read.ReadLine());
        for (int x = 0; x < PlayerDataSO.AllMusic.Length; x++)
            PlayerDataSO.AllMusic[x] = bool.Parse(read.ReadLine());
    }

}
