using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using HtmlConverter.Exceptions;

namespace HtmlConverter.Core
{
    public abstract class CoreDriver
    {
        /// <summary>
        /// Convert Giver string Html to Pdf/Image
        /// </summary>
        /// <param name="wkhtmlPath"></param>
        /// <param name="switches"></param>
        /// <param name="html"></param>
        /// <param name="wkhtmlExe"></param>
        /// <returns></returns>
        protected static byte[] ConvertByHtml(string wkhtmlPath, string switches, string html, string wkhtmlExe)
        {
            // switches:
            //     "-q"  - silent output, only errors - no progress messages
            //     " -"  - switch output to stdout
            //     "- -" - switch input to stdin and output to stdout
            switches = "-q " + switches + " -";

            // generate PDF from given HTML string, not from URL
            if (!string.IsNullOrEmpty(html))
            {
                switches += " -";
                html = SpecialCharsEncode(html);
            }

            var proc = Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(wkhtmlPath, wkhtmlExe),
                Arguments = switches,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                WorkingDirectory = wkhtmlPath,
                CreateNoWindow = true
            });

            if (proc == null)
            {
                throw new NotGeneratedException("Conversion operation terminated anomaly");
            }

            // generate PDF/Image from given HTML string, not from URL
            if (!string.IsNullOrEmpty(html))
            {
                using (var sIn = proc.StandardInput)
                {
                    sIn.WriteLine(html);
                }
            }
            using (var ms = new MemoryStream())
            {
                using (var sOut = proc.StandardOutput.BaseStream)
                {
                    var buffer = new byte[4096];
                    int read;

                    while ((read = sOut.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                var error = proc.StandardError.ReadToEnd();

                if (ms.Length == 0)
                {
                    throw new NotGeneratedException(error);
                }

                proc.WaitForExit();

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Convert Page website to Pdf/Image
        /// </summary>
        /// <param name="wkhtmlPath"></param>
        /// <param name="switches"></param>
        /// <param name="url"></param>
        /// <param name="wkhtmlExe"></param>
        /// <returns></returns>
        protected static byte[] ConvertByUrl(string wkhtmlPath, string switches, string url, string wkhtmlExe)
        {
            if(!IsWkhtmlExist(wkhtmlPath, wkhtmlExe))
                throw new NotInstalledException($"{wkhtmlExe} does not appear to be installed on this linux system according to which command; go to https://wkhtmltopdf.org/downloads.html");

            // switches:
            //     "-q"  - silent output, only errors - no progress messages
            //     " -"  - switch output to stdout
            //     "- -" - switch input to stdin and output to stdout
            switches = "-q " + switches + $" {url}" + " -";

            var proc = Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(wkhtmlPath, wkhtmlExe),
                Arguments = switches,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                WorkingDirectory = wkhtmlPath,
                CreateNoWindow = true
            });

            if (proc == null)
            {
                throw new NotGeneratedException("Conversion operation terminated anomaly");
            }

            using (var ms = new MemoryStream())
            {
                using (var sOut = proc.StandardOutput.BaseStream)
                {
                    var buffer = new byte[4096];
                    int read;

                    while ((read = sOut.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                var error = proc.StandardError.ReadToEnd();

                if (ms.Length == 0)
                {
                    throw new NotGeneratedException(error);
                }

                proc.WaitForExit();

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Encode all special chars
        /// </summary>
        /// <param name="text">Html text</param>
        /// <returns>Html with special chars encoded</returns>
        private static string SpecialCharsEncode(string text)
        {
            var chars = text.ToCharArray();
            var result = new StringBuilder(text.Length + (int)(text.Length * 0.1));

            foreach (var c in chars)
            {
                var value = Convert.ToInt32(c);
                if (value > 127)
                    result.AppendFormat("&#{0};", value);
                else
                    result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// Verify that wkhtmltopdf/wkhtmltoimage is installed on computer user
        /// </summary>
        /// <param name="wkhtmlpath"> Path of folder containing wkhtmltopdf/wkhtmltoimage</param>
        /// <param name="wkhtmlExe"></param>
        /// <returns></returns>
        private static bool IsWkhtmlExist(string wkhtmlpath, string wkhtmlExe)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return File.Exists(Path.Combine(wkhtmlpath, wkhtmlExe));
            }

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return false;
            var process = Process.Start(new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "/bin/",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                FileName = "/bin/bash",
                Arguments = $"which {wkhtmlExe}"
            });

            if (process == null) return false;

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return !string.IsNullOrEmpty(output) && output.Contains(wkhtmlExe);

        }
    }

}