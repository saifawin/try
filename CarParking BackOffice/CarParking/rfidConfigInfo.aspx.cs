using CarParkingBIL;
using CarParkingData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParking
{
    public partial class rfidConfigInfo : System.Web.UI.Page
    {
        private RfidConfigBIL rfidConfigBIL = new RfidConfigBIL();
        private RfidConfig rfidConfig = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AlertMsg.Visible = false;
                var id = Request["id"];
                rfidConfig = rfidConfigBIL.getById(Convert.ToInt32(id));

                if (rfidConfig != null)
                {
                    txtRfidUid.Text = rfidConfig.RfidUid;
                    txtCarNo.Text = rfidConfig.CarNo;
                }
            }
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            long result = 0;

            var id = Convert.ToInt32(Request["id"]);
            rfidConfig = rfidConfigBIL.getById(Convert.ToInt32(id));
            if (rfidConfig == null)
                rfidConfig = new RfidConfig();

            rfidConfig.RfidUid = txtRfidUid.Text;
            rfidConfig.CarNo= txtCarNo.Text;

            if (id > 0)
            {
                rfidConfigBIL.update(rfidConfig);
                result = 1;
            }
            else
            {
                result = rfidConfigBIL.insert(rfidConfig);
            }

            if (result > 0)
            {
                AlertMsg.Visible = true;
                Response.Redirect("rfidConfigInfo.aspx?id="+ rfidConfig.Id);
            }
        }
        protected void SaveBackClick(object sender, EventArgs e)
        {
            Response.Redirect("rfidConfigList.aspx");
        }
        protected void CloseBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("rfidConfigList.aspx");
        }
    }
}