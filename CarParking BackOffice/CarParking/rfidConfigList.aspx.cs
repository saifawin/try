using CarParkingBIL;
using CarParkingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParking
{
    public partial class rfidConfigList : Page
    {
        private int Id;
        private List<RfidConfig> rfidConfigs = null;
        private List<Search> searchs = null;
        public int IdValue
        {
            get
            {
                if (ViewState["id"] == null)
                {
                    ViewState["id"] = 0;
                }

                return (int)ViewState["id"];
            }
            set
            {
                this.Id = value;
            }
        }

        private RfidConfigBIL rfidConfigBIL = new RfidConfigBIL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            rfidConfigs = new List<RfidConfig>();
            rfidConfigs = rfidConfigBIL.getAll().ToList();
            RfidConfigGridView.RowStyle.Wrap = true;
            RfidConfigGridView.AutoGenerateColumns = false;
            RfidConfigGridView.DataSource = rfidConfigs;
            RfidConfigGridView.DataBind();
            Search search = null;
            searchs = new List<Search>();

            String boundFields = String.Empty;

            for (int i = 0; i < RfidConfigGridView.Columns.Count; i++)
            {
                DataControlField field = RfidConfigGridView.Columns[i];
                BoundField bfield = field as BoundField;

                if (bfield != null && bfield.DataField != "Id")
                {
                    search = new Search();
                    search.Code = bfield.DataField;
                    search.Name = bfield.HeaderText;
                    searchs.Add(search);
                }
            }
            DropDownListSearch.DataSource = searchs;
            DropDownListSearch.DataValueField = "Code";
            DropDownListSearch.DataTextField = "Name";
            DropDownListSearch.DataBind();
        }

        private void getGridViewIdValue(GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = RfidConfigGridView.Rows[index];
            ViewState["id"] = Convert.ToInt32(row.Cells[0].Text);
        }

        protected void RfidConfigGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                getGridViewIdValue(e);
                Response.Redirect("rfidConfigInfo.aspx?id=" + IdValue);
            }
            else if (e.CommandName == "RemoveRow")
            {
                getGridViewIdValue(e);
                bool result = rfidConfigBIL.delete(IdValue);
                Response.Redirect("RfidConfigList.aspx");
            }
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            rfidConfigs = rfidConfigBIL.getAll().ToList();
            string column = DropDownListSearch.SelectedValue;
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                RfidConfigGridView.DataSource = rfidConfigBIL.searchByCodition(column, txtSearch.Text);
            }
            else
            {
                RfidConfigGridView.DataSource = rfidConfigs;
            }
            RfidConfigGridView.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("rfidConfigInfo.aspx");
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RfidConfigGridView.PageIndex = e.NewPageIndex;
            bindData();
        }

        protected void RfidConfigGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.Cells[3].Controls[0];
                if (lb != null)
                {
                    lb.Attributes.Add("onclick", "javascript:return confirm('ยืนยันการลบข้อมูล')");
                }
            }
        }
    }
}