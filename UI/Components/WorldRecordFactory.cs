using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly:ComponentFactory(typeof(LiveSplit.WorldRecord.UI.Components.WorldRecordFactory))]

namespace LiveSplit.WorldRecord.UI.Components
{
    public class WorldRecordFactory : IComponentFactory
    {
        public string ComponentName
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public ComponentCategory Category
        {
            get { throw new NotImplementedException(); }
        }

        public IComponent Create(LiveSplitState state)
        {
            throw new NotImplementedException();
        }

        public string UpdateName
        {
            get { throw new NotImplementedException(); }
        }

        public string XMLURL
        {
            get { throw new NotImplementedException(); }
        }

        public string UpdateURL
        {
            get { throw new NotImplementedException(); }
        }

        public Version Version
        {
            get { throw new NotImplementedException(); }
        }
    }
}
