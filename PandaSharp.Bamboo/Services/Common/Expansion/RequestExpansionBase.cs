using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Common.Expansion
{
    internal abstract class RequestExpansionBase
    {
        private readonly string _expansionRoot;
        private readonly List<string> _expansionLevels;

        protected RequestExpansionBase(string expansionRoot)
        {
            _expansionRoot = expansionRoot;
            _expansionLevels = new List<string>();
        }

        protected void AddExpansionLevel(string expansionLevel)
        {
            _expansionLevels.Add($"{_expansionRoot}.{expansionLevel}");
        }

        public override string ToString()
        {
            if (_expansionLevels.Count == 0)
            {
                return _expansionRoot;
            }

            return string.Join(",", _expansionLevels);
        }
    }
}