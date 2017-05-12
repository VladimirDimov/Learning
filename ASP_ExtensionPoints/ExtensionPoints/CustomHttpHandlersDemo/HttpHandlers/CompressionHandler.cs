namespace CustomHttpHandlersDemo.HttpHandlers
{
    using System.IO;
    using System.Web;
    using Ionic.Zip;

    public class CompressionHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var compressionFormat = context.Request.Headers["Accept"];

            switch (compressionFormat)
            {
                case "application/zip":
                    this.AddZip(context);
                    return;

                default:
                    this.AddOriginalFile(context);
                    return;
            }
        }

        private void AddOriginalFile(HttpContext context)
        {
            var filePath = context.Request.PhysicalPath;

            context.Response.WriteFile(filePath, true);

            context.Response.AppendHeader("Content-Type", "image/jpg");
        }

        private void AddZip(HttpContext context)
        {
            var filePath = context.Request.PhysicalPath;
            var fileBytes = File.ReadAllBytes(filePath);
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var zip = new ZipFile();
                zip.AddFile(filePath, "/");
                zip.Save(context.Response.OutputStream);
            }

            context.Response.AppendHeader("Content-Type", "application/zip");
        }
    }
}