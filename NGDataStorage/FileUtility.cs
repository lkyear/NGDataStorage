using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Copyright © 2021 DigitalYear 保留所有权利。
/// NGDataStorage的文件操作类
/// </summary>

namespace NGDataStorage {
    public class FileUtility {

        /// <summary>
        /// 写入到文件
        /// </summary>
        /// <param name="FilePath">文件绝对路径</param>
        /// <param name="FileContent">文件内容</param>
        public static void WriteToFile(string FilePath, string FileContent) {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath))) {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            }
            using (Stream outStream = new FileStream(FilePath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(outStream, Encoding.Default)) {
                sw.Write(FileContent);
            }
        }

        /// <summary>
        /// 从文件读取
        /// </summary>
        /// <param name="FilePath">文件绝对路径</param>
        /// <returns>文件内容</returns>
        public static string ReadFromFile(string FilePath) {
            string fileContent = "";

            if (!File.Exists(FilePath)) {
                return "";
            }

            using (Stream intStream = new FileStream(FilePath, FileMode.Open))
            using (StreamReader reader = new StreamReader(intStream, Encoding.Default)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    fileContent += (line + Environment.NewLine);
                }
            }

            return fileContent;
        }

    }
}
