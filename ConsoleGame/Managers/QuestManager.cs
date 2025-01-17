﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Managers
{
    public class QuestManager
    {
        public int QuestNum = 1;
        public Dictionary<int, Quest> dicQuestInfos = new Dictionary<int, Quest>();
        public QuestManager()
        {
            InitQuest();
        }

        public void InitQuest()
        {
            dicQuestInfos.Clear();
            dicQuestInfos.Add(QuestNum++, new Quest("몬스터를 해치우자", "던전 밖으로 나오는 몬스터들이 증가했다. 던전에 들어가 마을 사람들에게 피해를 입히는 몬스터들을 5마리 제거하자", "몬스터 5마리 처치", 5, 1000));
            dicQuestInfos.Add(QuestNum++, new Quest("장비를 장착해보자", "이봐 형씨 아무것도 안입고 어딜 그렇게 가나. 마침 김씨네 상점에 좋은 물건이 들어왔으니 한 번 가보는게 어때?", "장비아이템 하나 구매 후 장착하기",1, 1000));
            dicQuestInfos.Add(QuestNum++, new Quest("더욱 더 강해지기!", "난 나보다 약한 자의 말은 듣지 않는다.","공격력 및 방어력 20 이상 달성하기", 20, 1000));
        }
    }
}
