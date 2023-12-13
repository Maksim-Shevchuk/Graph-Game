using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GraphGame;

public class JsonSerializerUtils
{
    public static void SerializeLevelInfo(string path, LevelInfo levelInfo)
    {
        using (FileStream fs = new(path, FileMode.OpenOrCreate))
        {
            LevelInfoDto dto = ToLevelInfoDto(levelInfo);
            JsonSerializer.Serialize<LevelInfoDto>(fs, dto);
            Console.WriteLine("saved");
        }
    }

#nullable enable
    public static LevelInfo DeserializeLevelInfo(string path)
    {
        using FileStream fs = new(path, FileMode.Open);
        return ToLevelInfo(JsonSerializer.Deserialize<LevelInfoDto>(fs)!);
    }

    private static LevelInfo ToLevelInfo(LevelInfoDto dto)
    {
        LevelInfo levelInfo = new(dto.Id, dto.Interval, dto.Margin, new(dto.StartPosition["x"], dto.StartPosition["y"]))
        {
            CheckpointCoords = ToCheckPointCoords(dto.CheckpointDictCoords)
        };
        return levelInfo;
    }

    private static LevelInfoDto ToLevelInfoDto(LevelInfo levelInfo)
    {
        LevelInfoDto dto = new(levelInfo.Id, levelInfo.Interval, levelInfo.Margin,
            new Dictionary<string, float>() { { "x", levelInfo.StartPosition.X }, { "y", levelInfo.StartPosition.Y } })
        {
            CheckpointDictCoords = ToCheckPointDictCoords(levelInfo.CheckpointCoords)
        };
        return dto;
    }

    private static List<Vector2> ToCheckPointCoords(List<Dictionary<string, float>> checkPointDictCoords)
    {
        return checkPointDictCoords.Select(dict => new Vector2(dict["x"], dict["y"])).ToList();
    }

    private static List<Dictionary<string, float>> ToCheckPointDictCoords(List<Vector2> checkPointCoords)
    {
        List<Dictionary<string, float>> dictCoords = checkPointCoords.Select(v => new Dictionary<string, float>{
            {"x", v.X}, {"y", v.Y}
         }).ToList();
        return checkPointCoords.Select(v => new Dictionary<string, float> { { "x", v.X }, { "y", v.Y } }).ToList();
    }
}