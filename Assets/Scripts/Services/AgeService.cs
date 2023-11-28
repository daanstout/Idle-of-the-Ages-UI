using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System.Collections.Generic;

namespace IdleOfTheAges.Skills {
    [Service(typeof(IAgeService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    internal class AgeService : IAgeService {
        private readonly List<AgeData> ages = new();

        public Result RegisterAge(AgeData age) {
            ages.Add(age);

            return true;
        }
    }
}
