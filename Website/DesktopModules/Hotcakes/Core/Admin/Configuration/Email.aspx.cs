#region License

// Distributed under the MIT License
// ============================================================
// Copyright (c) 2019 Hotcakes Commerce, LLC
// Copyright (c) 2020-2025 Upendo Ventures, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, 
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or 
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

#endregion

using System;
using Hotcakes.Commerce.Membership;
using Hotcakes.Modules.Core.Admin.AppCode;

namespace Hotcakes.Modules.Core.Admin.Configuration
{
    partial class Email : BaseAdminPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            PageTitle = Localization.GetString("EmailAddresses");
            CurrentTab = AdminTabType.Configuration;
            ValidateCurrentUserHasPermission(SystemPermissions.SettingsView);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                LocalizeView();

                ContactEmailField.Text = HccApp.CurrentStore.Settings.MailServer.EmailForGeneral;
                OrderNotificationEmailField.Text = HccApp.CurrentStore.Settings.MailServer.EmailForNewOrder;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                msg.ShowOk(Localization.GetString("SettingsSuccessful"));
            }
        }

        private bool Save()
        {
            HccApp.CurrentStore.Settings.MailServer.EmailForGeneral = ContactEmailField.Text.Trim();
            HccApp.CurrentStore.Settings.MailServer.EmailForNewOrder = OrderNotificationEmailField.Text.Trim();
            return HccApp.UpdateCurrentStore();
        }

        private void LocalizeView()
        {
            rfvContactEmailField.ErrorMessage = Localization.GetString("rfvContactEmailField.ErrorMessage");
            revContactEmailField.ErrorMessage = Localization.GetString("revContactEmailField.ErrorMessage");
            rfvOrderNotificationEmailField.ErrorMessage =
                Localization.GetString("rfvOrderNotificationEmailField.ErrorMessage");
            revOrderNotificationEmailField.ErrorMessage =
                Localization.GetString("revOrderNotificationEmailField.ErrorMessage");
        }
    }
}