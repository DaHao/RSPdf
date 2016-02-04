using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

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
        public List<string> _ArrTo  { get; set; }
        public string _CC  { get; set; }
        public List<string> _ArrCC  { get; set; }
        public string _Date  { get; set; }
        public string _Subject  { get; set; }
        public string _ContentType  { get; set; }
        public string _Content_Transfer_Encoding  { get; set; }
        public string _Return_Path  { get; set; }
        public string _Message_ID  { get; set; }
        public string _x_OriginalArrivaTime  { get; set; }
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
                Input2String(ze);
            }
            catch (Exception ex)
            { throw ex; }
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
                    while (!string.IsNullOrEmpty(line))
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
