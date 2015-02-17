using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.WorldRecord.UI.Components
{
    public class WorldRecordComponent : IComponent
    {
        public string ComponentName
        {
            get { throw new NotImplementedException(); }
        }

        public float HorizontalWidth
        {
            get { throw new NotImplementedException(); }
        }

        public float MinimumHeight
        {
            get { throw new NotImplementedException(); }
        }

        public float VerticalHeight
        {
            get { throw new NotImplementedException(); }
        }

        public float MinimumWidth
        {
            get { throw new NotImplementedException(); }
        }

        public float PaddingTop
        {
            get { throw new NotImplementedException(); }
        }

        public float PaddingBottom
        {
            get { throw new NotImplementedException(); }
        }

        public float PaddingLeft
        {
            get { throw new NotImplementedException(); }
        }

        public float PaddingRight
        {
            get { throw new NotImplementedException(); }
        }

        public IDictionary<string, Action> ContextMenuControls
        {
            get { throw new NotImplementedException(); }
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            throw new NotImplementedException();
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            throw new NotImplementedException();
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        public void SetSettings(XmlNode settings)
        {
            throw new NotImplementedException();
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
