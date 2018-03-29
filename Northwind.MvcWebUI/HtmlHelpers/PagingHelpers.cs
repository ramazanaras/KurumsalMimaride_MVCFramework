using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.HtmlHelpers
{
    //Extension metod
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo)  //@Html.Pager  olarak kullanabilmek için
        {

            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {


                var tagBuilder = new TagBuilder("a");//a tagini oluştur
                //a etiketine href ekleme yapıyoruz
                tagBuilder.MergeAttribute("href", String.Format("/Product/Index?page={0}&category={1}", i,pagingInfo.CurrentCategory));
                tagBuilder.InnerHtml = i.ToString(); //<a href="/Product/Index?page=3">i<a/>  değeri verdik
                //if (pagingInfo.CurrentPage==i)
                //{
                //    tagBuilder.AddCssClass("selected"); //css ekle
                //}
                stringBuilder.Append(tagBuilder);
            }



            return MvcHtmlString.Create(stringBuilder.ToString());//sayfalama htmli oluşturmuş olduk //yanyana a tagları oluşturmuş olduk

        }





    }
}