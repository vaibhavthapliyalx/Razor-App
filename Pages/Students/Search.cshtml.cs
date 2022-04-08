using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesAssignment1.Pages.Students
{
    public class SearchModel : PageModel
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxSearch.Focus();
            string selectCommand = "SELECT Details.Title AS Title, Details.LastName AS Surname, Details.FirstName  AS Name, Details.Email, Details.Phone " +
                                    "FROM Details " +
                                    "ORDER BY Details.LastName";

            AccessDataSourceDetails.SelectCommand = selectCommand;

            GridViewDetails.DataSource = AccessDataSourceDetails;
            GridViewDetails.DataBind();
        }

        /// <summary>
        /// Search the text in the TextBoxSearch into the database fields and update the GridView contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text != "")
            {
                string search = TextBoxSearch.Text;
                string selectCommand = "SELECT Details.Title AS Title, Details.LastName AS Surname, Details.FirstName  AS Name, Details.Email, Details.Phone " +
                                       "FROM Details " +
                                        "WHERE Details.LastName LIKE'%" + search + "%' OR " +
                                        "Details.FirstName LIKE'%" + search + "%' OR " +
                                        "Details.City LIKE'%" + search + "%' " +
                                        "ORDER BY Details.LastName";

                AccessDataSourceDetails.SelectCommand = selectCommand;

                GridViewEDetails.DataSource = AccessDataSourceDetails;
                GridViewDetails.DataBind();
                TextBoxSearch.Focus();
            }
        }
    }
}
}
