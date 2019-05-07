﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static bool useUserPrefs = false;
    public static int playerSpeed = 2;
    public static int playerSize = 2;
    public static int timer = 2;

    public static List<KeyValuePair<string, int>> highScores;

    public static string currentPlayerName;

    public static string highScoresFilePath = "theGameHighScores.txt";
    public static string optionsFilePath = "theGameOptions.txt";

    public static void LoadDefaultOptions()
    {
        useUserPrefs = false;
        playerSpeed = 2;
        playerSize = 2;
        timer = 2;
    }

    public static void LoadGameOptions()
    {
        string[] gameOptionsData;
        if (File.Exists(optionsFilePath))
        {
            gameOptionsData = File.ReadAllLines(optionsFilePath);

            foreach (string line in gameOptionsData)
            {
                string[] optionsDataEntry;
                if (line.Contains(","))
                {
                    optionsDataEntry = line.Trim().Split(',');

                    switch (optionsDataEntry[0])
                    {
                        case "playerSpeed":
                            playerSpeed = int.Parse(optionsDataEntry[1]);
                            break;
                        case "playerSize":
                            playerSize = int.Parse(optionsDataEntry[1]);
                            break;
                        case "useUserPrefs":
                            useUserPrefs = bool.Parse(optionsDataEntry[1]);
                            break;
                        case "timer":
                            timer = int.Parse(optionsDataEntry[1]);
                            break;
                    }
                }
            }
        }
    }

    public static void LoadHighScores()
    {
        highScores = new List<KeyValuePair<string, int>>();
        string[] highScoresData;
        if (File.Exists(highScoresFilePath))
        {
            highScoresData = File.ReadAllLines(highScoresFilePath);
            highScores.Clear();

            foreach (string line in highScoresData)
            {
                string[] highScoresDataEntry;
                if (line.Contains(","))
                {
                    highScoresDataEntry = line.Trim().Split(',');

                    highScores.Add(new KeyValuePair<string, int>(highScoresDataEntry[0], int.Parse(highScoresDataEntry[1])));
                }
            }

            SortHighScores();
        }
    }

    public static void SaveGameOptions()
    {
        string[] gameOptionsData = {
            "playerSpeed," + playerSpeed,
            "playerSize," + playerSize,
            "useUserPrefs," + useUserPrefs,
            "timer," + timer,
        };

        File.WriteAllLines(optionsFilePath, gameOptionsData);
    }

    public static void SaveHighScores()
    {
        List<string> highScoresDataList = new List<string>();

        SortHighScores();

        foreach (KeyValuePair<string, int> highScore in highScores)
        {
            highScoresDataList.Add(highScore.Key + ',' + highScore.Value);
        }

        File.WriteAllLines(highScoresFilePath, highScoresDataList.ToArray());
    }

    public static void SortHighScores()
    {
        // Sort high scores by comparing their values - highest first
        highScores.Sort((x, y) => y.Value.CompareTo(x.Value));
    }
}
