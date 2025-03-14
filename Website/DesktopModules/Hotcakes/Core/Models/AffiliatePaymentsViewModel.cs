﻿#region License

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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hotcakes.Modules.Core.Models
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class AffiliatePaymentsViewModel
    {
        /// <summary>
        ///     List of payments for the specific Afficiliate which shown on Affiliate Dashboard
        /// </summary>
        public List<PaymentViewModel> Payments { get; set; }

        /// <summary>
        ///     Total number of commission payments for the affiliate
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        ///     Total of amount of commission for all orders
        /// </summary>
        public string TotalAmount { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        ///     Individual Payment information which needs to be dispayed for Affiliate
        /// </summary>
        public class PaymentViewModel
        {
            public string Notes { get; set; }
            public string Amount { get; set; }
            public string AttachmentUrl { get; set; }
        }
    }
}