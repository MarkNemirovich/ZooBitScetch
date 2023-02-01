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
                        return new Stage($"Гараж-{stageIndex+1}", "В команде должен быть гитарист.\nПобедите за 5 раундов", teamSize, deckSize, euphoriaAmoount, Genre.Pop, Genre.Rap, 
                            OneGuitarRoleRestriction, (condition) => (condition.Item1 == Conditions.Rounds && (int)condition.Item2 < 5));
                    }
                case 1:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", "В команде должен быть барабанщик.\nПобедите за 5 раундов", teamSize, deckSize, (int)(1.1 * euphoriaAmoount), Genre.Pop, Genre.Reggae,
                             OneDrumsRoleRestriction, (condition) => (condition.Item1 == Conditions.Rounds && (int)condition.Item2 < 5));
                    }
                case 2:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", "В команде должен быть пианист.\nПобедите за 5 раундов", teamSize, deckSize, (int)(1.15 * euphoriaAmoount), Genre.Pop, Genre.Rock, 
                            OnePianistRoleRestriction, (condition) => (condition.Item1 == Conditions.Rounds && (int)condition.Item2 < 5));
                    }
                case 3:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", "В команде должен быть певец и гитарист.\nУ противника не должно быть более 75% эйфории", 
                            teamSize, deckSize, (int)(1.2 * euphoriaAmoount), Genre.Rock, Genre.Universal, 
                            SinglerGuitarRoleRestriction, (condition) => (condition.Item1 == Conditions.Euphoria && (int)condition.Item2 < (int)(0.75*1.2 * euphoriaAmoount)));
                    }
                case 4:
                    {
                        return new Stage($"Гараж-{stageIndex + 1}", "В команде должен быть певец, барабанщик и пианист.\nУ противника не должно быть более 75% эйфории",
                            teamSize, deckSize, (int)(1.25 * euphoriaAmoount), Genre.Rock, Genre.Universal,
                            SinglerDrumsPianistRoleRestriction, (condition) => (condition.Item1 == Conditions.Euphoria && (int)condition.Item2 < (int)(0.75 * 1.25 * euphoriaAmoount)));
                    }
                default: { return default; }
            }
        }
    }
}
