using System;
using System.Web;
using System.Drawing;

public class Program
{
	public static void Main()
	{
        FirstLoading();
    }
    enum DropDownListColors {Yellow=1, Black, Gray};

    public static void FirstLoading() {
        if (HttpContext.Current.Request.Cookies["firstLoading"].ToString() == null) {
	    	HttpContext.Current.Response.Cookies["firstLoading"].Value = "is not first anymore";
                if(HttpContext.Current.Request.Cookies["zapamti"] != null) {
                    Label1.BackColor  = Color.FromName(HttpContext.Current.Request.Cookies["boja"].ToString());
                }
        }
    }

    //sender and e are default arguments
    public void DropDownList1_SelectedIndexChanged(Object sender, EventArgs e) {
        if(HttpContext.Current.Request.Cookies["boja"] == null) {
            System.Drawing.Color selectedColor = Enum.GetName(typeof(DropDownListColors), DropDownList1.SelectedItem.Value));
			HttpCookie colorCookie = new HttpCookie("boja");
			colorCookie.Value = selectedColor.ToString();
            HttpContext.Current.Response.Cookies.Add(colorCookie);
        } else 
            HttpContext.Current.Response.Cookies["boja"].Value= DropDownList1.SelectedItem.Value;
    }
}