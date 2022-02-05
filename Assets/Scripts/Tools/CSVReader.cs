using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class CSVReader
{
  //재료 데이터
  //C# Reflection
    public static List<Dictionary<int, CombineInfo>> Read(string file)//조합식 데이터
    {
        int key;
        int m1;
        int m2;
        int m3;
        int m4;

        var list = new List<Dictionary<int, CombineInfo>>();

        TextAsset sourcefile = Resources.Load<TextAsset>("GameDatas/" + file);
        StringReader sr = new StringReader(sourcefile.text);//데이터 시트 열기
         // StringReader sr = new StringReader(Application.dataPath + "/Resources/GameDatas/" + file);//데이터 시트 열기

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            //데이터를 구조체 함수에 넣어 초기화
            var data_values = data_String.Split(',');
            var tmp = new Dictionary<int, CombineInfo>();
            int.TryParse(data_values[0], out key);
            int.TryParse(data_values[3], out m1);
            int.TryParse(data_values[5], out m2);
            int.TryParse(data_values[7], out m3);
            int.TryParse(data_values[9], out m4);

            CombineInfo combineInfo = new CombineInfo(data_values[1], data_values[2],m1, data_values[4], m2, data_values[6], m3, data_values[8], m4);
            tmp.Add(key,combineInfo);
            list.Add(tmp);
        }

        return list;

    }
    //무기 데이터
    public static List<Dictionary<int, WeaponInfo>>WeaponRead(string file)//무기 데이터
    {
        int key;
        string itemName;
        int itemCode;
        int type;
        int speed;
        float range;
        int damage;
        int hit;
        int price;
        var list = new List<Dictionary<int, WeaponInfo>>();
        TextAsset sourcefile = Resources.Load<TextAsset>("GameDatas/"+file);
        StringReader sr2 = new StringReader(sourcefile.text);//데이터 시트 열기
  // StringReader sr = new StringReader(Application.dataPath + "/Resources/GameDatas/" + file);//데이터 시트 열기
       // StringReader sr2 = new StringReader(Application.dataPath + "/Resources/GameDatas/" + file);
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String2 = sr2.ReadLine();
            if (data_String2 == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String2.Split(',');
            var tmp = new Dictionary<int, WeaponInfo>();
            int.TryParse(data_values[0], out key);
            itemName = data_values[1];
            int.TryParse(data_values[2], out itemCode);
            int.TryParse(data_values[3],out type);
            int.TryParse(data_values[4], out speed);
            float.TryParse(data_values[5], out range);
            int.TryParse(data_values[6], out damage);
            int.TryParse(data_values[7], out hit);
            int.TryParse(data_values[8], out price);
        
            WeaponInfo WeaponInfo = new WeaponInfo(data_values[1], data_values[2], type,speed, range, damage, hit,price);
            tmp.Add(key, WeaponInfo);
            list.Add(tmp);
        }

        return list;

    }

    public static List<Dictionary<int, ItemInfo>>ItemRead(string file)
    {
        int key;
        string itemName;
        string itemCode;
        string price;
        var list = new List<Dictionary<int, ItemInfo>>();
        TextAsset sourcefile = Resources.Load<TextAsset>("GameDatas/" + file);
        StringReader i2= new StringReader(sourcefile.text);//데이터 시트 열기
//  StringReader i2 = new StringReader(Application.dataPath + "/Resources/GameDatas/" + file);
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String2 = i2.ReadLine();
            if (data_String2 == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String2.Split(',');
            var tmp = new Dictionary<int, ItemInfo>();
            int.TryParse(data_values[0], out key);
            itemName = data_values[1];
            itemCode = data_values[2];
            price = data_values[3];

            ItemInfo itemInfo= new ItemInfo(data_values[1], data_values[2], data_values[3]);
            tmp.Add(key, itemInfo);
            list.Add(tmp);
        }
        return list;
    }//아이템 기본 데이터

    
    public static List<Dictionary<int, StageDatas>> Stage(string file)//스테이지 데이터
    {
        int key;
        string stageName;
        int stageDifficulty;
        int Danger;
        var list = new List<Dictionary<int, StageDatas>>();

        TextAsset sourcefile = Resources.Load<TextAsset>("GameDatas/"+file);
        StringReader r3 = new StringReader(sourcefile.text);//데이터 시트 열기

        // StringReader r3 = new StringReader(Application.dataPath + "/Resources/GameDatas/" + file);

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String2 = r3.ReadLine();
            if (data_String2 == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String2.Split(',');
            var tmp = new Dictionary<int, StageDatas>();
            int.TryParse(data_values[0], out key);
            stageName = data_values[1];
            int.TryParse(data_values[2], out stageDifficulty);
            int.TryParse(data_values[3], out Danger);

            StageDatas stageDatas = new StageDatas(data_values[1], data_values[2], data_values[3]);
            tmp.Add(key, stageDatas);
            list.Add(tmp);
        }



        return list;
    }

    public static List<Dictionary<int, BoxDataInfo>> BoxItems(string file)//상자 아이템
    {
        int key;
        string boxName;
       
        var list = new List<Dictionary<int, BoxDataInfo>>();
        TextAsset sourcefile = Resources.Load<TextAsset>("GameDatas"+file);
        StringReader bd = new StringReader(sourcefile.text);//데이터 시트 열기


        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String2 = bd.ReadLine();
            if (data_String2 == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String2.Split(',');
            var tmp = new Dictionary<int, BoxDataInfo>();
            int.TryParse(data_values[0], out key);
            boxName = data_values[1];
  

            BoxDataInfo boxDataInfo = new BoxDataInfo(data_values[1], data_values[2], data_values[3], data_values[4], data_values[5],
                data_values[6], data_values[7], data_values[8], data_values[9]);
            tmp.Add(key, boxDataInfo);


            list.Add(tmp);
        }

        return list;
    }
    
    public static List<Dictionary<int, DialogInfo>> DialogScript(string file)
    {
        int key;
        string talker;
        string script;
        int expression;

        var list = new List<Dictionary<int, DialogInfo>>();
        TextAsset sourcefile = Resources.Load<TextAsset>("GameDatas" + file);
        StringReader ds = new StringReader(sourcefile.text);//데이터 시트 열기

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String2 = ds.ReadLine();
            if (data_String2 == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String2.Split(',');
            var tmp = new Dictionary<int, DialogInfo>();

            int.TryParse(data_values[0], out key);

            talker = data_values[1];
            script = data_values[2];
            int.TryParse(data_values[3], out expression);

            DialogInfo dialogInfo = new DialogInfo(talker, script, expression);

            tmp.Add(key, dialogInfo);
            list.Add(tmp);


        }

        return list;
    }


}