namespace IdleOfTheAges {
    /// <summary>
    /// Contains the data required to render the <see cref="SkillSidebarElement"/>.
    /// </summary>
    public class SkillSidebarModel {
        /// <summary>
        /// The translation key of the skill.
        /// </summary>
        public string SkillTranslationKey { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the skill.
        /// </summary>
        public string SkillID { get; set; } = string.Empty;

        /// <summary>
        /// The thumbnail for the skill.
        /// </summary>
        public string SkillThumbnail { get; set; } = string.Empty;

        /// <summary>
        /// The current level of the skill.
        /// </summary>
        public int SkillLevel { get; set; }

        /// <summary>
        /// The maximum level of the skill.
        /// </summary>
        public int SkillMaxLevel { get; set; }
    }
}
