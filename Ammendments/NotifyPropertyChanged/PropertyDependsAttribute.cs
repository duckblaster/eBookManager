using System;
using System.Collections.Generic;

namespace Ammendments {
    public class PropertyDependencyMapItem : KeyValuePair<string, List<string>>{

    }
    public class PropertyDependencyMap : Dictionary<string, List<string>> {

    }
    class PropertyDependsAttribute : Attribute {
        public string[] Targets {
            get;
            set;
        }
        public PropertyDependsAttribute(params string[] targets) {
            Targets = targets;
        }
    }
}
