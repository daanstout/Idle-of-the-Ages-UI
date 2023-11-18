using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Data;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.Services.UI;

using System;
using System.Collections.Generic;

namespace IdleOfTheAges.Services {
    [Service(typeof(ISkillService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class SkillService : ISkillService {
        public SkillImplementation CurrentlyShowingSkill { get; private set; }

        public event Action<SkillImplementation> CurrentlyShowingSkillChangedEvent;

        private readonly Dictionary<string, SkillImplementation> skills = new();
        private readonly Dictionary<string, SkillData> skillDatas = new();

        private readonly IModLibrary modLibrary;
        private readonly IElementLibrary elementLibrary;

        public SkillService(IModLibrary modLibrary, IElementLibrary elementLibrary) {
            this.modLibrary = modLibrary;
            this.elementLibrary = elementLibrary;
        }

        public Result RegisterSkillImplementation<TSkill>(string skillID) where TSkill : SkillImplementation {
            return RegisterSkillImplementation(typeof(TSkill), skillID);
        }

        public Result RegisterSkillImplementation(Type skillType, string skillID) {
            var skill = (SkillImplementation)Activator.CreateInstance(skillType, skillDatas[skillID]);

            skill.Initialize(modLibrary.GetModObject(skill.Namespace).Value.ServiceLibrary);

            elementLibrary.RegisterElement(skill.SkillUI, skill.NamespacedID);
            elementLibrary.Create(skill.SkillUI, $"SKILL_VIEW_{skill.NamespacedID}", skill.NamespacedID);

            skills.Add(skill.NamespacedID, skill);

            if (skills.Count == 1) {
                ChangeShowingSkill(skill.NamespacedID);
            }

            return true;
        }

        public Result<IReadOnlyCollection<SkillImplementation>> GetSkills() {
            return skills.Values;
        }

        public Result ChangeShowingSkill(string skillID) {
            if (!skills.TryGetValue(skillID, out var skill))
                return (false, $"No skill with ID {skillID} has been registered!");

            CurrentlyShowingSkill = skill;

            CurrentlyShowingSkillChangedEvent?.Invoke(skill);

            return true;
        }

        public Result RegisterSkillData(SkillData skillData) {
            skillDatas[skillData.NamespacedID] = skillData;

            return true;
        }
    }
}
