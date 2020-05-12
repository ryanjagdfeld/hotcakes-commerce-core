﻿#region License

// Distributed under the MIT License
// ============================================================
// Copyright (c) 2019 Hotcakes Commerce, LLC
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
using System.Text;

namespace Hotcakes.Modules.Core.AppCode
{
    [Serializable]
    public static class Html
    {
        public static string JQueryIncludes(string baseScriptFolder, bool IsSecure)
        {
            var sb = new StringBuilder();
            if (!baseScriptFolder.EndsWith("/"))
            {
                baseScriptFolder += "/";
            }

            // Local JQuery
            sb.AppendLine("<script src=\"" + baseScriptFolder + "jquery-3.5.1.min.js\" type=\"text/javascript\"></script>");
            sb.AppendLine("<script src=\"" + baseScriptFolder + "jquery-ui-1.12.1/js/jquery-ui.min.js\" type=\"text/javascript\"></script>");
            sb.AppendLine("<link rel=\"stylesheet\" href=\"" + baseScriptFolder + "jquery-ui-1.12.1/css/jquery-ui.min.css\" />");
            sb.AppendLine("<link rel=\"stylesheet\" href=\"" + baseScriptFolder + "jquery-ui-1.12.1/css/jquery-ui.theme.min.css\" />");
            sb.AppendLine("<link rel=\"stylesheet\" href=\"" + baseScriptFolder + "jquery-ui-1.12.1/css/theme.css\" />");
            return sb.ToString();
        }

        public static string AdminFooter()
        {
            return "<div id=\"footer\"><div id=\"copyright\">&copy; Copyright 2013-2018 Hotcakes Commerce, LLC<br />&copy; Copyright 2019-" + DateTime.UtcNow.Year + " Upendo Ventures, LLC </div></div>";
        }
    }
}