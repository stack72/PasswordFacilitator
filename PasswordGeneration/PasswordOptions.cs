using System.Collections.Generic;
using PasswordGeneration.Entities;

namespace PasswordGeneration
{
    public class PasswordOptions : List<PasswordOption>
    {
        public bool AllOptionsAreUsed
        {
            get
            {
                foreach (PasswordOption po in this)
                {
                    if (po.Count < 1)
                        return false;
                }
                return true;
            }
        }

        public PasswordOption GetUnusedOption()
        {
            var options = new PasswordOptions();
            foreach (var po in this)
            {
                if (po.Count < 1)
                    options.Add(po);
            }
            if (options.Count < 1)
                return null;

            var random = RandomSeedGenerator.GetRandom();
            var optionIndex = random.Next(options.Count);
            return options[optionIndex];
        }
    }
}