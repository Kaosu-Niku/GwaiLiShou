using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI TypeA;
    [SerializeField] TMPro.TextMeshProUGUI TypeB;
    [SerializeField] AllEventSO GetAllEventSO;
    public void ChangeTypeText(int who)
    {
        switch (who)
        {
            case 0:
                switch (GameDataSO.Language)
                {
                    case 0:
                        TypeA.font = GetAllEventSO.ChineseFontAsset;
                        TypeB.font = GetAllEventSO.ChineseFontAsset;
                        TypeA.text = "Bomb:靈符「夢想封印」 TypeA:追尾型 高速射擊:Homing Amulet(自動追蹤敵人的攻擊) 低速射擊:貪婪大幣(自動退治近處敵人的大幣)";
                        TypeB.text = "Bomb:靈符「夢想封印」 Type B:速射型 高速射擊:Persuasion Needle(連續發射出針的攻擊) 低速射擊:Extermination(連續射出高威力的針的攻擊)";
                        break;
                    case 1:
                        TypeA.font = GetAllEventSO.EnglishFontAsset;
                        TypeB.font = GetAllEventSO.EnglishFontAsset;
                        TypeA.text = "";
                        TypeB.text = "";
                        break;
                    case 2:
                        TypeA.font = GetAllEventSO.JapaneseFontAsset;
                        TypeB.font = GetAllEventSO.JapaneseFontAsset;
                        TypeA.text = "";
                        TypeB.text = "";
                        break;
                }
                break;
            case 1:
                switch (GameDataSO.Language)
                {
                    case 0:
                        TypeA.font = GetAllEventSO.ChineseFontAsset;
                        TypeB.font = GetAllEventSO.ChineseFontAsset;
                        TypeA.text = "Bomb:戀符「Master Spark」 TypeA:貫通型 高速射擊:Illusion Laser(持續攻擊敵人的貫通激光) 低速射擊:Witch Ley Line(後方也能射擊到的集中激光)";
                        TypeB.text = "Bomb:戀符「Master Spark」 TypeB:高威力型 高速射擊:Magic Drain Missle(碰到敵人會爆炸的擴散型導彈) 低速射擊:八卦之火(距離越近威力越大的噴射攻擊)";
                        break;
                    case 1:
                        TypeA.font = GetAllEventSO.EnglishFontAsset;
                        TypeB.font = GetAllEventSO.EnglishFontAsset;
                        TypeA.text = "";
                        TypeB.text = "";
                        break;
                    case 2:
                        TypeA.font = GetAllEventSO.JapaneseFontAsset;
                        TypeB.font = GetAllEventSO.JapaneseFontAsset;
                        TypeA.text = "";
                        TypeB.text = "";
                        break;
                }
                break;
            case 2:
                switch (GameDataSO.Language)
                {
                    case 0:
                        TypeA.font = GetAllEventSO.ChineseFontAsset;
                        TypeB.font = GetAllEventSO.ChineseFontAsset;
                        TypeA.text = "Bomb:蛙符「操縱蛤蟆」 TypeA:廣角&誘導型 高速射擊:Cobalt Spread(打中敵人後炸裂的廣範圍蛙射擊) 低速射擊:Sky Serpent(咬住不放似地追擊敵人的蛇攻擊)";
                        TypeB.text = "Bomb:蛙符「操縱蛤蟆」 TypeB:廣角&蓄能型 高速射擊:Mighty Wind(向前方展開的廣闊攻擊) 低速射擊:神風招來(蓄力噴出越遠越大範圍的貫通風攻擊)";
                        break;
                    case 1:
                        TypeA.font = GetAllEventSO.EnglishFontAsset;
                        TypeB.font = GetAllEventSO.EnglishFontAsset;
                        TypeA.text = "";
                        TypeB.text = "";
                        break;
                    case 2:
                        TypeA.font = GetAllEventSO.JapaneseFontAsset;
                        TypeB.font = GetAllEventSO.JapaneseFontAsset;
                        TypeA.text = "";
                        TypeB.text = "";
                        break;
                }
                break;
        }

    }
}
