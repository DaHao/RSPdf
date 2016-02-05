using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;
using System.Text.RegularExpressions;

namespace RSPdf
{
    class EmlParser
    {

        #region "Property"
        public string _x_Sender { get; set; }
        public List<string> _x_Receivers { get; set; }
        public string _Received { get; set; }
        public string _Mime_Version  { get; set; }
        public string _From  { get; set; }
        public string _To  { get; set; }
        public List<string> _ListTo  { get; set; }
        public List<string> _ListCC  { get; set; }
        public string _Date  { get; set; }
        public string _Subject  { get; set; }
        public string _ContentType  { get; set; }
        public string _Content_Transfer_Encoding  { get; set; }
        public string _Return_Path  { get; set; }
        public string _Message_ID  { get; set; }
        public DateTime _x_OriginalArrivaTime  { get; set; }
        public string _Body  { get; set; }
        public string _HTMLBody  { get; set; }
        public string _attStr  { get; set; }
        public string _attStrZip  { get; set; }
        public string _att  { get; set; }
        public Dictionary<string, string> _listUnsupported { get; set; }
        #endregion

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="ze"></param>
        public EmlParser(ZipEntry ze)
        {
            try
            {
                parseEML(ze);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void parseEML(ZipEntry ze)
        {
            try
            {
                List<string> ListLine = Input2String(ze);

                //Get EML Header
                List<string> ListHeader = new List<string>();
                int lineIndex = -1;
                for (int i = 0; i < ListLine.Count; i++)
                {
                    //Header is End
                    if (ListLine[i] == string.Empty)
                    {
                        lineIndex = i;
                        break;
                    }

                    string sFullValue = ListLine[i];
                    GetFullValue(ListLine, ref i, ref sFullValue);
                    ListHeader.Add(sFullValue);
                }
                SetHeader(ListHeader);

                if (lineIndex == -1) return;

                //Get EML Body
                //1. contentType = multipart/alternative
                //2. contentType = nultipart/mixed
                //3. direction output
                if (_ContentType != null &&
                    _ContentType.ToLower().Contains("alternative"))
                {
                    int ix = _ContentType.ToLower().IndexOf("boundary");
                    if (ix == -1) return;

                    
                    List<string> ListBody = new List<string>();
                    //8 means "boundary".count
                    string sBDMarker = _ContentType.Substring(ix + 8).Trim();
                    for (int i = lineIndex + 1; i < ListLine.Count; i++)
                    {
                        if (ListLine[i].Contains(sBDMarker))
                        {
                            if (ListBody.Count > 0)
                            {
                                SetBody(ListBody);
                            }
                            continue;
                        }
                        ListBody.Add(ListLine[i]);
                    }

                }
                else if (_ContentType.ToLower().Contains("multipart/mixed"))
                {
                    int ix = _ContentType.ToLower().IndexOf("boundary");
                    if (ix == -1) return;


                    //8 means "boundary".count
                    string sBDMarker = _ContentType.Substring(ix + 8).Trim();
                    bool bContent = false;
                    bool bBD = false;

                    _Body = string.Empty;
                    for (int i = lineIndex + 1; i < ListLine.Count; i++)
                    {
                        if (ListLine[i].Contains(sBDMarker) || bBD)
                        {
                            bBD = true;
                            if (ListLine[i].Contains(sBDMarker) && bContent) break;

                            if (ListLine[i] == string.Empty || bContent)
                            {
                                if (!bContent)
                                    bContent = true;
                                else
                                    _Body += ListLine[i];
                            }
                        }
                        else
                        {
                            lineIndex++;
                            continue;
                        }

                        lineIndex++;
                    }
                }
                else
                {
                    _Body = string.Empty;
                    for (int i = lineIndex + 1; i < ListLine.Count; i++)
                    {
                        _Body += ListLine[i] + "\r\n";
                    }
                }

                //Get EML Attchment
                int index = _ContentType.ToLower().IndexOf("boundary");
                string sBD = _ContentType.Substring(index + 9).Trim();
                bool bAtt = false;
                bool bEmpty = false;
                bool bZip = false;
                _attStr = string.Empty;

                for (int i = lineIndex + 1; i < ListLine.Count; i++)
                {
                    if (ListLine[i].ToLower().Contains("application/zip"))
                        bZip = true;
                    if (ListLine[i].ToLower().Contains("attachment"))
                        bAtt = true;
                    if (ListLine[i] == string.Empty && bAtt)
                        bEmpty = true;
                    if (bEmpty)
                    {
                        if (ListLine[i].Contains(sBD))
                            break;
                        _attStr += ListLine[i];
                    }
                }

                if (bZip) _attStrZip = _attStr;

                _attStr = Encoding.UTF8.GetString(System.Convert.FromBase64String(_attStr));

            }
            catch (Exception ex)
            { throw ex; }
        }

        private void SetBody(List<string> ListBody)
        {
            bool bIsHTML = false;
            bool bIsBodyStart = false;

            List<string> ListContent = new List<string>();
            foreach (string s in ListBody)
            {
                if (s.ToLower().StartsWith("content-type"))
                {
                    if (s.ToLower().Contains("text/html"))
                    { bIsHTML = true; }
                    else if (!s.ToLower().Contains("text/plain"))
                    { return; }
                }
                else if (s == string.Empty && !bIsBodyStart)
                { bIsBodyStart = true; }
                else if (bIsBodyStart)
                { ListContent.Add(s); }
            }

            if (bIsHTML)
                _HTMLBody = string.Join("\r\n", ListContent);
            else
                _Body = string.Join("\r\n", ListContent);

        }

        /// <summary>
        /// Give the Header's Attr Value
        /// </summary>
        /// <param name="ListHeader"></param>
        private void SetHeader(List<string> ListHeader)
        {
            _listUnsupported = new Dictionary<string, string>();
            List<string> listX_Receiver = new List<string>();

            foreach( string Line in ListHeader )
            {
                char splitWord = ':';
                string[] sHdr = Line.Split(splitWord);
                if (sHdr == null) continue;

                
                //assign Header Attr
                switch (sHdr[0].ToLower())
                {
                    case "x-sender":
                        _x_Sender = sHdr[1];
                        break;

                    case "x-receiver":
                        listX_Receiver.Add(sHdr[1]);
                        break;

                    case "received":
                        _Received = sHdr[1];
                        break;

                    case "mime-version":
                        _Mime_Version = sHdr[1];
                        break;

                    case "from":
                        MatchCollection matchesFrom = new Regex(@"[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9\-\.]+\.[A-Za-z]{2,4}").Matches(sHdr[1].Trim());
                        if (matchesFrom.Count > 0)
                        {
                            foreach( Match m in matchesFrom)
                                _From = m.Value;
                        }
                        break;

                    case "to":
                        List<string> ListTo = new List<string>();

                        MatchCollection matchesTo = new Regex(@"[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9\-\.]+\.[A-Za-z]{2,4}").Matches(sHdr[1].Trim());
                        if (matchesTo.Count > 0)
                        {
                            foreach( Match m in matchesTo)
                                ListTo.Add( m.Value );
                        }

                        _ListTo = ListTo;
                        break;

                    case "cc":
                        List<string> ListCC = new List<string>();

                        MatchCollection matchesCC = new Regex(@"[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9\-\.]+\.[A-Za-z]{2,4}").Matches(sHdr[1].Trim());
                        if (matchesCC.Count > 0)
                        {
                            foreach( Match m in matchesCC)
                                ListCC.Add( m.Value );
                        }

                        _ListCC = ListCC;
                        break;

                    case "date":
                        _Date = sHdr[1];
                        break;

                    case "subject":
                        _Subject = sHdr[1];
                        break;

                    case "content-type":
                        _ContentType = sHdr[1];
                        break;

                    case "content-transfer-encoding":
                        _Content_Transfer_Encoding = sHdr[1];
                        break;

                    case "return-path":
                        _Return_Path = sHdr[1];
                        break;

                    case "message-id":
                        _Message_ID = sHdr[1];
                        break;

                    case "x-originalarrivaltime":
                        int ix = sHdr[1].IndexOf("FILETIME",StringComparison.OrdinalIgnoreCase);
                        if (ix != -1)
                        {
                            string sOAT = sHdr[1].Substring(0, ix);
                            sOAT = sOAT.Replace("(UTC)", "-0000");
                            _x_OriginalArrivaTime = DateTime.Parse(sOAT);
                        }
                        break;

                    default:
                        _listUnsupported.Add(sHdr[0], sHdr[1]);
                        break;
                }
            }

        }

        /// <summary>
        /// Combine the value in diff line
        /// </summary>
        /// <param name="ListLine"></param>
        /// <param name="i"></param>
        /// <param name="sFullValue"></param>
        private void GetFullValue(List<string> ListLine,ref int i,ref string sFullValue)
        {
            if (i + 1 <= ListLine.Count &&
                ListLine[i + 1] != string.Empty &&
                char.IsWhiteSpace(ListLine[i + 1], 0))
            {
                i += 1;
                sFullValue += " " + ListLine[i].Trim();
                GetFullValue(ListLine, ref i, ref sFullValue);
            }
        }

        /// <summary>
        /// Provide Entry Content
        /// </summary>
        /// <param name="ze"></param>
        /// <returns></returns>
        private List<string> Input2String(ZipEntry ze)
        {
            List<string> result = new List<string>();
            try
            {
                using (var s = ze.OpenReader())
                {
                    var sr = new StreamReader(s);
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        result.Add(line);
                        line = sr.ReadLine();
                    }
                    
                }
                //using (var ms = new MemoryStream())
                //{
                //    int n;
                //    var buffer = new byte[1024];
                //    while ((n = s.Read(buffer, 0, buffer.Length)) > 0)
                //        ms.Write(buffer, 0, n);
                //    ms.Seek(0, SeekOrigin.Begin);

                //    var sr = new StreamReader(ms);
                //    result = sr.ReadToEnd();

                //    sr.Close();
                //    sr.Dispose();
                //}
            }
            catch (Exception ex)
            { throw ex; }

            return result;
        }

    }
}
