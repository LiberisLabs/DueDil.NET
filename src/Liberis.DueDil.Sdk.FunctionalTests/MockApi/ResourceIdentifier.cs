using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Liberis.DueDil.Sdk.FunctionalTests.MockApi
{
    public class ResourceIdentifier
    {
        private readonly string _httpMethod;
        private readonly string _path;
        private readonly NameValueCollection _query;

        public ResourceIdentifier(string httpMethod, string path, string queryString)
        {
            _httpMethod = httpMethod;
            _path = path;
            _query = HttpUtility.ParseQueryString(queryString);
        }

        protected bool Equals(ResourceIdentifier other)
        {
            return Equals(_httpMethod, other._httpMethod) && string.Equals(_path, other._path);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_httpMethod != null ? _httpMethod.GetHashCode() : 0) * 397) ^ (_path != null ? _path.GetHashCode() : 0) ^ _query.AllKeys.OrderBy(x => x).Aggregate(2, (current, key) => current ^ key.GetHashCode() ^ _query[key].GetHashCode());
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ResourceIdentifier)obj);
        }
    }
}
