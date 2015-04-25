using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;

[assembly:ComponentFactory(typeof(LiveSplit.WorldRecord.UI.Components.WorldRecordFactory))]

namespace LiveSplit.WorldRecord.UI.Components
{
    public class WorldRecordFactory : IComponentFactory
    {
        public string ComponentName
        {
            get { return "World Record"; }
        }

        public string Description
        {
            get { return "Shows the World Record for the run"; }
        }

        public ComponentCategory Category
        {
            get { return ComponentCategory.Information; }
        }

        public IComponent Create(LiveSplitState state)
        {
            return new WorldRecordComponent(state);
        }

        public string UpdateName
        {
            get { return ComponentName; }
        }

        public string XMLURL
        {
#if RELEASE_CANDIDATE
            get { return "http://livesplit.org/update_rc_sdhjdop/Components/update.LiveSplit.WorldRecord.xml"; }
#else
            get { return "http://livesplit.org/update/Components/update.LiveSplit.WorldRecord.xml"; }
#endif
        }

        public string UpdateURL
        {
#if RELEASE_CANDIDATE
            get { return "http://livesplit.org/update_rc_sdhjdop/"; }
#else
            get { return "http://livesplit.org/update/"; }
#endif
        }

        public Version Version
        {
            get { return Version.Parse("1.5.2"); }
        }
    }
}
