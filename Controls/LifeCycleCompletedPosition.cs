#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.Controls
{
    public enum LifeCycleCompletedPosition
    {
        Init,
        LoadControlState,
        LoadViewState,
        Load,
        CreateChildControls,
        CreateControlCollection,
        DataBinding,
        PreRender,
        SaveControlState,
        SaveViewState,
        Render,
        Unload,
    }
}