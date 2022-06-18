using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUP : Prop
{
    [SerializeField] float Skill;
    protected override void Get()
    {
        GameDataSO.PlayerSkill += Skill;
    }
}
