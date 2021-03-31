using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

/// <summary>
/// Copyright © 2021 DigitalYear 保留所有权利。
/// NGDataStorage的读取类
/// </summary>

namespace NGDataStorage {
    public class NGData {

        private XmlDocument LinkFile = new XmlDocument();
        
        /// <summary>
        /// 构造该类的方法，其XML文件必须保存在应用程序所在的目录中。
        /// </summary>
        /// <param name="XmlFileName">XML文件绝对路径</param>
        public NGData(string XmlFileName) {
            try {
                LinkFile.Load(XmlFileName);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// 获取一个字符串的方法
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <returns>数据值</returns>
        public string GetString(string NodeName) {
            XmlNode QueryNode = LinkFile.DocumentElement.SelectSingleNode("/Atlas/string[@name='" + NodeName + "']");
            XmlElement ElementName = (XmlElement)QueryNode;
            return ElementName.GetAttribute("value").ToString();
        }

        /// <summary>
        /// 获取一个整形的方法
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <returns>数据值</returns>
        public int GetInt(string NodeName) {
            XmlNode QueryNode = LinkFile.DocumentElement.SelectSingleNode("/Atlas/int[@name='" + NodeName + "']");
            XmlElement ElementName = (XmlElement)QueryNode;
            return int.Parse(ElementName.GetAttribute("value").ToString());
        }

        /// <summary>
        /// 获取一个布尔型的方法
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <returns>数据值</returns>
        public bool GetBoolean(string NodeName) {
            XmlNode QueryNode = LinkFile.DocumentElement.SelectSingleNode("/Atlas/boolean[@name='" + NodeName + "']");
            XmlElement ElementName = (XmlElement)QueryNode;
            if (ElementName.GetAttribute("value").ToString().Equals("YES")) {
                return true;
            } else {
                return false;
            }
        }
    }
}
