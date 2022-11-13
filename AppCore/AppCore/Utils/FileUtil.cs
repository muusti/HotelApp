using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;

namespace AppCore.Utils
{
    public static class FileUtil
    {
        private static Dictionary<string, string> _mimeTypes;

        static FileUtil()
        {
            _mimeTypes = new Dictionary<string, string>()
            {
                {".jpg", "image/jpeg" },
                {".jpeg", "image/jpeg" },
                {".png", "image/png" }
            };
        }

        public static string GetContentType(string fileNameOrExtension, bool includeData = false, bool includeBase64 = false)
        {
            string contentType;
            string fileExtension = Path.GetExtension(fileNameOrExtension);
            contentType = _mimeTypes[fileExtension];
            if (includeData)
                contentType = "data:" + contentType;
            if (includeBase64)
                contentType = contentType + ";base64,";
            return contentType;

        }

        public static Result CheckFileExtension(string fileName, string acceptedFileExtensions, char seperator = ',')
        {
            Result result = new ErrorResult("Invalid file extension");

            string fileExtension = Path.GetExtension(fileName);
            string[] acceptedExtension = acceptedFileExtensions.Split(seperator);

            if (acceptedExtension.Any(ae => ae.Trim().ToLower() == fileExtension.ToLower()))
                result = new SuccessResult("Valid file extension");
            return result;
        }

        public static Result CheckFileLength(double fileLengthBytes, double acceptedLengthInMegaBytes)
        {
            if (fileLengthBytes > acceptedLengthInMegaBytes * Math.Pow(1024, 2))
                return new ErrorResult("Invalid file length");

            return new SuccessResult("Valid file length");
        }
    }
}
