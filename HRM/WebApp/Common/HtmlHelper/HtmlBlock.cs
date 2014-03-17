using System.Web.Mvc;
using System;

namespace Hrm.WebApp.Common.HtmlHelper
{
    public static class HtmlBlock
    {

        //#region 员工
        //public static MvcHtmlString Employee(int? employeeID)
        //{
        //    MvcHtmlString rtnValue;
        //    if (!employeeID.HasValue)
        //        rtnValue = new MvcHtmlString(null);
        //    else
        //    {
        //        var employee = Cache.EmployeeCache.GetEmployeeName(employeeID.Value);
        //        if (employee != null)
        //        {
        //            string strHtml = string.Format("<span title='{1}'>{0}</span>", employee.EmpName, employee.JobNumber);
        //            rtnValue = new MvcHtmlString(strHtml);
        //        }
        //        else
        //        {
        //            rtnValue = new MvcHtmlString(null);
        //        }
        //    }
        //    return rtnValue;
        //}
        //#endregion

        #region 日期
        public static MvcHtmlString DateTime(System.DateTime? time,string format=null)
        {
            MvcHtmlString rtnValue;
            if (!time.HasValue)
                rtnValue = new MvcHtmlString(null);
            else
            {
                if(string.IsNullOrWhiteSpace(format))
                    format="yyyy-MM-dd";
                string strHtml = time.Value.ToString(format);
                rtnValue = new MvcHtmlString(strHtml);
            }
            return rtnValue;
        }
        #endregion

        //#region 分支机构
        //public static MvcHtmlString Branch(int? branchID)
        //{
        //    MvcHtmlString rtnValue;
        //    if (!branchID.HasValue)
        //        rtnValue = new MvcHtmlString(null);
        //    else
        //    {
        //        var branch = Cache.BranchCache.GetBranchName(branchID.Value);
        //        if (branch != null)
        //        {
        //            string strHtml = string.Format("<span>{0}</span>", branch.BranchName);
        //            rtnValue = new MvcHtmlString(strHtml);
        //        }
        //        else
        //        {
        //            rtnValue = new MvcHtmlString(null);
        //        }
        //    }
        //    return rtnValue;
        //}
        //#endregion

        //#region 银行
        //public static MvcHtmlString Bank(int? bankID)
        //{
        //    MvcHtmlString rtnValue;
        //    if (!bankID.HasValue)
        //        rtnValue = new MvcHtmlString(null);
        //    else
        //    {
        //        var bank = Cache.BankCache.GetBankData(bankID.Value);
        //        if (bank != null)
        //        {
        //            string strHtml = string.Format("<span>{0}</span>", bank.BankName);
        //            rtnValue = new MvcHtmlString(strHtml);
        //        }
        //        else
        //        {
        //            rtnValue = new MvcHtmlString(null);
        //        }
        //    }
        //    return rtnValue;
        //}
        //#endregion

        //#region 部门
        //public static MvcHtmlString Depart(int? DepartID)
        //{
        //    MvcHtmlString rtnValue;
        //    if (!DepartID.HasValue)
        //        rtnValue = new MvcHtmlString(null);
        //    else
        //    {
        //        var depart = Cache.DepartCache.GetDepartName(DepartID.Value);
        //        if (depart != null)
        //        {
        //            string strHtml = string.Format("<span>{0}</span>", depart.DeptName);
        //            rtnValue = new MvcHtmlString(strHtml);
        //        }
        //        else
        //        {
        //            rtnValue = new MvcHtmlString(null);
        //        }
        //    }
        //    return rtnValue;
        //}
        //#endregion

        //#region 会员添加查看链接
        //public static MvcHtmlString PersonClientLink(string clientName, string phoneNumber, string idCard, string addLinkText=null, string viewLinkText=null)
        //{
        //    MvcHtmlString rtnValue;
        //    if (string.IsNullOrWhiteSpace(clientName) || string.IsNullOrWhiteSpace(phoneNumber))
        //        rtnValue = new MvcHtmlString(null);
        //    else
        //    {
        //        if (string.IsNullOrWhiteSpace(addLinkText))
        //            addLinkText = "添加会员";
        //        if (string.IsNullOrWhiteSpace(viewLinkText))
        //            viewLinkText = "查看会员";
        //        var tmp = "<span class='PersonClientLink' phoneNumber='{1}'><img class='Loading' src='/Images/loading02.gif' /><a class='Add' style='display:none' href='/Client/AddPersonClient?clientInfo={0},{1},{2}' target='_blank'>{3}</a><a class='View' style='display:none' href='/Multimedia/incomingcall?id={1}' target='_blank'>{4}</a><span>";
        //        var strHtml = string.Format(tmp,clientName,phoneNumber,idCard,addLinkText,viewLinkText);
        //        rtnValue = new MvcHtmlString(strHtml);
        //    }
        //    return rtnValue;
        //}
        //#endregion
    }
}