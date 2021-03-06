﻿//
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2011
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//

namespace DotNetNuke.Modules.Forums {
    using System;
    using Components.Models;
    using Components.Presenters;
    using Components.Views;
    using Web.Mvp;
    using WebFormsMvp;

    /// <summary>
    /// This is the initial view seen within the Forums module, loaded by Dispatch.ascx. 
    /// </summary>
    [PresenterBinding(typeof(TopicListPresenter))]
    public partial class TopicList : ModuleView<TopicListModel>, ITopicListView {

        /// <summary>
        /// The constructor is used here to set base properties. 
        /// </summary>
        /// <remarks>We disable AutoDataBind in the ctor so we can utlize Telerik and other 'Ajax' controls, otherwise we will get a PreRender script registration error.</remarks>
        public TopicList() {
            AutoDataBind = false;
        }
    }
}