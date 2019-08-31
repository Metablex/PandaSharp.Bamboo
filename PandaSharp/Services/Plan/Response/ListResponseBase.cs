using System.Collections;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public abstract class ListResponseBase<T> : IEnumerable<T>
    {
        [DeserializeAs(Name = "size")]
        public int Size { get; set; }

        [DeserializeAs(Name = "start-index")]
        public int StartIndex { get; set; }

        [DeserializeAs(Name = "max-result")]
        public int MaxResult { get; set; }

        public virtual List<T> InnerList { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList?.GetEnumerator() ?? new List<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}