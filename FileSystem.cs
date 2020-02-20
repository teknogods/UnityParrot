using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace UnityParrot
{
    public class FileSystem
    {
        private string m_basePath = "UnityParrot";

        public static FileSystem Configuration = new FileSystem("UnityParrot\\Configuration");

        public Func<string, string> Format = null;

        public FileSystem() { }

        public FileSystem(string basePath)
        {
            m_basePath = basePath;
            Directory.CreateDirectory(m_basePath);
        }

        public static class Formats
        {
            public static string TimePrefix(string data)
            {
                var now = DateTime.Now;
                var time = $"{now.Day}/{now.Month}/{now.Year} {now.Hour}:{now.Minute}:{now.Second}";
                return $"{time} >> {data}";
            }
        }


        public T LoadJson<T>(string fileName)
        {
            return JsonUtility.FromJson<T>(File.ReadAllText($"{m_basePath}\\{fileName}"));
            //return JsonConvert.DeserializeObject<T>(File.ReadAllText($"{m_basePath}\\{fileName}"));
        }

        public T TryLoadJson<T>(string fileName) 
        {
            if (!FileExists(fileName))
            {
                return default(T);
            }

            return LoadJson<T>(fileName);
        }

        public void SaveJson<T>(string fileName, T data)
        {
            File.WriteAllText($"{m_basePath}\\{fileName}", JsonUtility.ToJson(data, true));
            //File.WriteAllText($"{m_basePath}\\{fileName}", JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public string LoadText(string fileName)
        {
            return File.ReadAllText($"{m_basePath}\\{fileName}");
        }

        public string[] LoadLines(string fileName)
        {
            return File.ReadAllLines($"{m_basePath}\\{fileName}");
        }

        public void SaveText(string fileName, string data, bool append = false)
        {
            string dataCopy = data;

            if (Format != null)
            {
                dataCopy = Format(data);
            }

            string path = $"{m_basePath}\\{fileName}";

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            if (append)
            {
                File.AppendAllText(path, dataCopy);
                return;
            }

            File.WriteAllText(path, dataCopy);
        }

        public void SaveText(string fileName, string[] data, bool append = false)
        {
            string[] dataCopy = data;

            if (Format != null)
            {
                for (int i = 0; i < dataCopy.Length; i++)
                {
                    dataCopy[i] = Format(data[i]);
                }
            }

            string path = $"{m_basePath}\\{fileName}";

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            if (append)
            {
                File.AppendAllText(path, string.Join("\n", dataCopy));
                return;
            }

            File.WriteAllLines(path, dataCopy);
        }

        public void SaveText(string fileName, IEnumerable<string> data, bool append = false)
        {
            SaveText($"{m_basePath}\\{fileName}", data.ToArray(), append);
        }

        public bool FileExists(string fileName)
        {
            return File.Exists($"{m_basePath}\\{fileName}");
        }

        public string GetFilePath(string fileName)
        {
            return $"{m_basePath}\\{fileName}";
        }
    }
}