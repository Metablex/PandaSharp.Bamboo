using System.Collections.Generic;
using System.Linq;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo.Services.Common.Expansion
{
    internal abstract class RequestExpansionBase
    {
        private readonly string _expansionRoot;
        private readonly HashSet<string> _expansionLevels;

        protected RequestExpansionBase(string expansionRoot)
        {
            _expansionRoot = expansionRoot;
            _expansionLevels = new HashSet<string>();
        }

        public override string ToString()
        {
            var resultString = string.Join(",", GetExpansionLevels());
            if (resultString.IsNullOrEmpty())
            {
                return _expansionRoot;
            }

            return resultString;
        }

        protected void AddExpansionLevel(string expansionLevel)
        {
            var expansionLevelString = _expansionRoot.IsNullOrEmpty()
                ? expansionLevel
                : $"{_expansionRoot}.{expansionLevel}";

            _expansionLevels.Add(expansionLevelString);
        }

        protected virtual IEnumerable<RequestExpansionBase> GetSubExpansionLevel()
        {
            return Enumerable.Empty<RequestExpansionBase>();
        }

        private IEnumerable<string> GetExpansionLevels()
        {
            foreach (var expansionLevel in _expansionLevels)
            {
                yield return expansionLevel;
            }

            foreach (var subExpansionLevel in GetSubExpansionLevel())
            {
                yield return subExpansionLevel.ToString();
            }
        }
    }
}