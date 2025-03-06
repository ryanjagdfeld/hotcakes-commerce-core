﻿#region License

// Distributed under the MIT License
// ============================================================
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
using System.Linq;
using System.Text;
using Hotcakes.Commerce.Catalog;

namespace Hotcakes.Commerce.Tests.IRepository
{
    public interface IXmlProductReviewRepository : IDisposable
    {

        #region Product Review Repository Service

        /// <summary>
        /// Gets the total product review count.
        /// </summary>
        /// <returns></returns>
        int GetTotalProductReviewCount();

        /// <summary>
        /// Gets the add product review.
        /// </summary>
        /// <returns></returns>
        ProductReview GetAddProductReview();

        /// <summary>
        /// Gets the edit product review.
        /// </summary>
        /// <returns></returns>
        ProductReview GetEditProductReview();






        /// <summary>
        /// Finds the by product identifier paged count.
        /// </summary>
        /// <returns></returns>
        int FindByProductIdPagedCount();

        /// <summary>
        /// Finds the not approved count.
        /// </summary>
        /// <returns></returns>
        int FindNotApprovedCount();



        #endregion

    }
}
