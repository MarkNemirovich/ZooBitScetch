using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBitSketch.StageFactory
{
    internal class StageTutorialFactory : StageAbstractFactory
    {
        public override Stage CreateStage(int stageIndex)
        {
            string name = string.Empty;
            switch (stageIndex)
            {
                case 0:
                    {
                        return new Stage("Основа боя",
                            Genre.Universal,
                            Genre.Universal,
                            NoRoleRestriction,
                            NoCondition
                            );
                    }
                case 1:
                    {
                        return new Stage("Атака и защита",
                            Genre.Universal,
                            Genre.Universal,
                            NoRoleRestriction,
                            NoCondition
                            );
                    }
                case 2:
                    {
                        return new Stage("Синергия режима",
                            Genre.Rock,
                            Genre.Pop,
                            NoRoleRestriction,
                            NoCondition
                            );
                    }
                case 3:
                    {
                        return new Stage("Бафы",
                            Genre.Rock,
                            Genre.Pop,
                            NoRoleRestriction,
                            NoCondition
                            );
                    }
                case 4:
                    {
                        return new Stage("Условные ограничения",
                            Genre.Reggae,
                            Genre.Universal,
                            OneSinglerRoleRestriction,
                            NoCondition
                            );
                    }
                default: { return default; }
            }
        }
    }
}
