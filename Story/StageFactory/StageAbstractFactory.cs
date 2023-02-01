using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.Rewards;

namespace ZooBitSketch.Story.StageFactory
{
    internal abstract class StageAbstractFactory
    {
        protected int stagesAmount = 5;
        protected int euphoriaAmoount = 100;
        protected int teamSize = 4;
        protected int deckSize = 30;
        public Stage[] CreateStages()
        {
            var stages = new Stage[stagesAmount];
            for (int i = 0; i < stagesAmount; i++)
                stages[i] = CreateStage(i);
            return stages;
        }
        public abstract Stage CreateStage(int stageIndex);
        #region ThreeComboRoleRestrictions
        protected bool SinglerSinglerGuitarRoleRestriction(HashSet<Role> roles)
        {
            return TwoSinglerRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Guitar });
        }
        protected bool SinglerSinglerDrumsRoleRestriction(HashSet<Role> roles)
        {
            return TwoSinglerRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        protected bool SinglerSinglerPianistRoleRestriction(HashSet<Role> roles)
        {
            return TwoSinglerRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool SinglerGuitarGuitarRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                TwoGuitarRoleRestriction(roles);
        }
        protected bool SinglerDrumsDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                TwoDrumsRoleRestriction(roles);
        }
        protected bool SinglerPianistPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                TwoPianistRoleRestriction(roles);
        }
        protected bool SinglerGuitarDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                CompareSets(roles, new HashSet<Role> { Role.Guitar }) |
                CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        protected bool SinglerGuitarPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                CompareSets(roles, new HashSet<Role> { Role.Guitar }) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool SinglerDrumsPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                CompareSets(roles, new HashSet<Role> { Role.Drums }) |
            CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }


        protected bool GuitarGuitarDrumsRoleRestriction(HashSet<Role> roles)
        {
            return TwoGuitarRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        protected bool GuitarGuitarPianistRoleRestriction(HashSet<Role> roles)
        {
            return TwoGuitarRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool GuitarDrumsDrumsRoleRestriction(HashSet<Role> roles)
        {
            return TwoDrumsRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Guitar });
        }
        protected bool GuitarPianistPianistRoleRestriction(HashSet<Role> roles)
        {
            return TwoPianistRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Guitar });
        }
        protected bool GuitarDrumsPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar }) |
               CompareSets(roles, new HashSet<Role> { Role.Drums }) |
               CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool PianistDrumsDrumsRoleRestriction(HashSet<Role> roles)
        {
            return TwoDrumsRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool DrumsPianistPianistRoleRestriction(HashSet<Role> roles)
        {
            return TwoPianistRoleRestriction(roles) |
                CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        #endregion
        #region TwoComboRoleRestrictions
        protected bool SinglerGuitarRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                CompareSets(roles, new HashSet<Role> { Role.Guitar });
        }
        protected bool SinglerDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        protected bool SinglerPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler }) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool GuitarDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar }) |
                CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        protected bool GuitarPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar }) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        protected bool DrumsPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Drums }) |
                CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        #endregion
        #region FourRoleRestrictions
        protected bool FourSinglerRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler, Role.Singler, Role.Singler, Role.Singler });
        }
        protected bool FourGuitarRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar, Role.Guitar, Role.Guitar, Role.Guitar });
        }
        protected bool FourDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Drums, Role.Drums, Role.Drums, Role.Drums });
        }
        protected bool FourPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Pianist, Role.Pianist, Role.Pianist, Role.Pianist });
        }
        #endregion
        #region ThreeRoleRestrictions
        protected bool ThreeSinglerRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler, Role.Singler, Role.Singler });
        }
        protected bool ThreeGuitarRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar, Role.Guitar, Role.Guitar });
        }
        protected bool ThreeDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Drums, Role.Drums, Role.Drums });
        }
        protected bool ThreePianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Pianist, Role.Pianist, Role.Pianist });
        }
        #endregion
        #region TwoRoleRestrictions
        protected bool TwoSinglerRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler, Role.Singler });
        }
        protected bool TwoGuitarRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar, Role.Guitar });
        }
        protected bool TwoDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Drums, Role.Drums });
        }
        protected bool TwoPianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Pianist, Role.Pianist });
        }
        #endregion
        #region OneRoleRestrictions
        protected bool OneSinglerRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Singler });
        }
        protected bool OneGuitarRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Guitar });
        }
        protected bool OneDrumsRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Drums });
        }
        protected bool OnePianistRoleRestriction(HashSet<Role> roles)
        {
            return CompareSets(roles, new HashSet<Role> { Role.Pianist });
        }
        #endregion
        protected bool NoRoleRestriction(HashSet<Role> roles)
        {
            return true;
        }
        private bool CompareSets(HashSet<Role> roles, HashSet<Role> restrictions)
        {
            return roles.IsSupersetOf(restrictions);
        }
        protected bool NoCondition((Conditions type, int value) condition)
        {
            return true;
        }
        protected string DefaultDescription()
        {
            return "Победите в бою";
        }
        protected virtual Dictionary<Currency, int> SetCurrencies(int index)
        {
            Dictionary<Currency, int> reward = new Dictionary<Currency, int>();
            reward.Add(Currency.Money, 10 * (index + 1));
            if ((index + 1) % 5 == 0)
                reward.Add(Currency.Diamonds, 10);
            return reward;
        }
        protected virtual int SetExpirience(int index) => 10 + 5 * index;
        protected StageReward SetReward(int index)
        {
            return new StageReward(SetCurrencies(index), SetExpirience(index));
        }
    }
}