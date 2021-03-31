using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

/// <summary>
/// Copyright © 2021 DigitalYear 保留所有权利。
/// NGDataStorage的存储类
/// </summary>

namespace NGDataStorage {
    public class NGDataEditor {

        private XmlDocument LinkFile = new XmlDocument();
        private string XmlPath = "";

        /// <summary>
        /// 构造该类的方法，其XML文件必须保存在应用程序所在的目录中。
        /// </summary>
        /// <param name="XmlFileName">XML文件绝对路径</param>
        public NGDataEditor(string XmlFileName) {
            XmlPath = XmlFileName;
            try {
                LinkFile.Load(XmlFileName);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// 放入字符串方法，使用后立即生效。
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="Value">数据值</param>
        public void PutString(string NodeName, string Value) {
            XmlNode QueryNode = LinkFile.DocumentElement.SelectSingleNode("/Atlas/string[@name='" + NodeName + "']");
            QueryNode.Attributes["value"].Value = Value;
            LinkFile.Save(XmlPath);
        }

        /// <summary>
        /// 放入整形的方法，使用后立即生效。
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="Value">数据值</param>
        public void PutInt(string NodeName, int Value) {
            XmlNode QueryNode = LinkFile.DocumentElement.SelectSingleNode("/Atlas/int[@name='" + NodeName + "']");
            QueryNode.Attributes["value"].Value = Value + "";
            LinkFile.Save(XmlPath);
        }

        /// <summary>
        /// 放入布尔型的方法，使用后立即生效。
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="Value">数据值</param>
        public void PutBoolean(string NodeName, bool Value) {
            XmlNode QueryNode = LinkFile.DocumentElement.SelectSingleNode("/Atlas/boolean[@name='" + NodeName + "']");
            if (Value) {
                QueryNode.Attributes["value"].Value = "YES";
            } else {
                QueryNode.Attributes["value"].Value = "NO";
            }
            LinkFile.Save(XmlPath);
        }
    }
}
