using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace RealWorldStocks.Core.Http
{
    public abstract class HttpContent
    {
        public abstract void WriteToStream(Stream stream);
        public abstract string ContentType { get; set;  }
    }

    public class FormUrlEncodedContent : HttpContent
    {
        protected internal Collection<KeyValuePair<string, string>> NameValueCollection;

        public FormUrlEncodedContent() 
        {
            NameValueCollection = new Collection<KeyValuePair<string, string>>();
        }

        public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
            : this()
        {
            foreach (var kvp in nameValueCollection)
                NameValueCollection.Add(new KeyValuePair<string, string>(kvp.Key, kvp.Value));
        }

        public override string ContentType
        {
            get { return "application/x-www-form-urlencoded"; }
            set { }
        }

        public override void WriteToStream(Stream stream)
        {
            stream.WriteString(NameValueCollection.ToDataString());
        }

        public override string ToString()
        {
            return NameValueCollection.ToDataString();
        }
    }

    public class MultipartFormDataContent : HttpContent
    {
        private const string BoundaryBookend = "--";
        private const string NewLine = "\r\n";
        private static readonly string Boundary = Guid.NewGuid().ToString("N");
        private const string ContentDispositionFormat = "Content-Disposition: form-data; name=\"{0}\"";
        private const string FileContentDispositionFormat = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"";
        private const string ContentTypeFormat = "Content-Type: {0}";

        private List<HttpContent> _contentList;

        public MultipartFormDataContent()
        {
            _contentList = new List<HttpContent>();
        }

        public void Add(HttpContent content)
        {
            _contentList.Add(content);
        }

        public override void WriteToStream(Stream stream)
        {
            foreach (var content in _contentList)
            {
                if (content is FormUrlEncodedContent)
                {
                    var sb = new StringBuilder();
                    var formContent = content as FormUrlEncodedContent;
                    foreach (var item in formContent.NameValueCollection)
                    {
                        sb.Append(BoundaryBookend).AppendLine(Boundary);
                        sb.AppendLine(String.Format(ContentDispositionFormat, item.Key));
                        sb.AppendLine();
                        sb.AppendLine(item.Value);
                    }
                    stream.WriteString(sb.ToString());
                }
                else if (content is FileContent)
                {
                    var fileContent = content as FileContent;
                    var sb = new StringBuilder();
                    sb.Append(BoundaryBookend).AppendLine(Boundary);
                    sb.AppendLine(String.Format(FileContentDispositionFormat, fileContent.Name, fileContent.FileName));
                    sb.AppendLine(String.Format(ContentTypeFormat, content.ContentType));
                    sb.AppendLine();
                    stream.WriteString(sb.ToString());

                    fileContent.WriteToStream(stream);
                    stream.WriteString(NewLine);
                }
            }

            stream.WriteString(String.Format("{0}{1}{2}{3}", BoundaryBookend, Boundary, BoundaryBookend, NewLine));
        }


        public override string ContentType
        {
            get { return String.Format("multipart/form-data; boundary={0}", Boundary); }
            set { }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var content in _contentList)
                sb.AppendLine(content.ToString());

            return sb.ToString();
        }
    }

    public class FileContent : HttpContent
    {
        private string _contentType = "application/octet-stream";

        public byte[] Content { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        public FileContent()
        {
            FileName = "image";
        }

        public override string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        public override void WriteToStream(Stream stream)
        {
            stream.Write(Content, 0, Content.Length);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, FileName: {1}, ContentType: {2}", Name, FileName, ContentType);
        }
    }
}
