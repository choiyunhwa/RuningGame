using System;

[Serializable]
public class Data{
    //PlayerData
    public int atk;
    public int def;
    public int level;
    public int[] maxExp = {10,20,30,40,50};//5레벨까지 있다고 생각.
    public float exp;
    //stage
    public bool[] stages;

    //HighScore
    public int[] highScores;
}
