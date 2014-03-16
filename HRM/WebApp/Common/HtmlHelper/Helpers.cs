using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace Hrm.WebApp.Common.HtmlHelper
{
    public static class Helpers
    {
        /// <summary>
        /// 获取枚举的描述文本
        /// </summary>
        /// <param name="e">枚举成员</param>
        /// <returns></returns>
        public static string GetEnumDescription(object e)
        {
            //获取字段信息
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();

            Type t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {
                //判断名称是否相等
                if (f.Name != e.ToString()) continue;

                //反射出自定义属性
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }

            }
            //如果没有检测到合适的注释，则用默认名称
            return e.ToString();
        }

        ///// <summary>
        /////  把枚举的描述和值绑定到DropDownList
        ///// </summary>
        ///// <param name="enumType"></param>
        ///// <returns></returns>
        //public static List<SelectListItem> GetCategorySelectList(Type enumType, bool hasAcquiesce)
        //{
        //    List<SelectListItem> selectList = new List<SelectListItem>();
        //    if (hasAcquiesce)
        //    {
        //        selectList.Add(new SelectListItem { Text = "--请选择类型--", Value = "", Selected = true });
        //    }
        //    foreach (object e in Enum.GetValues(enumType))
        //    {
        //        selectList.Add(new SelectListItem { Text = GetEnumDescription(e), Value = ((int)e).ToString() });
        //    }

        //    return selectList;
        //}



        public static SelectList ToSelectListBy<T>(this IEnumerable<T> dataList, string valueName, string textName)
        {
            if (dataList == null || dataList.Count() <= 0)
            {
                return null;
            }
            SelectList list = new SelectList(dataList);
            SelectList rtnList = new SelectList(dataList.AsEnumerable(), valueName, textName);
            return rtnList;
        }
        public static IEnumerable<SelectListItem> ToSelectListBy<T>(this IEnumerable<T> dataList, string valueName, Func<T, string> textFunc)
        {
            if (dataList == null || dataList.Count() <= 0)
            {
                return null;
            }
            ICollection<SelectListItem> rtnCollection = new List<SelectListItem>();
            foreach (var data in dataList)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = data.GetType().GetProperty(valueName).GetValue(data,null).ToString();
                selectListItem.Text = textFunc(data);
                rtnCollection.Add(selectListItem);
            }
            return rtnCollection;
        }
    }
}