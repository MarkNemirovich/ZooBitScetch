using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;

namespace ZooBitSketch.StageFactory
{
    internal class StageTutorialFactory : StageAbstractFactory
    {
        public override Stage CreateStage(int stageIndex)
        {
            switch (stageIndex)
            {
                case 0:
                    {
                        teamSize = 1; deckSize= 9;
                        return new Stage("Механика боя", DefaultDescription(), teamSize, deckSize, euphoriaAmoount, Genre.Universal, Genre.Universal, 
                            NoRoleRestriction, NoCondition );
                    }
                case 1:
                    {
                        teamSize = 1; deckSize = 15;
                        return new Stage("Атака, защита, сброс", DefaultDescription(), teamSize, deckSize, euphoriaAmoount, Genre.Universal, Genre.Universal, 
                            NoRoleRestriction, NoCondition);
                    }
                case 2:
                    {
                        teamSize = 2; deckSize = 15;
                        return new Stage("Синергия режима", DefaultDescription(), teamSize, deckSize, euphoriaAmoount, Genre.Rock, Genre.Universal, 
                            NoRoleRestriction, NoCondition);
                    }
                case 3:
                    {
                        teamSize = 3; deckSize = 21;
                        return new Stage("Продолжительные эффекты", DefaultDescription(), teamSize, deckSize, euphoriaAmoount, Genre.Rock, Genre.Universal, 
                            NoRoleRestriction, NoCondition);
                    }
                case 4:
                    {
                        teamSize = 4; deckSize = 21;
                        return new Stage("Условные ограничения", "В команде должен быть певец.\nПобедите за 5 раундов", teamSize, deckSize, euphoriaAmoount, Genre.Rock, Genre.Universal, 
                            OneSinglerRoleRestriction, (condition) => (condition.Item1 == Conditions.Rounds && (int)condition.Item2 < 5));
                    }
                default: { return default; }
            }
        }
    }
}
