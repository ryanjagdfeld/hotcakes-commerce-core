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
using System.Globalization;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;

namespace Hotcakes.Shipping.USPostal.v4
{
    [Serializable]
    public class InternationalService
    {
        public InternationalService()
        {
            LastResponse = string.Empty;
            LastRequest = string.Empty;
        }

        public string LastRequest { get; set; }
        public string LastResponse { get; set; }

        public InternationalResponse ProcessRequest(InternationalRequest request)
        {
            LastResponse = string.Empty;
            LastRequest = string.Empty;

            // Validate Request First
            var result = ValidateRequest(request);
            if (result.Errors.Count > 0) return result;

            try
            {
                var sURL = request.ApiUrl;
                sURL += "?API=IntlRateV2&XML=";

                // Build XML
                var requestXml = string.Empty;

                var sw = new StringWriter(CultureInfo.InvariantCulture);
                var xw = new XmlTextWriter(sw) {Formatting = Formatting.None};

                // Start Request
                xw.WriteStartElement("IntlRateV2Request");
                xw.WriteAttributeString("USERID", request.UserId);
                xw.WriteElementString("Revision", request.Revision);

                foreach (var pak in request.Packages)
                {
                    pak.WriteToXml(ref xw);
                }

                //End Rate Request
                xw.WriteEndElement();
                xw.Flush();
                xw.Close();
                
                requestXml = sw.GetStringBuilder().ToString();
                
                if (!requestXml.StartsWith("<"))
                {
                    requestXml = requestXml.Substring(1, requestXml.Length - 1);
                }

                // Diagnostics
                LastRequest = requestXml;

                var sResponse = string.Empty;
                var dataToSend = sURL + HttpUtility.UrlEncode(requestXml);

                sResponse = readHtmlPage(dataToSend);

                // Diagnostics
                LastResponse = sResponse;

                result = new InternationalResponse(sResponse);
            }
            catch (Exception ex)
            {
                result.Errors.Add(new USPSError
                {
                    Description = ex.Message + " " + ex.StackTrace,
                    Source = "HCC Exception"
                });
            }
            return result;
        }

        private string readHtmlPage(string url)
        {
            url = url.Replace("\n", string.Empty);
            url = url.Replace("\r", string.Empty);
            url = url.Replace("\t", string.Empty);

            WebResponse objResponse;
            WebRequest objRequest;
            var result = string.Empty;
            objRequest = WebRequest.Create(url);
            objResponse = objRequest.GetResponse();
            var sr = new StreamReader(objResponse.GetResponseStream());
            result += sr.ReadToEnd();
            sr.Close();
            return result;
        }

        public InternationalResponse ValidateRequest(InternationalRequest request)
        {
            var result = new InternationalResponse();

            if (request == null)
            {
                result.Errors.Add(new USPSError {Description = "Request was null"});
                return result;
            }

            if (request.Packages.Count < 1)
            {
                result.Errors.Add(new USPSError {Description = "Request requires at least one package."});
            }

            if (request.UserId.Trim().Length < 1)
            {
                result.Errors.Add(new USPSError {Description = "UserId is Required for Requests"});
            }

            return result;
        }

        public static decimal GetInternationalWeightLimit(string countryName)
        {
            var result = 44m;

            switch (countryName)
            {
                case "Albania":
                case "Pakistan":
                case "Romania":
                case "Tanzania":
                case "Uganda":
                case "Vanuatu":
                    result = 22m;
                    break;
                case "Chile":
                case "El Salvador":
                case "Israel":
                case "Taiwan":
                    result = 33m;
                    break;
                case "Brazil":
                    result = 50m;
                    break;
                case "Andorra":
                case "Austria":
                case "Belgium":
                case "Canada":
                case "China":
                case "Czech Republic":
                case "Denmark":
                case "Eritrea":
                case "Finland":
                case "France":
                case "French Guiana":
                case "Georgia":
                case "Germany":
                case "Great Britain":
                case "Greece":
                case "Guadeloupe":
                case "Hong Kong":
                case "Ireland":
                case "Italy":
                case "Japan":
                case "Jordan":
                case "Korea":
                case "Liechtenstein":
                case "Luxembourg":
                case "Macao":
                case "Macedonia":
                case "Malaysia":
                case "Malta":
                case "Martinique":
                case "Mexico":
                case "Morocco":
                case "Netherlands":
                case "Norway":
                case "Portugal":
                case "San Marino":
                case "Saudi Arabia":
                case "Singapore":
                case "Slovakia":
                case "Spain":
                case "Sweden":
                case "Switzerland":
                case "Vatican City":
                case "Yemen":
                    result = 66m;
                    break;
                case "Faroe Islands":
                case "Haiti":
                case "Serbia":
                    result = 70m;
                    break;
                default:
                    result = 44m;
                    break;
            }

            return result;
        }
    }
}