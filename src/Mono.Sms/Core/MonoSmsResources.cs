using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace Mono.Sms.Core
{
    public static class MonoSmsResources
    {
        //fields
        private static Assembly ourAssembly;
        private const string ourNamespace = "Mono.Sms.Resources";
        private static string[] localeDirs;

        static MonoSmsResources()
        {
            Inicialize();
        }

        private static void Inicialize()
        {
            ourAssembly = Assembly.GetExecutingAssembly();
            localeDirs = GetLocaleDirs();
        }


        public static Image GetImage(string fileName)
        {
            Stream stream = GetResourceStream(fileName);

            if (stream != null)
            {
                return LoadImage(stream);
            }

            return null;
        }

        /// <summary>
        /// Get a resource from resources directories or from a assembly.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Stream GetResourceStream(string fileName)
        {
            Stream stream = null;

            for (int i = 0; i < localeDirs.Length; ++i)
            {
                string filePath = Path.Combine(localeDirs[i], fileName);

                if (File.Exists(filePath))
                {
                    stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    break;
                }
            }

            if (stream == null)
            {
                string fullName = string.Concat(ourNamespace, ".", fileName);
                stream = ourAssembly.GetManifestResourceStream(fullName);
                
                if(stream == null)
                {
                	 stream = ourAssembly.GetManifestResourceStream(fileName);                
                }
                

            }

            return stream;
        }

        public static string[] GetLocaleDirs()
        {
            //Debería devolver los directorios de los recursos de las diferentes culturas.
            //Por ahora devuelve el path para el directorio 'Resources/'
            //Ver buena implementación en Paint.Net

            List<string> dirs = new List<string>();
            string resourcesPath = Path.Combine(typeof (MonoSmsResources).Assembly.Location, "Resources");

            dirs.Add(resourcesPath);

            return dirs.ToArray();
        }

        public static Image LoadImage(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return LoadImage(stream);
            }
        }

        /// <summary>
        /// Loads an image from the given stream. The stream must be seekable.
        /// </summary>
        /// <param name="input">The Stream to load the image from.</param>
        public static Image LoadImage(Stream input)
        {
            /*
            if (!IsGdiPlusImageAllowed(input))
            {
                throw new IOException("File format is not supported");
            }
            */

            Image image = Image.FromStream(input);

            if (image.RawFormat == ImageFormat.Wmf || image.RawFormat == ImageFormat.Emf)
            {
                image.Dispose();
                throw new IOException("File format isn't supported");
            }

            return image;
        }

        public static Icon GetIconFromImage(string fileName)
        {
            Stream stream = GetResourceStream(fileName);

            Icon icon = null;

            if (stream != null)
            {
                Image image = LoadImage(stream);
                icon = Icon.FromHandle(((Bitmap)image).GetHicon());
                image.Dispose();
                stream.Close();
            }

            return icon;
        }
    }
}