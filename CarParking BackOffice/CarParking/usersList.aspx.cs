using CarParkingBIL;
using CarParkingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParking
{
    public partial class UsersList : Page
    {
        private int Id;
        private List<Users> Userss = null;
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

        private UsersBIL UsersBIL = new UsersBIL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            Userss = new List<Users>();
            Userss = UsersBIL.getAll().ToList();
            UsersGridView.RowStyle.Wrap = true;
            UsersGridView.AutoGenerateColumns = false;
            UsersGridView.DataSource = Userss;
            UsersGridView.DataBind();
            Search search = null;
            searchs = new List<Search>();

            String boundFields = String.Empty;

            for (int i = 0; i < UsersGridView.Columns.Count; i++)
            {
                DataControlField field = UsersGridView.Columns[i];
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
            GridViewRow row = UsersGridView.Rows[index];
            ViewState["id"] = Convert.ToInt32(row.Cells[0].Text);
        }

        protected void UsersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                getGridViewIdValue(e);
                Response.Redirect("UsersInfo.aspx?id=" + IdValue);
            }
            else if (e.CommandName == "RemoveRow")
            {
                getGridViewIdValue(e);
                bool result = UsersBIL.delete(IdValue);
                Response.Redirect("UsersList.aspx");
            }
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Userss = UsersBIL.getAll().ToList();
            string column = DropDownListSearch.SelectedValue;
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                UsersGridView.DataSource = UsersBIL.searchByCodition(column, txtSearch.Text);
            }
            else
            {
                UsersGridView.DataSource = Userss;
            }
            UsersGridView.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersInfo.aspx");
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersGridView.PageIndex = e.NewPageIndex;
            bindData();
        }
    }
}