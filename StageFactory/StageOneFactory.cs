using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;

namespace ZooBitSketch.StageFactory
{
    internal class StageOneFactory : StageAbstractFactory
    {
        public override Stage CreateStage(int stageIndex)
        {
            switch (stageIndex)
            {
                case 0:
                    {
                        return new Stage($"Гараж-{stageIndex+1}", teamSize, deckSize, euphoriaAmoount, Genre.Pop, Genre.Rap, NoRoleRestriction,
                            (condition) => (condition.Item1 == Conditions.Rounds && (int)condition.Item2 < 5));
                    }
                case 1:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", teamSize, deckSize, (int)(1.1 * euphoriaAmoount), Genre.Pop, Genre.Reggae, NoRoleRestriction,
                            (condition) => (condition.Item1 == Conditions.Rounds && (int)condition.Item2 < 5));
                    }
                case 2:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", teamSize, deckSize, (int)(1.15 * euphoriaAmoount), Genre.Pop, Genre.Rock, NoRoleRestriction,
                            (condition) => (condition.Item1 == Conditions.Euphoria && (int)condition.Item2 < 50));
                    }
                case 3:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", teamSize, deckSize, (int)(1.2 * euphoriaAmoount), Genre.Rock, Genre.Universal, NoRoleRestriction,
                            (condition) => (condition.Item1 == Conditions.Euphoria && (int)condition.Item2 < 50));
                    }
                case 4:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", teamSize, deckSize, (int)(1.25 * euphoriaAmoount), Genre.Rock, Genre.Universal, OneSinglerRoleRestriction,
                            (condition) => (condition.Item1 == Conditions.Euphoria && (int)condition.Item2 < 50));
                    }
                default: { return default; }
            }
        }
    }
}
