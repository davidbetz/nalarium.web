#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.ComponentModel;
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    /// <summary>
    /// This entity is to be used as a base for programmatic user controls that require a data source.
    /// </summary>
    public abstract class DataUserControl : UserControl
    {
        private Object _dataSource;

        //+
        //- @DataSource -//
        /// <summary>
        /// Gets the current data source.
        /// </summary>
        public Object DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = GetDataSource();
                }
                //+
                return _dataSource;
            }
            protected set
            {
                _dataSource = value;
            }
        }

        //- #GetDataSource -//
        /// <summary>
        /// Contains the implemenation logic for obtaining a data source; should only be called by the DataSource property
        /// </summary>
        /// <returns>Any data source</returns>
        protected abstract Object GetDataSource();

        //- #__BuildControlTree -//
        /// <summary>
        /// This is not to be called directly.
        /// </summary>
        /// <param name="__ctrl">The __CTRL.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected abstract void BuildControlTree(DataUserControl ctrl);

        //- #FrameworkInitialize -//
        /// <summary>
        /// This is not to be called directly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void FrameworkInitialize()
        {
            base.FrameworkInitialize();
            BuildControlTree(this);
        }
    }
}