using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using LiveSplit.Web.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.WorldRecord.UI.Components
{
    public class WorldRecordComponent : IComponent
    {
        protected InfoTextComponent InternalComponent { get; set; }

        private GraphicsCache Cache { get; set; }
        private ITimeFormatter TimeFormatter { get; set; }
        private LiveSplitState State { get; set; }
        private TripleDateTime LastUpdate { get; set; }
        private TimeSpan RefreshInterval { get; set; }

        public string ComponentName
        {
            get { return "World Record"; }
        }

        public float PaddingTop { get { return InternalComponent.PaddingTop; } }
        public float PaddingLeft { get { return InternalComponent.PaddingLeft; } }
        public float PaddingBottom { get { return InternalComponent.PaddingBottom; } }
        public float PaddingRight { get { return InternalComponent.PaddingRight; } }

        public float VerticalHeight { get { return InternalComponent.VerticalHeight; } }
        public float MinimumWidth { get { return InternalComponent.MinimumWidth; } }
        public float HorizontalWidth { get { return InternalComponent.HorizontalWidth; } }
        public float MinimumHeight { get { return InternalComponent.MinimumHeight; } }

        public IDictionary<string, Action> ContextMenuControls { get { return null; } }

        public WorldRecordComponent(LiveSplitState state)
        {
            State = state;

            RefreshInterval = TimeSpan.FromSeconds(5);
            Cache = new GraphicsCache();
            TimeFormatter = new RegularTimeFormatter();
            InternalComponent = new InfoTextComponent("World Record", "-");
            InternalComponent.AlternateNameText = new[]
            {
                "WR"
            };
        }

        public void Dispose()
        {
        }

        private void RefreshWorldRecord()
        {
            LastUpdate = TripleDateTime.Now;

            if (State != null && State.Run != null &&
                !string.IsNullOrEmpty(State.Run.GameName) && !string.IsNullOrEmpty(State.Run.CategoryName))
            {
                var wr = SpeedrunCom.Instance.GetWorldRecord(State.Run.GameName, State.Run.CategoryName);
                if (!string.IsNullOrEmpty(wr.Runner))
                {
                    var time = TimeFormatter.Format(wr.Time);
                    InternalComponent.InformationValue = string.Format("{0} by {1}", time, wr.Runner);
                }
                else
                {
                    InternalComponent.InformationValue = "-";
                }
            }
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            Cache.Restart();
            Cache["Game"] = state.Run.GameName;
            Cache["Category"] = state.Run.CategoryName;

            if (Cache.HasChanged || (LastUpdate != null && TripleDateTime.Now - LastUpdate >= RefreshInterval))
            {
                Task.Factory.StartNew(RefreshWorldRecord);
            }

            Cache["Value"] = InternalComponent.InformationValue;
            InternalComponent.Update(invalidator, state, width, height, mode);

            if (invalidator != null && Cache.HasChanged)
            {
                invalidator.Invalidate(0, 0, width, height);
            }
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return null;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return document.CreateElement("Settings");
        }

        public void SetSettings(XmlNode settings)
        {
        }
    }
}
