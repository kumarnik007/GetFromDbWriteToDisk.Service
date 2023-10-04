using SautinSoft;

namespace Service.Utils
{
    public class DiskWriter
    {
        public static void WriteTextFile(byte[] inBytes, string outFilePath)
        {
            try
            {
                CreateDirectoryIfNotExists(outFilePath);
                File.WriteAllBytes(outFilePath, inBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message} occured while file write.");
                throw;
            }
        }

        public static void WriteHtmlFile(byte[] inBytes, string outFilePath)
        {
            try
            {
                CreateDirectoryIfNotExists(outFilePath);

                byte[] htmlBytes = [];
                RtfToHtml r = new();

                using (MemoryStream inpMS = new(inBytes))
                {
                    using MemoryStream outMS = new();
                    r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions());
                    htmlBytes = outMS.ToArray();
                }

                File.WriteAllBytes(outFilePath, htmlBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message} occured while file write.");
                throw;
            }
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            try
            {
                FileInfo fileInfo = new(path);

                if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
